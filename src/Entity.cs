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
    public class Entity : GameObject
    {
        public int Size; // The size of the entity in collisiontiles
        public Vector2 Position;
        public Vector2 TilePosition;
        private TextureManager Textures;
        private Texture2D Texture;

        private float Depth;
        private Vector2 SpriteOrigin;   // The sprite origin

        public Entity(Vector2 tilePosition, TextureManager tm)
        {
            Textures = tm;
            TilePosition = tilePosition;
        }

        /// <summary>
        /// Updates the state of the gameObject
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Renders the gameObject to the screen using the spriteBatch.
        /// </summary>
        /// <param name="sb">The spriteBatch to draw with.</param>
        public void Draw(SpriteBatch sb)
        {
            Texture = Textures.GetTexture("tree"); // temporary solution

            // The original texture should have the origin in the middle-bottom
            SpriteOrigin = new Vector2((Texture.Width) / 2,
                                 (Texture.Height - 90));

            Depth = (Position.Y / GameManager.screenHeight);
            Depth = MathHelper.Clamp(Depth, 0.01f, 1);

            Textures.DrawTexture("tree", sb, Position, 1, Depth, SpriteOrigin);
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
