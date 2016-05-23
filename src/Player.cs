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
    
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public class Player : GameObject
    {
        public Direction PlayerDirection; // Which direction the player is facing
        private Texture2D PlayerTexture;  // The player sprite
        private int TextureHeight;        // The width of the sprite
        private int TextureWidth;         // The height of the sprite
        private int SpriteRow = 0;        // Which row of the spritesheet to draw
        private float Size;               // The size of the player. 1 = 100% of the sprite
        public int hp;                    // The player's health
        public Vector2 Position;          // The player's position
        private const float moveSpeed = 0.25f; // The player's movement speed

        private Vector2 Origin;     // The sprite origin
        private float Depth;        // Which layer to draw the player on

        public bool Attacking;      // Is the player attacking or not
        public int AttackRange;     // The range of the attack
        public TimeSpan AttackTime; // The duration of an attack
        int AttackDamage;           // How much damage to deal with each attack

        /// <summary>
        /// Instantiate the Player.
        /// </summary>
        public Player()
        {
            Position = new Vector2(100, 100);
            PlayerDirection = Direction.Down;
            Size = 1;
            hp = 5;
            Attacking = false;
            AttackRange = 150;
            AttackTime = new TimeSpan(0,0,0,0,200);
            AttackDamage = 1;
        }

        /// <summary>
        /// Attack a monster and deal damage to it.
        /// Called in PlayerController.
        /// </summary>
        /// <param name="monster">The monster that gets attacked.</param>
        public void Attack(Monster monster)
        {
            monster.TakeDamage(AttackDamage);
        }

        /// <summary>
        /// Handles player movement. Attack is handled in the class PlayerController.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (!Attacking)
            {
                if (state.IsKeyDown(Keys.W))
                {
                    PlayerDirection = Direction.Up;
                    Position.Y -= moveSpeed * deltaTime;
                }
                if (state.IsKeyDown(Keys.A))
                {
                    PlayerDirection = Direction.Left;
                    Position.X -= moveSpeed * deltaTime;
                }
                if (state.IsKeyDown(Keys.S))
                {
                    PlayerDirection = Direction.Down;
                    Position.Y += moveSpeed * deltaTime;
                }
                if (state.IsKeyDown(Keys.D))
                {
                    PlayerDirection = Direction.Right;
                    Position.X += moveSpeed * deltaTime;
                }
            }
        }

        /// <summary>
        /// Renders the player using the spriteBatch.
        /// A different sprite is used depending on which way the player
        /// is currently facing.
        /// </summary>
        /// <param name="sb">The SpriteBatch to draw with.</param>
        public void Draw(SpriteBatch sb)
        {
            // The original texture should have the origin in the middle-bottom
            Origin = new Vector2((TextureWidth * Size) / 2,
                                 (TextureHeight/4 * Size));

            Depth = (Position.Y / GameManager.screenHeight);
            Depth = MathHelper.Clamp(Depth, 0.01f, 1);

            switch (PlayerDirection)
            {
                case Direction.Down:
                    SpriteRow = 0;
                    break;
                case Direction.Up:
                    SpriteRow = 1;
                    break;
                case Direction.Right:
                    SpriteRow = 2;
                    break;
                case Direction.Left:
                    SpriteRow = 3;
                    break;
            }
            Rectangle SourceRect = new Rectangle(0, SpriteRow * TextureHeight / 4, 
                TextureWidth, TextureHeight / 4);
            
            sb.Draw(PlayerTexture, Position, SourceRect, Color.White, 0,
                    Origin, Size, SpriteEffects.None, Depth);
        }

        /// <summary>
        /// Loads necessary content of the gameObject.
        /// </summary>
        /// <param name="gd">The GraphicsDevice.</param>
        /// <param name="cm">The ContentManager (contains graphics).</param>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            PlayerTexture = cm.Load<Texture2D>("player");
            TextureHeight = PlayerTexture.Height;
            TextureWidth = PlayerTexture.Width;
        }

        /// <summary>
        /// Unloads content from the gameObject.
        /// </summary>
        public void UnloadContent()
        {
        }
    }
}
