using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Project_Broban.src
{
    class TextureManager
    {

        Dictionary<String, Texture2D> TextureDicionary;

        /// <summary>
        /// Loads alla textures into our texture dicionary
        /// </summary>
        public void LoadContent()
        {
            //Load all textures ayy lamao
        }
        
        public Texture2D GetTexture(String name)
        {
            Texture2D temp = null;
            if(TextureDicionary.TryGetValue(name,out temp))
            {
                return temp;
            }else
            {
                Console.WriteLine("Error texture not found: {0}", name);
                return temp;
            }
        }

    }
}
