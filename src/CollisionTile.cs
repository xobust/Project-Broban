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
        public int TileHeight;
        public int TileWidth;
        public int type;
        private int SqrtSize = 2; // SqrtSize = n, n root of the original tile size

        public CollisionTile(int squareSize)
        {
            SqrtSize = squareSize;
            TileWidth = 256;
            TileHeight = 128;
        }

        /// <summary>
        /// Calculate the current position of each node in
        /// each and every corner of the tile.
        /// </summary>
        /// <param name="tilePos"></param>
        public void CalculateTilePos(Vector2 tilePos, int type)
        {
            this.type = type;

            // top node
            A = new Vector2(tilePos.X + TileWidth / 2, tilePos.Y);
            
            // left node
            B = new Vector2(A.X - (TileWidth / 2) / SqrtSize,
                            A.Y + (TileHeight / 2) / SqrtSize);

            // right node
            C = new Vector2(A.X + (TileWidth / 2) / SqrtSize,
                            A.Y + (TileHeight / 2) / SqrtSize);

            // bottom node
            D = new Vector2(A.X, A.Y + TileHeight / SqrtSize);
        }
    }
}
