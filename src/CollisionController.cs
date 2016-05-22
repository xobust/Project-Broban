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
        public Tuple<Vector2, int>[][] Grid;
        private Tuple<Vector2, int, Vector2>[] SurroundingTiles;

        Tuple<Vector2, int> up;
        Tuple<Vector2, int> upLeft;
        Tuple<Vector2, int> upRight;
        Tuple<Vector2, int> left;
        Tuple<Vector2, int> right;
        Tuple<Vector2, int> downLeft;
        Tuple<Vector2, int> downRight;
        Tuple<Vector2, int> down;

        private Vector2 MoveVector;
        private Vector2 CenterTileIndex;
        private float TileArea;
        private Boolean Collided;
        private int SqrtSize = 2;
        private CollisionTile CurrentTile;
        GameManager GameManager;

        public CollisionController(GameManager gameManager)
        {
            MoveVector = Vector2.Zero;
            CurrentTile = new CollisionTile(SqrtSize);
            CurrentTile.CalculateTilePos(Vector2.Zero, 0);
            SurroundingTiles = new Tuple<Vector2, int, Vector2>[8];

            GenerateGrid(gameManager.GameWorld.WorldSize * 4,
                         gameManager.GameWorld.WorldSize * 4);
            this.GameManager = gameManager;

            TileArea = CalculateArea(CurrentTile.A, 
                                     CurrentTile.B, 
                                     CurrentTile.D, 
                                     CurrentTile.C);

            Grid[20][20] = new Tuple<Vector2, int>(Grid[5][5].Item1, 1);

            CenterTileIndex = new Vector2(5, 5);
            CalcSurrTiles();
        }

        public void GenerateGrid(int gridSizeX, int gridSizeY)
        {
            Grid = new Tuple<Vector2, int>[gridSizeX][];
            for (int x = 0; x < gridSizeX; x++)
            {
                Grid[x] = new Tuple<Vector2, int>[gridSizeY];
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (y % 2 == 0) // Even numbered tiles
                    {
                        Grid[x][y] = new Tuple<Vector2, int>
                                    (new Vector2((CurrentTile.TileWidth / SqrtSize) * x, 
                                                 (CurrentTile.TileHeight / SqrtSize) * y), 1);
                    }
                    else
                    {
                        Grid[x][y] = new Tuple<Vector2, int>
                                    (new Vector2((CurrentTile.TileWidth / SqrtSize) * x + 
                                                  CurrentTile.TileWidth / (SqrtSize/2), // the offset
                                                 (CurrentTile.TileHeight / SqrtSize) * y), 1);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Player player = GameManager.player;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float moveDistance = player.MoveSpeed * deltaTime;
            
            if (player.MovingUp)
            {
                player.NextPos = new Vector2(player.Position.X,
                                             player.Position.Y - moveDistance);
                // Implement loop of every tile to check
                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    CurrentTile.CalculateTilePos(SurroundingTiles[i].Item1, 
                                                 SurroundingTiles[i].Item2);
                    
                    if (IsColliding(player, CurrentTile))
                    {
                        if (SurroundingTiles[i].Item2 == 0)
                        {
                            CenterTileIndex = SurroundingTiles[i].Item3;
                        } 
                        else if (SurroundingTiles[i].Item2 == 1)
                        {
                            Collided = true;
                        }
                    }
                }
                if (!Collided)
                {
                    MoveVector = new Vector2(MoveVector.X, MoveVector.Y - moveDistance);
                }
                player.PlayerDirection = Direction.Up;
                player.MovingUp = false;
                Collided = false;
            }

            if (player.MovingLeft)
            {
                player.NextPos = new Vector2(player.Position.X - moveDistance,
                                             player.Position.Y);
                // Implement loop of every tile to check
                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    CurrentTile.CalculateTilePos(SurroundingTiles[i].Item1,
                                                 SurroundingTiles[i].Item2);

                    if (IsColliding(player, CurrentTile))
                    {
                        if (SurroundingTiles[i].Item2 == 0)
                        {
                            CenterTileIndex = SurroundingTiles[i].Item3;
                        }
                        else if (SurroundingTiles[i].Item2 == 1)
                        {
                            Collided = true;
                        }
                    }
                }
                if (!Collided)
                {
                    MoveVector = new Vector2(MoveVector.X - moveDistance, MoveVector.Y);
                }
                player.PlayerDirection = Direction.Left;
                player.MovingLeft = false;
                Collided = false;
            }

            if (player.MovingDown)
            {
                player.NextPos = new Vector2(player.Position.X,
                                             player.Position.Y + moveDistance);
                // Implement loop of every tile to check
                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    CurrentTile.CalculateTilePos(SurroundingTiles[i].Item1,
                                                 SurroundingTiles[i].Item2);

                    if (IsColliding(player, CurrentTile))
                    {
                        if (SurroundingTiles[i].Item2 == 0)
                        {
                            CenterTileIndex = SurroundingTiles[i].Item3;
                        }
                        else if (SurroundingTiles[i].Item2 == 1)
                        {
                            Collided = true;
                        }
                    }
                }
                if (!Collided)
                { 
                    MoveVector = new Vector2(MoveVector.X, MoveVector.Y + moveDistance);
                }
                player.PlayerDirection = Direction.Down;
                player.MovingDown = false;
                Collided = false;
            }

            if (player.MovingRight)
            {
                player.NextPos = new Vector2(player.Position.X + moveDistance,
                                             player.Position.Y);
                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    CurrentTile.CalculateTilePos(SurroundingTiles[i].Item1,
                                                 SurroundingTiles[i].Item2);

                    if (IsColliding(player, CurrentTile))
                    {
                        if (SurroundingTiles[i].Item2 == 0)
                        {
                            CenterTileIndex = SurroundingTiles[i].Item3;
                        }
                        else if (SurroundingTiles[i].Item2 == 1)
                        {
                            Collided = true;
                        }
                    }
                }
                if (!Collided)
                { 
                    MoveVector = new Vector2(MoveVector.X + moveDistance, MoveVector.Y);
                }
                player.PlayerDirection = Direction.Right;
                player.MovingRight = false;
                Collided = false;
            }

            player.Position = new Vector2(player.Position.X + MoveVector.X, 
                                          player.Position.Y + MoveVector.Y);
            MoveVector = Vector2.Zero;
        }

        private Boolean IsColliding(Player player, CollisionTile collisionTile)
        {
            if ((CalculateArea(player.NextPos, collisionTile.A, collisionTile.D)+
                 CalculateArea(player.NextPos, collisionTile.D, collisionTile.C)+
                 CalculateArea(player.NextPos, collisionTile.C, collisionTile.B)+
                 CalculateArea(player.NextPos, collisionTile.B, collisionTile.A)) < TileArea)
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

        private void CalcSurrTiles()
        {
            // http://bit.ly/1TsUSgX - explanation of the indexes below
            // Top to bottom - Left to right following to the image above:

            up = Grid[(int)CenterTileIndex.X][(int)CenterTileIndex.Y - 2];
            upLeft = Grid[(int)CenterTileIndex.X][(int)CenterTileIndex.Y - 1];
            upRight = Grid[(int)CenterTileIndex.X + 1][(int)CenterTileIndex.Y - 1];
            left = Grid[(int)CenterTileIndex.X - 1][(int)CenterTileIndex.Y];
            right = Grid[(int)CenterTileIndex.X + 1][(int)CenterTileIndex.Y];
            downLeft = Grid[(int)CenterTileIndex.X][(int)CenterTileIndex.Y + 1];
            downRight = Grid[(int)CenterTileIndex.X + 1][(int)CenterTileIndex.Y + 1];
            down = Grid[(int)CenterTileIndex.X][(int)CenterTileIndex.Y + 2];

            if (up != null)
            {
                SurroundingTiles[0] = new Tuple<Vector2, int, Vector2>(up.Item1, up.Item2,
                                      new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 2));
            }

            if (upLeft != null)
            {
                SurroundingTiles[1] = new Tuple<Vector2, int, Vector2>(upLeft.Item1, upLeft.Item2,
                                      new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 1));
            }

            if (upRight != null)
            {
                SurroundingTiles[2] = new Tuple<Vector2, int, Vector2>(upRight.Item1, upRight.Item2,
                                      new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y - 1));
            }
            if (left != null)
            {
                SurroundingTiles[3] = new Tuple<Vector2, int, Vector2>(left.Item1, left.Item2,
                                      new Vector2(CenterTileIndex.X - 1, CenterTileIndex.Y));
            }
            if (right != null)
            {
                SurroundingTiles[4] = new Tuple<Vector2, int, Vector2>(right.Item1, right.Item2,
                                      new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y));
            }
            if (downLeft != null)
            {
                SurroundingTiles[5] = new Tuple<Vector2, int, Vector2>(downLeft.Item1, downLeft.Item2,
                                      new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 1));
            }
            if (downRight != null)
            {
                SurroundingTiles[6] = new Tuple<Vector2, int, Vector2>(downRight.Item1, downRight.Item2,
                                      new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y + 1));
            }
            if (down != null)
            {
                SurroundingTiles[7] = new Tuple<Vector2, int, Vector2>(down.Item1, down.Item2,
                                      new Vector2(CenterTileIndex.X, CenterTileIndex.Y + 2));
            }
        }
    }
}
