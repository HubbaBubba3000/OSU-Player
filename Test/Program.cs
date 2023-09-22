using OSU_Player.Core;

namespace OSU_Player.Test {
    public class Test {

        public static void Main(string[] args) {
            var audio = new AudioEngine();

            audio.CreateStream("dataset/calamity.mp3", 1000);
            audio.Play();
            if (audio.IsPlay) {
                Console.WriteLine(audio.Output);
                Console.WriteLine("audio is play");
            }
            //wait
            Console.ReadLine();
        }
    }
}