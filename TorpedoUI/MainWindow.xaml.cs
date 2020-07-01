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
        public void DisplayBoard(object sender, EventArgs e)
        {
            //GameArea.Width = Board.Width * Board.TileWidth;
            //GameArea.Height = Board.Height * Board.TileHeight;
            /*text.Text = "bambam";
            for (int i = 0; i < Board.Height; i++)
            {
                for (int j = 0; j < Board.Width; j++)
                {
                    Rectangle Tile = new Rectangle
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        Width = Board.TileWidth,
                        Height = Board.TileHeight
                    };
                    Canvas.SetLeft(Tile,Board.TileWidth*j);
                    GameArea.Children.Add(Tile);
                }
                Rectangle Tile2 = new Rectangle
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Width = Board.TileWidth,
                    Height = Board.TileHeight
                };
                Canvas.SetTop(Tile2,Board.TileHeight*i);
                GameArea.Children.Add(Tile2);
            }*/
            Rectangle Tile = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Width = Board.TileWidth,
                Height = Board.TileHeight,
                Fill = Brushes.AliceBlue
            };
            GameArea.Children.Remove(button);
            Canvas.SetLeft(Tile, 0);
            Canvas.SetTop(Tile, 0);
            GameArea.Children.Add(Tile);
        }
        /*public  RegisterPlayer(object sender, EventArgs e)
        {

            return Factory.CreatePlayer(text.Text);
        }*/
        public void DisplayShips()
        {

        }
        public MainWindow()
        {
            InitializeComponent();
            //button.Click += RegisterPlayer;  
            IPlayer p1 = Factory.CreatePlayer("p1",Player.Type.Human);
            IPlayer p2 = Factory.CreatePlayer("p2",Player.Type.Human);
            List<IPlayer> playerList = new List<IPlayer>
            {
                p1,
                p2
            };
            Board.CreateBoard(10, 10, 50, 50,playerList);
            Factory.CreateShip(3, new Vector2(1, 1), Ship.Orientation.Down);
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
            
            Button b = new Button
            {
                Name = "asd",
                Width = 20,
                Height = 20,
            };
            button.Click += DisplayBoard;
            GameArea.Children.Add(b);
            b.Click += DisplayBoard;
            IPlayer p = Factory.CreatePlayer("buuu",Player.Type.Human);
            IPlayer c = Factory.CreatePlayer("baaa",Player.Type.Human);
            p.Actions = c.Actions;
            text.Text = p.Actions.aaName();
        }
    }
}
