
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Client.Views.Common;
using System;
using Serilog;

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

        public string GetPrompt()
        {
            return "\n\n\tPlease select a product: ";
        }

        public Actions HandleUserInput(string input, out IView nextView)
        {
            Log.Information($"Inside ProductSelect handleInput");
            nextView = null;
            if (!int.TryParse(input, out int selection))
            {
                Log.Information($"Invalid input {input}");
                return Actions.REPEAT_PROMPT;
            }
            if (selection < 1 || selection > Products.Count)
            {
                Log.Information($"Invalid selection {selection}");
                return Actions.REPEAT_PROMPT;
            }
            HandleProductSelected(Products[selection - 1]);
            return Actions.CLOSE_MENU;
        }

    }
}