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
    public class Room : GameObject
    {
        int XPosition;                      // The x-coordinate of the room in the world map
        int YPosition;                      // The y-coordinate of the room in the world map
        private string[][] map;             // A 2D array of the tiles in the room
        private const int mapSizeX = 12;    // The width of the room
        private const int mapSizeY = 29;    // The height of the room
        public Monster[] monsters;          // An array of all monsters in the room
        private Random rngGenerator;        // Random number generator
        private TextureManager Textures;    // Holds all the sprites
        private TileRenderer Tiles;         // Renders the actual tile sprites

        /// <summary>
        /// Creates an empty room. The room will be filled/generated when 
        /// the player enters it for the first time.
        /// </summary>
        /// <param name="xPosition">The world position of the room.</param>
        /// <param name="yPosition">The world position of the room.</param>
        /// <param name="tm">The TextureManager </param>
        /// <param name="tr">The TileRenderer draws the tile sprites.</param>
        public Room(int xPosition, int yPosition, TextureManager tm, TileRenderer tr)
        {
            Textures = tm;
            monsters = new Monster[30];
            Tiles = tr;
            rngGenerator = new Random();
            
            XPosition = xPosition;
            YPosition = yPosition;
            map = new string[mapSizeX][];

            for (int x = 0; x < mapSizeX; x++)
            {
                map[x] = new string[mapSizeY];
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x][y] = null;
                }
            }
        }

        /// <summary>
        /// Generates the room map.
        /// </summary>
        public void Generate()
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x][y] = "Grass";
                }
            }
            SpawnMonsters();
        }

        /// <summary>
        /// Spawns Monsters in the room in random locations.
        /// </summary>
        public void SpawnMonsters()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i] = new Monster(rngGenerator.Next(0,700),
                                          rngGenerator.Next(0,400), Textures);
            }
        }

        /// <summary>
        /// Updates the state of the gameObject.
        /// Updates all the currently alive monsters in the room.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.alive)
                {
                    monster.Update(gameTime);
                }
            }
        }

        /// <summary>
        /// Renders the Room using the spriteBatch.
        /// </summary>
        /// <param name="sb">The SpriteBatch to draw with.</param>
        public void Draw(SpriteBatch sb)
        {
            Tiles.Draw(sb, map);
            foreach (Monster monster in monsters)
            {
                if (monster.alive)
                {
                    monster.Draw(sb);
                }
            }
        }

        /// <summary>
        /// Loads necessary content of the gameObject.
        /// </summary>
        /// <param name="gd">The GraphicsDevice.</param>
        /// <param name="cm">The ContentManager (contains graphics).</param>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
        }

        /// <summary>
        /// Unloads content from the gameObject.
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}