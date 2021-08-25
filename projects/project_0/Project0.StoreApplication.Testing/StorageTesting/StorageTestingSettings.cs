
using Project0.StoreApplication.Domain.Interfaces;

/// <summary>
/// Tests specific to storage project
/// </summary>
namespace Project0.StoreApplication.Testing.StorageTesting
{
    /// <summary>
    /// Settings object to provide settings definition for testing environment
    /// </summary>
    public class StorageTestingSettings : IApplicationSettings
    {
        private static readonly string testDataDir = "/home/jon/revature/my_code/data/project_0/test_data/";
        public string GetDataDir()
        {
            return testDataDir;
        }
    }
}