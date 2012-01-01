using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using BountyBanditsWorldEditor.Map;

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
            this.currentPosTextLabel.Text = (gameref.currentLocation.X + gameref.offset.X) + "x   " + (gameref.currentLocation.Y + gameref.offset.Y) + "y";
        }

        private void updateLevelButton_Click(object sender, EventArgs e)
        {
            List<int> adjacent = new List<int>();
            string[] adjStrings = this.adjacentLevelsBox.Text.Split(',');
            foreach(string adjstr in adjStrings)
                if(adjstr!="")
                    adjacent.Add(int.Parse(adjstr));

            List<int> prereq = new List<int>();
            string[] prereqStrings = this.prereqLevelsBox.Text.Split(',');
            foreach (string prereqstr in prereqStrings)
                if(prereqstr!="")
                    prereq.Add(int.Parse(prereqstr));

            gameref.updateLevel(float.Parse(this.locXBox.Text), float.Parse(this.locYBox.Text), adjacent, prereq, this.levelNameBox.Text, int.Parse(this.levelIndexBox.Text));
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
            gameref.levels[gameref.selectedLevelIndex].horizon = filechooserPicture();
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
            mapLevelTabControl.SelectedTab = mapTab;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                CampaignImportExport.exportMap(openFileDialog1.FileName, gameref);
        }

        private void enemySpawnButton_Click(object sender, EventArgs e)
        {
            GameItem item = new GameItem();
            item.name = this.enemyTypeText.Text;
            item.startdepth = uint.Parse(this.enemyCountBox.Text);
            item.weight = uint.Parse(this.enemyWeightBox.Text);
            item.loc = gameref.currentLocation + gameref.offset;
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
                    item.radius = uint.Parse(this.itemRadiusText.Text);
                    item.polygonType = PhysicsPolygonType.Circle;
                }
                else
                {
                    String[] sideLengths = this.itemRadiusText.Text.Split(',');
                    item.sideLengths = new Vector2(int.Parse(sideLengths[0]), int.Parse(sideLengths[1]));
                    item.polygonType = PhysicsPolygonType.Rectangle;
                }
                item.immovable = this.itemImmovableBox.Checked;
                item.startdepth = (uint)this.itemDepthSlider.Value;
                item.weight = uint.Parse(this.itemWeightBox.Text);
                item.width = 1;
                item.loc = gameref.currentLocation + gameref.offset;
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
            str.texturePath = backgroundTextureLabel.Text;
            str.location = gameref.currentLocation + gameref.offset;
            str.rotation = float.Parse(backgroundRotationText.Text);
            str.scale = float.Parse(backgroundScaleField.Text);
            gameref.levels[gameref.selectedLevelIndex].backgroundItems.Add(str);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm form = new OptionsForm(gameref);
            form.Visible = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "xml files (*.xml)|*.xml";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                CampaignImportExport.importMap(openFileDialog.FileName, gameref);
        }

        private void deleteLevelButton_Click(object sender, EventArgs e)
        {
            gameref.levels.RemoveAt(gameref.selectedLevelIndex--);
            gameref.selectedLevelIndex = Math.Max(0, gameref.selectedLevelIndex);
        }

        internal void setLevelEditorTabActive()
        {
            mapLevelTabControl.SelectedTab = levelTab;
        }
    }
}
