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
        public Nullable<decimal> Salary { get; private set; }
        public Buddy() { }
        public Buddy(int no, string text, string country)
        {
            NO = no;
            Name = text;
            Country = country;
        }
        public Buddy(int no, string text, string country, decimal salary)
        {
            NO = no;
            Name = text;
            Country = country;
            Salary = salary;
        }
        public override string ToString() => $"{NO}={Name} ({Country})";
    }

    public class Exercise1
    {
        public void Run()
        {
            var buddiesAll = new List<Buddy>() {
                new Buddy(1, "Sylvester", "UK"),
                new Buddy(7, "Bogdan", "Poland", 51000),
                new Buddy(3, "Mark", "UK", 65000),
                new Buddy(2, "Robert", "Poland", 43000),
                new Buddy(6, "Akos", "UK", 49000),
                new Buddy(9, "Sergey", "Ukraine", 34000)
            };
            ConsoleTools.WriteCollection(buddiesAll);
            // [1=Sylvester (UK), 7=Bogdan (Poland), 3=Mark (UK), 2=Robert (Poland), 6=Akos (UK), 9=Sergey (Ukraine)]

            // -- Linq Select ---------------------------
            IEnumerable<string> namelist = buddiesAll
                .Select(buddy => buddy.Name);
            ConsoleTools.WriteCollection(namelist);
            // [Sylvester, Bogdan, Mark, Robert, Akos, Sergey]

            // -- Linq Distinct ---------------------------
            var countries = buddiesAll
                .Select(buddy => buddy.Country)
                .Distinct();
            ConsoleTools.WriteCollection(countries);
            // [UK, Poland, Ukraine]

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
            // [UK=3, Poland=2, Ukraine=1]

            // -- Linq Where ---------------------------
            var polishBuddies = buddiesAll
                .Where(buddy=>buddy.Country == "Poland");
            ConsoleTools.WriteCollection(polishBuddies);
            // [7=Bogdan (Poland), 2=Robert (Poland)]

            // -- Linq Count ---------------------------
            var polishBuddiesCounter = buddiesAll
                .Count(buddy=>buddy.Country == "Poland");
            Console.WriteLine(polishBuddiesCounter);
            // 2

            // -- Linq All ---------------------------
            var onlyBritishBuddies = buddiesAll.All(buddy=>buddy.Country=="UK");
            var msg = onlyBritishBuddies ? "I can speak only English" : "I'm a polyglot";
            Console.WriteLine(msg);
            // I'm a polyglot

            // -- Linq Sum, Average, Max ---------------------------
            var total = buddiesAll.Where(buddy=>buddy.Salary.HasValue)
                .Sum(buddy=>buddy.Salary.Value);
            var avg = buddiesAll.Where(buddy=>buddy.Salary.HasValue)
                .Average(buddy=>buddy.Salary.Value);
            var max = buddiesAll.Where(buddy=>buddy.Salary.HasValue)
                .Max(buddy=>buddy.Salary.Value);
            Console.WriteLine($"Total: {total:n0}  Average: {avg:n0}  Maximum: {max:n0}");
            // Total: 242,000  Average: 48,400  Maximum: 65,000
   

            // TODO: OrderByDescending (Country) ThenBy (Name)
            // TODO: Intersect https://docs.microsoft.com/pl-pl/dotnet/api/system.linq.enumerable.intersect?view=netcore-3.1
        }
    }
}