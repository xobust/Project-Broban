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
        private const float moveSpeed = 0.5f;
        private const int damage = 1;
        private const float attackTime = 100; // in milliseconds
        private const float coolDown = 1000;
        private float waitingForAttack;
        private float attackChargeTime;
        private float size;
        private int hp;
        private Texture2D texture;
        private Player target;
        public float range;
        public float pullRange;
        public Boolean attacking;
        public Vector2 startPos;
        Vector2 position;

        public Monster(float x, float y, TextureManager tm)
        {
            texture = tm.GetTexture("blobbie");
            position = new Vector2(x, y);
            hp = 1;
            size = 1;
            range = 10;
            pullRange = 150;
            attacking = false;

            startPos.X = x;
            startPos.Y = y;
        }

        public void Attacking(Player player)
        {
            target = player;
            attacking = true;
        }

        public void Move(Vector2 targetPos)
        {
            float deltaY = targetPos.Y - position.Y;
            float deltaX = targetPos.X - position.X;

            position.X += moveSpeed * (float)Math.Cos(Math.Atan2(deltaY, deltaX));
            position.Y += moveSpeed * (float)Math.Sin(Math.Atan2(deltaY, deltaX));
        }

        public double Distance(Vector2 targetPos)
        {
            float deltaY = position.Y - targetPos.Y;
            float deltaX = position.X - targetPos.X;

            return Math.Abs(Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
        }

        public void Update(GameTime gameTime)
        {
            if (attacking)
            {
                waitingForAttack += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (coolDown < waitingForAttack)
                {
                    target.Position.X += 1;
                    attackChargeTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    // Implement attack animation here
                    if (attackTime < attackChargeTime)
                    {
                        target.hp -= damage;
                        attackChargeTime = 0;
                        waitingForAttack = 0;
                    }
                }
            } else
            {
                waitingForAttack = 0;
                attackChargeTime = 0;
            }
            attacking = false; // Reset attacking so it has to check each frame if
                               // it can still attack the target.
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, 0,
                    Vector2.Zero, size, SpriteEffects.None, 0);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
        }

        public void UnloadContent()
        {
        }
    }
}