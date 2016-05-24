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
    /// <summary>
    /// A class for a Room in the world map.
    /// Room types:
    /// 0 = Regular
    /// 1 = Boss
    /// </summary>
    public class Room : GameObject
    {
        int XPosition;                      // The x-coordinate of the room in the world map
        int YPosition;                      // The y-coordinate of the room in the world map
        private string[][] map;             // A 2D array of the tiles in the room
        private const int mapSizeX = 12;    // The width of the room
        private const int mapSizeY = 29;    // The height of the room
        public List<Monster> monsters;      // A list of all monsters in the room
        private Random rngGenerator;        // Random number generator
        private TextureManager Textures;    // Holds all the sprites
        private TileRenderer Tiles;         // Renders the actual tile sprites
        public int RoomType;                // Which type of room

        /// <summary>
        /// Creates an empty room. The room will be filled/generated when 
        /// the player enters it for the first time.
        /// </summary>
        /// <param name="xPosition">The world position of the room.</param>
        /// <param name="yPosition">The world position of the room.</param>
        /// <param name="tm">The TextureManager </param>
        /// <param name="tr">The TileRenderer draws the tile sprites.</param>
        public Room(int xPosition, int yPosition, TextureManager tm, TileRenderer tr, int type)
        {
            Textures = tm;
            monsters = new List<Monster>();
            Tiles = tr;
            rngGenerator = new Random();
            
            XPosition = xPosition;
            YPosition = yPosition;
            map = new string[mapSizeX][];

            RoomType = type;

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
            if (RoomType == 1) // Boss room
            {
                for (int x = 0; x < mapSizeX; x++)
                {
                    for (int y = 0; y < mapSizeY; y++)
                    {
                        map[x][y] = "darkGrass";
                    }
                }

                // Add one boss to `monsters`
                Monster boss = new Monster(700, 600, Textures, "boss", 2, 10);
                monsters.Add(boss);
            }
            else // Regular rooms
            {
                for (int x = 0; x < mapSizeX; x++)
                {
                    for (int y = 0; y < mapSizeY; y++)
                    {
                        map[x][y] = "grass";
                    }
                }
                SpawnMonsters();
            }
        }

        /// <summary>
        /// Spawns Monsters in the room in random locations.
        /// </summary>
        public void SpawnMonsters()
        {
            int monsterAmount = rngGenerator.Next(20, 41);
            for (int i = 0; i < monsterAmount; i++)
            {
                monsters.Add(new Monster(rngGenerator.Next(0,1920), 
                    rngGenerator.Next(0,1080), Textures));
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
            if(RoomType == 1 && !monsters[0].alive)
            {
                // CHANGE THIS ASAP
                GameManager.gameState = GameManager.GameState.WIN;
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