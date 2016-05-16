using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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

        public void Update(GameTime gameTime)
        {
            // The monster list and player position changes so I'm keeping it in the update function
            monsters = gameManager.GameWorld.currentRoom.monsters;
            player = gameManager.player;

            foreach (Monster monster in monsters)
            {
                double distToPlayer = monster.Distance(player.Position);
                if (distToPlayer < monster.range)
                {
                    monster.Attacking(player);
                } else if (distToPlayer < monster.pullRange)
                {
                    monster.Move(player.Position);
                } else
                {
                    monster.Move(monster.startPos);
                }
            }
        }
    }
}