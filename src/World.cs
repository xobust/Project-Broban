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
    class World : GameObject
    {
        int CurrentXPossition;
        int CurrentYPossition;
        Room[][] WorldMap;

        /// <summary>
        /// Creates a world with a given size
        /// </summary>
        /// <param name="size">The size of the world</param>
        /// <param name="startX">The starting possition for the player in axis X</param>
        /// <param name="startY">The starting possition for the player in axis Y</param>
        public World(int size, int startX, int startY)
        {
            WorldMap = new Room[size][];
            for (int i = 0; i < size; i++)
            {
                WorldMap[i] = new Room[size];
            }

            //TODO create a special Room class for the starting room
            WorldMap[startX][startY] = new Room(startX, startY);
            WorldMap[startX][startY].Generate();
            CurrentXPossition = startX;
            CurrentYPossition = startY;
        }

        /// <summary>
        /// This function is executed when the player enters a room
        /// </summary>
        /// <param name="x">X possition for the room</param>
        /// <param name="y">Y possition for the room</param>
        public void EnterRoom(int x, int y)
        {
            if(WorldMap[x][y] == null)
            {
                WorldMap[x][y] = new Room(x, y);
                WorldMap[x][y].Generate();
            }
            CurrentXPossition = x;
            CurrentYPossition = y;
        }

        /// <summary>
        /// Updates the state of the world 
        /// </summary>
        public void Update()
        {
            WorldMap[CurrentXPossition][CurrentYPossition].Update();
        }

        /// <summary>
        /// Renders the world to the screen using the spritebatch
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            WorldMap[CurrentXPossition][CurrentYPossition].Draw(sb);
        }

        /// <summary>
        /// Loads necessary content of the gameobject
        /// </summary>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {

        }

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}