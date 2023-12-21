using OSU_Player.Core;
using System;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
namespace OSU_Player.ViewModel {
    public class ControlPanelVM : BaseVM {
        Player player;
        MainPageVM page;
        DispatcherTimer timer;
        ILogger<ControlPanelVM> logger;
        public bool IsDrag = false;
        public ControlPanelVM(Player player, MainPageVM page, ILogger<ControlPanelVM> logger) {
            this.player = player;
            this.logger = logger;
            this.page = page;
            timer = new DispatcherTimer(TimeSpan.FromSeconds(1),DispatcherPriority.ApplicationIdle, new EventHandler(TimerHandler), Dispatcher.CurrentDispatcher);
            //timer.Stop();
        }
        public bool IsPlay {
            get {
                return player.audioEngine.IsPlay;
            }
            set {
                OnPropertyChanged("IsPlay");
            }
        }

        public void TimerHandler(object? sender, EventArgs e) {               
            if (IsPlay) {
              //  if (!IsDrag) 
                    Position = player.audioEngine.Position;
              //  logger.LogInformation("timer ");

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
               // if (IsDrag) 
               if (player.audioEngine.Position != value)
                    player.audioEngine.Position = value;

                TimePosition = TimeSpan.Zero;
                OnPropertyChanged("Position");
            }
        }
        public TimeSpan TimePosition {
            get {
                return TimeSpan.FromSeconds(Position);
            }
            set {
                OnPropertyChanged("TimePosition");
            }
        }

        public double Length {
            get {
                return player.audioEngine.Length;
            }
            set {
                TimeLength = TimeSpan.FromSeconds(value);
                OnPropertyChanged("Length");
            }
        }
        public TimeSpan TimeLength {
            get {
                return TimeSpan.FromSeconds(Length);
            }
            set {
                OnPropertyChanged("TimeLength");
            }
        }
        public ICommand PrevBeatmap {
            get {
                return new RelayCommand ((obj) => {
                    page.Current = page.List[page.List.IndexOf(player.currentBeatmap) - 1];
                    Length = 0;
                },
                (obj) => ((page.List.IndexOf(player.currentBeatmap) > 0)));
            }
        }
        public ICommand NextBeatmap {
            get {
                return new RelayCommand ((obj) => {
                    page.Current = page.List[page.List.IndexOf(player.currentBeatmap) + 1];
                    Length = 0;
                },
                (obj) => (page.List.IndexOf(player.currentBeatmap) < page.List.Count));
            }
        }
        public ICommand TooglePlayAndPause {
            get {
                return new RelayCommand((obj) => { 
                    player.TooglePlayAndPause();
                    IsPlay = true;
                    Length = player.audioEngine.Length;
                    TimeLength = TimeSpan.Zero;
                });
            }
        }
        public ICommand MuteAudio {
            get {
                return new RelayCommand((obj) => {IsMute = !IsMute; });
            }
        }
        
        // public ICommand DragStart {
        //     get {
        //         return new RelayCommand((obj) => { 
        //             IsDrag = true; 
        //             logger.LogInformation("drag true");
        //         });
        //     }
        // }
        // public ICommand DragEnd {
        //     get {
        //         return new RelayCommand((obj) => { 
        //             IsDrag = false; 
        //             logger.LogInformation("drag false");
        //         });
        //     }
        // }
    }
}