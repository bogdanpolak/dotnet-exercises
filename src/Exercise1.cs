using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest
{

    public class Foo
    {
        public int No { get; private set; }
        public string Text { get; private set; }
        public string Country { get; private set; }
        public Foo() { }
        public Foo(int no, string text, string country)
        {
            No = no;
            Text = text;
            Country = country;
        }
        public override string ToString() => $"{No}={Text} ({Country})";
    }

    public class Exercise1
    {
        public void Run()
        {
            var list = new List<Foo>() {
                new Foo(1, "Sylvester", "UK"),
                new Foo(7, "Bogdan", "Poland"),
                new Foo(3, "Daniel", "UK"),
                new Foo(2, "Robert", "Poland")
            };
            ConsoleTools.WriteCollection(list);
            
            // -- Linq select ---------------------------
            var list2 = list.Select(it => it.No);
            ConsoleTools.WriteCollection(list2);
        }
    }
}