﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

namespace BountyBanditsWorldEditor.Map
{
    public class SpawnPoint
    {
        public Vector2 loc, triggerLocation;
        public uint count = 1, bosses = 0, triggerWidth = 64;
        public string type;
        /// <summary>
        /// This can be weight of a box OR the level if it is an enemy
        /// </summary>
        public uint level = 1;
        public bool isSpawned = false;
        XmlNode fromNode;

        public SpawnPoint Clone()
        {
            return SpawnPoint.fromXML(fromNode);
        }

        public static SpawnPoint fromXML(XmlNode node)
        {
            SpawnPoint point = new SpawnPoint();
            point.fromNode = node;
            foreach (XmlNode itemChild in node)
                if (itemChild.Name.Equals("loc"))
                {
                    string[] locStr = itemChild.FirstChild.Value.Split(',');
                    point.loc = new Vector2(float.Parse(locStr[0]), float.Parse(locStr[1]));
                }
                else if (itemChild.Name.Equals("triggerLocation"))
                {
                    string[] locStr = itemChild.FirstChild.Value.Split(',');
                    point.triggerLocation = new Vector2(float.Parse(locStr[0]), float.Parse(locStr[1]));
                }
                else if (itemChild.Name.Equals("count"))
                    point.count = uint.Parse(itemChild.FirstChild.Value);
                else if (itemChild.Name.Equals("bosses"))
                    point.bosses = uint.Parse(itemChild.FirstChild.Value);
                else if (itemChild.Name.Equals("level"))
                    point.level = uint.Parse(itemChild.FirstChild.Value);
                else if (itemChild.Name.Equals("width"))
                    point.triggerWidth = uint.Parse(itemChild.FirstChild.Value);
                else if (itemChild.Name.Equals("type"))
                    point.type = itemChild.FirstChild.Value;
            return point;
        }

        public bool insideTrigger(Vector2 position)
        {
            return position.X < triggerLocation.X + triggerWidth && position.X > triggerLocation.X - triggerWidth &&
                position.Y < triggerLocation.Y + triggerWidth && position.Y > triggerLocation.Y - triggerWidth;
        }
    }
}