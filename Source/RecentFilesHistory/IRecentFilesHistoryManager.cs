namespace RecentFilesHistory
{
    using System.Collections.ObjectModel;


    /// <summary>
    /// Defines generic methods to add single or multiple items to a limited <see cref="ObservableCollection{T}"/> (see also <see cref="Items"/> property!).
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
        /// Inserts given parameter as first item to the observable collection if not found in collection, 
        /// else existing item will be moved to the first position in observable collection.
        /// </summary>
        /// <param name="pItem"></param>
        void PutAtFront(T pItem);


        /// <summary>
        /// Clears the observable collection.
        /// </summary>
        void Clear();
    }
}