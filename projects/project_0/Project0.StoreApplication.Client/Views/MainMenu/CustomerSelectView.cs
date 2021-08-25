
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Client.Views.CustomerMenu;

namespace Project0.StoreApplication.Client.Views.MainMenu
{
    /// <summary>
    /// A View to display customers and allow user to select one
    /// </summary>
    public class CustomerSelectView : BaseView, IView
    {
        public List<string> GetMenuOptions()
        {
            return Storage.GetCustomers().ConvertAll((Customer c) => c.ToString());
        }

        public bool HandleUserInput(string input)
        {
            int selection;
            if (!int.TryParse(input, out selection))
            {
                return false;
            }
            // NOTE: not thread safe
            var customers = Storage.GetCustomers();
            if (selection < 1 || selection > customers.Count)
            {
                return false;
            }
            CurrentContext.Customer = customers[selection - 1];
            NextView = new CustomerView();
            return true;
        }
    }
}