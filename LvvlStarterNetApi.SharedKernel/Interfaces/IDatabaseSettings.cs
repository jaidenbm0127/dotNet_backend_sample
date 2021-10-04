namespace LvvlStarterNetApi.SharedKernel
{
    public interface IDatabaseSettings
    {
        string BlogsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}