using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace LvvlStarterNetApi.SharedKernel.Interfaces
{
    public interface IBlog
    {
        ObjectId Id { get; set; }
        string Author { get; set; }
        string Title { get; set; }
        string Text { get; set; }
    }
}
