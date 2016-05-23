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
    interface GameObject
    {
        /// <summary>
        /// Updates the state of the gameObject
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Renders the gameObject to the screen using the spriteBatch.
        /// </summary>
        /// <param name="sb">The spriteBatch to draw with.</param>
        void Draw(SpriteBatch sb);

        /// <summary>
        /// Loads necessary content of the gameObject.
        /// </summary>
        /// <param name="gd">The GraphicsDevice from GameManager.</param>
        /// <param name="cm">The ContentManager from GameManager.</param>
        void LoadContent(GraphicsDevice gd, ContentManager cm);

        /// <summary>
        /// Unloads content from the gameObject.
        /// </summary>
        void UnloadContent();
    }
}
