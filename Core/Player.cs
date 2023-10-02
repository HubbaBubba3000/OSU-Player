using OSU_Player.Data;

namespace OSU_Player.Core {
    public class Player {
        private Beatmap _beatmap;
        private DefaultConfig config;
        public Beatmap currentBeatmap {
            get {return _beatmap;}
            set {
                _beatmap = value;
                audioEngine.CreateStream(Path.Combine(_beatmap.FolderPath, _beatmap.FileName), config.Volume);
            }
        }
        public AudioEngine audioEngine;
        public Player(AudioEngine ae) {
            this.config = DefaultConfig.Default;
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
