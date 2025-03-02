using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_2
{
    internal class Cello : MusicalInstrument
    {
        public Cello() : base("Cello", "A large bowed string instrument.", "The cello was developed in the 16th century in Italy.") { }

        public override void Sound()
        {
            Console.WriteLine("The cello produces a deep and warm sound.");
        }
    }
}
