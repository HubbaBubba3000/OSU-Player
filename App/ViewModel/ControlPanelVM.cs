using OSU_Player.Core;
using System;
using System.Windows.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
namespace OSU_Player.ViewModel {
    public class ControlPanelVM : BaseVM {
        Player player;
        // todo implement position timer
        DispatcherTimer timer;
        bool IsDrag = false;
        public ControlPanelVM(Player player) {
            this.player = player;
            timer = new DispatcherTimer(TimeSpan.FromSeconds(0.5),DispatcherPriority.ApplicationIdle, new EventHandler(TimerHandler), Dispatcher.CurrentDispatcher);
            timer.Start();
        }

        public void TimerHandler(object? sender, EventArgs e) {
            if (player.audioEngine.IsPlay) {
                Position = 0;

            }

        }

        public int Volume {
            get {
                return player.audioEngine.Volume;
            }
            set {
                IsMute = (value == 0);
                    player.audioEngine.Volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public bool IsMute {
            get {
                return player.audioEngine.IsMute;
            }
            set {
                player.audioEngine.IsMute = value;
                OnPropertyChanged("IsMute");
            }
        }

        public double Position {
            get {
                return player.audioEngine.Position;
            }
            set {
                if (IsDrag) 
                    player.audioEngine.Position = value;

                TimePosition = TimeSpan.Zero;
                OnPropertyChanged("Position");
            }
        }
        public TimeSpan TimePosition {
            get {
                return TimeSpan.FromMilliseconds(Position);
            }
            set {
                OnPropertyChanged("Position");
            }
        }

        public double Length {
            get {
                return player.audioEngine.Length;
            }
            set {
                TimeLength = TimeSpan.Zero;
                OnPropertyChanged("Length");
            }
        }
        public TimeSpan TimeLength {
            get {
                return TimeSpan.FromMilliseconds(Length);
            }
            set {
                OnPropertyChanged("Length");
            }
        }

        public ICommand TooglePlayAndPause {
            get {
                return new RelayCommand((obj) => { player.TooglePlayAndPause(); });
            }
        }
        public ICommand MuteAudio {
            get {
                return new RelayCommand((obj) => {IsMute = !IsMute; });
            }
        }
        public ICommand DragStart {
            get {
                return new RelayCommand((obj) => { IsDrag = true; });
            }
        }
        public ICommand DragEnd {
            get {
                return new RelayCommand((obj) => { IsDrag = false; });
            }
        }
    }
}