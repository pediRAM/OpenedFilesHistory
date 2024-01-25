namespace RecentFilesHistory
{
    using System.Collections.ObjectModel;


    /// <summary>
    /// Defines generic methods to add single item with LRU policy to a limited <see cref="ObservableCollection{T}"/> (see also <see cref="Items"/> property!).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRecentFilesHistoryManager<T>
    {
        /// <summary>
        /// Gets/Sets the limitation of items in observable collection.
        /// </summary>
        int Capacity { get; set; }


        /// <summary>
        /// Contains the cached items.
        /// </summary>
        ObservableCollection<T> Items { get; set; }


        /// <summary>
        /// Contains total elements in collection.
        /// </summary>
        int Count { get; }


        /// <summary>
        /// Inserts given parameter as first item to the observable collection and returns TRUE if not found in collection, 
        /// else existing item will be moved to the first position in observable collection and FALSE will be returned.
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns>TRUE if item is inserted, otherwise FALSE when item is moved to the front of collection.</returns>
        bool PutAtFront(T pItem);


        /// <summary>
        /// Returns TRUE if given item has been found and removed from collection <see cref="Items"/>, else FALSE.
        /// </summary>
        /// <param name="pItem">Item to remove from collection.</param>
        /// <returns>TREU if given item found, else FALSE.</returns>
        bool Remove(T pItem);


        /// <summary>
        /// Clears the observable collection.
        /// </summary>
        void Clear();
    }
}