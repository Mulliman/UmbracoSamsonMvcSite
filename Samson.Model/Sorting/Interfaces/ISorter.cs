using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Model.Sorting.Interfaces
{
    public interface ISorter
    {
        IEnumerable<T> Sort<T>(IEnumerable<T> items);
    }
}
