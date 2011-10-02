using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Text;

namespace BountyBanditsWorldEditor
{
    public class Level
    {
        #region Map editor relevant
        public static int totalLevels = 0;
        public int number = -1;
        public string name = "default";
        public List<int> adjacent = new List<int>();
        public List<int> prereq = new List<int>();
        public Vector2 loc = Vector2.Zero;
        #endregion
        #region In game specific
        public string backgroundpath;
        public List<GameItem> items = new List<GameItem>();
        #endregion

    }
}
