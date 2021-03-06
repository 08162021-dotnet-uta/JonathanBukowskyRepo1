
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using System;

/// <summary>
/// The Views namespace contains classes to control command line menu interactions
/// </summary>
namespace Project0.StoreApplication.Client.Views.CustomerMenu
{
    /// <summary>
    /// A view to provide the menu for customers to interact with their cart
    /// </summary>
    public class CustomerPurchaseView : BaseView, IView
    {
        private List<Product> _selectedProducts;
        public CustomerPurchaseView()
        {
            _selectedProducts = new();
        }

        private static readonly List<string> _menu = new()
        {
            "Show cart",
            "Add product to cart",
            "Remove product from cart",
            "Save and exit"
        };

        public List<string> GetMenuOptions()
        {
            return _menu;
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            int selection;
            nextView = null;
            if (!int.TryParse(input, out selection))
            {
                return Actions.REPEAT_PROMPT;
            }
            if (selection < 1 || selection > 4)
            {
                return Actions.REPEAT_PROMPT;
            }
            switch (selection)
            {
                case 1:
                    PrintCart();
                    return Actions.RERUN_MENU;
                case 2:
                    nextView = AddProductView();
                    return Actions.OPEN_SUBMENU;
                case 3:
                    nextView = RemoveProductView();
                    return Actions.OPEN_SUBMENU;
                case 4:
                    return Actions.CLOSE_MENU;
                default:
                    throw new NotImplementedException("Not all actions implemented");
            }
        }

        private void PrintCart()
        {
            Console.WriteLine($"{CurrentContext.Customer.Name}'s Cart:");
            if (CurrentContext.Cart.Count == 0)
            {
                Console.WriteLine("This cart is empty");
            }
            foreach (var product in CurrentContext.Cart)
            {
                Console.WriteLine($"\t{product}");
            }
        }

        private void AddProductToCart(Product product)
        {
            CurrentContext.Cart.Add(product);
        }

        private IView AddProductView()
        {
            var selector = new ProductSelectView();
            selector.HandleProductSelected = AddProductToCart;
            selector.Products = Storage.GetProducts();
            return selector;
            //RunView(selector, CurrentContext);
        }

        private void RemoveProductFromCart(Product product)
        {
            if (CurrentContext.Cart.Remove(product))
            {
                Console.WriteLine("Product removed from cart");
            }
            else
            {
                Console.WriteLine("Error removing product from cart");
            }
        }

        private IView RemoveProductView()
        {
            var selector = new ProductSelectView();
            selector.HandleProductSelected = RemoveProductFromCart;
            selector.Products = CurrentContext.Cart;
            return selector;
            //RunView(selector, CurrentContext);
        }
    }
}