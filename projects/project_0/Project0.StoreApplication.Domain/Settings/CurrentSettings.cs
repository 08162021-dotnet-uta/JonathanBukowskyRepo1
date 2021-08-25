
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Domain.Settings
{
    /// <summary>
    /// Singleton - Stores current application settings
    /// </summary>
    public static class CurrentSettings
    {
        public static IApplicationSettings Settings { get; set; }
    }
}