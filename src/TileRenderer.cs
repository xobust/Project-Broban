using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban_win.src
{
    class TileRenderer
    {
        private Texture2D tileSet;  // The sprite sheet for the tiles
        private const int tileSize = 32;
        private const int tileOffset = tileSize/2; // The position offset when placing diagonal tiles

        public void Draw(SpriteBatch sb, string[][] map)
        {
            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    if (y % 2 == 0) // Even numbered tiles
                    {

                    }
                    else
                    {

                    }
                }
            }
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            //Temporary test texture
             tileSet = cm.Load<Texture2D>("tileSet");
        }

        public void UnloadContent()
        {
        }
    }
}
