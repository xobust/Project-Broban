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
        void Render(SpriteBatch sb);
    }
}
