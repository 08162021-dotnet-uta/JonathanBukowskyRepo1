
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

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            if (selection < 1 || selection > 4)
            {
                return false;
            }
            NextView = this;
            switch (selection)
            {
                case 1:
                    PrintCart();
                    break;
                case 2:
                    AddProduct();
                    break;
                case 3:
                    RemoveProduct();
                    break;
                case 4:
                    NextView = null;
                    break;
            }
            return true;
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

        private void AddProduct()
        {
            var selector = new ProductSelectView();
            selector.HandleProductSelected = AddProductToCart;
            selector.Products = Storage.GetProducts();
            RunView(selector, CurrentContext);
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

        private void RemoveProduct()
        {
            var selector = new ProductSelectView();
            selector.HandleProductSelected = RemoveProductFromCart;
            selector.Products = CurrentContext.Cart;
            RunView(selector, CurrentContext);
        }
        /*
public CustomerPurchaseView() : base()
{
   _selectedProducts = new();
   RegisterAction(new MenuAction() { Description = "Add product to cart", DoAction = AddProduct });
   RegisterAction(new MenuAction() { Description = "Save to cart", DoAction = SaveCart });
   RegisterAction(new MenuAction() { Description = "Discard changes", DoAction = (Context context) => null });
}

/// <summary>
/// Show the product selection view
/// </summary>
/// <param name="context"></param>
/// <returns></returns>
public View AddProduct(Context context)
{
   RunView(new ProductSelectView(_selectedProducts), context);
   return this;
}

/// <summary>
/// Save cart and exit customer purchase view
/// </summary>
/// <param name="context"></param>
/// <returns></returns>
public View SaveCart(Context context)
{
   context.Cart.AddRange(_selectedProducts);
   return null;
}
*/
    }
}