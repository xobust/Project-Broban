using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    class World : GameObject
    {
        Vector2 CurrentPossition = new Vector2( 0, 0 );
        Room[][] WorldMap;

        World(int size)
        {

        }


        /// <summary>
        /// Updates the state of the world 
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Renders the world to the screen using the spritebatch
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
        }

        /// <summary>
        /// Loads necessary content of the gameobject
        /// </summary>
        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {

        }

        /// <summary>
        /// Unloads content from the gameobject
        /// </summary>
        public void UnloadContent()
        {

        }
    }
}
