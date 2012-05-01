using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using BountyBanditsWorldEditor.Map;

namespace BountyBanditsWorldEditor
{
    public static class CampaignImportExport
    {
        public static bool exportMap(string filename, Game1 game)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            textWriter.Formatting = Formatting.Indented;
            textWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            textWriter.WriteStartElement("Root");
            textWriter.WriteElementString("guid", game.guid.ToString());
            foreach (Level level in game.levels)
            {
                textWriter.WriteStartElement("level");
                textWriter.WriteAttributeString("length", level.levelLength.ToString());
                textWriter.WriteAttributeString("name", level.name);
                textWriter.WriteAttributeString("autoProgress", level.autoProgress.ToString());
                string adj = "";
                foreach (int adjint in level.adjacent)
                {
                    adj += adjint;
                    if (adjint != level.adjacent[level.adjacent.Count - 1])
                        adj += ",";
                }
                textWriter.WriteElementString("adj", adj.ToString());
                textWriter.WriteElementString("horizonPath", level.horizon);
                textWriter.WriteStartElement("background");
                foreach (BackgroundItemStruct str in level.backgroundItems)
                {
                    textWriter.WriteStartElement("graphic");
                    textWriter.WriteAttributeString("rotation", str.rotation.ToString());
                    textWriter.WriteAttributeString("scale", str.scale.ToString());
                    textWriter.WriteElementString("path", str.texturePath);
                    textWriter.WriteStartElement("location");
                    textWriter.WriteElementString("x", str.location.X.ToString());
                    textWriter.WriteElementString("y", str.location.Y.ToString());
                    textWriter.WriteEndElement();
                    textWriter.WriteEndElement();
                }
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("items");
                foreach (GameItem item in level.items)
                {
                    textWriter.WriteStartElement("item");
                    textWriter.WriteAttributeString("rotation", item.rotation.ToString());
                    switch (item.polygonType)
                    {
                        case PhysicsPolygonType.Circle:
                            textWriter.WriteElementString("radius", item.radius.ToString());
                            break;
                        case PhysicsPolygonType.Rectangle:
                            textWriter.WriteStartElement("sideLengths");
                            textWriter.WriteElementString("x", item.sideLengths.X.ToString());
                            textWriter.WriteElementString("y", item.sideLengths.Y.ToString());
                            textWriter.WriteEndElement();
                            break;
                    }
                    textWriter.WriteElementString("immovable", item.immovable.ToString());
                    textWriter.WriteElementString("startdepth", item.startdepth.ToString());
                    textWriter.WriteElementString("width", item.width.ToString());
                    textWriter.WriteElementString("name", item.name);
                    textWriter.WriteElementString("loc", item.loc.X + "," + item.loc.Y);
                    textWriter.WriteElementString("weight", item.weight.ToString());
                    textWriter.WriteEndElement();
                }
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("spawns");
                foreach (SpawnPoint spawn in level.spawns)
                {
                    textWriter.WriteStartElement("enemy");
                    textWriter.WriteElementString("count", spawn.count.ToString());
                    textWriter.WriteElementString("bosses", spawn.bosses.ToString());
                    textWriter.WriteElementString("type", spawn.type.ToString());
                    textWriter.WriteElementString("name", spawn.name.ToString());
                    textWriter.WriteElementString("weight", spawn.weight.ToString());
                    textWriter.WriteElementString("loc", spawn.loc.X.ToString() + "," + spawn.loc.Y.ToString());
                    textWriter.WriteEndElement();
                }
                textWriter.WriteEndElement();
                textWriter.WriteElementString("location", level.loc.X + "," + level.loc.Y);
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

        public static void importMap(string filename, Game1 gameref)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            gameref.levels.Clear();
            foreach(XmlElement levelElement in xmlDoc.GetElementsByTagName("level"))
                gameref.levels.Add(Level.fromXML(levelElement, gameref, filename.Substring(0, filename.LastIndexOf(@"\"))));
            gameref.guid = Guid.Parse(xmlDoc.GetElementsByTagName("guid")[0].FirstChild.Value);
        }
    }
}
