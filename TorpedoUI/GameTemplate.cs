using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoUI
{
    abstract class GameTemplate
    {
        abstract public void RegisterPlayer(string name);
        abstract public void PlayGame();
        virtual public void Game()
        {

        }
    }
}
