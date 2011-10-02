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
        public int timeSinceLastClick = 0;
        SpriteFont font;
        private int windowWidth, windowHeight;
        Enums.State currentState; private int timeSinceLastStateChange = 0;
        public string mapBackgroundPath;
        #endregion
        public Vector2 loc, offset;

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
            windowWidth = (int)(GraphicsDevice.DisplayMode.Width / 1.2);
            windowHeight = (int)(GraphicsDevice.DisplayMode.Height / 1.2);
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
                    if (ButtonState.Pressed == Mouse.GetState().LeftButton && Environment.TickCount - timeSinceLastClick > 1000
                        && Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        loc = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                        control.updateLevelLoc();
                    }
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
                    if (ButtonState.Pressed == Mouse.GetState().LeftButton && Environment.TickCount - timeSinceLastClick > 1000
                        && Mouse.GetState().X > 0 && Mouse.GetState().Y > 0)
                    {
                        if (distance < DISTANCE_FOR_SELECTION)
                        {
                            control.setLevelInfo(levels[indexOfClosestLevel].loc.X, levels[indexOfClosestLevel].loc.Y,
                                levels[indexOfClosestLevel].adjacent, levels[indexOfClosestLevel].prereq,
                                levels[indexOfClosestLevel].name, levels[indexOfClosestLevel].number);
                        }
                        else
                            addLevel();
                        timeSinceLastClick = Environment.TickCount;
                    }
                    else if (ButtonState.Pressed == Mouse.GetState().LeftButton && Environment.TickCount - timeSinceLastClick > 200
                        && Mouse.GetState().X > 0 && Mouse.GetState().Y > 0 && distance < DISTANCE_FOR_SELECTION)
                    {
                        switchState();
                        selectedLevelIndex = indexOfClosestLevel;
                        timeSinceLastClick = Environment.TickCount;
                    }
                    break;
                #endregion
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.SaveState);
            switch (currentState)
            {
                #region Leveleditor
                case Enums.State.Leveleditor:
                    foreach(GameItem item in levels[selectedLevelIndex].items)
                    {
                        string lowerName = item.name.ToLower();
                        PrimitiveLine brush = new PrimitiveLine(GraphicsDevice);
                        if (lowerName.Contains("box"))
                        {
                            brush.AddVector(item.loc);
                            brush.AddVector(new Vector2(item.loc.X, item.loc.Y + float.Parse(item.radius)));
                            brush.AddVector(new Vector2(item.loc.X + float.Parse(item.radius), item.loc.Y + float.Parse(item.radius)));
                            brush.AddVector(new Vector2(item.loc.X + float.Parse(item.radius), item.loc.Y));
                            brush.AddVector(item.loc);
                            brush.Position = -offset;
                        }
                        if (lowerName.Contains("circle") || lowerName.Contains("log"))
                        {
                            brush.CreateCircle(float.Parse(item.radius), 12);
                            brush.Position = item.loc - offset;
                        }
                        brush.Render(spriteBatch);
                    }
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
            item.loc.X = Mouse.GetState().X;
            item.loc.Y = Mouse.GetState().Y;
            item.number = Level.totalLevels++;
            levels.Add(item);
            control.setLevelInfo(item.loc.X, item.loc.Y, item.name, item.number);
        }

        public bool exportMap(string filename)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            textWriter.Formatting = Formatting.Indented;
            textWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            textWriter.WriteStartElement("Root");

            foreach (Level level in levels)
            {
                textWriter.WriteStartElement("level");
                string adj = "";
                foreach(int adjint in level.adjacent){
                    adj += adjint;
                    if(adjint != level.adjacent[level.adjacent.Count-1])
                        adj += ",";
                }
                textWriter.WriteElementString("adj", adj.ToString());
                textWriter.WriteElementString("backgroundPath", level.backgroundpath);

                textWriter.WriteStartElement("items");
                foreach (GameItem item in level.items)
                {
                    textWriter.WriteStartElement("item");
                    textWriter.WriteElementString("name", item.name);
                    textWriter.WriteElementString("loc", item.loc.X + "," + item.loc.Y);
                    if (item.name.Contains("enemies"))
                    {
                        textWriter.WriteElementString("count", item.startdepth);
                        textWriter.WriteElementString("bosses", item.width.ToString());
                        textWriter.WriteElementString("type", item.radius);
                    }
                    else
                    {
                        textWriter.WriteElementString("radius", item.radius);
                        textWriter.WriteElementString("startdepth", item.startdepth);
                        textWriter.WriteElementString("width", item.width.ToString());
                    }
                    textWriter.WriteElementString("weight", item.weight.ToString());
                    textWriter.WriteEndElement();
                }
                textWriter.WriteEndElement();

                textWriter.WriteElementString("location", level.loc.X + "," + level.loc.Y);
                textWriter.WriteElementString("name", level.name);
                textWriter.WriteElementString("number", level.number.ToString());

                string prereq = "";
                foreach (int prereqint in level.prereq)
                {
                    prereq += prereqint;
                    if (prereqint != level.prereq[level.prereq.Count - 1])
                        prereq += ",";
                }
                textWriter.WriteElementString("prereq", prereq.ToString());

                textWriter.WriteEndElement();
            }

            textWriter.Close();  
            return false;
        }

        public void newMap()
        {
            
            offset = loc = Vector2.Zero;
            currentState = Enums.State.Worldeditor;
            selectedLevelIndex = 0;
            Level.totalLevels = 0;
            levels = new List<Level>();
        }

        public void updateLevel(float locx, float locy, List<int> adjacent, List<int> prereqs, string name, int number)
        {
            levels[number].loc.X = locx;
            levels[number].loc.Y = locy;
            levels[number].name = name;
            levels[number].adjacent = adjacent;
            levels[number].prereq = prereqs;
        }

        public void switchState()
        {
            if (Environment.TickCount - timeSinceLastStateChange < 250)
                return;
            control.switchState();
            if (currentState == Enums.State.Leveleditor)
                currentState = Enums.State.Worldeditor;
            else if (currentState == Enums.State.Worldeditor)
                currentState = Enums.State.Leveleditor;
        }
    }
}
