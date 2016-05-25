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
        private const float moveSpeed = 0.5f; // The movement speed
        private const int damage = 1;         // The attack damage
        private const float attackTime = 100; // The startup time for an attack
        private const float coolDown = 1000;  // How long before the next attack
        private float waitingForAttack;     // The current cool down time
        private float attackChargeTime;     // The current start up time that has passed
        private float size;     // The size of the monster
        private float depth;    // Which layer to draw the monster on
        private int hp;         // The health of the monster
        private Player target;  // The target to attack and move towards
        private Vector2 spriteOrigin;   // The sprite origin
        private TextureManager Textures;    // Contains the monster sprites
        private Texture2D texture;          // The sprite for this monster
        public float range;         // The attack range of the monster
        public float pullRange;     // How close the player has to be for the monster to move
        public Boolean attacking;   // Is the monster attack or not
        public Vector2 startPos;    // The starting position of the monster
        public Boolean alive;       // If the monster is alive
        public Vector2 position;    // The current position of the monster

        /// <summary>
        /// Creates a monster at a specified position.
        /// </summary>
        /// <param name="x">The starting x-coordinate of the monster.</param>
        /// <param name="y">The starting y-coordinate of the monster.</param>
        /// <param name="tm">The TextureManager that contains the monster sprite.</param>
        public Monster(float x, float y, TextureManager tm)
        {
            Textures = tm;
            position = new Vector2(x, y);
            hp = 1;
            alive = true;
            size = 1; // 1 means 100% of the sprite size
            range = 10;
            pullRange = 150;
            attacking = false;

            startPos.X = x;
            startPos.Y = y;
        }

        /// <summary>
        /// Attack the player.
        /// </summary>
        /// <param name="player">A reference to the player object.</param>
        public void Attacking(Player player)
        {
            target = player;
            attacking = true;
        }

        /// <summary>
        /// Take damange when the Player attacks the monster.
        /// See the class PlayerController.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            hp -= damage;
            if(hp<= 0)
            {
                this.UnloadContent();
                hp = 0;
                alive = false;
            }
        }

        /// <summary>
        /// Handles Monster movement.
        /// </summary>
        /// <param name="targetPos">The position to move to.</param>
        public void Move(Vector2 targetPos)
        {
            float deltaY = targetPos.Y - position.Y;
            float deltaX = targetPos.X - position.X;

            position.X += moveSpeed * (float)Math.Cos(Math.Atan2(deltaY, deltaX));
            position.Y += moveSpeed * (float)Math.Sin(Math.Atan2(deltaY, deltaX));
        }

        /// <summary>
        /// Returns the distance between the monster and the target.
        /// </summary>
        /// <param name="targetPos">The target to move to.</param>
        /// <returns></returns>
        public double Distance(Vector2 targetPos)
        {
            float deltaY = position.Y - targetPos.Y;
            float deltaX = position.X - targetPos.X;

            return Math.Abs(Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));
        }

        /// <summary>
        /// Update the monster object. Handles attack charge and cooldown. 
        /// See also the class MonsterController.
        /// The Room class calls this method.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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

        /// <summary>
        /// Render the monster on screen.
        /// </summary>
        /// <param name="sb">The spriteBatch to draw with.</param>
        public void Draw(SpriteBatch sb)
        {
            texture = Textures.GetTexture("blobbie"); // temporary solution

            // The original texture should have the origin in the middle-bottom
            spriteOrigin = new Vector2((texture.Width * size) / 2,
                                 (texture.Height * size - 30));

            // We need to make it 1 - the depth since we want 1 to be on 
            // the top of the screen instead of 0 being on the top.
            // Example 1 - 0.2 = 0.8 reverts 0.2 at the top to 0.8 instead
            depth = (position.Y / GameManager.screenHeight);
            depth = MathHelper.Clamp(depth, 0.01f, 1);
            
            Textures.DrawTexture("blobbie", sb, position, size, depth, spriteOrigin);
        }

        /// <summary>
        /// Loads necessary content of the gameObject.
        /// </summary>
        /// <param name="gd">The GraphicsDevice from GameManager.</param>
        /// <param name="cm">The ContentManager from GameManager.</param>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
        }

        /// <summary>
        /// Unloads content from the gameObject.
        /// </summary>
        public void UnloadContent()
        {
        }
    }
}