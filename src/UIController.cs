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
    class UIController : Controller
    {
        GameManager gameManager; 
        Player player;
        private Texture2D heartTexture;
        private int heartWidth;
        private int heartHeight;
        private int leftOffsetX = 10; // Adds extra space to the left of the hearts

        public UIController(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Update(GameTime gameTime)
        {
            player = gameManager.player;
        }

        public void Draw(SpriteBatch sb)
        {
            for(int i = 0; i < player.hp; i++)
            {
                Rectangle destRectangle = new Rectangle(heartWidth * i + leftOffsetX, 0, heartWidth, heartHeight);
                
                sb.Draw(heartTexture, destRectangle, null, Color.White, 0, Vector2.Zero,
                    SpriteEffects.None, 1);
            }
        }

        public void LoadContent(GraphicsDevice gd, ContentManager cm)
        {
            heartTexture = cm.Load<Texture2D>("heart");
            heartWidth = heartTexture.Width;
            heartHeight = heartTexture.Height;
        }
    }
}
