namespace RecentFilesHistory
{
    using System;
    using System.Text.Json;
    using System.IO;
    using System.Text;
    using System.Linq;

    public class RecentFilesHistoryManager : APathHistoryManager
    {
        private string _Path;


        /// <summary>
        /// Constructs a new instance and sets the path to the json file, where all paths will be loaded/saved persistently.
        /// </summary>
        /// <param name="pPath"></param>
        /// <exception cref="ArgumentNullException">When given path is NULL.</exception>
        /// <exception cref="ArgumentException">When given path is empty or consists only of whitecharacters.</exception>
        public RecentFilesHistoryManager(string pPath)
        {
            if (pPath == null)
                throw new ArgumentNullException(nameof(pPath));

            if (string.IsNullOrWhiteSpace(pPath)) 
                throw new ArgumentException($"Path cannot be NULL, empty or consist only of whitespaces!", nameof(pPath));

            _Path = pPath;
        }


        /// <summary>
        /// Loads all saved paths from json file.
        /// </summary>
        public override void Load()
            => AddRange(JsonSerializer.Deserialize<string[]>(File.ReadAllText(_Path, Encoding.UTF8)));


        /// <summary>
        /// Saves all paths to json file.
        /// </summary>
        public override void Save()
            => File.WriteAllText(_Path, JsonSerializer.Serialize<string[]>(Paths.ToArray(), new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8 );
    }
}
