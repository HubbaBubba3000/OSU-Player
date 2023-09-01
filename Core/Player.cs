using OSU_Player.Data;

namespace OSU_Player.Core {
    public class Player {
        private Beatmap _beatmap;
        private DefaultConfig config;
        public Beatmap currentBeatmap {
            get {return _beatmap;}
            set {
                _beatmap = value;
                audioEngine.CreateStream(_beatmap.FileName, config.Volume);
            }
        }
        AudioEngine audioEngine;
        public Player(AudioEngine ae, DefaultConfig config) {
            this.config = config;
            audioEngine = ae;
        }

        public void TooglePlayAndPause() {
            if (_beatmap == null) return;
            
            if (audioEngine.IsPlay) {
                audioEngine.Pause();
            } else {
                audioEngine.Play();
            }
        }
    }
}
