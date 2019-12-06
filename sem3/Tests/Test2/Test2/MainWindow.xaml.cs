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

namespace Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int count = 0;
        string[,] values = new string[3, 3];

        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in grid.Children)
            {
                if (c is Button)
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
            count++;
            if (count % 2 != 0)
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
                    break;
                case 2:
                    MessageBox.Show("Player O WIN!");
                    break;
            }
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            foreach (UIElement c in grid.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Content = "";
                }
            }
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
                        values[row - 1, column] = ((Button)grid.Children[currentCell]).Content.ToString();
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
            else return 0;
        }

        /// <summary>
        /// checks if current player wins
        /// </summary>
        /// <param name="player"> player "X" or "O" </param>
        /// <returns> true if wins </returns>
        private bool CheckWin(string player)
        {
            if (values[0, 0] == player & values[0, 1] == player & values[0, 2] == player)
                return true;
            else if (values[0, 0] == player & values[1, 0] == player & values[2, 0] == player)
                return true;
            else if (values[2, 0] == player & values[2, 1] == player & values[2, 2] == player)
                return true;
            else if (values[0, 2] == player & values[1, 2] == player & values[2, 2] == player)
                return true;
            else if (values[0, 0] == player & values[1, 1] == player & values[2, 2] == player)
                return true;
            else if (values[0, 2] == player & values[1, 1] == player & values[2, 0] == player)
                return true;
            else if (values[1, 0] == player & values[1, 1] == player & values[1, 2] == player)
                return true;
            else if (values[0, 1] == player & values[1, 1] == player & values[1, 2] == player)
                return true;
            else
            {
                return false;
            }
        }
    }
}
