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
            this.polygonTypeLabel = new System.Windows.Forms.Label();
            this.polygonType = new System.Windows.Forms.ComboBox();
            this.immovableBox = new System.Windows.Forms.CheckBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightBox = new System.Windows.Forms.TextBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.widthTrackBar = new System.Windows.Forms.TrackBar();
            this.depthLabel = new System.Windows.Forms.Label();
            this.depthComboBox = new System.Windows.Forms.ComboBox();
            this.maxOffsetBox = new System.Windows.Forms.TextBox();
            this.maxoffsetLabel = new System.Windows.Forms.Label();
            this.offsetSliderLabel = new System.Windows.Forms.Label();
            this.offsetTrackBar = new System.Windows.Forms.TrackBar();
            this.spawnItemButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.currentPosTextLabel = new System.Windows.Forms.Label();
            this.backgroundPictureLabel = new System.Windows.Forms.Label();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.itemTextureLabel = new System.Windows.Forms.Label();
            this.currentPosLabel = new System.Windows.Forms.Label();
            this.leveEditorTitleLabel = new System.Windows.Forms.Label();
            this.itemsDropBox = new System.Windows.Forms.ComboBox();
            this.mapPanel.SuspendLayout();
            this.levelEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackBar)).BeginInit();
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
            this.levelEditorPanel.Controls.Add(this.polygonTypeLabel);
            this.levelEditorPanel.Controls.Add(this.polygonType);
            this.levelEditorPanel.Controls.Add(this.immovableBox);
            this.levelEditorPanel.Controls.Add(this.weightLabel);
            this.levelEditorPanel.Controls.Add(this.weightBox);
            this.levelEditorPanel.Controls.Add(this.radiusLabel);
            this.levelEditorPanel.Controls.Add(this.radiusBox);
            this.levelEditorPanel.Controls.Add(this.widthTrackBar);
            this.levelEditorPanel.Controls.Add(this.depthLabel);
            this.levelEditorPanel.Controls.Add(this.depthComboBox);
            this.levelEditorPanel.Controls.Add(this.maxOffsetBox);
            this.levelEditorPanel.Controls.Add(this.maxoffsetLabel);
            this.levelEditorPanel.Controls.Add(this.offsetSliderLabel);
            this.levelEditorPanel.Controls.Add(this.offsetTrackBar);
            this.levelEditorPanel.Controls.Add(this.spawnItemButton);
            this.levelEditorPanel.Controls.Add(this.acceptButton);
            this.levelEditorPanel.Controls.Add(this.currentPosTextLabel);
            this.levelEditorPanel.Controls.Add(this.backgroundPictureLabel);
            this.levelEditorPanel.Controls.Add(this.backgroundButton);
            this.levelEditorPanel.Controls.Add(this.itemTextureLabel);
            this.levelEditorPanel.Controls.Add(this.itemsDropBox);
            this.levelEditorPanel.Controls.Add(this.currentPosLabel);
            this.levelEditorPanel.Controls.Add(this.leveEditorTitleLabel);
            this.levelEditorPanel.Location = new System.Drawing.Point(13, 212);
            this.levelEditorPanel.Name = "levelEditorPanel";
            this.levelEditorPanel.Size = new System.Drawing.Size(314, 329);
            this.levelEditorPanel.TabIndex = 3;
            // 
            // polygonTypeLabel
            // 
            this.polygonTypeLabel.AutoSize = true;
            this.polygonTypeLabel.Location = new System.Drawing.Point(4, 140);
            this.polygonTypeLabel.Name = "polygonTypeLabel";
            this.polygonTypeLabel.Size = new System.Drawing.Size(75, 13);
            this.polygonTypeLabel.TabIndex = 28;
            this.polygonTypeLabel.Text = "Polygon Type:";
            // 
            // polygonType
            // 
            this.polygonType.FormattingEnabled = true;
            this.polygonType.Items.AddRange(new object[] {
            "Rectangle",
            "Circle"});
            this.polygonType.Location = new System.Drawing.Point(140, 140);
            this.polygonType.Name = "polygonType";
            this.polygonType.Size = new System.Drawing.Size(84, 21);
            this.polygonType.TabIndex = 27;
            // 
            // immovableBox
            // 
            this.immovableBox.AutoSize = true;
            this.immovableBox.Location = new System.Drawing.Point(232, 170);
            this.immovableBox.Name = "immovableBox";
            this.immovableBox.Size = new System.Drawing.Size(77, 17);
            this.immovableBox.TabIndex = 26;
            this.immovableBox.Text = "Immovable";
            this.immovableBox.UseVisualStyleBackColor = true;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(4, 167);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(44, 13);
            this.weightLabel.TabIndex = 25;
            this.weightLabel.Text = "Weight:";
            // 
            // weightBox
            // 
            this.weightBox.Location = new System.Drawing.Point(140, 167);
            this.weightBox.Name = "weightBox";
            this.weightBox.Size = new System.Drawing.Size(84, 20);
            this.weightBox.TabIndex = 24;
            this.weightBox.Text = "10";
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(4, 193);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(127, 13);
            this.radiusLabel.TabIndex = 23;
            this.radiusLabel.Text = "Radius / side length (x,y):";
            // 
            // radiusBox
            // 
            this.radiusBox.Location = new System.Drawing.Point(140, 193);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(84, 20);
            this.radiusBox.TabIndex = 22;
            this.radiusBox.Text = "30";
            // 
            // widthTrackBar
            // 
            this.widthTrackBar.Location = new System.Drawing.Point(230, 113);
            this.widthTrackBar.Maximum = 4;
            this.widthTrackBar.Minimum = 1;
            this.widthTrackBar.Name = "widthTrackBar";
            this.widthTrackBar.Size = new System.Drawing.Size(75, 45);
            this.widthTrackBar.TabIndex = 21;
            this.widthTrackBar.Value = 1;
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(4, 113);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(103, 13);
            this.depthLabel.TabIndex = 18;
            this.depthLabel.Text = "Start Depth / Width:";
            // 
            // depthComboBox
            // 
            this.depthComboBox.FormattingEnabled = true;
            this.depthComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.depthComboBox.Location = new System.Drawing.Point(140, 113);
            this.depthComboBox.Name = "depthComboBox";
            this.depthComboBox.Size = new System.Drawing.Size(84, 21);
            this.depthComboBox.TabIndex = 17;
            this.depthComboBox.Text = "0";
            // 
            // maxOffsetBox
            // 
            this.maxOffsetBox.Location = new System.Drawing.Point(258, 248);
            this.maxOffsetBox.Name = "maxOffsetBox";
            this.maxOffsetBox.Size = new System.Drawing.Size(45, 20);
            this.maxOffsetBox.TabIndex = 16;
            this.maxOffsetBox.Text = "100";
            this.maxOffsetBox.TextChanged += new System.EventHandler(this.maxOffsetBox_TextChanged);
            // 
            // maxoffsetLabel
            // 
            this.maxoffsetLabel.AutoSize = true;
            this.maxoffsetLabel.Location = new System.Drawing.Point(222, 248);
            this.maxoffsetLabel.Name = "maxoffsetLabel";
            this.maxoffsetLabel.Size = new System.Drawing.Size(30, 13);
            this.maxoffsetLabel.TabIndex = 15;
            this.maxoffsetLabel.Text = "Max:";
            // 
            // offsetSliderLabel
            // 
            this.offsetSliderLabel.AutoSize = true;
            this.offsetSliderLabel.Location = new System.Drawing.Point(2, 248);
            this.offsetSliderLabel.Name = "offsetSliderLabel";
            this.offsetSliderLabel.Size = new System.Drawing.Size(38, 13);
            this.offsetSliderLabel.TabIndex = 14;
            this.offsetSliderLabel.Text = "Offset:";
            // 
            // offsetTrackBar
            // 
            this.offsetTrackBar.Location = new System.Drawing.Point(46, 248);
            this.offsetTrackBar.Maximum = 100;
            this.offsetTrackBar.Name = "offsetTrackBar";
            this.offsetTrackBar.Size = new System.Drawing.Size(165, 45);
            this.offsetTrackBar.TabIndex = 13;
            this.offsetTrackBar.TickFrequency = 10;
            this.offsetTrackBar.Scroll += new System.EventHandler(this.offsetTrackBar_Scroll);
            // 
            // spawnItemButton
            // 
            this.spawnItemButton.Location = new System.Drawing.Point(140, 219);
            this.spawnItemButton.Name = "spawnItemButton";
            this.spawnItemButton.Size = new System.Drawing.Size(84, 23);
            this.spawnItemButton.TabIndex = 12;
            this.spawnItemButton.Text = "Spawn Item";
            this.spawnItemButton.UseVisualStyleBackColor = true;
            this.spawnItemButton.Click += new System.EventHandler(this.spawnItemButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(223, 295);
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
            this.currentPosTextLabel.Location = new System.Drawing.Point(137, 59);
            this.currentPosTextLabel.Name = "currentPosTextLabel";
            this.currentPosTextLabel.Size = new System.Drawing.Size(105, 13);
            this.currentPosTextLabel.TabIndex = 9;
            this.currentPosTextLabel.Text = "currentPosTextLabel";
            // 
            // backgroundPictureLabel
            // 
            this.backgroundPictureLabel.AutoSize = true;
            this.backgroundPictureLabel.Location = new System.Drawing.Point(4, 31);
            this.backgroundPictureLabel.Name = "backgroundPictureLabel";
            this.backgroundPictureLabel.Size = new System.Drawing.Size(68, 13);
            this.backgroundPictureLabel.TabIndex = 5;
            this.backgroundPictureLabel.Text = "Background:";
            // 
            // backgroundButton
            // 
            this.backgroundButton.Location = new System.Drawing.Point(140, 26);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(80, 23);
            this.backgroundButton.TabIndex = 4;
            this.backgroundButton.Text = "Browse...";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // itemTextureLabel
            // 
            this.itemTextureLabel.AutoSize = true;
            this.itemTextureLabel.Location = new System.Drawing.Point(4, 86);
            this.itemTextureLabel.Name = "itemTextureLabel";
            this.itemTextureLabel.Size = new System.Drawing.Size(66, 13);
            this.itemTextureLabel.TabIndex = 3;
            this.itemTextureLabel.Text = "Spawn Item:";
            // 
            // currentPosLabel
            // 
            this.currentPosLabel.AutoSize = true;
            this.currentPosLabel.Location = new System.Drawing.Point(4, 59);
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
            // itemsDropBox
            // 
            this.itemsDropBox.FormattingEnabled = true;
            this.itemsDropBox.Items.AddRange(new object[] {
            "enemies",
            "box",
            "circle",
            "log"});
            this.itemsDropBox.Location = new System.Drawing.Point(140, 86);
            this.itemsDropBox.Name = "itemsDropBox";
            this.itemsDropBox.Size = new System.Drawing.Size(165, 21);
            this.itemsDropBox.TabIndex = 2;
            this.itemsDropBox.Text = "box";
            this.itemsDropBox.SelectedIndexChanged += new System.EventHandler(this.itemsDropBox_SelectedIndexChanged);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 554);
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
            ((System.ComponentModel.ISupportInitialize)(this.widthTrackBar)).EndInit();
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
        private System.Windows.Forms.Label itemTextureLabel;
        private System.Windows.Forms.Label currentPosTextLabel;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button spawnItemButton;
        private System.Windows.Forms.Button mapBackgroundButton;
        private System.Windows.Forms.Label mapBackgroundLabel;
        private System.Windows.Forms.TrackBar offsetTrackBar;
        private System.Windows.Forms.Label offsetSliderLabel;
        private System.Windows.Forms.TextBox maxOffsetBox;
        private System.Windows.Forms.Label maxoffsetLabel;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.TrackBar widthTrackBar;
        private System.Windows.Forms.ComboBox depthComboBox;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.TextBox weightBox;
        private System.Windows.Forms.CheckBox immovableBox;
        private System.Windows.Forms.Label polygonTypeLabel;
        private System.Windows.Forms.ComboBox polygonType;
        private System.Windows.Forms.ComboBox itemsDropBox;
    }
}