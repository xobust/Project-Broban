using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Broban
{
    class MonsterController : Controller
    {
        GameManager gameManager;

        public MonsterController(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void Update()
        {

        }
    }
}
