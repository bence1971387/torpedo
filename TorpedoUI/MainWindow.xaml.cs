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

namespace TorpedoUI 
{
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            Player player1 = new Player("p1", new Actions());
            Player player2 = new Player("p2", new Actions());
            List<Player> playerlist = new List<Player>();
            playerlist.Add(player1);
            playerlist.Add(player2);
            playerlist.Remove(new Player("p1", new Actions()));
            text.Text = playerlist.Count.ToString();
            Board.CreateBoard(6, 6, 50, 50, playerlist);
            
            if(Ship.IsShipPlaceable(3, new Vector2(0, 2), Ship.Orientation.Right))
            {
                Ship ship = new Ship(3, new Vector2(0, 2), Ship.Orientation.Right);
                Board.playerList[1].AddShip(ship);
            }
            Rectangle rect = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            rect.Width = 100;
            rect.Height = 100;
            GameArea.Children.Add(rect);
            Rectangle rect2 = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Width = 50,
                Height = 60,
            };
            GameArea.Children.Add(rect2);
        }
    }
}
