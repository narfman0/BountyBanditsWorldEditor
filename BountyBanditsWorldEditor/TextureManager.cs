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
        public TextureManager(ContentManager content)
        {
            foreach (String textureDirectory in new String[]{@".\"})
                addTextureDirectory(content, textureDirectory);
        }
        public void addTextureDirectory(ContentManager content, string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                string name = fileName.Split('\\')[fileName.Split('\\').Length - 1].Split('.')[0];
                try
                {
                    textures.Add(name, content.Load<Texture2D>(path.Substring(8) + name));
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
                try
                {
                    textures.Add(name, content.Load<Texture2D>(path.Substring(10) + name));
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
                try
                {
                    textures.Add(name, content.Load<Texture2D>(path + name));
                }
                catch (Exception e) { Console.WriteLine(e.StackTrace); }
            }
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in Directory.GetDirectories(path))
                addTextureDirectory(content, dir + @"\");
        }
        public Texture2D getTexture(string name)
        {
            return textures.ContainsKey(name) ? textures[name] : null;
        }
    }
}
