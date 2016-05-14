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
        public Vector2 Position;

        public Player()
        {
            Position = new Vector2(0, 0);
        }

        public void Update()
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
            sb.Draw(PlayerTexture, Position, Color.White);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            //Temporary test texture
            PlayerTexture = cm.Load<Texture2D>("player");
        }

        public void UnloadContent()
        {
        }

    }
}
