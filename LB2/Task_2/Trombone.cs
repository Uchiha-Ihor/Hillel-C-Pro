using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_2
{
    internal class Trombone : MusicalInstrument
    {
        public Trombone() : base("Trombone", "A brass instrument with a sliding tube.", "The first trombones appeared in the 15th century in Europe.") { }

        public override void Sound()
        {
            Console.WriteLine("The trombone produces a deep and rich sound.");
        }
    }
}
