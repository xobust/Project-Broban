using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class CollisionGrid
    {
        public int[][] grid;

        public CollisionGrid()
        {
            GenerateGrid(10,10);
        }

        public struct tile
        {
            Vector2 A;
            Vector2 B;
            Vector2 C;
            Vector2 D;
        }

        public void GenerateGrid(int mapSizeX, int mapSizeY)
        {
            grid = new int[mapSizeX][];
            for (int x = 0; x < mapSizeX; x++)
            {
                grid[x] = new int[mapSizeY];
                for (int y = 0; y < mapSizeY; y++)
                {
                    grid[x][y] = 0;
                }
            }
        }
    }
}
