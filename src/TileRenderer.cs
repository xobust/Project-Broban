using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban_win.src
{
    class TileRenderer
    {
        private Texture2D tileSet;

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch sb)
        {

        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            //Temporary test texture
             = cm.Load<Texture2D>("player");
        }

        public void UnloadContent()
        {
        }
    }
}
