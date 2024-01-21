namespace RecentFilesHistory
{
    using System.Collections.Generic;
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
        /// Adds given item to the observable collection at first position if not found in collection, else item will be moved to first position of observable collection.
        /// </summary>
        /// <param name="pItem"></param>
        void Add(T pItem);


        /// <summary>
        /// Adds given items to the observable collection in the same manner like <see cref="Add(T)"/>. If number of items in observable collection has been exceeded, last item(s) will be removed.
        /// </summary>
        /// <param name="pItems"></param>
        void AddRange(IEnumerable<T> pItems);


        /// <summary>
        /// Clears the observable collection.
        /// </summary>
        void Clear();
    }
}