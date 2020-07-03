﻿using System;
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
        enum GameStates { Init, Naming, Game };
        enum GameModes { PvP, PvAI };
        private GameStates _gameState;
        private GameModes _gameMode;
        private IEnumerable<IPlayer> CurrentPlayer()
        {
            while (true)
            {
                foreach (var player in Board.PlayerList)
                {
                    yield return player;
                }
            }
        }
        public void PlayerVersusPlayer(object sender, EventArgs e)
        {
            _gameState = GameStates.Naming;
            _gameMode = GameModes.PvP;
            Game();
        }
        public void PlayerVersusAI(object sender, EventArgs e)
        {
            _gameState = GameStates.Naming;
            _gameMode = GameModes.PvAI;
            Game();
        }
        public void PlayPvE()
        {

        }
        public void PlayPvP()
        {

        }
        public void DisplayBoard(IPlayer player)
        {
            GameArea.Children.Clear();
            Line line = new Line
            {
                Stroke = Brushes.Brown,
                StrokeThickness = 4,
                X1 = (Board.Width * Board.TileWidth) / 2,
                Y1 = 0,
                X2 = (Board.Width * Board.TileWidth) / 2,
                Y2 = Board.Height * Board.TileHeight
            };

            for (int i = 0; i < Board.Width; i++)
            {
                for (int j = 0; j < Board.Height; j++)
                {
                    Canvas.SetLeft(Board.Positions[i, j].Display, i * Board.TileWidth);
                    Canvas.SetTop(Board.Positions[i, j].Display, j * Board.TileHeight);
                    GameArea.Children.Add(Board.Positions[i, j].Display);
                }
            }
            GameArea.Children.Add(line);
            Label name = new Label
            {
                Content = player.Name + " " + player.Score,
            };
            Canvas.SetTop(name, Board.Height * Board.TileHeight);
            Canvas.SetLeft(name, (Board.Width * Board.TileWidth) / 2);
            GameArea.Children.Add(name);
        }
        public void Game()
        {
            GameArea.Width = Board.Width * Board.TileWidth;
            GameArea.Height = Board.Height * Board.TileHeight + 27;
            switch (_gameState)
            {
                case GameStates.Init:
                    Button playerVersusPlayer = new Button
                    {
                        Width = 100,
                        Height = 50,
                        Content = "Player vs Player"
                    };
                    Canvas.SetTop(playerVersusPlayer, 30);
                    Canvas.SetLeft(playerVersusPlayer, ((Board.Width * Board.TileWidth) / 2) - 50);
                    GameArea.Children.Add(playerVersusPlayer);
                    playerVersusPlayer.Click += PlayerVersusPlayer;
                    Button playerVersusAI = new Button
                    {
                        Width = 100,
                        Height = 50,
                        Content = "Player vs AI"
                    };
                    Canvas.SetTop(playerVersusAI, 90);
                    Canvas.SetLeft(playerVersusAI, ((Board.Width * Board.TileWidth) / 2) - 50);
                    GameArea.Children.Add(playerVersusAI);
                    playerVersusAI.Click += PlayerVersusAI;
                    break;
                case GameStates.Naming:
                    GameArea.Children.Clear();
                    switch (_gameMode)
                    {
                        case GameModes.PvP:
                            TextBox playerOneName = new TextBox
                            {
                                Width = 100,
                                Text = ""
                            };
                            Canvas.SetTop(playerOneName, 30);
                            Canvas.SetLeft(playerOneName, ((Board.Width * Board.TileWidth) / 2) - 50);
                            GameArea.Children.Add(playerOneName);
                            TextBox playerTwoName = new TextBox
                            {
                                Width = 100,
                                Text = "",
                            };
                            Canvas.SetTop(playerTwoName, 90);
                            Canvas.SetLeft(playerTwoName, ((Board.Width * Board.TileWidth) / 2) - 50);
                            GameArea.Children.Add(playerTwoName);
                            Button StartPvP = new Button
                            {
                                Width = 100,
                                Height = 50,
                                Content = "Play PvP"
                            };
                            Canvas.SetTop(StartPvP, 110);
                            Canvas.SetLeft(StartPvP, ((Board.Width * Board.TileWidth) / 2) - 50);
                            GameArea.Children.Add(StartPvP);
                            break;
                        case GameModes.PvAI:
                            TextBox playerName = new TextBox
                            {
                                Width = 100,
                                Text = ""
                            };
                            Canvas.SetTop(playerName, 30);
                            Canvas.SetLeft(playerName, ((Board.Width * Board.TileWidth) / 2) - 50);
                            GameArea.Children.Add(playerName);
                            Button StartPvE = new Button
                            {
                                Width = 100,
                                Height = 50,
                                Content = "Play PvE"
                            };
                            Canvas.SetTop(StartPvE, 110);
                            Canvas.SetLeft(StartPvE, ((Board.Width * Board.TileWidth) / 2) - 50);
                            GameArea.Children.Add(StartPvE);
                            break;
                    }
                    break;
                case GameStates.Game:

                    
                    break;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            _gameState = GameStates.Init;
            Board.CreateBoard(20, 10, 50, 50, Brushes.Black, Brushes.White);
            Game();
            /*DataBase.AddPlayer("asd");
            IPlayer player = Factory.CreatePlayer("PlayerOne", Player.Type.Human);
            IPlayer player2 = Factory.CreatePlayer("PlayerTwo", Player.Type.AI);
            Board.AddPlayer(player);
            Board.AddPlayer(player2);
            Factory.GeneratePlayerAreaList();
            Factory.CreateShip(player, 6, Board.Positions[0, 0], Ship.Orientation.Down);
            Factory.CreateShip(player2, 6, Board.Positions[10, 0], Ship.Orientation.Down);
            Factory.CreateShip(player2, 6, Board.Positions[15, 4], Ship.Orientation.Down);
            if (Factory.CreateShip(player, 5, Board.Positions[5, 3], Ship.Orientation.Right))
            {
                
            }
            IAI ai = new AI(player2);
            ai.Attack();
            //DisplayBoard();
            //player2.Actions.AttackOnCoordinate(Board.Positions[5, 4]);
            //player2.Actions.AttackOnCoordinate(Board.Positions[6, 3]);
            DisplayBoard(player);*/
        }

        private void GameArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(GameArea);
            int xNormalized = (int)((point.X / Board.TileWidth));
            int yNormalized = (int)((point.Y / Board.TileHeight));
            //CurrentPlayer().
            Board.PlayerList[1].Actions.AttackOnCoordinate(Board.Positions[xNormalized,yNormalized]);
            DisplayBoard(Board.PlayerList[1]);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.S) && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Board.PlayerList[1].Actions.AttackOnCoordinate(Board.Positions[1, 3]);
                DisplayBoard(Board.PlayerList[0]);
            }
        }
    }
}
