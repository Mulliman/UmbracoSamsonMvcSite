using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Model.DocumentTypes.Interfaces
{
    public interface IListablePage : IPage
    {
        string Summary { get; set; }

        int ArticleImageId { get; set; }

        IList<string> Tags { get; set; }
    }
}