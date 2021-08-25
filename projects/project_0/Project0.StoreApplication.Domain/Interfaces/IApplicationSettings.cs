
namespace Project0.StoreApplication.Domain.Interfaces
{
    /// <summary>
    /// Interface for accessing program settings
    /// </summary>
    public interface IApplicationSettings
    {
        string GetDataDir();
        string GetProductsFile()
        {
            return GetDataDir() + "products.xml";
        }
        string GetStoresFile()
        {
            return GetDataDir() + "stores.xml";
        }
        string GetCustomersFile()
        {
            return GetDataDir() + "customers.xml";
        }
        string GetOrdersFile()
        {
            return GetDataDir() + "orders.xml";
        }
    }
}