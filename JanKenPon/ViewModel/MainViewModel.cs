using JanKenPon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JanKenPon.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private JKPResult _player;
        private JKPResult _computer;

        private Random _rand;

        public MainViewModel()
        {
            Player = JKPResult.None;
            Computer = JKPResult.None;
            _rand = new Random();
            Play = new ParameterizedRelayCommand(
                (param) =>
                {
                    if (param is /*JKPResult*/ string)
                    {
                        switch (param)
                        {
                            case /*JKPResult.Rock*/ "1": Player = JKPResult.Rock; break;
                            case /*JKPResult.Paper*/ "2": Player = JKPResult.Paper; break;
                            case /*JKPResult.Scissors*/ "3": Player = JKPResult.Scissors; break;
                            default: Player = JKPResult.None; break;
                        }
                        Computer = (JKPResult)_rand.Next(3) + 1;
                    }
                        
                },
                (param) => true
            );
        }

        public JKPResult Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged();
            }
        }
        public JKPResult Computer
        {
            get
            {
                return _computer;
            }
            set
            {
                _computer = value;
                NotifyPropertyChanged();
            }
        }

        public  ParameterizedRelayCommand Play { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
