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
                new Buddy(3, "Mark", "UK"),
                new Buddy(2, "Robert", "Poland"),
                new Buddy(6, "Akos", "UK"),
                new Buddy(9, "Sergey", "Ukraine")
            };
            ConsoleTools.WriteCollection(buddiesAll);

            // -- Linq Select ---------------------------
            IEnumerable<string> namelist = buddiesAll
                .Select(buddy => buddy.Name);
            ConsoleTools.WriteCollection(namelist);

            // -- Linq Distinct ---------------------------
            var countries = buddiesAll
                .Select(buddy => buddy.Country)
                .Distinct();
            ConsoleTools.WriteCollection(countries);

            // -- Linq Aggreagate ---------------------------
            var buddiesByCountry = buddiesAll
                .Aggregate<Buddy, Dictionary<string, int>>(
                    new Dictionary<string, int>(),
                    (dict, buddy) =>
                    {
                        if (dict.ContainsKey(buddy.Country))
                            dict[buddy.Country] += 1;
                        else
                            dict[buddy.Country] = 1;
                        return dict;
                    }
                );
            var printlist = buddiesByCountry
                .Select(pair => $"{pair.Key}={pair.Value}");
            ConsoleTools.WriteCollection(printlist);
        }
    }
}