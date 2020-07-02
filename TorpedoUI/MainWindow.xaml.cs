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
            GameArea.Children.Clear();
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
        /*public void DisplayShips(IPlayer player)
        {
            foreach (var ship in player.ShipList)
            {
                foreach (var tile in ship.PositionList)
                {
                    Canvas.SetLeft(tile.Display, tile.Position.X * Board.TileWidth);
                    Canvas.SetTop(tile.Display, tile.Position.Y * Board.TileHeight);
                    GameArea.Children.Add(tile.Display);
                }
            }
        }*/
        /*public void DisplayAttack(object sender, ITile tile)
        {
            
            Canvas.SetLeft(display, tile.Position.X*Board.TileWidth);
            Canvas.SetTop(display, tile.Position.Y*Board.TileHeight);
            GameArea.Children.Add(display);
        }*/
        /*public void InitializeShips()
        {
            foreach (var playerArea in Board.PlayerAreaList)
            {
                foreach (var ship in playerArea.Player.ShipList)
                {
                    ship.EventShipHit += DisplayAttack;
                }
            }
        }*/
        public MainWindow()
        {
            InitializeComponent();
            Board.CreateBoard(20, 10, 50, 50, Brushes.Black, Brushes.White);
            IPlayer player = Factory.CreatePlayer("PlayerOne", Player.Type.Human);
            IPlayer player2 = Factory.CreatePlayer("PlayerTwo", Player.Type.AI);
            Board.AddPlayer(player);
            Board.AddPlayer(player2);
            Factory.GeneratePlayerAreaList();
            Factory.CreateShip(player, 6, Board.Positions[0, 0], Ship.Orientation.Down);
            if(Factory.CreateShip(player, 5, Board.Positions[5, 3], Ship.Orientation.Right))
            {
                
            }
            //DisplayBoard();
            //player2.Actions.AttackOnCoordinate(Board.Positions[5, 4]);
            //player2.Actions.AttackOnCoordinate(Board.Positions[6, 3]);
            DisplayBoard();
        }

        private void GameArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(GameArea);
            int xNormalized = (int)((point.X / Board.TileWidth));
            int yNormalized = (int)((point.Y / Board.TileHeight));
            Board.PlayerList[1].Actions.AttackOnCoordinate(Board.Positions[xNormalized,yNormalized]);
            DisplayBoard();
        }
    }
}
