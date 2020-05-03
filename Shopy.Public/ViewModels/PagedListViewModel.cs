using System.Collections.Generic;

namespace Shopy.Public.ViewModels
{
    public class PagedListViewModel<TItem>
    {
        public IEnumerable<TItem> Items { get; set; }

        public long TotalRecords { get; set; }

        public PagedListViewModel(IEnumerable<TItem> items, int totalRecords)
        {
            Items = items;
            TotalRecords = totalRecords;
        }
    }
}