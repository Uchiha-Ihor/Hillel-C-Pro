using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2.Task_2
{
    internal abstract class MusicalInstrument
    {
        protected string Name;
        protected string Description;
        protected string HistoryInfo;

        public MusicalInstrument(string _name, string _description, string _history)
        {
            Name = _name;
            Description = _description;
            HistoryInfo = _history;
        }

        public virtual void Sound() { }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}");
        }

        public virtual void Desc()
        {
            Console.WriteLine($"Description: {Description}");
        }

        public virtual void History()
        {
            Console.WriteLine($"History: {HistoryInfo}");
        }
    }
}
