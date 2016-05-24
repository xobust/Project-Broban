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
        private string[][] Map;             // A 2D array of the tiles in the room
        private const int MapSizeX = 12;    // The width of the room
        private const int MapSizeY = 29;    // The height of the room
        public Monster[] Monsters;          // An array of all monsters in the room
        public List<Entity> Entitys;        // A list of entitys in the room
        private Random RngGenerator;        // Random number generator
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
            Entitys = new List<Entity>();
            Textures = tm;
            Monsters = new Monster[30];
            Tiles = tr;
            RngGenerator = new Random();
            
            XPosition = xPosition;
            YPosition = yPosition;
            Map = new string[MapSizeX][];

            for (int x = 0; x < MapSizeX; x++)
            {
                Map[x] = new string[MapSizeY];
                for (int y = 0; y < MapSizeY; y++)
                {
                    Map[x][y] = null;
                }
            }
        }

        /// <summary>
        /// Generates the room map.
        /// </summary>
        public void Generate()
        {
            for (int x = 0; x < MapSizeX; x++)
            {
                for (int y = 0; y < MapSizeY; y++)
                {
                    Map[x][y] = "Grass";
                }
            }
            SpawnMonsters();
            GenerateEntitys(5);
        }

        public void GenerateEntitys(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Entitys.Add(new Entity(new Vector2(5,i)));
            }
        }

        /// <summary>
        /// Spawns Monsters in the room in random locations.
        /// </summary>
        public void SpawnMonsters()
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                Monsters[i] = new Monster(RngGenerator.Next(0,700),
                                          RngGenerator.Next(0,400), Textures);
            }
        }

        /// <summary>
        /// Updates the state of the gameObject.
        /// Updates all the currently alive monsters in the room.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            foreach (Monster monster in Monsters)
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
            Tiles.Draw(sb, Map);
            foreach (Monster monster in Monsters)
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