using ManagedBass;
using Microsoft.Extensions.Logging;

namespace OSU_Player.Core {
    public class AudioEngine {

        public int Volume {
            get {
                return Bass.GlobalStreamVolume ;
            }
            set {
                Bass.GlobalStreamVolume = value;
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
            set {
                Bass.ChannelSetPosition(stream, Bass.ChannelSeconds2Bytes(stream, value));
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
        public string LastError {
            get {
                return Bass.LastError.ToString();
            }
        }
        public bool IsPlay;

         public int stream;
        public string audioFile {
            get {
                if (stream != 0) {
                    return Bass.ChannelGetInfo(stream).FileName;
                }
                else return "err";
            }
        }

        public int Output {
            get {
                if (stream != 0) {
                   return Bass.ChannelGetDevice(stream);
                } else return -1;
            }
        }
        public AudioEngine() {
            
            Bass.Init();
        }

        public void CreateStream(string file, int volume) {
            stream = Bass.CreateStream(file);
            
            Volume = volume;
            
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