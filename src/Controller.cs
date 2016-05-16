using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    interface Controller
    {
        /// <summary>
        /// Updates the state of the gameobject
        /// </summary>
        void Update(GameTime gameTime);
    }
}
