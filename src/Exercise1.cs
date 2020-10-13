using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest
{

    public class Buddy
    {
        public int NO { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public Buddy() { }
        public Buddy(int no, string text, string country)
        {
            NO = no;
            Name = text;
            Country = country;
        }
        public override string ToString() => $"{NO}={Name} ({Country})";
    }

    public class Exercise1
    {
        public void Run()
        {
            var buddiesAll = new List<Buddy>() {
                new Buddy(1, "Sylvester", "UK"),
                new Buddy(7, "Bogdan", "Poland"),
                new Buddy(3, "Daniel", "UK"),
                new Buddy(2, "Robert", "Poland")
            };
            ConsoleTools.WriteCollection(buddiesAll);

            // -- Linq Select ---------------------------
            IEnumerable<string> namelist = buddiesAll.Select(it => it.Name);
            ConsoleTools.WriteCollection(namelist);

            // -- Linq Distinct ---------------------------
            var countries = buddiesAll.Select(bu=>bu.Country).Distinct();
            ConsoleTools.WriteCollection(countries);
        }
    }
}