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

        struct Atlas
        {
            public Texture2D Texture;
            public int Rows;
            public int Colums;
            public Atlas(ContentManager cm, String name, int rows, int colums) 
            {
                this.Rows = rows;
                this.Colums = colums;
                this.Texture = cm.Load<Texture2D>(name); 
            }
        }

        Dictionary<String, Texture2D> TextureDicionary;
        Dictionary<String, Atlas> AtlasDictionary;

        public TextureManager()
        {
            TextureDicionary = new Dictionary<String, Texture2D>();
            AtlasDictionary = new Dictionary<String, Atlas>();
        }

        /// <summary>
        /// Loads alla textures into our texture dicionary
        /// </summary>
        public void LoadContent(ContentManager cm)
        {
            TextureDicionary.Add("blobbie", cm.Load<Texture2D>("blobbie")); 
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

        /// <summary>
        /// Draws a texture from the TextureDictionary.
        /// </summary>
        /// <param name="texture">The file name of the texture.</param>
        /// <param name="sb">The spriteBatch that the game uses to draw.</param>
        /// <param name="position">The location (on-screen coordinates) to draw the texture.</param>
        /// <param name="scale">The scale of the sprite. 1 = 100%.</param>
        /// <param name="depth">Which layer to draw the texture on, 1 is on top, 0 is far back.</param>
        /// <param name="origin">The sprite origin, Vector2.Zero is the default.</param>
        public void DrawFromAtlas(String texture, SpriteBatch sb, Vector2 position, float scale, float depth,
            Vector2 origin)
        {
            // The origin of the texture will have to be added to this aswell
            sb.Draw(GetTexture(texture), position, null, Color.White, 0, 
                    origin, scale, SpriteEffects.None, depth); 
        }

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
