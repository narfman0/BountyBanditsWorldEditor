﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using BountyBanditsWorldEditor;

namespace BountyBanditsWorldEditor.Map
{
    public class Level
    {
        #region Map editor relevant
        public static int totalLevels = 0;
        public int number = -1, levelLength = 1000;
        public string name = "default";
        public List<int> adjacent = new List<int>();
        public List<int> prereq = new List<int>();
        public List<BackgroundItemStruct> backgroundItems = new List<BackgroundItemStruct>();
        public Vector2 loc = Vector2.Zero;
        #endregion
        #region In game specific
        public string horizon;
        public List<GameItem> items = new List<GameItem>();
        public List<SpawnPoint> spawns = new List<SpawnPoint>();
        #endregion

        public static Level fromXML(XmlElement node, Game gameref, String campaignPath)
        {
            Level newLvl = new Level();
            newLvl.number =int.Parse(node.GetElementsByTagName("number")[0].FirstChild.Value);
            newLvl.name = node.GetAttribute("name");
            foreach (string singleAdj in node.GetElementsByTagName("adj")[0].FirstChild.Value.Split(','))
                newLvl.adjacent.Add(Int32.Parse(singleAdj));
            XmlNodeList list = node.GetElementsByTagName("prereq");
            if (list.Count > 0 && list[0].FirstChild != null)
                foreach (string singlePrereq in node.GetElementsByTagName("prereq")[0].FirstChild.Value.Split(','))
                    newLvl.prereq.Add(Int32.Parse(singlePrereq));
            newLvl.loc = XMLUtil.fromXMLVector2(node.GetElementsByTagName("location")[0]);
            newLvl.horizon = node.GetElementsByTagName("horizonPath")[0].FirstChild.Value;
            foreach (XmlElement item in node.GetElementsByTagName("items")[0].ChildNodes)
            {
                string name = "";
                foreach (XmlNode itemChild in item.ChildNodes)
                    if (itemChild.Name.Equals("name"))
                        name = itemChild.FirstChild.Value;
                if (name.Equals("enemies"))
                    newLvl.spawns.Add(SpawnPoint.fromXML(item));
                else
                    newLvl.items.Add(GameItem.fromXML(item));
            }
            //XmlNodeList storyNodes = node.GetElementsByTagName("story");
            //if(storyNodes.Count>0 && storyNodes[0].ChildNodes.Count>0)
            //    foreach (XmlNode item in storyNodes[0].ChildNodes)
            //        newLvl.storyElements.Add(StoryElement.fromXML(item, gameref));
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
