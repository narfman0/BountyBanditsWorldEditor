﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BountyBanditsWorldEditor
{
    /// <summary>
    /// Scan texture directories and add all to hashmap
    /// </summary>
    public class TextureManager
    {
        private Dictionary<String, Texture2D> textures = new Dictionary<String, Texture2D>();
        private Game1 gameref;
        private ContentManager content;

        public TextureManager(Game1 gameref, ContentManager content)
        {
            this.gameref = gameref;
            this.content = content;
            foreach (String textureDirectory in gameref.getOptions().getTextureDirectories())
                addTextureDirectory(textureDirectory);
        }
        public void addTextureDirectory(string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                string name = fileName.Split('\\')[fileName.Split('\\').Length - 1].Split('.')[0];
                List<String> pathMethods = new List<String> {path, path + @"\" };
                if(path.Length > 8) 
                    pathMethods.Add(path.Substring(8));
                if(path.Length > 10) 
                    pathMethods.Add(path.Substring(10));
                foreach(String pathMethod in pathMethods)
                    try
                    {
                        textures.Add(name, content.Load<Texture2D>(pathMethod + name));
                    }
                    catch (Exception e) { Console.WriteLine(e.StackTrace); }
                try
                {
                    textures.Add(name, LoadTextureStream(fileName));
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in Directory.GetDirectories(path))
                addTextureDirectory(dir + @"\");
        }
        public Texture2D getTexture(string name)
        {
            return textures.ContainsKey(name) ? textures[name] : null;
        }
        private Texture2D LoadTextureStream(string loc)
        {
            Texture2D file = null;
            RenderTarget2D result = null;

            using (Stream titleStream = new FileStream(loc, FileMode.Open))
            {
                file = Texture2D.FromStream(gameref.GraphicsDevice, titleStream);
            }

            //Setup a render target to hold our final texture which will have premulitplied alpha values
            result = new RenderTarget2D(gameref.GraphicsDevice, file.Width, file.Height);

            gameref.GraphicsDevice.SetRenderTarget(result);
            gameref.GraphicsDevice.Clear(Color.Black);

            //Multiply each color by the source alpha, and write in just the color values into the final texture
            BlendState blendColor = new BlendState();
            blendColor.ColorWriteChannels = ColorWriteChannels.Red | ColorWriteChannels.Green | ColorWriteChannels.Blue;

            blendColor.AlphaDestinationBlend = Blend.Zero;
            blendColor.ColorDestinationBlend = Blend.Zero;

            blendColor.AlphaSourceBlend = Blend.SourceAlpha;
            blendColor.ColorSourceBlend = Blend.SourceAlpha;

            SpriteBatch spriteBatch = new SpriteBatch(gameref.GraphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Immediate, blendColor);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            //Now copy over the alpha values from the PNG source texture to the final one, without multiplying them
            BlendState blendAlpha = new BlendState();
            blendAlpha.ColorWriteChannels = ColorWriteChannels.Alpha;

            blendAlpha.AlphaDestinationBlend = Blend.Zero;
            blendAlpha.ColorDestinationBlend = Blend.Zero;

            blendAlpha.AlphaSourceBlend = Blend.One;
            blendAlpha.ColorSourceBlend = Blend.One;

            spriteBatch.Begin(SpriteSortMode.Immediate, blendAlpha);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            //Release the GPU back to drawing to the screen
            gameref.GraphicsDevice.SetRenderTarget(null);

            return result as Texture2D;
        }
    }
}
