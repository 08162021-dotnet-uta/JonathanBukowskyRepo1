using Project0.StoreApplication.Domain.Settings;

namespace Project0.StoreApplication.Testing.StorageTesting.RepositoryTesting
{
    /// <summary>
    /// Provides functionality to arrange Repositiories for testing
    /// </summary>
    public static class RepositorySetup
    {
        public static void InitializeSettings()
        {
            CurrentSettings.Settings = new StorageTestingSettings();
        }
    }
}