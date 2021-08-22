
using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Views
{
    public class CustomerSelectView : ItemSelectView<Customer>
    {
        protected override List<Customer> GetItems()
        {
            return CustomerRepository.Factory().Customers;
        }

        protected override View HandleSelectedItem(Context context, int choice)
        {
            context.Customer = GetItems()[choice - 1];
            Console.WriteLine("Hello, " + context.Customer);
            return new CustomerView();
        }

    }
}