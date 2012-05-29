using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using BountyBanditsWorldEditor;
using System.Windows.Forms;

namespace BountyBanditsWorldEditor.Map
{
    public class Level
    {
        #region Map editor relevant
        public int number = -1, levelLength = 1000;
        public string name = "default";
        public List<int> adjacent = new List<int>();
        public List<int> prereq = new List<int>();
        public List<BackgroundItemStruct> backgroundItems = new List<BackgroundItemStruct>();
        public Vector2 loc = Vector2.Zero;
        #endregion
        #region In game specific
        public bool autoProgress = false;
        public string horizon;
        public List<GameItem> items = new List<GameItem>();
        public List<SpawnPoint> spawns = new List<SpawnPoint>();
        #endregion
        private const float DEFAULT_DIMENSION = 64f;

        public GameItem getGameItemAtLocation(float x, float y)
        {
            foreach (GameItem item in items)
                switch(item.polygonType)
                {
                    case PhysicsPolygonType.Circle:
                        if ( Math.Pow(x - item.loc.X, 2) + Math.Pow(y - item.loc.Y, 2) < Math.Pow(item.radius, 2))
                            return item;
                        break;
                    case PhysicsPolygonType.Rectangle:
                        if (x < item.loc.X + item.sideLengths.X / 2 && x > item.loc.X - item.sideLengths.X / 2 &&
                            y < item.loc.Y + item.sideLengths.Y / 2 && y > item.loc.Y - item.sideLengths.Y / 2)
                            return item;
                        break;
                }
            return null;
        }

        public SpawnPoint getSpawnAtLocation(float x, float y, Game1 gameref)
        {
            foreach (SpawnPoint spawn in spawns)
            {
                Vector2 dimensions = getDimensions(spawn.type, gameref);
                if (x < spawn.loc.X + dimensions.X && x > spawn.loc.X - dimensions.X &&
                    y < spawn.loc.Y + dimensions.Y && y > spawn.loc.Y - dimensions.Y)
                    return spawn;
            }
            return null;
        }

        public BackgroundItemStruct? getBackgroundItemAtLocation(float x, float y, Game1 gameref)
        {
            foreach (BackgroundItemStruct str in backgroundItems)
            {
                Vector2 dimensions = getDimensions(str.texturePath, gameref);
                if (x < str.location.X + dimensions.X && x > str.location.X - dimensions.X &&
                    y < str.location.Y + dimensions.Y && y > str.location.Y - dimensions.Y)
                    return str;
            }
            return null;
        }

        private Vector2 getDimensions(string texName, Game1 gameref)
        {
            Texture2D tex = gameref.textureManager.getTexture(texName);
            return new Vector2(tex != null ? tex.Width : DEFAULT_DIMENSION, tex != null ? tex.Height : DEFAULT_DIMENSION);
        }

        public static Level fromXML(XmlElement node, Game gameref, String campaignPath)
        {
            Level newLvl = new Level();
            newLvl.number = int.Parse(node.GetElementsByTagName("number")[0].FirstChild.Value);
            if (node.HasAttribute("autoProgress"))
                newLvl.autoProgress = bool.Parse(node.GetAttribute("autoProgress"));
            newLvl.name = node.GetAttribute("name");
            foreach (string singleAdj in node.GetElementsByTagName("adj")[0].FirstChild.Value.Split(','))
                newLvl.adjacent.Add(Int32.Parse(singleAdj));
            XmlNodeList list = node.GetElementsByTagName("prereq");
            if (list.Count > 0 && list[0].FirstChild != null)
                foreach (string singlePrereq in node.GetElementsByTagName("prereq")[0].FirstChild.Value.Split(','))
                    newLvl.prereq.Add(Int32.Parse(singlePrereq));
            newLvl.loc = XMLUtil.fromXMLVector2(node.GetElementsByTagName("location")[0]);
            if (node.GetElementsByTagName("horizonPath").Count > 0)
                newLvl.horizon = node.GetElementsByTagName("horizonPath")[0].FirstChild.Value;
            if (node.GetElementsByTagName("items").Count > 0)
                foreach (XmlElement item in node.GetElementsByTagName("items")[0].ChildNodes)
                    newLvl.items.Add(GameItem.fromXML(item));
            if (node.GetElementsByTagName("spawns").Count > 0)
                foreach (XmlElement item in node.GetElementsByTagName("spawns")[0].ChildNodes)
                    newLvl.spawns.Add(SpawnPoint.fromXML(item));
            /*XmlNodeList storyNodes = node.GetElementsByTagName("story");
            if (storyNodes.Count > 0 && storyNodes[0].ChildNodes.Count > 0)
                foreach (XmlNode item in storyNodes[0].ChildNodes)
                    newLvl.storyElements.Add(StoryElement.fromXML(item, gameref));*/
            newLvl.levelLength = int.Parse(node.GetAttribute("length"));
            foreach (XmlElement graphic in node.GetElementsByTagName("graphic"))
                newLvl.backgroundItems.Add(BackgroundItemStruct.fromXML(graphic));
            return newLvl;
        }
    }

    public struct BackgroundItemStruct
    {
        public string texturePath;
        public Vector2 location;
        public float rotation, scale;
        public static BackgroundItemStruct fromXML(XmlElement element)
        {
            BackgroundItemStruct str = new BackgroundItemStruct();
            str.location = XMLUtil.fromXMLVector2(element.GetElementsByTagName("location")[0]);
            str.texturePath = element.GetElementsByTagName("path")[0].FirstChild.Value;
            str.rotation = element.GetAttribute("rotation") != "" ? float.Parse(element.GetAttribute("rotation")) : 0f;
            str.scale = element.GetAttribute("scale") == "" ? 1f : float.Parse(element.GetAttribute("scale"));
            return str;
        }
    }
}
