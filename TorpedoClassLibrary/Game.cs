using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Game
    {
        public void asd()
        {
            Player p1 = new Player("Bence", new Actions());
            Player p2 = new Player("Mina", new Actions());
            Board board = new Board(2, 2);
            board.AddPlayer(p1);
            board.AddPlayer(p2);
            p1.Name = "asd";
            p1.Score = 2;
        }
    }
}
