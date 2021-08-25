
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using System;

namespace Project0.StoreApplication.Client.Views.CustomerMenu
{
    /// <summary>
    /// View to allow user to select a product
    /// </summary>
    public class ProductSelectView : BaseView, IView
    {
        public Action<Product> HandleProductSelected { get; set; }
        public List<Product> Products { get; set; }
        public List<string> GetMenuOptions()
        {
            return Products.ConvertAll((Product p) => p.ToString());
        }

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            if (selection < 1 || selection > Products.Count)
            {
                return false;
            }
            HandleProductSelected(Products[selection - 1]);
            return true;
        }


        /*
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

        public ProductSelectView(List<Product> tempCart) : base()
        {
            _selectedProducts = tempCart;
        }
        */
    }
}