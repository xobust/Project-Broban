﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class CollisionController : Controller
    {
        public int[][] grid;
        private CollisionTile currentTile;

        public CollisionController()
        {
            currentTile = new CollisionTile(2);
            GenerateGrid(10,10);
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

        public void Update(GameTime gameTime)
        {

        }

    }
}
