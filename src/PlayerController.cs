using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project_Broban
{
    class PlayerController
    {
        GameManager GameManager;
        Player player;
        KeyboardState OldState;

        public PlayerController(GameManager gameManager)
        {
            this.GameManager = gameManager;
            player = gameManager.player;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if(state.IsKeyDown(Keys.Space) && OldState.IsKeyUp(Keys.Space))
            {
                Monster[] monsters = GameManager.GameWorld.currentRoom.monsters;

                foreach (Monster monster in monsters)
                {
                    double distToPlayer = monster.Distance(player.Position);
                    if (distToPlayer < player.AttackRange)
                    {
                        player.Attack(monster);
                    }
                }
            }

            OldState = state;
        }
    }
}
