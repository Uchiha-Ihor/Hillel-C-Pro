using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB6
{
    internal partial class Play (string title, string author, string genre, int year)
    {
        private bool playing;

        public string GetTitle () => title;
        public string GetAuthor() => author;
        public string GetGenre() => genre;
        public int GetYear() => year;


        public bool isPlaying() { Console.WriteLine(this); return playing; }

        public void StartPlay() { Console.WriteLine($"The play begins. \n{this}"); playing = true; }

        public void EndPlay() { Console.WriteLine($"The play ends. \n{this}"); playing = false; }

        public override string ToString()
        {
            return $" Title: {title} \n Author: {author} \n Genre: {genre} \n Year: {year}";
        }

        ~Play(){
            Dispose();
        }

    }
}
