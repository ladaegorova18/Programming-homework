using System.Windows;
using System.Windows.Controls;

namespace Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private XandOs game = new XandOs();

        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement c in grid.Children)
            {
                if (c is Button && ((Button)c).Tag.ToString().CompareTo("cell") == 0)
                {
                    ((Button)c).Click += CellClick;
                }
            }
        }

        /// <summary>
        /// Current player's turn
        /// </summary>
        private void CellClick(object sender, RoutedEventArgs e)
        {
            ++game.Count;
            if (game.Count % 2 != 0)
            {
                ((Button)e.OriginalSource).Content = "X";
                ((Button)e.OriginalSource).IsEnabled = false;
            }
            else
            {
                ((Button)e.OriginalSource).Content = "O";
                ((Button)e.OriginalSource).IsEnabled = false;
            }

            switch (Ended())
            {
                case 1:
                    MessageBox.Show("Player X WIN!");
                    Restart(sender, e);
                    break;
                case 2:
                    MessageBox.Show("Player O WIN!");
                    Restart(sender, e);
                    break;
                case 3:
                    MessageBox.Show("Nobody wins!");
                    Restart(sender, e);
                    break;
            }
        }

        //Restarts the game
        public void Restart(object sender, RoutedEventArgs e)
        {
            foreach (UIElement c in grid.Children)
            {
                if (c is Button && ((Button)c).Tag.ToString().CompareTo("cell") == 0)
                {
                    ((Button)c).Content = "";
                    ((Button)c).IsEnabled = true;
                }
            }
            game.Count = 0;
        }

        private int Ended()
        {
            var element = new UIElement();
            for (int k = 1; k < 4; k++)
            {
                int currentCell = 0;
                for (int row = 1; row < 4; row++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        game.Values[row - 1, column] = ((Button)grid.Children[currentCell]).Content.ToString();
                        currentCell++;
                    }
                }
            }
            if (game.CheckWin("X"))
            {
                return 1;
            }
            if (game.CheckWin("O"))
            {
                return 2;
            }
            if (game.Count == 9)
            {
                return 3;
            }
            else return 0;
        }
    }
}
