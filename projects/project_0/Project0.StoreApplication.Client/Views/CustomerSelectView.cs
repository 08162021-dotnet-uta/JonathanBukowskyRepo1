
using Project0.StoreApplication.Storage.Repositories;

namespace Project0.StoreApplication.Client.Views
{
    public class CustomerSelectView : View
    {
        public override View Run(Context context)
        {
            var customers = CustomerRepository.Factory().Customers;
            int customerId = SelectFromMenu(PrintCustomers, customers.Count);
            context.Customer = customers[customerId - 1];
            System.Console.WriteLine("Hello, " + context.Customer.Name);
            return new CustomerView();
        }

        public string PrintCustomers()
        {
            var customers = CustomerRepository.Factory().Customers;
            string output = "";
            int i = 1;
            foreach (var customer in customers)
            {
                output += (i++) + " - " + customer.Name + "\n";
            }
            return output;
        }
    }
}