using System;
using System.Linq;

namespace CodeTest
{
    public class Product
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj) => obj is Product product &&
                Name == product.Name && Code == product.Code;

        public override int GetHashCode() => HashCode.Combine(Name, Code);

        public override string ToString() => $"{Name} ({Code})";
    }

    public class Exercise2
    {
        private void Snippet_LinqIntersect()
        {
            Product[] store1 = {
                new Product { Name = "apple", Code = 9 },
                new Product { Name = "orange", Code = 4 }, 
                new Product { Name = "lemon", Code = 29 }, 
                new Product { Name = "bannanas", Code = 7 } 
            };
            Product[] store2 = {
                new Product { Name = "apple", Code = 9 },
                new Product { Name = "lemon", Code = 12 }, 
                new Product { Name = "pinapple", Code = 15 },
                new Product { Name = "bannanas", Code = 7 },
            };
            var duplicates = store1.Intersect(store2);
            ConsoleTools.WriteCollection(duplicates);
            // [apple (9), bannanas (7)]
        }

        public void Run()
        {
            Snippet_LinqIntersect();
        }
    }

}