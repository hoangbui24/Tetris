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
        }

        private Image[,] SetUp(GameGrid gameGrid)
        {
            Image[,] imageControl = new Image[gameGrid.Rows, gameGrid.Cols];
            int cellSize = 25;

            for (int i = 0; i < gameGrid.Rows; i++)
            {
                for (int j = 0; j < gameGrid.Cols; j++)
                {
                    Image image = new Image()
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
