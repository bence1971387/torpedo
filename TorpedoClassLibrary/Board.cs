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
        public static bool Initialized { get; private set; } = false;
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static int TileWidth { get; private set; }
        public static int TileHeight { get; private set; }
       
        public static IList<IPlayer> PlayerList { get; private set; }
        public static ITile[,] Positions { get; private set; }
        static Board()
        {

        }
        public static void CreateBoard(int height, int width, int tileWidth, int tileHeight, IList<IPlayer> players)
        {
            if (!Initialized)
            {
                //initialized = true;
                Height = height;
                Width = width;
                TileWidth = tileWidth;
                TileHeight = tileHeight;
                Positions = new ITile[width,height];
                PlayerList = players;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Positions[i, j] = new Tile(new Vector2(i, j), tileWidth, tileHeight, true);
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
