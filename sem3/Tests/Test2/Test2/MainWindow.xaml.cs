using System.Windows;
using System.Windows.Controls;

namespace Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// count of used cells
        /// </summary>
        public static int Count { get; set; } = 0;

        /// <summary>
        /// values in cells
        /// </summary>
        public string[,] Values { get; set; } = new string[3, 3];

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
            ++Count;
            if (Count % 2 != 0)
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
            Count = 0;
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
                        Values[row - 1, column] = ((Button)grid.Children[currentCell]).Content.ToString();
                        currentCell++;
                    }
                }
            }
            if (CheckWin("X"))
            {
                return 1;
            }
            if (CheckWin("O"))
            {
                return 2;
            }
            if (Count == 9)
            {
                return 3;
            }
            else return 0;
        }

        /// <summary>
        /// checks if current player wins
        /// </summary>
        /// <param name="player"> player "X" or "O" </param>
        /// <returns> true if wins </returns>
        private bool CheckWin(string player)
        {
            return
            ((Values[0, 0] == player & Values[0, 1] == player & Values[0, 2] == player)
                ||
            (Values[0, 0] == player & Values[1, 0] == player & Values[2, 0] == player)
                ||
            (Values[2, 0] == player & Values[2, 1] == player & Values[2, 2] == player)
                ||
            (Values[0, 2] == player & Values[1, 2] == player & Values[2, 2] == player)
                ||
            (Values[0, 0] == player & Values[1, 1] == player & Values[2, 2] == player)
                ||
            (Values[0, 2] == player & Values[1, 1] == player & Values[2, 0] == player)
                ||
            (Values[1, 0] == player & Values[1, 1] == player & Values[1, 2] == player)
                ||
            (Values[0, 1] == player & Values[1, 1] == player & Values[2, 1] == player));
        }
    }
}
