using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    class Board
    {
        public int Height { get; }
        public int Width { get; }
        public List<Player> PlayerList { get; private set; }
        public Tile[,] Positions { get; private set; }
        public void AddPlayer(Player player)
        {
            PlayerList.Add(player);
        }
        public Board(int height, int width)
        {
            Height = height;
            Width = width;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    Positions[i,j] = new Tile(i, j, true);
                }
            }
        }
    }
}
