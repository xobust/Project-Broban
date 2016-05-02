using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Broban
{
    interface GameObject
    {
        /// <summary>
        /// Updates the state of the gameobject
        /// </summary>
        void Update();

        /// <summary>
        /// Renders the gameobject to the screen using the spritebatch
        /// </summary>
        void Draw(SpriteBatch sb);

        /// <summary>
        /// Loads necessary content of the gameobject
        /// </summary>
        void LoadContent();

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        void UnloadContent();
    }
}
