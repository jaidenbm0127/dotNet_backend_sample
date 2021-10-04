using System.Collections.Generic;
using System.Linq;
using LvvlStarterNetApi.Core.Models;

namespace LvvlStarterNetApi.SharedKernel.Interfaces
{
    public interface IBlogService
    {
        List<Blog> Get();
    }
}
