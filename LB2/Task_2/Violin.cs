using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_2
{
    internal class Violin : MusicalInstrument
    {
        public Violin() : base("Violin", "A bowed string instrument.", "The violin originated in the 16th century in Italy.") { }

        public override void Sound()
        {
            Console.WriteLine("The violin produces a melodic and expressive sound.");
        }
    }
}
