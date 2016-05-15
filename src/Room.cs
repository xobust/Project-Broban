using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    public class Room : GameObject
    {
        int XPosition;
        int YPosition;
        private string[][] map;
        private const int mapSizeX = 12;
        private const int mapSizeY = 29;
        public Monster[] monsters;
        private Random rngGenerator;

        public Room(int xPosition, int yPosition)
        {
            monsters = new Monster[10];
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

            SpawnMonsters();
        }

        /// <summary>
        /// Generates the room map
        /// </summary>
        /// <returns></returns>
        public void Generate()
        {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x][y] = "Grass";
                }
            }
        }

        public void SpawnMonsters()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                monsters[i] = new Monster(rngGenerator.Next(0,700),
                                          rngGenerator.Next(0,400));
            }
        }
           /// <summary>
           /// Updates the state of the gameobject
           /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Renders the gameobject to the screen using the spritebatch
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            TileRenderer.Instance.Draw(sb, map);
            foreach (Monster monster in monsters)
            {
                monster.Draw(sb);
            }
        }

        /// <summary>
        /// Loads necessary content of the gameobject
        /// </summary>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            foreach (Monster monster in monsters)
            {
                monster.LoadContent(gd, cm);
            }
        }

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}