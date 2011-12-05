using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace BountyBanditsWorldEditor
{
    public partial class Control : Form
    {
        private Game1 gameref;
        public Control(Game1 gameref)
        {
            this.gameref = gameref;
            InitializeComponent();
            this.levelEditorPanel.Visible = false;
        }
        public void setLevelInfo(float locX, float locY, List<int> adj, List<int> prereqs, string levelName, int levelIndex)
        {
            setLevelInfo(locX, locY, levelName, levelIndex);
            for (int index = 0; index < prereqs.Count; index++)
            {
                this.prereqLevelsBox.Text = this.prereqLevelsBox.Text + prereqs[index];
                if(index+1 != prereqs.Count)
                    this.prereqLevelsBox.Text = this.prereqLevelsBox.Text+",";
            }
            for (int index = 0; index < adj.Count; index++)
            {
                this.adjacentLevelsBox.Text = this.adjacentLevelsBox.Text + adj[index];
                if (index + 1 != adj.Count)
                    this.adjacentLevelsBox.Text = this.adjacentLevelsBox.Text + ",";
            }
        }

        public void setLevelInfo(float locX, float locY, string levelName, int levelIndex)
        {
            this.levelIndexBox.Text = levelIndex.ToString();
            this.locXBox.Text = locX.ToString();
            this.locYBox.Text = locY.ToString();
            this.adjacentLevelsBox.Clear();
            this.prereqLevelsBox.Clear();
            this.levelNameBox.Text = levelName;
        }

        public void switchState()
        {
            updateLevelLoc();
            this.levelEditorPanel.Visible = !this.levelEditorPanel.Visible;
        }

        public void updateLevelLoc()
        {
            this.currentPosTextLabel.Text = (gameref.loc.X + gameref.offset.X) + "x   " + (gameref.loc.Y + gameref.offset.Y) + "y";
        }

        private void updateLevelButton_Click(object sender, EventArgs e)
        {
            List<int> adjacent = new List<int>();
            string[] adjStrings = this.adjacentLevelsBox.Text.Split(',');
            foreach(string adjstr in adjStrings)
                if(adjstr!="")
                    adjacent.Add(int.Parse(adjstr));

            List<int> prereqacent = new List<int>();
            string[] prereqStrings = this.prereqLevelsBox.Text.Split(',');
            foreach (string prereqstr in prereqStrings)
                if(prereqstr!="")
                    prereqacent.Add(int.Parse(prereqstr));

            gameref.updateLevel(float.Parse(this.locXBox.Text), float.Parse(this.locYBox.Text), adjacent, prereqacent, this.levelNameBox.Text, int.Parse(this.levelIndexBox.Text));
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            gameref.newMap();
        }

        private void mapBackgroundButton_Click(object sender, EventArgs e)
        {
            gameref.mapBackgroundPath = filechooserPicture();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            gameref.levels[gameref.selectedLevelIndex].horizonPath = filechooserPicture();
        }
        private string filechooserPicture(){
            OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "picture files (*.jpg)|*.jpg";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return null;
        }

        private void offsetTrackBar_Scroll(object sender, EventArgs e)
        {
            gameref.offset.X = this.offsetTrackBar.Value;
        }

        private void maxOffsetBox_TextChanged(object sender, EventArgs e)
        {
            this.offsetTrackBar.Maximum = int.Parse(this.maxOffsetBox.Text);
            this.offsetTrackBar.TickFrequency = this.offsetTrackBar.Maximum / 20;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            gameref.switchState();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                gameref.exportMap(openFileDialog1.FileName);
        }

        private void enemySpawnButton_Click(object sender, EventArgs e)
        {
            GameItem item = new GameItem();
            item.name = this.enemyTypeText.Text;
            item.startdepth = this.enemyCountBox.Text;
            item.weight = uint.Parse(this.enemyWeightBox.Text);
            item.loc = gameref.loc + gameref.offset;
            gameref.levels[gameref.selectedLevelIndex].items.Add(item);
        }

        private void itemSpawnButton_Click(object sender, EventArgs e)
        {

            try
            {
                GameItem item = new GameItem();
                item.name = this.itemTextureText.Text;
                if (this.itemPolygonType.Text == "Circle")
                {
                    item.radius = this.itemRadiusText.Text;
                    item.polygonType = GameItem.PhysicsPolygonType.Circle;
                }
                else
                {
                    String[] sideLengths = this.itemRadiusText.Text.Split(',');
                    item.sideLengths = new Vector2(int.Parse(sideLengths[0]), int.Parse(sideLengths[1]));
                    item.polygonType = GameItem.PhysicsPolygonType.Rectangle;
                }
                item.immovable = this.itemImmovableBox.Checked;
                item.startdepth = this.itemDepthSlider.Text;
                item.weight = uint.Parse(this.itemWeightBox.Text);
                item.width = 1;
                item.loc = gameref.loc + gameref.offset;
                gameref.levels[gameref.selectedLevelIndex].items.Add(item);
            }
            catch (Exception exceptionSpawnItem)
            {
                MessageBox.Show("Exception from game item: " + exceptionSpawnItem.StackTrace);
            }
        }

        private void itemPolygonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemPolygonType.Text == "Rectangle")
            {
                itemRadiusLabel.Text = "Side Lengths (x,y):";
                itemRadiusText.Text = "10,10";
            }
            else
            {
                itemRadiusLabel.Text = "Radius:";
                itemRadiusText.Text = "10";
            }
        }

        private void backgroundSpawnButton_Click(object sender, EventArgs e)
        {
            BackgroundItemStruct str = new BackgroundItemStruct();
            str.location = gameref.loc + gameref.offset;
            str.rotation = float.Parse(backgroundRotationText.Text);
            str.scale = float.Parse(backgroundScaleField.Text);
            gameref.levels[gameref.selectedLevelIndex].backgroundItems.Add(str);
        }
    }
}
