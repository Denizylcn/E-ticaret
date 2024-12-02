namespace MultiShop.Catalog.Settings
{
    public class DatabaseSettings2 : IDatabaseSettings2
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
