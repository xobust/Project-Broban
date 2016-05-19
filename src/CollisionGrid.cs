using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Broban
{
    class CollisionGrid
    {
        public int[][] map;

        public void GenerateGrid(int mapSizeX, int mapSizeY)
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x][y] = 0;
                }
            }
        }
    }
}
