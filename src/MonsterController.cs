using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Broban
{
    class MonsterController : Controller
    {
        GameManager gameManager;
        Monster[] monsters;
        Player player;

        public MonsterController(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Update()
        {
            // The monster list and player position changes so I'm keeping it in the update function
            monsters = gameManager.GameWorld.currentRoom.monsters;
            player = gameManager.player;

            foreach (Monster monster in monsters)
            {
                monster.Move(player.Position.X, player.Position.Y);
            }
        }
    }
}
