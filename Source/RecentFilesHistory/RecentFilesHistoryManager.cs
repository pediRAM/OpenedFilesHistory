namespace RecentFilesHistory
{
    #region Usings
    using System;
    using System.Text.Json;
    using System.IO;
    using System.Text;
    using System.Linq;
    #endregion Usings


    /// <summary>
    /// Provides limited additive ObservaleCollection with LRU (Least Recently Used) policy.
    /// <para><see cref="Save"/> method will save the paths in persistent in a json file.</para>
    /// </summary>
    public class RecentFilesHistoryManager : ARecentFilesHistoryManager<string>
    {
        private string _Path;


        /// <summary>
        /// Constructs a new instance and sets the path to the json file, where all paths will be loaded/saved persistently.
        /// </summary>
        /// <param name="pPath">Path to json file for loading/saving paths to/from observable collection Itmes.</param>
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
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public override void Load()
        {
            Clear();
            AddRange(JsonSerializer.Deserialize<string[]>(File.ReadAllText(_Path, Encoding.UTF8)));
        }


        /// <summary>
        /// Saves all paths to json file.
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public override void Save()
            => File.WriteAllText(_Path, JsonSerializer.Serialize<string[]>(Items.ToArray(), new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8 );
    }
}
