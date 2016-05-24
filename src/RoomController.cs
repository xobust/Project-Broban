using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class RoomController : Controller
    {
        private GameManager GameManager;

        public RoomController(GameManager gameManager)
        {
            GameManager = gameManager;
            EnterRoom(GameManager.GameWorld.CurrentXPosition, 
                      GameManager.GameWorld.CurrentYPosition);
        }

        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// This function is executed when the player enters a room.
        /// </summary>
        /// <param name="x">X position for the room.</param>
        /// <param name="y">Y position for the room.</param>
        public void EnterRoom(int x, int y)
        {
            World world = GameManager.GameWorld;
            if (world.WorldMap[x][y] == null)
            {
                world.WorldMap[x][y] = new Room(x, y, world.Textures, world.Tiles);
                world.WorldMap[x][y].Generate();
            }
            world.CurrentXPosition = x;
            world.CurrentYPosition = y;
            world.currentRoom.Generate();
            world.currentRoom = world.WorldMap[world.CurrentXPosition][world.CurrentYPosition];

            GameManager.collisionController.GenerateCollisionMap();
        }
    }
}
