using Project1.StoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.StoreApplication.Business
{
    class CartManager : ICarts
    {
        // TODO: Use interface instead of concrete class?
        private Dictionary<Customer, Cart> _carts;
        public CartManager()
        {
            _carts = new();
        }

        public ICart GetCart(Customer customer)
        {
            if (!_carts.ContainsKey(customer))
            {
                _carts[customer] = new Cart();
            }
            return _carts[customer];
        }
    }
}
