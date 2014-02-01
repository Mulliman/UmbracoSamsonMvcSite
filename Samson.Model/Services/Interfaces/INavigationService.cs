using System.Collections.Generic;
using Samson.Model.DocumentTypes.Interfaces;

namespace Samson.Model.Services.Interfaces
{
    public interface INavigationService
    {
        IEnumerable<IPage> GetTopLevelNavigationPages();
    }
}