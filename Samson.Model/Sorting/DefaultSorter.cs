using System.Collections.Generic;
using Samson.Model.Sorting.Interfaces;

namespace Samson.Model.Sorting
{
    public class DefaultSorter : ISorter
    {
        public IEnumerable<T> Sort<T>(IEnumerable<T> items)
        {
            return items;
        }
    }
}