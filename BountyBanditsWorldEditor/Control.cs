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
        public void setLevelInfo(float locX, float locY, List<int> adj, List<int> prereqs, string levelName,
            int levelIndex, bool autoProgress)
        {
            setLevelInfo(locX, locY, levelName, levelIndex, autoProgress);
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

        public void setLevelInfo(float locX, float locY, string levelName, int levelIndex, bool autoProgress)
        {
            this.levelIndexBox.Text = levelIndex.ToString();
            this.locXBox.Text = locX.ToString();
            this.locYBox.Text = locY.ToString();
            this.adjacentLevelsBox.Clear();
            this.prereqLevelsBox.Clear();
            this.levelNameBox.Text = levelName;
            this.autoProgressCheckBox.Checked = autoProgress;
        }

        public void switchState()
        {
            updateCurrentPositionLabel();
            this.levelEditorPanel.Visible = !this.levelEditorPanel.Visible;
        }

        public void updateCurrentPositionLabel()
        {
            this.currentPosTextLabel.Text = gameref.currentLocation.X + "x   " + gameref.currentLocation.Y + "y";
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

            gameref.updateLevel(float.Parse(this.locXBox.Text), float.Parse(this.locYBox.Text), 
                adjacent, prereq, this.levelNameBox.Text, int.Parse(this.levelIndexBox.Text), autoProgressCheckBox.Checked);
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
            gameref.CurrentLevel.horizon = filechooserPicture();
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
            maxOffsetChanged();
        }

        private void maxOffsetChanged(){
            this.offsetTrackBar.Maximum = int.Parse(this.maxOffsetBox.Text);
            this.offsetTrackBar.TickFrequency = this.offsetTrackBar.Maximum / 20;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            gameref.switchState();
            mapLevelTabControl.SelectedTab = mapTab;
            updateLevelButton_Click(sender, e);
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
            try
            {
                SpawnPoint spawn = new SpawnPoint();
                spawn.count = uint.Parse(enemyCountBox.Text);
                spawn.name = enemyTypeText.Text;
                spawn.type = enemyTypeText.Text;
                spawn.weight = uint.Parse(enemyWeightBox.Text);
                spawn.loc = gameref.currentLocation;
                gameref.CurrentLevel.spawns.Add(spawn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception from spawn point:\n" + ex.StackTrace);
            }
        }

        private void itemSpawnButton_Click(object sender, EventArgs e)
        {
            try
            {
                GameItem item = new GameItem();
                item.name = this.itemTextureText.Text;
                item.polygonType = (PhysicsPolygonType)Enum.Parse(typeof(PhysicsPolygonType), this.itemPolygonType.Text);
                if (item.polygonType == PhysicsPolygonType.Circle)
                    item.radius = uint.Parse(this.itemRadiusText.Text);
                else
                {
                    String[] sideLengths = this.itemRadiusText.Text.Split(',');
                    item.sideLengths = new Vector2(int.Parse(sideLengths[0]), int.Parse(sideLengths[1]));
                }
                item.immovable = this.itemImmovableBox.Checked;
                item.startdepth = (uint)this.itemDepthSlider.Value;
                item.weight = uint.Parse(this.itemWeightBox.Text);
                item.width = (uint)this.itemWidthSlider.Value;
                item.rotation = float.Parse(this.itemRotationTextBox.Text);
                item.loc = gameref.currentLocation;
                gameref.CurrentLevel.items.Add(item);
            }
            catch (Exception exceptionSpawnItem)
            {
                MessageBox.Show("Exception from game item:\n" + exceptionSpawnItem.StackTrace);
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
            str.location = gameref.currentLocation;
            str.rotation = float.Parse(backgroundRotationText.Text);
            str.scale = float.Parse(backgroundScaleField.Text);
            gameref.CurrentLevel.backgroundItems.Add(str);
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

        public void setLevelEditorTabActive()
        {
            mapLevelTabControl.SelectedTab = levelTab;
            this.maxOffsetBox.Text = gameref.CurrentLevel.levelLength.ToString();
            maxOffsetChanged();
        }

        public void setGuiControls(GameItem item)
        {
            itemPolygonType.SelectedItem = item.polygonType.ToString();
            itemTextureText.Text = item.name;
            itemWeightBox.Text = item.weight.ToString();
            itemRadiusText.Text = item.polygonType == PhysicsPolygonType.Circle ? item.radius.ToString() : 
                item.sideLengths.X.ToString() + "," + item.sideLengths.Y.ToString();
            itemRotationTextBox.Text = item.rotation.ToString();
            itemDepthSlider.Value = (int)item.startdepth;
            itemWidthSlider.Value = (int)item.width;
            itemImmovableBox.Checked = item.immovable;
        }

        public void setGuiControls(SpawnPoint spawn)
        {
            enemyCountBox.Text = spawn.count.ToString();
            enemyTypeText.Text = spawn.name.ToString();
            enemyWeightBox.Text = spawn.weight.ToString();
        }

        public void setGuiControls(BackgroundItemStruct backgroundItemStruct)
        {
            backgroundRotationText.Text = backgroundItemStruct.rotation.ToString();
            backgroundScaleField.Text = backgroundItemStruct.scale.ToString();
            backgroundTextureField.Text = backgroundItemStruct.texturePath;
        }
    }
}
