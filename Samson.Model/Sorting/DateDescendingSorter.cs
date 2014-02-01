using System.Collections.Generic;
using System.Linq;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Sorting.Interfaces;

namespace Samson.Model.Sorting
{
    public class DateDescendingSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> items)
        {
            return items.Where(i => i is IDateSortable)
                .Cast<IDateSortable>()
                .OrderByDescending(i => i.GetSortingDate())
                .Cast<T>();
        }
    }
}