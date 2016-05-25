using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    public class World : GameObject
    {
        public int CurrentXPosition;   // The x-coordinate of the current room in WorldMap
        public int CurrentYPosition;   // The y-coordinate of the current room in WorldMap
        public Room[][] WorldMap;      // A 2D array of all the rooms
        public Room currentRoom;    // The current room
        public TextureManager Textures;    // Holds all the textures
        public TileRenderer Tiles;         // Renders the tile textures
        public int WorldSize;               // The size of the world

        /// <summary>
        /// Creates a world with a given size.
        /// </summary>
        /// <param name="size">The size of the world.</param>
        /// <param name="startX">The starting position for the player in axis X.</param>
        /// <param name="startY">The starting position for the player in axis Y.</param>
        public World(int size, int startX, int startY)
        {
            Textures = new TextureManager();
            Tiles = new TileRenderer();
            WorldSize = size;
            WorldMap = new Room[size][];
            for (int i = 0; i < size; i++)
            {
                WorldMap[i] = new Room[size];
            }

            //TODO create a special Room class for the starting room
            WorldMap[startX][startY] = new Room(startX, startY, Textures, Tiles);
            CurrentXPosition = startX;
            CurrentYPosition = startY;

            currentRoom = WorldMap[startX][startY];
        }

        /// <summary>
        /// Updates the state of the world. 
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            currentRoom.Update(gameTime);
        }

        /// <summary>
        /// Renders the world to the screen using the spritebatch.
        /// </summary>
        /// <param name="sb">The spriteBatch to draw with.</param>
        public void Draw(SpriteBatch sb)
        {
            currentRoom.Draw(sb);
        }

        /// <summary>
        /// Loads necessary content of the gameobject
        /// </summary>
        /// <param name="cm">The ContentManager (contains graphics).</param>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            // We should make it so this runs every time a new room is entered.
            // Maybe make a singleton for all textures?
            currentRoom.LoadContent(gd, cm);
            Textures.LoadContent(cm);
            Tiles.LoadContent(gd, cm);
        }

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}
