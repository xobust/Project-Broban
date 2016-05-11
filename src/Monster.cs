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
    class Monster : GameObject
    {
        private const float size = 0.5f;
        private const float speed = 1;
        private const float moveSpeed = 1;
        private const int damage = 1;
        private int hp = 1;
        private Texture2D texture;
        Vector2 position;

        public Monster(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 
                    size, SpriteEffects.None, 0);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            // Load temporary texture (Like the player class)
            texture = cm.Load<Texture2D>("player");
        }

        public void UnloadContent()
        {
        }
    }
}