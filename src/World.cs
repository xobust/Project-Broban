﻿using System;
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
        int CurrentXPosition;   // The x-coordinate of the current room in WorldMap
        int CurrentYPosition;   // The y-coordinate of the current room in WorldMap
        Room[][] WorldMap;      // A 2D array of all the rooms
        public Room currentRoom;            // The current room
        private TextureManager Textures;    // Holds all the textures
        private TileRenderer Tiles;         // Renders the tile textures
        public int WorldSize;               // The size of the world
        private Point BossRoom;             // The coordinates of the boss room;

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
            BossRoom = new Point(1, 1);

            //TODO create a special Room class for the starting room
            WorldMap[startX][startY] = new Room(startX, startY, Textures, Tiles, 0);
            CurrentXPosition = startX;
            CurrentYPosition = startY;

            currentRoom = WorldMap[startX][startY];
        }

        /// <summary>
        /// This function is executed when the player enters a room.
        /// </summary>
        /// <param name="x">X position for the room.</param>
        /// <param name="y">Y position for the room.</param>
        public void EnterRoom(int x, int y)
        {
            if(WorldMap[x][y] == null)
            {
                int RoomType;
                if(x == BossRoom.X && y == BossRoom.Y)
                {
                    RoomType = 1;
                }
                else
                {
                    RoomType = 0;
                }
                WorldMap[x][y] = new Room(x, y, Textures, Tiles, RoomType);
                WorldMap[x][y].Generate();
            }
            CurrentXPosition = x;
            CurrentYPosition = y;
            currentRoom = WorldMap[CurrentXPosition][CurrentYPosition];
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
            currentRoom.Generate();
        }

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}
