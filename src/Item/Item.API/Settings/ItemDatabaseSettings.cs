using System;
namespace Item.API.Settings
{
    public class ItemDatabaseSettings : IItemDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
