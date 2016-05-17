using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
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

        /// <summary>
        /// Draws a texture from the TextureDictionary
        /// </summary>
        /// <param name="name"></param>
        /// <param name="possition"></param>
        /// <param name="size"></param>
        public void DrawTexture(String name, SpriteBatch sb, Vector2 position, float size, float depth)
        {
            // The origin of the texture will have to be added to this aswell
            sb.Draw(GetTexture(name), position, null, Color.White, 0, 
                    Vector2.Zero, size, SpriteEffects.None, depth); 
        }

        //Todo: Implement Draw function for sprite sheets, animation etc.
        
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
