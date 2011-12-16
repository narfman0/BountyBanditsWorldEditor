using System;
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
            }
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in Directory.GetDirectories(path))
                addTextureDirectory(dir + @"\");
        }
        public Texture2D getTexture(string name)
        {
            return textures.ContainsKey(name) ? textures[name] : null;
        }
    }
}
