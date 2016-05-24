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
    public class TileRenderer
    {
        private Texture2D tileSet;                  // The sprite sheet for the tiles
        private const int tileWidth = 256;           // The width of one tile
        private const int tileHeight = 128;          // The height of one tile
        private const int tileOffset = tileWidth/2; // The position offset when placing diagonal tiles
        private const int gridOffset = 256;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            //Temporary test texture
            tileSet = cm.Load<Texture2D>("tileSet");
        }

        /// <summary>
        /// Takes in a 2D array and draws the map.
        /// </summary>
        /// <param name="sb">The SpriteBatch, passed in from the main Draw method.</param>
        /// <param name="map">The 2D array that represents the game map.</param>
        public void Draw(SpriteBatch sb, string[][] map)
        {
            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    if (y % 2 == 0) // Even numbered tiles
                    {
                        DrawTile(sb, x * tileWidth - gridOffset, 
                                     y * tileHeight/2 - gridOffset, map[x][y]);
                    }
                    else
                    {
                        DrawTile(sb, x * tileWidth + tileOffset - gridOffset, 
                                     y * tileHeight/2 - gridOffset, map[x][y]);
                    }
                }
            }
        }

        /// <summary>
        /// Draws one tile at the specified position and the specified type.
        /// </summary>
        /// <param name="sb">The SpriteBatch.</param>
        /// <param name="xPos">The x-coordinate of the tile.</param>
        /// <param name="yPos">The y-coordinate of the tile.</param>
        /// <param name="tileType">A string that represents the tile type.</param>
        private void DrawTile(SpriteBatch sb, int xPos, int yPos, string tileType)
        {
            if (tileType == "0") return; // Empty tile

            Rectangle destination = new Rectangle(xPos, yPos, tileWidth, tileHeight);
            Rectangle tileSource = new Rectangle(0, 0, tileWidth, tileHeight);

            switch (tileType)
            {
                case "grass":
                    tileSource = new Rectangle(0, 0, tileWidth, tileHeight);
                    break;
                case "darkGrass":
                    tileSource = new Rectangle(tileWidth, 0, tileWidth, tileHeight);
                    break;
                default:
                    tileSource = new Rectangle(0, 0, tileWidth, tileHeight);
                    break;
            }

            sb.Draw(tileSet, destination, tileSource, Color.White, 0, new Vector2(0, 0),
                    SpriteEffects.None, 0);
        }

        /// <summary>
        /// Unloads content from the gameObject.
        /// </summary>
        public void UnloadContent()
        {
        }
    }
}
