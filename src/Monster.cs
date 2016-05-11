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
        private const float size = 1;
        private const float speed = 1;
        private const int hp = 1;
        private const float moveSpeed = 1;
        private const int damage = 1;
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
            
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            
        }

        public void UnloadContent()
        {
        }
    }
}
