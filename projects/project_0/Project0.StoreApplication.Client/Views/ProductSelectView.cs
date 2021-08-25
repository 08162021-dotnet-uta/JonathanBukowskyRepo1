
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Views
{
    /// <summary>
    /// View to allow user to select a product
    /// </summary>
    public class ProductSelectView : ItemSelectView<Product>
    {
        protected override List<Product> GetItems()
        {
            //return ProductRepository.Factory().Products;
            return Storage.GetProducts();
        }

        protected override View HandleSelectedItem(Context context, int choice)
        {
            //_selectedProducts.Add(ProductRepository.Factory().Products[choice - 1]);
            _selectedProducts.Add(Storage.GetProducts()[choice - 1]);
            return null;
        }

        private List<Product> _selectedProducts;
        public ProductSelectView(List<Product> tempCart) : base()
        {
            _selectedProducts = tempCart;
        }


    }
}