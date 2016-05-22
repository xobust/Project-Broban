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
        private float tileArea;
        private CollisionTile currentTile;
        GameManager gameManager;

        public CollisionController(GameManager gameManager)
        {
            currentTile = new CollisionTile(2);
            currentTile.CalculateTilePos(new Vector2(200, 200));
            GenerateGrid(10,10);
            this.gameManager = gameManager;
            tileArea = CalculateArea(currentTile.A, currentTile.B, currentTile.D, currentTile.C);
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
            float moveDistance = player.MoveSpeed * deltaTime;

            if (player.MovingUp)
            {
                player.NextPos = new Vector2(player.Position.X,
                                             player.Position.Y - moveDistance);
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {
                    // Implement collision positioning (pixel perfect collision)
                    // As of now, the player just stops if it's colliding and can't
                    // move in the direction it's facing.
                }
                else
                {
                    player.Position.Y -= moveDistance;
                }
                player.PlayerDirection = Direction.Up;
                player.MovingUp = false;
            }
            if (player.MovingLeft)
            {
                player.NextPos = new Vector2(player.Position.X - moveDistance,
                                             player.Position.Y);
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {
                    // Implement collision positioning (pixel perfect collision)
                    // As of now, the player just stops if it's colliding and can't
                    // move in the direction it's facing.
                }
                else
                {
                    player.Position.X -= moveDistance;
                }
                player.PlayerDirection = Direction.Left;
                player.MovingLeft = false;
            }
            if (player.MovingDown)
            {
                player.NextPos = new Vector2(player.Position.X,
                                             player.Position.Y + moveDistance);
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {
                    // Implement collision positioning (pixel perfect collision)
                    // As of now, the player just stops if it's colliding and can't
                    // move in the direction it's facing.
                }
                else
                {
                    player.Position.Y += moveDistance;
                }
                player.PlayerDirection = Direction.Down;
                player.MovingDown = false;
            }
            if (player.MovingRight)
            {
                player.NextPos = new Vector2(player.Position.X + moveDistance,
                                             player.Position.Y);
                // Implement loop of every tile to check
                if (IsColliding(player, currentTile))
                {
                    // Implement collision positioning (pixel perfect collision)
                    // As of now, the player just stops if it's colliding and can't
                    // move in the direction it's facing.
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
            if ((CalculateArea(player.NextPos, collisionTile.A, collisionTile.D)+
                 CalculateArea(player.NextPos, collisionTile.D, collisionTile.C)+
                 CalculateArea(player.NextPos, collisionTile.C, collisionTile.B)+
                 CalculateArea(player.NextPos, collisionTile.B, collisionTile.A)) < tileArea)
            {
                return true;
            }
            return false;
        }

        private float CalculateArea(Vector2 a, Vector2 b, Vector2 c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2);
        }

        private float CalculateArea(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
            return Math.Abs (((a.X * b.Y - a.Y * b.X) +
                              (b.X * c.Y - b.Y * c.X) + 
                              (c.X * d.Y - c.Y * d.X) +
                              (d.X * a.Y - d.Y * a.X))/2);
        }
    }
}
