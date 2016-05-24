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

        Vector2 up;
        Vector2 upLeft;
        Vector2 upRight;
        Vector2 left;
        Vector2 right;
        Vector2 downLeft;
        Vector2 downRight;
        Vector2 down;

        private Vector2 MoveVector;
        private Vector2 CenterTileIndex;
        private float TileArea;
        private Boolean Collided;
        private int SqrtSize = 2;
        private CollisionTile CurrentTile;
        GameManager GameManager;

        public CollisionController(GameManager gameManager)
        {
            this.GameManager = gameManager;
            MoveVector = Vector2.Zero;
            SurroundingTiles = new Tuple<Vector2, int, Vector2>[8];

            CurrentTile = new CollisionTile(SqrtSize);
            CurrentTile.CalculateTilePos(gameManager.player.Position, 0);
            TileArea = CalculateArea(CurrentTile.A,
                                     CurrentTile.B,
                                     CurrentTile.D,
                                     CurrentTile.C);

            GenerateGrid(gameManager.GameWorld.WorldSize * 4,
                         gameManager.GameWorld.WorldSize * 4);


            // Set the starter position
            Vector2 tileOffset = new Vector2(CurrentTile.TileWidth/2, CurrentTile.TileHeight/4);
            Vector2 startPos = gameManager.player.TileStartPos;
            CenterTileIndex = startPos;

            gameManager.player.Position = 
            new Vector2(Grid[(int)startPos.X][(int)startPos.Y].Item1.X + tileOffset.X,
                        Grid[(int)startPos.X][(int)startPos.Y].Item1.Y + tileOffset.Y);

            // Placing collision tiles in these places below: 
            // (feel free to test or remove this)
            Grid[5][5] = new Tuple<Vector2, int>(Grid[5][5].Item1, 1);
            Grid[4][4] = new Tuple<Vector2, int>(Grid[4][4].Item1, 1);
            Grid[3][3] = new Tuple<Vector2, int>(Grid[3][3].Item1, 1);
            Grid[2][2] = new Tuple<Vector2, int>(Grid[2][2].Item1, 1);
            Grid[1][1] = new Tuple<Vector2, int>(Grid[1][1].Item1, 1);

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
                                    (new Vector2((CurrentTile.TileWidth / (SqrtSize)) * x, 
                                                 (CurrentTile.TileHeight / (SqrtSize*2)) * y), 0);
                    }
                    else
                    {
                        Grid[x][y] = new Tuple<Vector2, int>
                                    (new Vector2((CurrentTile.TileWidth / (SqrtSize)) * x + 
                                                  CurrentTile.TileWidth / (SqrtSize*2), // the offset
                                                 (CurrentTile.TileHeight / (SqrtSize*2)) * y), 0);
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

                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    if (SurroundingTiles[i] == null)
                    {
                        continue;
                    }

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

                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    if (SurroundingTiles[i] == null)
                    {
                        continue;
                    }
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

                for (int i = 0; i < SurroundingTiles.Length; i++)
                {
                    if (SurroundingTiles[i] == null)
                    {
                        continue;
                    }
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
                    if (SurroundingTiles[i] == null)
                    {
                        continue;
                    }
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


            CalcSurrTiles();
            Console.WriteLine(CenterTileIndex);
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

        private Boolean InsideBounds(float indexOne, float indexTwo)
        {
            if (indexOne >= 0 && indexOne < Grid.Length-1 &&
                indexTwo >= 0 && indexTwo < Grid.Length-1)
            {
                return true;
            }
            return false;
        }

        private void CalcSurrTiles()
        {
            // http://bit.ly/1TsUSgX - explanation of the indexes below (when on an odd column)
            // http://bit.ly/1TyiEdS - explanation of the indexes below (when on an even column)
            // Top to bottom - Left to right following to the image above:
            Console.WriteLine(CenterTileIndex);
            if (CenterTileIndex.Y % 2 == 0)
            {
                upLeft = new Vector2(CenterTileIndex.X - 1, CenterTileIndex.Y - 1);
                upRight = new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 1);
                downLeft = new Vector2(CenterTileIndex.X - 1, CenterTileIndex.Y + 1);
                downRight = new Vector2(CenterTileIndex.X, CenterTileIndex.Y + 1);
            }
            else
            {
                upLeft = new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 1);
                upRight = new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y - 1);
                downLeft = new Vector2(CenterTileIndex.X, CenterTileIndex.Y + 1);
                downRight = new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y + 1);
            }

            up = new Vector2(CenterTileIndex.X, CenterTileIndex.Y - 2);
            left = new Vector2(CenterTileIndex.X - 1, CenterTileIndex.Y);
            right = new Vector2(CenterTileIndex.X + 1, CenterTileIndex.Y);
            down = new Vector2(CenterTileIndex.X, CenterTileIndex.Y + 2);

            if (InsideBounds(up.X, up.Y))
            {
                SurroundingTiles[0] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)up.X][(int)up.Y].Item1, 
                                      Grid[(int)up.X][(int)up.Y].Item2, up);
            }

            if (InsideBounds(upLeft.X, upLeft.Y))
            {
                SurroundingTiles[1] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)upLeft.X][(int)upLeft.Y].Item1,
                                      Grid[(int)upLeft.X][(int)upLeft.Y].Item2, upLeft);
            }

            if (InsideBounds(upRight.X, upRight.Y))
            {
                SurroundingTiles[2] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)upRight.X][(int)upRight.Y].Item1,
                                      Grid[(int)upRight.X][(int)upRight.Y].Item2, upRight);
            }

            if (InsideBounds(left.X, left.Y))
            {
                SurroundingTiles[3] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)left.X][(int)left.Y].Item1,
                                      Grid[(int)left.X][(int)left.Y].Item2, left);
            }

            if (InsideBounds(right.X, right.Y))
            {
                SurroundingTiles[4] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)right.X][(int)right.Y].Item1,
                                      Grid[(int)right.X][(int)right.Y].Item2, right);
            }

            if (InsideBounds(downLeft.X, downLeft.Y))
            {
                SurroundingTiles[5] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)downLeft.X][(int)downLeft.Y].Item1,
                                      Grid[(int)downLeft.X][(int)downLeft.Y].Item2, downLeft);
            }

            if (InsideBounds(downRight.X, downRight.Y))
            {
                SurroundingTiles[6] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)downRight.X][(int)downRight.Y].Item1,
                                      Grid[(int)downRight.X][(int)downRight.Y].Item2, downRight);
            }

            if (InsideBounds(down.X, down.Y))
            {
                SurroundingTiles[7] = new Tuple<Vector2, int, Vector2>
                                     (Grid[(int)down.X][(int)down.Y].Item1,
                                      Grid[(int)down.X][(int)down.Y].Item2, down);
            }
        }
    }
}
