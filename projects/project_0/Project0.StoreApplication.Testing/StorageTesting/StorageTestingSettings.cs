
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Testing.StorageTesting
{
    public class StorageTestingSettings : IApplicationSettings
    {
        private static readonly string testDataDir = "/home/jon/revature/my_code/data/project_0/test_data/";
        public string GetDataDir()
        {
            return testDataDir;
        }
    }
}