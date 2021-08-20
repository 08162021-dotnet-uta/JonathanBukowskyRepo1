
using Project0.StoreApplication.Domain.Abstracts;

namespace Project0.StoreApplication.Domain.Models
{
    public class GroceryStore : Store
    {
        public GroceryStore() : base()
        {
            Name = "Grocery: " + Name;
        }
        public GroceryStore(string name) : base(name) { }

    }
}