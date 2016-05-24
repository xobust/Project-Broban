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
        Player player;
        World world;

        public RoomController(GameManager gameManager)
        {
            this.player = gameManager.player;
            this.world = gameManager.GameWorld;
        }

        /// <summary>
        /// Checks player position and moves him to a new room
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            int xpos = world.CurrentXPosition;
            int ypos = world.CurrentYPosition;
            if (player.Position.X > 1920)
            {
                world.EnterRoom(xpos-1, ypos, player);
            }
            else if (player.Position.X < 0)
            {
                world.EnterRoom(xpos+1, ypos, player);
            }
            else if (player.Position.Y > 1080)
            {
                world.EnterRoom(xpos, ypos-1, player);
            }
            else if (player.Position.Y < 0)
            {
                world.EnterRoom(xpos, ypos+1, player);
            }

        } 
        
    }
}
