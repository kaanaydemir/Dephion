using System;
namespace Item.API.Settings
{
    public interface IItemDatabaseSettings
    {
        string CollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
