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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] imageSources = new ImageSource[]
        {
            new BitmapImage(new Uri("HinhAnh/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileRed.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/TilePurple.png", UriKind.Relative)),
        };

        private readonly ImageSource[] TetrominoesImage = new ImageSource[]
        {
            new BitmapImage(new Uri("HinhAnh/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-Z.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("HinhAnh/Block-T.png", UriKind.Relative)),

        };

        private readonly Image[,] imageControl;

        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            imageControl = SetUp(gameState.gameGrid);
        }

        private Image[,] SetUp(GameGrid gameGrid)
        {
            Image[,] imageControl = new Image[gameGrid.Rows, gameGrid.Cols];
            int cellSize = 25;

            for (int i = 0; i < gameGrid.Rows; i++)
            {
                for (int j = 0; j < gameGrid.Cols; j++)
                {
                    Image image = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };
                    Canvas.SetTop(image, (i - 2) * cellSize);
                    Canvas.SetLeft(image, j * cellSize);
                    GameCanvas.Children.Add(image);
                    imageControl[i,j] = image;
                }
            }
            return imageControl;
        }
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Cols; c++)
                {
                    int id = grid[r,c];
                    imageControl[r,c].Source = imageSources[id];
                }    
            }    
        }

        private void DrawTetro(Tetrominoes tetrominoes)
        {
            foreach(Pos p in tetrominoes.TilePositions())
            {
                imageControl[p.Row, p.Column].Source = imageSources[tetrominoes.Id];
            }
        }

        private void Draw(GameState gamestate)
        {
            DrawGrid(gamestate.gameGrid);
            DrawTetro(gamestate.CurrentTetro);
        }
        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                await Task.Delay(500);
                gameState.MoveDown();
                Draw(gameState);
            }
            GameOverMenu.Visibility = Visibility.Visible;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                case Key.D:
                    gameState.MoveLeft();
                    break;
                case Key.Right:
                case Key.A:
                    gameState.MoveRight();
                    break;
                case Key.Down:
                case Key.S:
                    gameState.MoveDown();
                    break;
                case Key.Up:
                case Key.W:
                    gameState.RotateTetroCW();
                    break;
                case Key.Space:
                case Key.Z:
                    gameState.RotateTetroCCW();
                    break;
                default:
                    return;
            }
            Draw(gameState);
        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }

        

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
