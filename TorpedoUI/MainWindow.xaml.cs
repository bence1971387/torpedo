using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;
using TorpedoClassLibrary;
using System.ComponentModel;

namespace TorpedoUI 
{
    public partial class MainWindow : Window
    {
        public void DisplayBoard()
        {
            GameArea.Width = Board.Width * Board.TileWidth;
            GameArea.Height = Board.Height * Board.TileHeight;
            for(int i = 0; i < Board.Width; i++)
            {
                for (int j = 0; j < Board.Height; j++)
                {
                    Canvas.SetLeft(Board.Positions[i, j].Display, i * Board.TileWidth);
                    Canvas.SetTop(Board.Positions[i, j].Display, j * Board.TileHeight);
                    GameArea.Children.Add(Board.Positions[i, j].Display);
                }
            }
        }
        public void DisplayShips(IPlayer player)
        {
            foreach (var ship in player.ShipList)
            {
                foreach (var tile in ship.PositionList)
                {
                    Rectangle position = new Rectangle
                    {
                        Stroke = Brushes.Black,
                        Fill = Brushes.Green,
                        StrokeThickness = 2,
                        Width = Board.TileWidth,
                        Height = Board.TileHeight
                    };
                    Canvas.SetLeft(position, tile.Position.X * Board.TileWidth);
                    Canvas.SetTop(position, tile.Position.Y * Board.TileHeight);
                    GameArea.Children.Add(position);
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Board.CreateBoard(20, 10, 50, 50, Brushes.Black, Brushes.White);
            DisplayBoard();
            IPlayer player = Factory.CreatePlayer("PlayerOne", Player.Type.Human);
            IPlayer player2 = Factory.CreatePlayer("PlayerTwo", Player.Type.AI);
            Board.AddPlayer(player);
            Board.AddPlayer(player2);
            Factory.GeneratePlayerAreaList();
            Factory.CreateShip(player, 3, Board.Positions[0, 0], Ship.Orientation.Down);
            if(Factory.CreateShip(player, 5, Board.Positions[5, 3], Ship.Orientation.Right))
            {
                
            }
            DisplayShips(player);
            /*Board.CreateBoard(10, 10, 50, 50);
            IPlayer p1 = Factory.CreatePlayer("p1", Player.Type.Human);
            IPlayer p2 = Factory.CreatePlayer("p2", Player.Type.AI);
            IShip ship = Factory.CreateShip(3, Board.Positions[0, 0], Ship.Orientation.Down);
            
            Board.AddPlayer(p1);
            Board.AddPlayer(p2);
            Factory.GeneratePlayerAreaList();
            p1.AddShip(ship);
            if (p2.Actions.AttackOnCoordinate(Board.Positions[0, 1]))
            {
                //text.Text = "success";
            } 
            else
            {
                //text.Text = "Failure";
            }*/
        }
    }
}
