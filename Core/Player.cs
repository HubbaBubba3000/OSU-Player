using OSU_Player.Data;
using Microsoft.Extensions.Logging;
namespace OSU_Player.Core {
    public class Player {
        private Beatmap _beatmap;
        private string beatmapName = ""; 
        private ILogger<Player> logger;
        private DefaultConfig config;
        public Beatmap currentBeatmap {
            get {return _beatmap;}
            set {
                _beatmap = value;
                if (audioEngine.stream == 0) 
                    logger.LogInformation("stream error - {err}", audioEngine.LastError);
                logger.LogInformation("currentBeatmap {cur}", value.Name);
            }
        }
        public AudioEngine audioEngine;
        public Player(AudioEngine ae, ILogger<Player> logger) {
            this.config = JsonParser<DefaultConfig>.TryParse("../App/Configs/Default.json");
            this.logger = logger;
            audioEngine = ae;
            audioEngine.Volume = config.Volume;
        }


        public void TooglePlayAndPause() {
            if (_beatmap == null) {
                logger.LogInformation("beatmap is null");
                return;
            }
            if (beatmapName != Path.Combine(_beatmap.FolderPath, _beatmap.AudioFile)) {
                    audioEngine.Stop();
                    beatmapName = Path.Combine(_beatmap.FolderPath, _beatmap.AudioFile);
                    audioEngine.CreateStream(beatmapName, audioEngine.Volume);
                }

            if (audioEngine.IsPlay) 
                audioEngine.Pause();
            else 
                audioEngine.Play();
        }
    }
}
