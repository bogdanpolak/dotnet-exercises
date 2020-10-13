using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest {
    
    public class Foo 
    {
        public int No { get; private set; } 
        public string Text { get; private set; }
        public Foo() {}
        public Foo(int no, string text)
        {
            No = no;
            Text = text;
        }
    }
    
    public class Exercise1
    {
        public void Run() {
            var list = new List<Foo>() {
                new Foo(1, "Sylvester"),
                new Foo(5, "Bogdan"),
                new Foo(3, "Daniel")
            };
            var length = list.Count;
            var date = DateTime.Now;
            Console.WriteLine($"Collection lenght: {length}  [{date:t}]");
        }
    }
}