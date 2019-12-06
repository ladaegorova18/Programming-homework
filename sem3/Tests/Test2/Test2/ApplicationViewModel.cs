using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private XandOs game = new XandOs();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand newGame;

        public RelayCommand NewGame
        {
            get
            {
                return newGame ??
                  (newGame = new RelayCommand(obj =>
                  {
                      
                  }));
            }
        }
    }
}
