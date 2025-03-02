using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_2
{
    internal class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Ukulele", "A small four-string guitar from Hawaii.", "The ukulele originated from Portugal but became popular in Hawaii in the 19th century.") { }

        public override void Sound()
        {
            Console.WriteLine("The ukulele produces a light and cheerful sound.");
        }
    }
}
