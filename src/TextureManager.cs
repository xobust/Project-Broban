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
            TextureDicionary.Add("tree", cm.Load<Texture2D>("tree"));
            TextureDicionary.Add("blobbie", cm.Load<Texture2D>("blobbie"));
            TextureDicionary.Add("boss", cm.Load<Texture2D>("boss"));
        }

        /// <summary>
        /// Draws a texture from the TextureDictionary.
        /// </summary>
        /// <param name="texture">The file name of the texture.</param>
        /// <param name="sb">The spriteBatch that the game uses to draw.</param>
        /// <param name="position">The location (on-screen coordinates) to draw the texture.</param>
        /// <param name="scale">The scale of the sprite. 1 = 100%.</param>
        /// <param name="depth">Which layer to draw the texture on, 1 is on top, 0 is far back.</param>
        /// <param name="origin">The sprite origin, Vector2.Zero is the default.</param>
        public void DrawTexture(String texture, SpriteBatch sb, Vector2 position, float scale, float depth,
            Vector2 origin)
        {
            // The origin of the texture will have to be added to this aswell
            sb.Draw(GetTexture(texture), position, null, Color.White, 0, 
                    origin, scale, SpriteEffects.None, depth); 
        }

        //Todo: Implement Draw function for sprite sheets, animation etc.

        /// <summary>
        /// Fetches a texture from the project and returns it.
        /// </summary>
        /// <param name="name">The file name of the texture.</param>
        /// <returns>The texture.</returns>
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
