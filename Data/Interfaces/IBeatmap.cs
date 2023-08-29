
namespace OSU_Player.Data {

    public interface IBeatmap {
        /// <summary>
        /// music author 
        /// </summary>
        string Artist { get; }

        string Name { get; }

        /// <summary>
        /// audio length in milliseconds
        /// </summary>
        int length { get; }  

        string FileName { get; }

        string FolderPath { get; }

    }
}