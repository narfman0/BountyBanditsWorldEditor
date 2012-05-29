using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using BountyBanditsWorldEditor.Map;

namespace BountyBanditsWorldEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        #region World editor stuff
        const string MAP_PATH = @"Content\Map\map.xml";
        const int DISTANCE_FOR_SELECTION = 20;
        public List<Level> levels;
        public int selectedLevelIndex;
        Control control;
        SpriteFont font;
        Enums.State currentState; private int timeSinceLastStateChange = 0;
        public string mapBackgroundPath;
        #endregion
        private MouseState previousMouseState = Mouse.GetState();
        public Vector2 currentLocation, offset;
        public TextureManager textureManager;
        private PrimitiveLine brush;
        private Resolution resolution;
        private Options options;
        public Guid guid = Guid.Empty;
        #region Moving items
        private GameItem movingItem;
        private SpawnPoint movingSpawn;
        private BackgroundItemStruct movingBackgroundItem;
        #endregion

        public Level CurrentLevel { get { return levels[selectedLevelIndex]; } }

        public Game1()
        {
            this.IsMouseVisible = true;
            control = new Control(this);
            control.Visible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            brush = new PrimitiveLine(GraphicsDevice);
            options = new Options(this);
            textureManager = new TextureManager(this, Content);
            resolution = new Resolution(graphics, ScreenMode.tv720p);
            newMap();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Arial");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (currentState)
            {
                #region Leveleditor
                case Enums.State.Leveleditor:
                    Vector2 currentLocation = new Vector2(Mouse.GetState().X + offset.X, resolution.ScreenHeight - (Mouse.GetState().Y + offset.Y));
                    #region Moving gameitem
                    if (ButtonState.Pressed == Mouse.GetState().LeftButton &&
                        ButtonState.Pressed != previousMouseState.LeftButton &&
                        Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        this.currentLocation = currentLocation;
                        control.updateCurrentPositionLabel();
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                            movingItem = CurrentLevel.getGameItemAtLocation(currentLocation.X, currentLocation.Y);
                        else if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt))
                            movingSpawn = CurrentLevel.getSpawnAtLocation(currentLocation.X, currentLocation.Y, this);
                        else if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                        {
                            BackgroundItemStruct? str = CurrentLevel.getBackgroundItemAtLocation(currentLocation.X, currentLocation.Y, this);
                            if(str.HasValue)
                                movingBackgroundItem = str.Value;
                        }
                    }
                    if (ButtonState.Pressed == Mouse.GetState().LeftButton && 
                        Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        if (movingItem != null)             movingItem.loc = currentLocation;
                        if (movingSpawn != null)            movingSpawn.loc = currentLocation;
                        movingBackgroundItem.location = currentLocation;
                    }
                    if (ButtonState.Pressed != Mouse.GetState().LeftButton &&
                        ButtonState.Pressed == previousMouseState.LeftButton &&
                        Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        movingItem = null;
                        movingSpawn = null;
                    }
                    #endregion
                    #region Remove level item
                    if (ButtonState.Pressed == Mouse.GetState().RightButton &&
                        ButtonState.Pressed != previousMouseState.RightButton &&
                        Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                        {
                            GameItem item = CurrentLevel.getGameItemAtLocation(currentLocation.X, currentLocation.Y);
                            if (item != null)
                            {
                                CurrentLevel.items.Remove(item);
                                control.setGuiControls(item);
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt))
                        {
                            SpawnPoint spawn = CurrentLevel.getSpawnAtLocation(currentLocation.X, currentLocation.Y, this);
                            if (spawn != null)
                            {
                                CurrentLevel.spawns.Remove(spawn);
                                control.setGuiControls(spawn);
                            }
                        }
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                        {
                            BackgroundItemStruct? str = CurrentLevel.getBackgroundItemAtLocation(currentLocation.X, currentLocation.Y, this);
                            if (str.HasValue)
                            {
                                CurrentLevel.backgroundItems.Remove(str.Value);
                                control.setGuiControls(str.Value);
                            }
                        }
                    }
                    #endregion
                    break;
                #endregion
                #region Worldeditor
                case Enums.State.Worldeditor:
                    //if clicked on a level, choose that, otherwise make a new one
                    Vector2 point = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                    int indexOfClosestLevel = -1;
                    float distance = float.MaxValue;
                    foreach (Level level in levels)
                    {
                        float newdistance = Vector2.Distance(level.loc, point);
                        if (newdistance < distance)
                        {
                            distance = newdistance;
                            indexOfClosestLevel = level.number;
                        }
                    }
                    if (ButtonState.Pressed == Mouse.GetState().LeftButton &&
                        ButtonState.Pressed != previousMouseState.LeftButton &&
                        Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        if (distance < DISTANCE_FOR_SELECTION)
                        {
                            control.setLevelInfo(levels[indexOfClosestLevel].loc.X, levels[indexOfClosestLevel].loc.Y,
                                levels[indexOfClosestLevel].adjacent, levels[indexOfClosestLevel].prereq,
                                levels[indexOfClosestLevel].name, levels[indexOfClosestLevel].number, 
                                levels[indexOfClosestLevel].autoProgress);
                            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                            {
                                levels.RemoveAt(indexOfClosestLevel);
                                foreach (Level level in levels)
                                {
                                    if (level.number >= indexOfClosestLevel)
                                        --level.number;
                                    for (int i = 0; i < level.adjacent.Count; i++)
                                        if (level.adjacent[i] == indexOfClosestLevel)
                                            level.adjacent.RemoveAt(i);
                                }
                                selectedLevelIndex = 0;
                            }
                            else if (selectedLevelIndex == indexOfClosestLevel)
                                switchState();
                            else
                                selectedLevelIndex = indexOfClosestLevel;
                        }
                        else
                            addLevel();
                    }
                    break;
                #endregion
            }
            previousMouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            switch (currentState)
            {
                #region Leveleditor
                case Enums.State.Leveleditor:
                    #region Draw background items
                    foreach (BackgroundItemStruct backgroundItem in CurrentLevel.backgroundItems)
                    {
                        Texture2D texture = textureManager.getTexture(backgroundItem.texturePath);
                        if (texture == null)
                            texture = textureManager.getTexture("backgrnditem");
                        Vector2 textureDimensions = new Vector2(texture.Width, texture.Height),
                                scale = new Vector2(backgroundItem.scale),
                                origin = scale * textureDimensions / 2;
                        spriteBatch.Draw(texture, new Vector2(backgroundItem.location.X - offset.X, resolution.ScreenHeight - (backgroundItem.location.Y-offset.Y)),
                            null, Color.White, backgroundItem.rotation, origin, scale, SpriteEffects.None, 0f);
                    }
                    #endregion
                    #region Draw spawns
                    foreach (SpawnPoint spawn in CurrentLevel.spawns)
                    {
                        Texture2D texture = textureManager.getTexture(spawn.type);
                        if (texture == null)
                            texture = textureManager.getTexture("enemy");
                        spriteBatch.Draw(texture, new Vector2(spawn.loc.X - offset.X, resolution.ScreenHeight - (spawn.loc.Y - offset.Y)),
                            null, Color.White, 0f, new Vector2(texture.Width/2, texture.Height/2), 1f, SpriteEffects.None, 0f);
                    }
                    #endregion
                    #region Draw game items
                    foreach(GameItem item in CurrentLevel.items)
                    {
                        Texture2D texture = textureManager.getTexture(item.name);
                        //if texture manager has item, draw with texture, otherwise hand draw with brush
                        if (texture != null)
                        {
                            Vector2 textureDimensions = new Vector2(texture.Width, texture.Height),
                                scale = item.polygonType == PhysicsPolygonType.Circle ? 
                                    new Vector2(item.radius) / textureDimensions : 
                                    item.sideLengths / textureDimensions,
                                origin = scale * textureDimensions / 2;
                            spriteBatch.Draw(texture, new Vector2(item.loc.X - offset.X, resolution.ScreenHeight - (item.loc.Y-offset.Y)), 
                                null, Color.White, item.rotation, origin, scale, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            brush.ClearVectors();
                            switch (item.polygonType)
                            {
                                case PhysicsPolygonType.Rectangle:
                                    brush.AddVector(new Vector2(item.loc.X - offset.X - item.sideLengths.X / 2, resolution.ScreenHeight - (item.loc.Y - offset.Y - item.sideLengths.Y / 2)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X - item.sideLengths.X / 2, resolution.ScreenHeight - (item.loc.Y - offset.Y + item.sideLengths.Y / 2)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X + item.sideLengths.X / 2, resolution.ScreenHeight - (item.loc.Y - offset.Y + item.sideLengths.Y / 2)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X + item.sideLengths.X / 2, resolution.ScreenHeight - (item.loc.Y - offset.Y - item.sideLengths.Y / 2)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X - item.sideLengths.X / 2, resolution.ScreenHeight - (item.loc.Y - offset.Y - item.sideLengths.Y / 2)));
                                    brush.Render(spriteBatch);
                                    break;
                                case PhysicsPolygonType.Circle:
                                    brush.AddVector(new Vector2(item.loc.X - offset.X - item.radius, resolution.ScreenHeight - (item.loc.Y - offset.Y + item.radius)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X + item.radius, resolution.ScreenHeight - (item.loc.Y - offset.Y + item.radius)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X + item.radius, resolution.ScreenHeight - (item.loc.Y - offset.Y - item.radius)));
                                    brush.AddVector(new Vector2(item.loc.X - offset.X - item.radius, resolution.ScreenHeight - (item.loc.Y - offset.Y - item.radius)));
                                    brush.Render(spriteBatch);
                                    break;
                                //case PhysicsPolygonType.Polygon:
                                //    foreach (Vector2 vertex in item.vertices)
                                //        brush.AddVector(vertex);
                                //    brush.Render(spriteBatch);
                                //    break;
                            }
                        }
                    }
                    #endregion
                    break;
                #endregion
                #region worldeditor
                case Enums.State.Worldeditor:
                    foreach (Level level in levels)
                    {
                        spriteBatch.DrawString(font, level.name, new Vector2(level.loc.X, level.loc.Y), Color.Black);

                        List<Level> adjacentLevels = new List<Level>();
                        foreach (int adjlevel in level.adjacent)
                            adjacentLevels.Add(levels[adjlevel]);
                        foreach (Level adjlevel in adjacentLevels)
                        {
                            PrimitiveLine brush = new PrimitiveLine(GraphicsDevice);
                            brush.AddVector(level.loc);
                            brush.AddVector(adjlevel.loc);
                            brush.Position = Vector2.Zero;
                            brush.Render(spriteBatch);
                        }
                    }
                break;
                #endregion
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void addLevel()
        {
            Level item = new Level();
            selectedLevelIndex = levels.Count;
            item.number = selectedLevelIndex;
            item.loc.X = Mouse.GetState().X;
            item.loc.Y = Mouse.GetState().Y;
            levels.Add(item);
            control.setLevelInfo(item.loc.X, item.loc.Y, item.name, item.number, false);
        }

        public void newMap()
        {
            
            offset = currentLocation = Vector2.Zero;
            currentState = Enums.State.Worldeditor;
            selectedLevelIndex = 0;
            levels = new List<Level>();
        }

        public void updateLevel(float locx, float locy, List<int> adjacent, List<int> prereqs, string name, int number, bool autoProgress)
        {
            levels[number].loc.X = locx;
            levels[number].loc.Y = locy;
            levels[number].name = name;
            levels[number].adjacent = adjacent;
            levels[number].prereq = prereqs;
            levels[number].autoProgress = autoProgress;
        }

        public void switchState()
        {
            if (Environment.TickCount - timeSinceLastStateChange < 250)
                return;
            control.switchState();
            if (currentState == Enums.State.Leveleditor)
                currentState = Enums.State.Worldeditor;
            else if (currentState == Enums.State.Worldeditor)
            {
                currentState = Enums.State.Leveleditor;
                control.setLevelEditorTabActive();
            }
        }

        public Options getOptions() { return options; }
    }
}
