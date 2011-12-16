using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace BountyBanditsWorldEditor
{
    public class Options
    {
        private static String OPTIONS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Bounty Bandits\",
            OPTIONS_FILE = OPTIONS_PATH + "options.xml";
        private List<string> textureDirectories = new List<string>(new String[] { @".\" });
        private Game1 gameref;

        public Options(Game1 gameref)
        {
            this.gameref = gameref;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(OPTIONS_FILE);
                foreach (XmlElement texturePathElement in xmlDoc.GetElementsByTagName("texturePath"))
                    textureDirectories.Add(texturePathElement.InnerText);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
        public void writeOptions()
        {
            Directory.CreateDirectory(OPTIONS_PATH);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(OPTIONS_FILE);
            }
            catch (System.IO.FileNotFoundException)
            {
                //if file is not found, create a new xml file
                XmlTextWriter xmlWriter = new XmlTextWriter(OPTIONS_FILE, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
                xmlWriter.WriteStartElement("root");
                //If WriteProcessingInstruction is used as above,
                //Do not use WriteEndElement() here
                //xmlWriter.WriteEndElement();
                //it will cause the <Root> to be &ltRoot />
                xmlWriter.Close();
                xmlDoc.Load(OPTIONS_FILE);
            }
            XmlNode root = xmlDoc.DocumentElement;
            root.AppendChild(asXML(root));
            xmlDoc.Save(OPTIONS_FILE);
        }
        private XmlNode asXML(XmlNode root)
        {
            XmlElement element = root.OwnerDocument.CreateElement("options");
            foreach (String texturePath in textureDirectories)
            {
                XmlElement texturePathElement = element.OwnerDocument.CreateElement("texturePath");
                texturePathElement.InnerText = texturePath;
                element.AppendChild(texturePathElement);
            }
            return element;
        }
        public List<string> getTextureDirectories()
        {
            return textureDirectories;
        }
        public void setTextureDirectories(List<string> textureDirectories)
        {
            this.textureDirectories = textureDirectories;
            writeOptions();
            foreach(String textureDirectory in textureDirectories)
                gameref.textureManager.addTextureDirectory(textureDirectory);
        }
    }
}
