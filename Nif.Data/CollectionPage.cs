using System;
using System.Collections.Generic;

namespace Nif.Data
{
    /// <summary>
    /// Holds relevant information related to a page of a collection of information.
    /// </summary>
    public class CollectionPage<T>
    {
        /// <summary>
        /// A page of items.
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Total number of items, regardless of page.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The number of items that should be shown per page.
        /// </summary>
        public int ItemsPerPage { get; set; }

        ///<summary>
        /// The current page index.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int TotalPages
        {
            get { return (int)(Math.Ceiling((Decimal)TotalItems / ItemsPerPage)); }
        }

        /// <summary>
        /// Indicates is there any items on requested page number.
        /// </summary>
        public bool HasItemsOnRequestedPage
        {
            get { return CurrentPage <= TotalPages; }
        }
    }
}