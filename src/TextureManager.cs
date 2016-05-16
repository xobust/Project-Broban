using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Project_Broban
{
    public class TextureManager
    {

        Dictionary<String, Texture2D> TextureDicionary;

        public TextureManager()
        {
            TextureDicionary = new Dictionary<String, Texture2D>();
        }

        /// <summary>
        /// Loads alla textures into our texture dicionary
        /// </summary>
        public void LoadContent(ContentManager cm)
        {
            TextureDicionary.Add("blobbie", cm.Load<Texture2D>("blobbie")); 
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
