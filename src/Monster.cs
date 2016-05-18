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
        private float depth;
        private int hp;
        private Player target;
        private Vector2 spriteOrigin;
        private TextureManager Textures;
        private Texture2D texture;
        public float range;
        public float pullRange;
        public Boolean attacking;
        public Vector2 startPos;
        Vector2 position;

        public Monster(float x, float y, TextureManager tm)
        {
            Textures = tm;
            position = new Vector2(x, y);
            hp = 1;
            size = 1; // 1 means 100% of the sprite size
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
            texture = Textures.GetTexture("blobbie"); // temporary solution

            // The original texture should have the origin in the middle-bottom
            spriteOrigin = new Vector2((texture.Width * size) / 2,
                                 (texture.Height * size));

            // We need to make it 1 - the depth since we want 1 to be on 
            // the top of the screen instead of 0 being on the top.
            // Example 1 - 0.2 = 0.8 reverts 0.2 at the top to 0.8 instead
            depth = (position.Y / GameManager.screenHeight); 
            depth = MathHelper.Clamp(depth, 0.01f, 1);
            
            Textures.DrawTexture("blobbie", sb, position, size, depth, spriteOrigin);
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
        }

        public void UnloadContent()
        {
        }
    }
}