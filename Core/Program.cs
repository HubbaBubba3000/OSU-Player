using ManagedBass;

namespace OSU_Player.Core {
	public class CoreBass {
        int stream;
        public CoreBass() {
            stream = Bass.CreateStream(@"C:\Users\WinRAR\Documents\yakui the maid\Goodnight World - 2019\2. Calamity.mp3");
            Bass.Init();
        }
		public void Run() {
            Console.WriteLine(Bass.CPUUsage);
			if (Bass.Init())
            {
                // Create a stream from a file
                
                if (stream != 0)
                    Bass.ChannelPlay(stream);

                // Free the stream
                
            }
            else {
                throw new Exception("bass not init");
            }
		}
        public void Stop() {
            Bass.StreamFree(stream);

                // Free current device.
                Bass.Free();
        }
    } 
}