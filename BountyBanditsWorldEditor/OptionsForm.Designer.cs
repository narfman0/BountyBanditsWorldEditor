namespace BountyBanditsWorldEditor
{
    partial class OptionsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.applyButton = new System.Windows.Forms.Button();
            this.texturePathTab = new System.Windows.Forms.TabPage();
            this.pathsTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.texturePathTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.texturePathTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(285, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(6, 290);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // texturePathTab
            // 
            this.texturePathTab.Controls.Add(this.pathsTextBox);
            this.texturePathTab.Controls.Add(this.applyButton);
            this.texturePathTab.Location = new System.Drawing.Point(4, 22);
            this.texturePathTab.Name = "texturePathTab";
            this.texturePathTab.Padding = new System.Windows.Forms.Padding(3);
            this.texturePathTab.Size = new System.Drawing.Size(277, 319);
            this.texturePathTab.TabIndex = 0;
            this.texturePathTab.Text = "TexturePaths";
            this.texturePathTab.UseVisualStyleBackColor = true;
            // 
            // pathsTextBox
            // 
            this.pathsTextBox.Location = new System.Drawing.Point(7, 7);
            this.pathsTextBox.Name = "pathsTextBox";
            this.pathsTextBox.Size = new System.Drawing.Size(264, 277);
            this.pathsTextBox.TabIndex = 1;
            this.pathsTextBox.Text = "";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 369);
            this.Controls.Add(this.tabControl1);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.tabControl1.ResumeLayout(false);
            this.texturePathTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage texturePathTab;
        private System.Windows.Forms.RichTextBox pathsTextBox;
        private System.Windows.Forms.Button applyButton;
    }
}