using ManagedBass;
using Microsoft.Extensions.Logging;

namespace OSU_Player.Core {
    public class AudioEngine {
        ILogger<AudioEngine> logger;
        private int volumebuffer;
        public int Volume {
            get {
                return Bass.GlobalStreamVolume ;
            }
            set {
                Bass.GlobalStreamVolume = value;
            }
        }
        public bool IsMute {
            get {
                return (Volume == 0);
            }
            set {
                if (value) {
                    volumebuffer = Volume;
                    Volume = 0;
                }
                else {
                    Volume = volumebuffer;

                }
            }
        }

        public double Position {
            get {
                if (stream != 0) {
                    return Bass.ChannelBytes2Seconds(stream,
                        Bass.ChannelGetPosition(stream, PositionFlags.Bytes));
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
                        Bass.ChannelGetLength(stream, PositionFlags.Bytes));
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
        private int _stream;
        public int stream {
            get {
                return _stream;
            }
            set {
                _stream = value;
            }
        }
        public string audioFile {
            get {
                if (stream != 0) {
                    return Bass.ChannelGetInfo(stream).FileName;
                }
                else return $"error : {LastError}";
            }
        }

        public int Output {
            get {
                int device;
                if (stream != 0) device = Bass.ChannelGetDevice(stream);
                else device = -2; 
                if (device == -1) logger.LogError("output device = -1 | {err}", LastError);
                return device;
            }
        }
        public AudioEngine(ILogger<AudioEngine> logger) {
            this.logger = logger;
            if (Bass.Init(1)) 
                logger.LogInformation("BassInit ok");
            else 
                logger.LogInformation("init error {err}", Bass.LastError);

        }
        

        public void CreateStream(string file, int volume) {
            stream = Bass.CreateStream(file);
            logger.LogInformation(
                @" stream info :
                        lasterror : {lasterror}
                        stream : {stream}
                        file : {file}
                        volume : {volume}
                        output : {output}
                ",
                LastError,stream, audioFile, volume, Output); 

            Volume = volume;
            
        }
        public void Play() {
            
            if (!IsPlay) {
                Bass.ChannelPlay(stream);
                IsPlay = true;
                logger.LogInformation("stream play");
            }
        }
        public void Pause() {
            if (IsPlay) {
                Bass.ChannelPause(stream);
                IsPlay = false;
                logger.LogInformation("stream pause");
            }
        }

        public void Stop() {
            if (IsPlay) {
                Bass.ChannelStop(stream);
                IsPlay = false;
            }
            if (stream != 0)
                Bass.StreamFree(stream);

            logger.LogInformation("stream stop");
        }

    }
} 