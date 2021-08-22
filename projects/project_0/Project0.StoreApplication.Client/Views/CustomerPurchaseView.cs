
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client.Views
{
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

        public View AddProduct(Context context)
        {
            RunView(new ProductSelectView(_selectedProducts), context);
            return this;
        }

        public View SaveCart(Context context)
        {
            context.Cart.AddRange(_selectedProducts);
            return null;
        }
    }
}