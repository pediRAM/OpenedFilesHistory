using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecentFilesHistory
{
    /// <summary>
    /// Defines provided methods of path history manager.
    /// </summary>
    public interface IPathHistoryManager
    {

        /// <summary>
        /// Gets/Sets the maximum of saved paths.
        /// </summary>
        int Capacity { get; set; }


        /// <summary>
        /// Contains saved paths.
        /// </summary>
        ObservableCollection<string> Paths { get; set; }


        /// <summary>
        /// Adds given path to saved paths.
        /// <para>If the number of items in <see cref="Paths"/> is exeeding the <see cref="Capacity"/>, then the last item will be removed.</para>
        /// <para>If the given path argument already exists in <see cref="Paths"/>, then the path will be moved to the first position of collection.</para>
        /// </summary>
        /// <param name="pPath">Path of file or directory.</param>
        void Add(string pPath);


        /// <summary>
        /// Adds all paths to given paths, ignoring already existing/saved items in <see cref="Paths"/> property.
        /// </summary>
        /// <param name="pPaths"></param>
        void AddRange(IEnumerable<string> pPaths);


        /// <summary>
        /// Removes all items from <see cref="Paths"/> property.
        /// </summary>
        void Clear();


        /// <summary>
        /// Loads paths into <see cref="Paths"/> property.
        /// <para>This should always be done at first, before first call of <see cref="Add"/> or <see cref="AddRange(IEnumerable{string})"/>!</para>
        /// </summary>
        void Load();


        /// <summary>
        /// Will save all paths from <see cref="Paths"/>.
        /// </summary>
        void Save();
    }
}