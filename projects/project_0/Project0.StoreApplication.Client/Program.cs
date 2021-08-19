using System;
using System.Collections.Generic;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAllStoreLocations();
        }

        static void PrintAllStoreLocations()
        {
            var storeLocations = new List<Store>()
            {
                new Store(),
                new Store()
            };

            foreach (var store in storeLocations)
            {
                Console.WriteLine(store);
            }
        }
    }
}
