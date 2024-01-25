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
    public abstract class ARecentFilesHistoryManager<T> : INotifyPropertyChanged, IRecentFilesHistoryManager<T> where T : IComparable<T>, IEquatable<T>
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Variables
        private int _Capacity = 10;
        private ObservableCollection<T> _Items = new ObservableCollection<T>();        
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

                if (value == _Capacity)
                    return;

                _Capacity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Capacity)));

                // Remove elements that exceed capacity!
                TrimItems();
            }
        }


        /// <summary>
        /// Contains the cached items.
        /// </summary>
        public virtual ObservableCollection<T> Items
        {
            get => _Items;
            set
            {
                if (value == _Items)
                    return;

                _Items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }


        /// <summary>
        /// Contains total elements in collection <see cref="Items"/>.
        /// </summary>
        public virtual int Count => Items.Count;
        #endregion Properties


        #region Methods

        /// <summary>
        /// Inserts an item with LRU policy (Least Recently Used) and:
        /// <para>returns TRUE: If item is not found in collection <see cref="Items"/>: inserts given item as first element, else</para>
        /// <para>returns FALSE: moves found item in collection to the front (first position).</para>
        /// <para>Notice: Null arguments will be ignored, FALSE returned and no exception will be thrown.!</para>
        /// </summary>
        /// <param name="pItem">Item to put into the front of collection or move it there.</param>
        /// <returns>TRUE if item has been added, otherwise FALSE when item moved to front or given item is NULL.</returns>
        public virtual bool PutAtFront(T pItem)
        {
            if (null == pItem)
                return false;

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

            return foundItem == null;
        }


        /// <summary>
        /// Adds given items to the observable collection in the same order as they are and 
        /// extra items which exceed the Capacity are ignored.
        /// <para>This method is used internally or by implementors when loading items from file or other sources.</para>
        /// <para>IMPORTANT: DO NOT CALL THIS METHOD FOR USUAL ACTIVITIES LIKE INSERTING/SAVING PATHS!</para>
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
        /// Returns TRUE if given item has been found and removed from collection <see cref="Items"/>, else FALSE.
        /// </summary>
        /// <param name="pItem">Item to remove from collection.</param>
        /// <returns>TREU if given item found, else FALSE.</returns>
        public virtual bool Remove(T pItem)
        {
            if (!Items.Contains(pItem))
                return false;
            
            return Items.Remove(pItem); ;
        }


        /// <summary>
        /// Remove elements that exceed capacity!
        /// </summary>
        protected virtual void TrimItems()
        {
            while (_Capacity < Items.Count)
                Items.RemoveAt(Items.Count - 1);
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
