
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;

/// <summary>
/// The Views namespace contains classes to control command line menu interactions
/// </summary>
namespace Project0.StoreApplication.Client.Views.CustomerMenu
{
    /// <summary>
    /// A view to provide the menu for customers to interact with their cart
    /// </summary>
    public class CustomerPurchaseView : StaticMenuView
    {
        private List<Product> _selectedProducts;
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
    }
}