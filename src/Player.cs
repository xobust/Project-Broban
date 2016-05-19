using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    
    enum Direction
    {
        Up, Down, Left, Right
    }

    public class Player : GameObject
    {
        private Direction PlayerDirection;
        private Texture2D PlayerTexture;
        private float Size;
        public int hp;
        public Vector2 Position;

        private Vector2 Origin;
        private float Depth;

        KeyboardState OldState;

        public Player()
        {
            Position = new Vector2(100, 100);
            PlayerDirection = Direction.Down;
            Size = 1;
            hp = 100;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                PlayerDirection = Direction.Up;
                Position.Y --;
            }
            if (state.IsKeyDown(Keys.A))
            {
                PlayerDirection = Direction.Left;
                Position.X --;
            }
            if (state.IsKeyDown(Keys.S))
            {
                PlayerDirection = Direction.Down;
                Position.Y ++;
            }
            if (state.IsKeyDown(Keys.D))
            {
                PlayerDirection = Direction.Right;
                Position.X ++;
            }

        }

        public void Draw(SpriteBatch sb)
        {
            // The original texture should have the origin in the middle-bottom
            Origin = new Vector2((PlayerTexture.Width * Size) / 2,
                                 (PlayerTexture.Height * Size));

            Depth = (Position.Y / GameManager.screenHeight);
            Depth = MathHelper.Clamp(Depth, 0.01f, 1);

            //TODO: Draw player sprite acording to the direction of the player
            sb.Draw(PlayerTexture, Position, null, Color.White, 0,
                    Origin, Size, SpriteEffects.None, Depth);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            PlayerTexture = cm.Load<Texture2D>("player");
        }

        public void UnloadContent()
        {
        }

    }
}
