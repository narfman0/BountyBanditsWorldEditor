using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BountyBanditsWorldEditor
{
    public partial class OptionsForm : Form
    {
        private Game1 gameref;
        public OptionsForm(Game1 gameref)
        {
            this.gameref = gameref;
            InitializeComponent();
            foreach (String textureDir in gameref.getOptions().getTextureDirectories())
                pathsTextBox.Text += textureDir + ",";
            if (gameref.getOptions().getTextureDirectories().Count > 0)
                pathsTextBox.Text = pathsTextBox.Text.Substring(0,pathsTextBox.Text.Length - 1);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            List<String> paths = null;
            if (pathsTextBox.Text.Contains(','))
                paths = new List<string>(pathsTextBox.Text.Split(','));
            else
                paths = new List<string>(new String[]{pathsTextBox.Text});
            if(!pathsTextBox.Text.Trim().Equals(""))
                gameref.getOptions().setTextureDirectories(paths);
        }
    }
}
