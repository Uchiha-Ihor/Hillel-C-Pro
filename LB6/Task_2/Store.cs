using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LB6.Store;

namespace LB6
{
    internal partial class Store (string name, string address, StoreType storeType) : IDisposable
    {
        private bool disposed;

        public enum StoreType
        {
            Grocery,
            Household,
            Clothing,
            Footwear
        }

        public override string ToString()
        {
            return $"Name"; 
        }

        public void DisplayInfo()
        {
            if (!disposed)
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"StoreType: {storeType}");
                Console.WriteLine("-------------------");
            }
            else
            {
                Console.WriteLine("Error object was deleted");
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine($"Shop '{name}' delete from heap.");
                disposed = true;
            }
        }

    }
}
