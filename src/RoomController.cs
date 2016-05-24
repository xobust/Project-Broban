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

        } 
        
    }
}
