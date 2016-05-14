using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Project_Broban
{
    public class Monster : GameObject
    {
        private float size = 1;
        private const float moveSpeed = 0.2f;
        private const float range = 1;
        private const int damage = 1;
        private int hp = 1;
        Vector2 position;

        //The texture is static and shared across instances
        private static Texture2D texture;

        public Monster(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public void Move(float x, float y)
        {
            float deltaY = y - position.Y;
            float deltaX = x - position.X;

            position.X += moveSpeed * (float)Math.Cos(Math.Atan2(deltaY, deltaX));
            position.Y += moveSpeed * (float)Math.Sin(Math.Atan2(deltaY, deltaX));
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, 0,
                    Vector2.Zero, size, SpriteEffects.None, 0);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            // Load temporary texture (Like the player class)
            texture = cm.Load<Texture2D>("blobbie");
        }

        public void UnloadContent()
        {
        }
    }
}