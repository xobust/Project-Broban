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

        public struct Atlas
        {
            public Texture2D Texture;
            public int Rows;
            public int Colums;
            public Vector2 Origin;
            public Atlas(ContentManager cm, String name, int rows, int colums, Vector2 origin) 
            {
                this.Rows = rows;
                this.Colums = colums;
                this.Origin = origin;
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
            sb.Draw(GetTexture(texture), position, null, Color.White, 0, 
                    origin, scale, SpriteEffects.None, depth); 
        }

        /// <summary>
        /// Draws a sprite from a texture atlas 
        /// </summary>
        /// <param name="atlas">The atlas to draw from</param>
        /// <param name="sb">The spriteBatch that the game uses to draw.</param>
        /// <param name="row">The row position for the sprite</param>
        /// <param name="column">The column position for the sprite</param> 
        /// <param name="position">The location (on-screen coordinates) to draw the texture.</param>
        /// <param name="scale">The scale of the sprite. 1 = 100%.</param>
        /// <param name="depth">Which layer to draw the texture on, 1 is on top, 0 is far back.</param>
        /// <param name="origin">The sprite origin, Vector2.Zero is the default.</param>
        public void DrawFromAtlas(String atlas, int row, int column,  SpriteBatch sb, Vector2 position, float scale, float depth)
        {

            Atlas Sheet = GetAtlas(atlas);
            Texture2D Texture = Sheet.Texture;
            //Calculate the source rectangle 
            int width = Texture.Width / Sheet.Colums;
            int height = Texture.Height / Sheet.Rows;
            Rectangle SourceRectangle = new Rectangle(width * column, height * row, width, height);

            sb.Draw(Texture, position, SourceRectangle, Color.White, 0, 
                    Sheet.Origin, scale, SpriteEffects.None, depth); 
        }

        /// <summary>
        /// Fetchees a atlas from our atlas dictionary
        /// </summary>
        /// <param name="name">Name of the atlas</param>
        /// <returns>The atlas</returns>
        public Atlas GetAtlas(string name)
        {
            Atlas temp;
            if(AtlasDictionary.TryGetValue(name,out temp))
            {
                return temp;
            }else
            {
                Console.WriteLine("Error atlas not found: {0}", name);
                return temp;
            }
        }

        /// <summary>
        /// Fetches a texture from the project and returns it.
        /// </summary>
        /// <param name="name">The file name of the texture.</param>
        /// <returns>The texture</returns>
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
