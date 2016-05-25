using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    /// <summary>
    /// Handles things that relate to the monster, but that also relate to objects
    /// that the monster class doesn't have access to.
    /// </summary>
    class MonsterController : Controller
    {
        GameManager gameManager;
        Monster[] monsters;
        Player player;
        
        public MonsterController(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        /// <summary>
        /// Handles when to attack the player and makes the monster move
        /// towards the player if the player is in range.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values</param>
        public void Update(GameTime gameTime)
        {
            // The monster list and player position changes so I'm keeping it in the update function
            monsters = gameManager.GameWorld.currentRoom.Monsters;
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