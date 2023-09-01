using ManagedBass;

namespace OSU_Player.Core {
    public class AudioEngine {

        public double Volume {
            get {
                return Bass.GlobalStreamVolume / 100;
            }
            set {
                Bass.GlobalStreamVolume = (int)(value*100);
            }
        }
        public double Position {
            get {
                if (stream != 0) {
                    return Bass.ChannelBytes2Seconds(stream,
                        Bass.ChannelGetPosition(stream, PositionFlags.Relative));
                }
                else return 0;
            }
        }
        public double Length {
            get {
                if (stream != 0) {
                    return Bass.ChannelBytes2Seconds(stream,
                        Bass.ChannelGetLength(stream, PositionFlags.Relative));
                }
                else return 0;
            }
        }
        public bool IsPlay;

        int stream;
        string audioFile {
            get {
                if (stream != 0) {
                    return Bass.ChannelGetInfo(stream).FileName;
                }
                else return Bass.LastError.ToString();
            }
        }

        int Output {
            get {
                if (stream != 0) {
                   return Bass.ChannelGetDevice(stream);
                } else return -1;
            }
        }

        public AudioEngine() {
            
        }

        public void CreateStream(string file, double volume) {
            stream = Bass.CreateStream(file);
            Bass.GlobalStreamVolume = (int)(volume*100);
            
        }
        public void Play() {
            if (!IsPlay) {
                Bass.ChannelPlay(stream);
                IsPlay = true;
            }
        }
        public void Pause() {
            if (!IsPlay) {
                Bass.ChannelPause(stream);
                IsPlay = false;
            }
        }

        public void Stop() {
            if (IsPlay) {
                Bass.ChannelStop(stream);
            }
            Bass.StreamFree(stream);
        }

    }
} 