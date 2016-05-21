using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class CollisionTile
    {
        public Vector2 A, B, C, D;
        private int TileHeight;
        private int TileWidth;
        private const int SqrtSize = 2; // SqrtSize = n, n root of the original tile size
        private float TileRatio;

        public CollisionTile()
        {
            TileWidth = 256;
            TileHeight = 128;
            TileRatio = TileHeight / TileWidth;
        }

        /// <summary>
        /// Calculate the current position of each node in
        /// each and every corner of the tile.
        /// </summary>
        /// <param name="tilePos"></param>
        public void CalculateTilePos(Vector2 tilePos)
        {
            // (the top node)
            A = new Vector2(tilePos.X + TileHeight, tilePos.Y);

            // 135 degrees means 45 degrees to the left (the left node)
            B = new Vector2(tilePos.X + (float)(TileHeight * Math.Cos(DegToRad(135))),
                            tilePos.Y + (float)(TileHeight * Math.Sin(DegToRad(135))));

            // 45 degrees to the right (the right node)
            C = new Vector2(tilePos.X + (float)(TileHeight * Math.Cos(DegToRad(45))),
                            tilePos.Y + (float)(TileHeight * Math.Sin(DegToRad(45))));

            // (the bottom node)
            D = new Vector2(tilePos.X, tilePos.Y + TileHeight);
            
            // Calculating new positions because of the tile scaling
            Vector2 NewB = new Vector2(A.X - Distance(B.X, A.X) / SqrtSize, 
                                       A.Y + (Distance(B.Y, A.Y) / TileRatio) / SqrtSize);

            Vector2 NewC = new Vector2(A.X + Distance(C.X, A.X) / SqrtSize,
                                       A.Y + (Distance(C.Y, A.Y) / TileRatio) / SqrtSize);

            Vector2 NewD = new Vector2(A.X + Distance(D.X, A.X) / SqrtSize,
                                       A.Y + (Distance(D.Y, A.Y) / TileRatio) / SqrtSize);
        }

        /// <summary>
        /// Calculate degrees to radians.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private double DegToRad(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private float Distance(double posA, double posB)
        {
            return (float)Math.Abs(posA - posB);
        }
    }
}
