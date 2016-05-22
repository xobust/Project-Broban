using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class CollisionController : Controller
    {
        public int[][] grid;
        private CollisionTile currentTile;
        GameManager gameManager;

        public CollisionController(GameManager gameManager)
        {
            currentTile = new CollisionTile(2);
            GenerateGrid(10,10);
            this.gameManager = gameManager;
        }

        public void GenerateGrid(int mapSizeX, int mapSizeY)
        {
            grid = new int[mapSizeX][];
            for (int x = 0; x < mapSizeX; x++)
            {
                grid[x] = new int[mapSizeY];
                for (int y = 0; y < mapSizeY; y++)
                {
                    grid[x][y] = 0;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Player player = gameManager.player;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (player.MovingUp)
            {
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {
                } else
                {
                    player.Position.Y -= player.MoveSpeed * deltaTime;
                }
                player.PlayerDirection = Direction.Up;
                player.MovingUp = false;
            }
            if (player.MovingLeft)
            {
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {

                }
                else
                {
                    player.Position.X -= player.MoveSpeed * deltaTime;
                }
                player.PlayerDirection = Direction.Left;
                player.MovingLeft = false;
            }
            if (player.MovingDown)
            {
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {

                }
                else
                {
                    player.Position.Y += player.MoveSpeed * deltaTime;
                }
                player.PlayerDirection = Direction.Down;
                player.MovingDown = false;
            }
            if (player.MovingRight)
            {
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {

                }
                else
                {
                    player.Position.X += player.MoveSpeed * deltaTime;
                }
                player.PlayerDirection = Direction.Right;
                player.MovingRight = false;
            }
        }

        private Boolean IsColliding(Player player, CollisionTile collisionTile)
        {
            return false;
        }

    }
}
