using System;
using System.Collections.Generic;
using System.Linq;

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
            var buddies = new List<Buddy>() {
                new Buddy(1, "Sylvester", "UK"),
                new Buddy(7, "Bogdan", "Poland", 51000.00m),
                new Buddy(3, "Mark", "UK", 65000.00m),
                new Buddy(2, "Robert", "Poland", 43000.00m),
                new Buddy(6, "Akos", "UK", 49000.00m),
                new Buddy(9, "Sergey", "Ukraine", 34000.00m)
            };
            ConsoleTools.WriteCollection(buddies);
            Snippet_LinqSelect(buddies);
            Snippet_LinqDistinct(buddies);
            Snippet_LinqAggregate(buddies);
            Snippet_LinqWhere(buddies);
            Snippet_LinqCount(buddies);
            Snippet_LinqAll(buddies);
            Snippet_LinqSumAvgMax(buddies);
            Snippet_LinqOrderByDescending_ThenBy(buddies);
        }

        private void Snippet_LinqSelect(List<Buddy> buddies)
        {
            IEnumerable<string> namelist = buddies
                .Select(buddy => buddy.Name);
            ConsoleTools.WriteCollection(namelist);
            // [Sylvester, Bogdan, Mark, Robert, Akos, Sergey]
        }

        private void Snippet_LinqDistinct(List<Buddy> buddies)
        {
            var countries = buddies
                .Select(buddy => buddy.Country)
                .Distinct();
            ConsoleTools.WriteCollection(countries);
            // [UK, Poland, Ukraine]
        }

        private void Snippet_LinqAggregate(List<Buddy> buddies)
        {
            var buddiesByCountry = buddies
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
        }

        private void Snippet_LinqWhere(List<Buddy> buddies)
        {
            var polishBuddies = buddies
                .Where(buddy => buddy.Country == "Poland");
            ConsoleTools.WriteCollection(polishBuddies);
            // [7=Bogdan (Poland), 2=Robert (Poland)]
        }

        private void Snippet_LinqCount(List<Buddy> buddies)
        {
            var polishBuddiesCounter = buddies
                .Count(buddy => buddy.Country == "Poland");
            Console.WriteLine(polishBuddiesCounter);
            // 2
        }

        private void Snippet_LinqAll(List<Buddy> buddiesAll)
        {
            var onlyBritishBuddies = buddiesAll.All(buddy => buddy.Country == "UK");
            var msg = onlyBritishBuddies ? "I can speak only English" : "I'm a polyglot";
            Console.WriteLine(msg);
            // I'm a polyglot
        }

        private void Snippet_LinqSumAvgMax(List<Buddy> buddies)
        {
            var total = buddies.Where(buddy => buddy.Salary.HasValue)
                .Sum(buddy => buddy.Salary.Value);
            var avg = buddies.Where(buddy => buddy.Salary.HasValue)
                .Average(buddy => buddy.Salary.Value);
            var max = buddies.Where(buddy => buddy.Salary.HasValue)
                .Max(buddy => buddy.Salary.Value);
            Console.WriteLine($"Total: {total:n0}  Average: {avg:n0}  Maximum: {max:n0}");
            // Total: 242,000  Average: 48,400  Maximum: 65,000
        }

        private void Snippet_LinqOrderByDescending_ThenBy(List<Buddy> buddies)
        {
            var buddiesOrdered = buddies
                .OrderByDescending(buddy => buddy.Country)
                .ThenBy(buddy => buddy.Name);
            ConsoleTools.WriteCollection(buddiesOrdered);
            // [9=Sergey (Ukraine), 6=Akos (UK), 3=Mark (UK), 1=Sylvester (UK), 7=Bogdan (Poland), 2=Robert (Poland)]
        }
    }
}