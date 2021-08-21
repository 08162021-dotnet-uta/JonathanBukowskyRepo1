
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Views
{
    public class ProductSelectView : CustomerView
    {
        public ProductSelectView() : base()
        {
            _selectedProducts = new();
        }
        private List<Product> _selectedProducts;
        public override View Run(Context context)
        {
            Console.WriteLine(PrintAllProducts());
            int choice = SelectFromMenu(AddMenu, 3);
            if (choice == 1)
            {
                var product = SelectProduct();
                if (product != null)
                {
                    _selectedProducts.Add(product);
                }
                return this;
            }
            else if (choice == 2)
            {
                context.Cart.AddRange(_selectedProducts);
                //return new CustomerView();
            }
            else if (choice == 3)
            {

            }
            return null;
        }

        private Product SelectProduct()
        {
            var products = ProductRepository.Factory().Products;
            int choice = SelectFromMenu(PrintAllProducts, products.Count, false);
            if (choice < 1 || choice > products.Count)
            {
                return null;
            }
            return products[choice - 1];
        }

        public static string AddMenu()
        {
            var menu =
                " 1 - Select product to add to cart\n" +
                " 2 - Save changes to cart\n" +
                " 3 - Discard changes\n";
            return menu;
        }
    }
}