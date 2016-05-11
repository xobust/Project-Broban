using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    class Room
    {
        private string[][] map;
        private const int mapSizeX = 12;
        private const int mapSizeY = 29;

        public string[][] Generate()
        {
            map = new string[mapSizeX][];
            for (int x = 0; x < mapSizeX; x++)
            {
                map[x] = new string[mapSizeY];
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x][y] = "Grass";
                }
            }
            return map;
        }
    }
}
