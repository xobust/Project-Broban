using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    class Room : GameObject
    {
        int XPossition;
        int YPossition;

        // TODO add tile map here int[][] TileMap;

        Room(int xPossition, int yPossition)
        {
            XPossition = xPossition;
            YPossition = yPossition;
        }

        /// <summary>
        /// Generates the world 
        /// </summary>
        public void Generate()
        {
            // TODO write room generation code here 
        }
        /// <summary>
        /// Updates the state of the gameobject
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Renders the gameobject to the screen using the spritebatch
        /// </summary>
        public void Draw(SpriteBatch sb)
        {
            // TODO create a singelton object that renders the tilemap here. TileRenderer.Draw(TileMap);
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
