using LvvlStarterNetApi.SharedKernel;

namespace LvvlStarterNetApi.Infrastructure
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BlogsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}