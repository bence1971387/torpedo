using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public static class Board
    {
        public static bool Initialized { get; private set; } = false;
        public static bool IsPlayerAreaSet { get; private set; } = false;
        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static int TileWidth { get; private set; }
        public static int TileHeight { get; private set; }
        public static IList<IPlayer> PlayerList { get; private set; }
        public static IList<IPlayerArea> PlayerAreaList { get; private set; }
        //public static IList<IPlayer> PlayerList { get; private set; }
        public static ITile[,] Positions { get; set; }
        public static void SetPlayerAreaList(IList<IPlayerArea> playerAreaList)
        {
            if (!IsPlayerAreaSet)
            {
                IsPlayerAreaSet = true;
                PlayerAreaList = playerAreaList;
            }
            else
            {
                throw new Exception("Player area is already set!");
            }
        }
        public static void CreateBoard(int width, int height, int tileWidth, int tileHeight, Brush tileOutline, Brush tileFill)
        {
            if (!Initialized)
            {
                Positions = new Tile[width, height];
                Initialized = true;
                Width = width;
                Height = height;
                TileWidth = tileWidth;
                TileHeight = tileHeight;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Positions[i, j] = new Tile(new Vector2(i, j), 
                            new Rectangle { 
                            Stroke = tileOutline,
                            Fill = tileFill,
                            StrokeThickness = 2,
                            Width = tileWidth,
                            Height = tileHeight
                        },
                        true);
                    }
                }
            } 
            else
            {
                throw new Exception("Board is already initialized!");
            }
        }
        public static void AddPlayer(IPlayer player)
        {
            if (PlayerList.Contains(player))
            {
                throw new Exception("You cannot add the same player twice!");
            }
            if (PlayerList.Count < 2)
            {
                PlayerList.Add(player);
            } 
            else
            {
                throw new Exception("Cannot add more than 2 players!");
            }
        }
        static Board()
        {
            PlayerList = new List<IPlayer>();
            
        }
    }
}
