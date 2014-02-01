using System.Collections.Generic;
using System.Linq;
using Samson.Model.DocumentTypes.Interfaces;
using Samson.Model.Sorting.Interfaces;

namespace Samson.Model.Sorting
{
    public class DateAscendingSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> items)
        {
            return items.Where(i => i is IDateSortable)
                .Cast<IDateSortable>()
                .OrderBy(i => i.GetSortingDate())
                .Cast<T>();
        }
    }
}