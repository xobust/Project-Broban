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
        KeyboardState CurrentState; // The current pressed down key
        KeyboardState OldState;     // The previous keyboard state
        TimeSpan AttackTime;

        public PlayerController(GameManager gameManager)
        {
            this.GameManager = gameManager;
            player = gameManager.player;
        }

        /// <summary>
        /// Checks if the player presses the Space bar, then checks if any monsters are in range.
        /// Those monsters then take damage.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            CurrentState = Keyboard.GetState();

            if(CurrentState.IsKeyDown(Keys.Space) && OldState.IsKeyUp(Keys.Space) && !player.Attacking)
            {
                player.Attacking = true;
                AttackTime = gameTime.TotalGameTime;

                // An array of all monsters in the current room.
                List<Monster> monsters = GameManager.GameWorld.currentRoom.Monsters;

                foreach (Monster monster in monsters)
                {
                    double distToPlayer = monster.Distance(player.Position);
                    if (distToPlayer < player.AttackRange)
                    {
                    switch (player.PlayerDirection)
                    {
                        case Direction.Down:
                            if (monster.position.Y > player.Position.Y)
                                player.Attack(monster);
                            break;
                        case Direction.Up:
                            if (monster.position.Y < player.Position.Y)
                                player.Attack(monster);
                            break;
                        case Direction.Right:
                            if (monster.position.X > player.Position.X)
                                player.Attack(monster);
                            break;
                        case Direction.Left:
                            if (monster.position.X < player.Position.X)
                                player.Attack(monster);
                            break;
                    }
                    }
                }
            }

            if (player.Attacking)
            {
                if (gameTime.TotalGameTime - AttackTime > player.AttackTime)
                {
                    player.Attacking = false;
                }
            }

            OldState = CurrentState;
        }
    }
}
