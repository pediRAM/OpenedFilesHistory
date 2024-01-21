namespace RecentFilesHistory
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    #endregion Usings


    public abstract class AbstractPathHistoryManager : IPathHistoryManager, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events


        #region Variables

        private int _Capacity = 10;

        #endregion Variables


        #region Properties

        /// <summary>
        /// Gets/Sets the maximum of saved paths.
        /// </summary>
        public int Capacity
        {
            get => _Capacity;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(Capacity));

                _Capacity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Capacity)));
            }
        }


        /// <summary>
        /// Contains saved paths.
        /// </summary>
        public virtual ObservableCollection<string> Paths { get; set; } = new ObservableCollection<string>();

        #endregion Properties


        #region Methods

        /// <summary>
        /// Adds given path to saved paths.
        /// <para>If the number of items in <see cref="Paths"/> is exeeding the <see cref="Capacity"/>, then the last item will be removed.</para>
        /// <para>If the given path argument already exists in <see cref="Paths"/>, then the path will be moved to the first position of collection.</para>
        /// </summary>
        /// <param name="pPath">Path of file or directory.</param>
        public virtual void Add(string pPath)
        {
            if (string.IsNullOrWhiteSpace(pPath))
                return;

            // Is path already saved?
            var foundPath = Paths.FirstOrDefault(p => p.Equals(pPath, StringComparison.InvariantCultureIgnoreCase));
            if (foundPath == null)
            {
                // No! Given path is new one.
                Paths.Insert(0, pPath);
            }
            else
            {
                // Yes! Move already saved path to first position.
                int index = Paths.IndexOf(foundPath);
                if (index != 0)
                    Paths.Move(index, 0);
            }

            // Remove last item if number of items exceeded.
            if (Paths.Count > Capacity)
                Paths.RemoveAt(Paths.Count - 1);
        }


        /// <summary>
        /// Adds all paths to given paths, ignoring already existing/saved items in <see cref="Paths"/> property.
        /// </summary>
        /// <param name="pPaths"></param>
        public virtual void AddRange(IEnumerable<string> pPaths)
        {
            foreach (var pFilePath in pPaths)
                Paths.Add(pFilePath);
        }


        /// <summary>
        /// Removes all items from <see cref="Paths"/> property.
        /// </summary>
        public virtual void Clear() => Paths.Clear();


        /// <summary>
        /// Loads paths into <see cref="Paths"/> property.
        /// <para>This should always be done at first, before first call of <see cref="Add"/> or <see cref="AddRange(IEnumerable{string})"/>!</para>
        /// </summary>
        public abstract void Load();


        /// <summary>
        /// Will save all items in <see cref="Paths"/>.
        /// </summary>
        public abstract void Save();

        #endregion Methods


    }
}
