using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BountyBanditsWorldEditor
{
    public class GameItem
    {
        public enum PhysicsPolygonType
        {
            Rectangle, Circle, Polygon
        }

        public string name = "default";
        public uint weight = 1;
        public string radius = "10";
        public string startdepth = "0";
        public uint width = 1;
        public Vector2 loc = Vector2.Zero, sideLengths;
        public bool immovable = false;
        public PhysicsPolygonType polygonType;
    }
}
