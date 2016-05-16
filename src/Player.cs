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
    public class Player : GameObject
    {
        private Texture2D PlayerTexture;
        private float Size;
        public int hp;
        public Vector2 Position;
        private Vector2 Origin;

        public Player()
        {
            Position = new Vector2(100, 100);
            Size = 1;
            hp = 100;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                Position.Y --;
            }
            if (state.IsKeyDown(Keys.A))
            {
                Position.X --;
            }
            if (state.IsKeyDown(Keys.S))
            {
                Position.Y ++;
            }
            if (state.IsKeyDown(Keys.D))
            {
                Position.X ++;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            // Temporary origin 
            // The original texture should have the origin in the middle-bottom
            Origin = new Vector2((PlayerTexture.Width * Size) / 5,
                                 (PlayerTexture.Height * Size));

            sb.Draw(PlayerTexture, Position, null, Color.White, 0,
                    Origin, Size, SpriteEffects.None, 0);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            //Temporary test texture
            PlayerTexture = cm.Load<Texture2D>("playerTemp");
        }

        public void UnloadContent()
        {
        }

    }
}
