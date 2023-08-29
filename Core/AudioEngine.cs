using ManagedBass;

namespace OSU_Player.Core {
    public class AudioEngine {

        double Volume;

        int stream;
        string audioFile;

        int Output;

        public AudioEngine(double volume, string file) {
            
        }

        public void CreateStream(string file, double volume) {
            stream = Bass.CreateStream(file);
            Bass.GlobalStreamVolume = (int)(volume*100);
            
        }
        public void Start() {

        }
        public void Stop() {

        }
    }
} 