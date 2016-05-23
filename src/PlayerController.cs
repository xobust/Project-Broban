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
        KeyboardState currentState;
        KeyboardState OldState;
        TimeSpan AttackTime;

        public PlayerController(GameManager gameManager)
        {
            this.GameManager = gameManager;
            player = gameManager.player;
        }
        
        public void Update(GameTime gameTime)
        {
            currentState = Keyboard.GetState();

            if(currentState.IsKeyDown(Keys.Space) && OldState.IsKeyUp(Keys.Space) && !player.Attacking)
            {
                player.Attacking = true;
                AttackTime = gameTime.TotalGameTime;
                Monster[] monsters = GameManager.GameWorld.currentRoom.monsters;

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

            OldState = currentState;
        }
    }
}
