using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static LB6.Store;
using System.Xml.Linq;

namespace LB6 
{ 
    internal partial class Play : IDisposable
    {
        private bool disposed;

        public void DisplayInfo()
        {
            if (!disposed)
            {
                Console.WriteLine(this);
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
                EndPlay();
                disposed = true;
            }
        } 
    }
}
