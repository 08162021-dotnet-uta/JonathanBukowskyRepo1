
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Client
{
    /// <summary>
    /// Default implementation of Settings object for StoreApplication
    /// </summary>
    public class ApplicationSettings : IApplicationSettings
    {
        private static readonly string dataDir = "/home/jon/revature/my_code/data/project_0/data/";
        public string GetDataDir()
        {
            return dataDir;
        }
    }
}