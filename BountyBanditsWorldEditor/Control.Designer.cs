namespace BountyBanditsWorldEditor
{
    partial class Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.mapBackgroundButton = new System.Windows.Forms.Button();
            this.mapBackgroundLabel = new System.Windows.Forms.Label();
            this.levelIndexLabel = new System.Windows.Forms.Label();
            this.levelIndexBox = new System.Windows.Forms.TextBox();
            this.updateLevelButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locXBox = new System.Windows.Forms.TextBox();
            this.locYBox = new System.Windows.Forms.TextBox();
            this.prereqLevelsLabel = new System.Windows.Forms.Label();
            this.prereqLevelsBox = new System.Windows.Forms.TextBox();
            this.adjacentLevelsBox = new System.Windows.Forms.TextBox();
            this.adjacentLevelsLabel = new System.Windows.Forms.Label();
            this.levelNameBox = new System.Windows.Forms.TextBox();
            this.selectedLevelLabel = new System.Windows.Forms.Label();
            this.levelEditorPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.enemyTab = new System.Windows.Forms.TabPage();
            this.enemyCountLabel = new System.Windows.Forms.Label();
            this.enemyCountBox = new System.Windows.Forms.TextBox();
            this.enemySpawnButton = new System.Windows.Forms.Button();
            this.enemyTypeText = new System.Windows.Forms.TextBox();
            this.enemyTypeLabel = new System.Windows.Forms.Label();
            this.enemyWeightBox = new System.Windows.Forms.TextBox();
            this.enemyWeightLabel = new System.Windows.Forms.Label();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.itemDepthSlider = new System.Windows.Forms.TrackBar();
            this.itemSpawnButton = new System.Windows.Forms.Button();
            this.itemTextureText = new System.Windows.Forms.TextBox();
            this.itemSpawnLabel = new System.Windows.Forms.Label();
            this.depthLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.itemWeightBox = new System.Windows.Forms.TextBox();
            this.itemRadiusText = new System.Windows.Forms.TextBox();
            this.itemRadiusLabel = new System.Windows.Forms.Label();
            this.itemImmovableBox = new System.Windows.Forms.CheckBox();
            this.polygonTypeLabel = new System.Windows.Forms.Label();
            this.itemPolygonType = new System.Windows.Forms.ComboBox();
            this.maxOffsetBox = new System.Windows.Forms.TextBox();
            this.maxoffsetLabel = new System.Windows.Forms.Label();
            this.offsetSliderLabel = new System.Windows.Forms.Label();
            this.offsetTrackBar = new System.Windows.Forms.TrackBar();
            this.acceptButton = new System.Windows.Forms.Button();
            this.currentPosTextLabel = new System.Windows.Forms.Label();
            this.backgroundPictureLabel = new System.Windows.Forms.Label();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.currentPosLabel = new System.Windows.Forms.Label();
            this.leveEditorTitleLabel = new System.Windows.Forms.Label();
            this.mapPanel.SuspendLayout();
            this.levelEditorPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.enemyTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDepthSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(13, 13);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New...";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(95, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // mapPanel
            // 
            this.mapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapPanel.Controls.Add(this.mapBackgroundButton);
            this.mapPanel.Controls.Add(this.mapBackgroundLabel);
            this.mapPanel.Controls.Add(this.levelIndexLabel);
            this.mapPanel.Controls.Add(this.levelIndexBox);
            this.mapPanel.Controls.Add(this.updateLevelButton);
            this.mapPanel.Controls.Add(this.locationLabel);
            this.mapPanel.Controls.Add(this.locXBox);
            this.mapPanel.Controls.Add(this.locYBox);
            this.mapPanel.Controls.Add(this.prereqLevelsLabel);
            this.mapPanel.Controls.Add(this.prereqLevelsBox);
            this.mapPanel.Controls.Add(this.adjacentLevelsBox);
            this.mapPanel.Controls.Add(this.adjacentLevelsLabel);
            this.mapPanel.Controls.Add(this.levelNameBox);
            this.mapPanel.Controls.Add(this.selectedLevelLabel);
            this.mapPanel.Location = new System.Drawing.Point(13, 43);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(314, 162);
            this.mapPanel.TabIndex = 2;
            // 
            // mapBackgroundButton
            // 
            this.mapBackgroundButton.Location = new System.Drawing.Point(140, 134);
            this.mapBackgroundButton.Name = "mapBackgroundButton";
            this.mapBackgroundButton.Size = new System.Drawing.Size(84, 23);
            this.mapBackgroundButton.TabIndex = 13;
            this.mapBackgroundButton.Text = "Browse...";
            this.mapBackgroundButton.UseVisualStyleBackColor = true;
            this.mapBackgroundButton.Click += new System.EventHandler(this.mapBackgroundButton_Click);
            // 
            // mapBackgroundLabel
            // 
            this.mapBackgroundLabel.AutoSize = true;
            this.mapBackgroundLabel.Location = new System.Drawing.Point(4, 134);
            this.mapBackgroundLabel.Name = "mapBackgroundLabel";
            this.mapBackgroundLabel.Size = new System.Drawing.Size(89, 13);
            this.mapBackgroundLabel.TabIndex = 12;
            this.mapBackgroundLabel.Text = "Map Background";
            // 
            // levelIndexLabel
            // 
            this.levelIndexLabel.AutoSize = true;
            this.levelIndexLabel.Location = new System.Drawing.Point(4, 108);
            this.levelIndexLabel.Name = "levelIndexLabel";
            this.levelIndexLabel.Size = new System.Drawing.Size(65, 13);
            this.levelIndexLabel.TabIndex = 11;
            this.levelIndexLabel.Text = "Level Index:";
            // 
            // levelIndexBox
            // 
            this.levelIndexBox.Location = new System.Drawing.Point(140, 108);
            this.levelIndexBox.Name = "levelIndexBox";
            this.levelIndexBox.Size = new System.Drawing.Size(84, 20);
            this.levelIndexBox.TabIndex = 10;
            // 
            // updateLevelButton
            // 
            this.updateLevelButton.Location = new System.Drawing.Point(230, 134);
            this.updateLevelButton.Name = "updateLevelButton";
            this.updateLevelButton.Size = new System.Drawing.Size(81, 23);
            this.updateLevelButton.TabIndex = 9;
            this.updateLevelButton.Text = "Update";
            this.updateLevelButton.UseVisualStyleBackColor = true;
            this.updateLevelButton.Click += new System.EventHandler(this.updateLevelButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(4, 82);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(51, 13);
            this.locationLabel.TabIndex = 8;
            this.locationLabel.Text = "Location:";
            // 
            // locXBox
            // 
            this.locXBox.Location = new System.Drawing.Point(140, 82);
            this.locXBox.Name = "locXBox";
            this.locXBox.Size = new System.Drawing.Size(84, 20);
            this.locXBox.TabIndex = 7;
            // 
            // locYBox
            // 
            this.locYBox.Location = new System.Drawing.Point(230, 82);
            this.locYBox.Name = "locYBox";
            this.locYBox.Size = new System.Drawing.Size(81, 20);
            this.locYBox.TabIndex = 6;
            // 
            // prereqLevelsLabel
            // 
            this.prereqLevelsLabel.AutoSize = true;
            this.prereqLevelsLabel.Location = new System.Drawing.Point(4, 56);
            this.prereqLevelsLabel.Name = "prereqLevelsLabel";
            this.prereqLevelsLabel.Size = new System.Drawing.Size(75, 13);
            this.prereqLevelsLabel.TabIndex = 5;
            this.prereqLevelsLabel.Text = "Prereq Levels:";
            // 
            // prereqLevelsBox
            // 
            this.prereqLevelsBox.Location = new System.Drawing.Point(140, 56);
            this.prereqLevelsBox.Name = "prereqLevelsBox";
            this.prereqLevelsBox.Size = new System.Drawing.Size(171, 20);
            this.prereqLevelsBox.TabIndex = 4;
            // 
            // adjacentLevelsBox
            // 
            this.adjacentLevelsBox.Location = new System.Drawing.Point(140, 30);
            this.adjacentLevelsBox.Name = "adjacentLevelsBox";
            this.adjacentLevelsBox.Size = new System.Drawing.Size(171, 20);
            this.adjacentLevelsBox.TabIndex = 3;
            // 
            // adjacentLevelsLabel
            // 
            this.adjacentLevelsLabel.AutoSize = true;
            this.adjacentLevelsLabel.Location = new System.Drawing.Point(4, 30);
            this.adjacentLevelsLabel.Name = "adjacentLevelsLabel";
            this.adjacentLevelsLabel.Size = new System.Drawing.Size(86, 13);
            this.adjacentLevelsLabel.TabIndex = 2;
            this.adjacentLevelsLabel.Text = "Adjacent Levels:";
            // 
            // levelNameBox
            // 
            this.levelNameBox.Location = new System.Drawing.Point(140, 4);
            this.levelNameBox.Name = "levelNameBox";
            this.levelNameBox.Size = new System.Drawing.Size(171, 20);
            this.levelNameBox.TabIndex = 1;
            // 
            // selectedLevelLabel
            // 
            this.selectedLevelLabel.AutoSize = true;
            this.selectedLevelLabel.Location = new System.Drawing.Point(4, 4);
            this.selectedLevelLabel.Name = "selectedLevelLabel";
            this.selectedLevelLabel.Size = new System.Drawing.Size(81, 13);
            this.selectedLevelLabel.TabIndex = 0;
            this.selectedLevelLabel.Text = "Selected Level:";
            // 
            // levelEditorPanel
            // 
            this.levelEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.levelEditorPanel.Controls.Add(this.tabControl1);
            this.levelEditorPanel.Controls.Add(this.maxOffsetBox);
            this.levelEditorPanel.Controls.Add(this.maxoffsetLabel);
            this.levelEditorPanel.Controls.Add(this.offsetSliderLabel);
            this.levelEditorPanel.Controls.Add(this.offsetTrackBar);
            this.levelEditorPanel.Controls.Add(this.acceptButton);
            this.levelEditorPanel.Controls.Add(this.currentPosTextLabel);
            this.levelEditorPanel.Controls.Add(this.backgroundPictureLabel);
            this.levelEditorPanel.Controls.Add(this.backgroundButton);
            this.levelEditorPanel.Controls.Add(this.currentPosLabel);
            this.levelEditorPanel.Controls.Add(this.leveEditorTitleLabel);
            this.levelEditorPanel.Location = new System.Drawing.Point(13, 212);
            this.levelEditorPanel.Name = "levelEditorPanel";
            this.levelEditorPanel.Size = new System.Drawing.Size(314, 406);
            this.levelEditorPanel.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.enemyTab);
            this.tabControl1.Controls.Add(this.itemTab);
            this.tabControl1.Location = new System.Drawing.Point(17, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 257);
            this.tabControl1.TabIndex = 17;
            // 
            // enemyTab
            // 
            this.enemyTab.Controls.Add(this.enemyCountLabel);
            this.enemyTab.Controls.Add(this.enemyCountBox);
            this.enemyTab.Controls.Add(this.enemySpawnButton);
            this.enemyTab.Controls.Add(this.enemyTypeText);
            this.enemyTab.Controls.Add(this.enemyTypeLabel);
            this.enemyTab.Controls.Add(this.enemyWeightBox);
            this.enemyTab.Controls.Add(this.enemyWeightLabel);
            this.enemyTab.Location = new System.Drawing.Point(4, 22);
            this.enemyTab.Name = "enemyTab";
            this.enemyTab.Padding = new System.Windows.Forms.Padding(3);
            this.enemyTab.Size = new System.Drawing.Size(271, 231);
            this.enemyTab.TabIndex = 0;
            this.enemyTab.Text = "Enemies";
            this.enemyTab.UseVisualStyleBackColor = true;
            // 
            // enemyCountLabel
            // 
            this.enemyCountLabel.AutoSize = true;
            this.enemyCountLabel.Location = new System.Drawing.Point(6, 59);
            this.enemyCountLabel.Name = "enemyCountLabel";
            this.enemyCountLabel.Size = new System.Drawing.Size(38, 13);
            this.enemyCountLabel.TabIndex = 43;
            this.enemyCountLabel.Text = "Count:";
            // 
            // enemyCountBox
            // 
            this.enemyCountBox.Location = new System.Drawing.Point(73, 59);
            this.enemyCountBox.Name = "enemyCountBox";
            this.enemyCountBox.Size = new System.Drawing.Size(92, 20);
            this.enemyCountBox.TabIndex = 42;
            this.enemyCountBox.Text = "1";
            // 
            // enemySpawnButton
            // 
            this.enemySpawnButton.Location = new System.Drawing.Point(73, 85);
            this.enemySpawnButton.Name = "enemySpawnButton";
            this.enemySpawnButton.Size = new System.Drawing.Size(92, 23);
            this.enemySpawnButton.TabIndex = 41;
            this.enemySpawnButton.Text = "Spawn";
            this.enemySpawnButton.UseVisualStyleBackColor = true;
            this.enemySpawnButton.Click += new System.EventHandler(this.enemySpawnButton_Click);
            // 
            // enemyTypeText
            // 
            this.enemyTypeText.Location = new System.Drawing.Point(73, 6);
            this.enemyTypeText.Name = "enemyTypeText";
            this.enemyTypeText.Size = new System.Drawing.Size(92, 20);
            this.enemyTypeText.TabIndex = 29;
            this.enemyTypeText.Text = "governator";
            // 
            // enemyTypeLabel
            // 
            this.enemyTypeLabel.AutoSize = true;
            this.enemyTypeLabel.Location = new System.Drawing.Point(6, 9);
            this.enemyTypeLabel.Name = "enemyTypeLabel";
            this.enemyTypeLabel.Size = new System.Drawing.Size(37, 13);
            this.enemyTypeLabel.TabIndex = 29;
            this.enemyTypeLabel.Text = "Type: ";
            // 
            // enemyWeightBox
            // 
            this.enemyWeightBox.Location = new System.Drawing.Point(73, 32);
            this.enemyWeightBox.Name = "enemyWeightBox";
            this.enemyWeightBox.Size = new System.Drawing.Size(92, 20);
            this.enemyWeightBox.TabIndex = 29;
            this.enemyWeightBox.Text = "10";
            // 
            // enemyWeightLabel
            // 
            this.enemyWeightLabel.AutoSize = true;
            this.enemyWeightLabel.Location = new System.Drawing.Point(6, 32);
            this.enemyWeightLabel.Name = "enemyWeightLabel";
            this.enemyWeightLabel.Size = new System.Drawing.Size(44, 13);
            this.enemyWeightLabel.TabIndex = 26;
            this.enemyWeightLabel.Text = "Weight:";
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.itemDepthSlider);
            this.itemTab.Controls.Add(this.itemSpawnButton);
            this.itemTab.Controls.Add(this.itemTextureText);
            this.itemTab.Controls.Add(this.itemSpawnLabel);
            this.itemTab.Controls.Add(this.depthLabel);
            this.itemTab.Controls.Add(this.weightLabel);
            this.itemTab.Controls.Add(this.itemWeightBox);
            this.itemTab.Controls.Add(this.itemRadiusText);
            this.itemTab.Controls.Add(this.itemRadiusLabel);
            this.itemTab.Controls.Add(this.itemImmovableBox);
            this.itemTab.Controls.Add(this.polygonTypeLabel);
            this.itemTab.Controls.Add(this.itemPolygonType);
            this.itemTab.Location = new System.Drawing.Point(4, 22);
            this.itemTab.Name = "itemTab";
            this.itemTab.Padding = new System.Windows.Forms.Padding(3);
            this.itemTab.Size = new System.Drawing.Size(271, 231);
            this.itemTab.TabIndex = 1;
            this.itemTab.Text = "Items";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // itemDepthSlider
            // 
            this.itemDepthSlider.Location = new System.Drawing.Point(142, 128);
            this.itemDepthSlider.Maximum = 4;
            this.itemDepthSlider.Minimum = 1;
            this.itemDepthSlider.Name = "itemDepthSlider";
            this.itemDepthSlider.Size = new System.Drawing.Size(84, 45);
            this.itemDepthSlider.TabIndex = 41;
            this.itemDepthSlider.Value = 1;
            // 
            // itemSpawnButton
            // 
            this.itemSpawnButton.Location = new System.Drawing.Point(142, 186);
            this.itemSpawnButton.Name = "itemSpawnButton";
            this.itemSpawnButton.Size = new System.Drawing.Size(84, 23);
            this.itemSpawnButton.TabIndex = 40;
            this.itemSpawnButton.Text = "Spawn";
            this.itemSpawnButton.UseVisualStyleBackColor = true;
            this.itemSpawnButton.Click += new System.EventHandler(this.itemSpawnButton_Click);
            // 
            // itemTextureText
            // 
            this.itemTextureText.Location = new System.Drawing.Point(142, 48);
            this.itemTextureText.Name = "itemTextureText";
            this.itemTextureText.Size = new System.Drawing.Size(84, 20);
            this.itemTextureText.TabIndex = 39;
            this.itemTextureText.Text = "log";
            // 
            // itemSpawnLabel
            // 
            this.itemSpawnLabel.AutoSize = true;
            this.itemSpawnLabel.Location = new System.Drawing.Point(6, 48);
            this.itemSpawnLabel.Name = "itemSpawnLabel";
            this.itemSpawnLabel.Size = new System.Drawing.Size(69, 13);
            this.itemSpawnLabel.TabIndex = 38;
            this.itemSpawnLabel.Text = "Item Texture:";
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(6, 128);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(64, 13);
            this.depthLabel.TabIndex = 36;
            this.depthLabel.Text = "Start Depth:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(6, 74);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(44, 13);
            this.weightLabel.TabIndex = 34;
            this.weightLabel.Text = "Weight:";
            // 
            // itemWeightBox
            // 
            this.itemWeightBox.Location = new System.Drawing.Point(142, 74);
            this.itemWeightBox.Name = "itemWeightBox";
            this.itemWeightBox.Size = new System.Drawing.Size(84, 20);
            this.itemWeightBox.TabIndex = 33;
            this.itemWeightBox.Text = "10";
            // 
            // itemRadiusText
            // 
            this.itemRadiusText.Location = new System.Drawing.Point(142, 102);
            this.itemRadiusText.Name = "itemRadiusText";
            this.itemRadiusText.Size = new System.Drawing.Size(84, 20);
            this.itemRadiusText.TabIndex = 26;
            this.itemRadiusText.Text = "30";
            // 
            // itemRadiusLabel
            // 
            this.itemRadiusLabel.AutoSize = true;
            this.itemRadiusLabel.Location = new System.Drawing.Point(6, 102);
            this.itemRadiusLabel.Name = "itemRadiusLabel";
            this.itemRadiusLabel.Size = new System.Drawing.Size(127, 13);
            this.itemRadiusLabel.TabIndex = 32;
            this.itemRadiusLabel.Text = "Radius / side length (x,y):";
            // 
            // itemImmovableBox
            // 
            this.itemImmovableBox.AutoSize = true;
            this.itemImmovableBox.Location = new System.Drawing.Point(9, 189);
            this.itemImmovableBox.Name = "itemImmovableBox";
            this.itemImmovableBox.Size = new System.Drawing.Size(77, 17);
            this.itemImmovableBox.TabIndex = 31;
            this.itemImmovableBox.Text = "Immovable";
            this.itemImmovableBox.UseVisualStyleBackColor = true;
            // 
            // polygonTypeLabel
            // 
            this.polygonTypeLabel.AutoSize = true;
            this.polygonTypeLabel.Location = new System.Drawing.Point(6, 18);
            this.polygonTypeLabel.Name = "polygonTypeLabel";
            this.polygonTypeLabel.Size = new System.Drawing.Size(75, 13);
            this.polygonTypeLabel.TabIndex = 30;
            this.polygonTypeLabel.Text = "Polygon Type:";
            // 
            // itemPolygonType
            // 
            this.itemPolygonType.FormattingEnabled = true;
            this.itemPolygonType.Items.AddRange(new object[] {
            "Rectangle",
            "Circle"});
            this.itemPolygonType.Location = new System.Drawing.Point(142, 18);
            this.itemPolygonType.Name = "itemPolygonType";
            this.itemPolygonType.Size = new System.Drawing.Size(84, 21);
            this.itemPolygonType.TabIndex = 29;
            this.itemPolygonType.Text = "Circle";
            this.itemPolygonType.SelectedIndexChanged += new System.EventHandler(this.itemPolygonType_SelectedIndexChanged);
            // 
            // maxOffsetBox
            // 
            this.maxOffsetBox.Location = new System.Drawing.Point(264, 356);
            this.maxOffsetBox.Name = "maxOffsetBox";
            this.maxOffsetBox.Size = new System.Drawing.Size(45, 20);
            this.maxOffsetBox.TabIndex = 16;
            this.maxOffsetBox.Text = "100";
            this.maxOffsetBox.TextChanged += new System.EventHandler(this.maxOffsetBox_TextChanged);
            // 
            // maxoffsetLabel
            // 
            this.maxoffsetLabel.AutoSize = true;
            this.maxoffsetLabel.Location = new System.Drawing.Point(228, 356);
            this.maxoffsetLabel.Name = "maxoffsetLabel";
            this.maxoffsetLabel.Size = new System.Drawing.Size(30, 13);
            this.maxoffsetLabel.TabIndex = 15;
            this.maxoffsetLabel.Text = "Max:";
            // 
            // offsetSliderLabel
            // 
            this.offsetSliderLabel.AutoSize = true;
            this.offsetSliderLabel.Location = new System.Drawing.Point(8, 356);
            this.offsetSliderLabel.Name = "offsetSliderLabel";
            this.offsetSliderLabel.Size = new System.Drawing.Size(38, 13);
            this.offsetSliderLabel.TabIndex = 14;
            this.offsetSliderLabel.Text = "Offset:";
            // 
            // offsetTrackBar
            // 
            this.offsetTrackBar.Location = new System.Drawing.Point(52, 356);
            this.offsetTrackBar.Maximum = 100;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(165, 45);
            this.offsetTrackBar.TabIndex = 13;
            this.offsetTrackBar.TickFrequency = 10;
            this.offsetTrackBar.Scroll += new System.EventHandler(this.offsetTrackBar_Scroll);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(223, 378);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(80, 23);
            this.acceptButton.TabIndex = 11;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // currentPosTextLabel
            // 
            this.currentPosTextLabel.AutoSize = true;
            this.currentPosTextLabel.Location = new System.Drawing.Point(137, 30);
            this.currentPosTextLabel.Name = "currentPosTextLabel";
            this.currentPosTextLabel.Size = new System.Drawing.Size(105, 13);
            this.currentPosTextLabel.TabIndex = 9;
            this.currentPosTextLabel.Text = "currentPosTextLabel";
            // 
            // backgroundPictureLabel
            // 
            this.backgroundPictureLabel.AutoSize = true;
            this.backgroundPictureLabel.Location = new System.Drawing.Point(4, 59);
            this.backgroundPictureLabel.Name = "backgroundPictureLabel";
            this.backgroundPictureLabel.Size = new System.Drawing.Size(68, 13);
            this.backgroundPictureLabel.TabIndex = 5;
            this.backgroundPictureLabel.Text = "Background:";
            // 
            // backgroundButton
            // 
            this.backgroundButton.Location = new System.Drawing.Point(140, 54);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(80, 23);
            this.backgroundButton.TabIndex = 4;
            this.backgroundButton.Text = "Browse...";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // currentPosLabel
            // 
            this.currentPosLabel.AutoSize = true;
            this.currentPosLabel.Location = new System.Drawing.Point(4, 30);
            this.currentPosLabel.Name = "currentPosLabel";
            this.currentPosLabel.Size = new System.Drawing.Size(84, 13);
            this.currentPosLabel.TabIndex = 1;
            this.currentPosLabel.Text = "Current Position:";
            // 
            // leveEditorTitleLabel
            // 
            this.leveEditorTitleLabel.AutoSize = true;
            this.leveEditorTitleLabel.Location = new System.Drawing.Point(4, 4);
            this.leveEditorTitleLabel.Name = "leveEditorTitleLabel";
            this.leveEditorTitleLabel.Size = new System.Drawing.Size(63, 13);
            this.leveEditorTitleLabel.TabIndex = 0;
            this.leveEditorTitleLabel.Text = "Level Editor";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 630);
            this.Controls.Add(this.levelEditorPanel);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newButton);
            this.Name = "Control";
            this.Text = "Control";
            this.mapPanel.ResumeLayout(false);
            this.mapPanel.PerformLayout();
            this.levelEditorPanel.ResumeLayout(false);
            this.levelEditorPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.enemyTab.ResumeLayout(false);
            this.enemyTab.PerformLayout();
            this.itemTab.ResumeLayout(false);
            this.itemTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemDepthSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Label prereqLevelsLabel;
        private System.Windows.Forms.TextBox prereqLevelsBox;
        private System.Windows.Forms.TextBox adjacentLevelsBox;
        private System.Windows.Forms.Label adjacentLevelsLabel;
        private System.Windows.Forms.TextBox levelNameBox;
        private System.Windows.Forms.Label selectedLevelLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locXBox;
        private System.Windows.Forms.TextBox locYBox;
        private System.Windows.Forms.Button updateLevelButton;
        private System.Windows.Forms.Label levelIndexLabel;
        private System.Windows.Forms.TextBox levelIndexBox;
        private System.Windows.Forms.Panel levelEditorPanel;
        private System.Windows.Forms.Label leveEditorTitleLabel;
        private System.Windows.Forms.Label currentPosLabel;
        private System.Windows.Forms.Label backgroundPictureLabel;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Label currentPosTextLabel;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button mapBackgroundButton;
        private System.Windows.Forms.Label mapBackgroundLabel;
        private System.Windows.Forms.TrackBar offsetTrackBar;
        private System.Windows.Forms.Label offsetSliderLabel;
        private System.Windows.Forms.TextBox maxOffsetBox;
        private System.Windows.Forms.Label maxoffsetLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage enemyTab;
        private System.Windows.Forms.TextBox enemyTypeText;
        private System.Windows.Forms.Label enemyTypeLabel;
        private System.Windows.Forms.TextBox enemyWeightBox;
        private System.Windows.Forms.Label enemyWeightLabel;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TrackBar itemDepthSlider;
        private System.Windows.Forms.Button itemSpawnButton;
        private System.Windows.Forms.TextBox itemTextureText;
        private System.Windows.Forms.Label itemSpawnLabel;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.TextBox itemWeightBox;
        private System.Windows.Forms.TextBox itemRadiusText;
        private System.Windows.Forms.Label itemRadiusLabel;
        private System.Windows.Forms.CheckBox itemImmovableBox;
        private System.Windows.Forms.Label polygonTypeLabel;
        private System.Windows.Forms.ComboBox itemPolygonType;
        private System.Windows.Forms.Button enemySpawnButton;
        private System.Windows.Forms.Label enemyCountLabel;
        private System.Windows.Forms.TextBox enemyCountBox;
    }
}