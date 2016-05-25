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
        Player Player;
        World World;
        private GameManager GameManager;
        private Point BossRoom;

        public RoomController(GameManager gameManager)
        {
            this.Player = gameManager.player;
            this.World = gameManager.GameWorld;
            GameManager = gameManager;
            EnterRoom(GameManager.GameWorld.CurrentXPosition,
                      GameManager.GameWorld.CurrentYPosition);

            BossRoom = new Point(1, 1);
        }

        /// <summary>
        /// Checks player position and moves him to a new room
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            int xpos = World.CurrentXPosition;
            int ypos = World.CurrentYPosition;
            if (Player.Position.X > 1920)
            {
                EnterRoom(xpos-1, ypos);
            }
            else if (Player.Position.X < 0)
            {
                EnterRoom(xpos+1, ypos);
            }
            else if (Player.Position.Y > 1080)
            {
                EnterRoom(xpos, ypos-1);
            }
            else if (Player.Position.Y < 0)
            {
                EnterRoom(xpos, ypos+1);
            }

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
                if (x == BossRoom.X && y == BossRoom.Y)
                {
                    world.currentRoom.RoomType = 1;
                }
                else
                {
                    world.currentRoom.RoomType = 0;
                }
                world.WorldMap[x][y] = new Room(x, y, world.Textures, world.Tiles);
                world.WorldMap[x][y].Generate();
            }
            world.CurrentXPosition = x;
            world.CurrentYPosition = y;
            world.currentRoom.Generate();
            world.currentRoom = world.WorldMap[world.CurrentXPosition][world.CurrentYPosition];

            GameManager.player.TileStartPos = new Vector2(10,10);

            GameManager.collisionController.GenerateCollisionMap();
        }
    }
}
