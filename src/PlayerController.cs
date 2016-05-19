using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project_Broban
{
    class PlayerController
    {
        GameManager GameManager;
        Player player;

        public PlayerController(GameManager gameManager)
        {
            this.GameManager = gameManager;
            player = gameManager.player;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
