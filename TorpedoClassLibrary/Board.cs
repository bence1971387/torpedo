using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public static class Board
    {
        static bool initialized = false;
        public static int height { get; private set; }
        public static int width { get; private set; }
        public static List<Player> playerList { get; private set; }
        public static Tile[,] positions { get; private set; }
        public static void CreateBoard(int height, int width, int tileWidth, int tileHeight, List<Player> players)
        {
            if (!initialized)
            {
                initialized = true;
                Board.height = height;
                Board.width = width;
                positions = new Tile[width,height];
                playerList = players;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        positions[i, j] = new Tile(new Vector2(i, j), tileWidth, tileHeight, true);
                    }
                }
            } 
            else
            {
                throw new Exception("Board is already initialized.");
            }
        }
    }
}
