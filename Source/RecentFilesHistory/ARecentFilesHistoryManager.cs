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


    /// <summary>
    /// Implements <see cref="IRecentFilesHistoryManager{T}"/> and defines abstract 
    /// methods <see cref="Load"/> and <see cref="Save"/> for loading and saving items persistently.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ARecentFilesHistoryManager<T> : IRecentFilesHistoryManager<T> where T : IComparable<T>, IEquatable<T>
    {
        #region Variables

        private int _Capacity = 10;
        #endregion Variables


        #region Properties

        /// <summary>
        /// Gets/Sets the limitation of items in observable collection.
        /// </summary>
        public virtual int Capacity
        {
            get => _Capacity;
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(Capacity));

                _Capacity = value;

                // Remove items when downsized!
                while (_Capacity < Items.Count)
                    Items.RemoveAt(Items.Count - 1);
            }
        }


        /// <summary>
        /// Contains the cached items.
        /// </summary>
        public virtual ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();
        #endregion Properties


        #region Methods

        /// <summary>
        /// Inserts an item with LRU (Least Recently Used) policy: inserts given argument as first 
        /// item to the observable collection if not found in collection, else updates item position 
        /// by moving it to the first position of observable collection.
        /// <para>Notice: Null arguments will be ignored!</para>
        /// </summary>
        /// <param name="pItem"></param>
        public virtual void PutAtFront(T pItem)
        {
            if (null == pItem)
                return;

            // Is item already cached?
            var foundItem = Items.FirstOrDefault(p => p.Equals(pItem));
            if (foundItem == null)
            {
                // No! Given item is new one.
                Items.Insert(0, pItem);
            }
            else
            {
                // Yes! Move already saved item to first position.
                int index = Items.IndexOf(foundItem);
                if (index != 0)
                    Items.Move(index, 0);
            }

            // Remove last item if number of items exceeded.
            if (Items.Count > Capacity)
                Items.RemoveAt(Items.Count - 1);
        }


        /// <summary>
        /// Adds given items to the observable collection in the same order as they are and 
        /// extra items which exceed the Capacity are ignored.
        /// <para>This method is used internally or by implementors when loading items from file or other sources.</para>
        /// <para>IMPORTANT: DO NOT CALL THIS METHOD FOR USUAL ACTIVITIES LIKE SAVING PATHS!</para>
        /// </summary>
        /// <param name="pItems"></param>
        protected virtual void AddRange(IEnumerable<T> pItems)
        {
            foreach (var pItem in pItems)
            {
                if (Items.Count == Capacity)
                    return;

                Items.Add(pItem);
            }
        }


        /// <summary>
        /// Clears the observable collection.
        /// </summary>
        public virtual void Clear() => Items.Clear();


        /// <summary>
        /// Implement this method to load items of observable collection from file or any other source.
        /// </summary>
        public abstract void Load();


        /// <summary>
        /// Implement this method to save items in observable collection persistently in a file or other target.
        /// </summary>
        public abstract void Save();

        #endregion Methods
    }
}
