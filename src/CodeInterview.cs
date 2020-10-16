using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest
{
    public class CodeInterview
    {
        /* ===== Expected output ===== */
        // Chef's menu:
        // STARTERS
        // tartare or pancake
        // MAINS
        // risotto, salmon or lamb
        // DESSERTS
        // icecream

        Dictionary<string, List<string>> MENU = new Dictionary<string, List<string>> {
            { "starters", new List<string>(){ "tartare", "pancake", "salad" } },
            { "mains", new List<string>(){ "risotto", "lamb", "haddock", "salmon", "steak" } },
            { "desserts", new List<string>(){ "sorbet", "icecream", "cheesecake" } }
        };
        List<string> CHEFS_DISHES = new List<string>() {
            "tartare","risotto","salmon","icecream","pancake","lamb"};

        public string GenerateServed(string category)
        {
            var list = MENU[category].Intersect(CHEFS_DISHES).ToList();
            var sb = new StringBuilder();
            for (var i = 0; i < list.Count; i++) {
                if (i>0 && i == list.Count - 1)
                    sb.Append(" or ");
                else if (i > 0)
                    sb.Append(", ");
                sb.Append(list[i]);
            }
            return sb.ToString();
        }

        public void Run()
        {
            var codeInterview = new CodeInterview();
            Console.WriteLine("Chef's menu:");
            Console.WriteLine("STARTERS");
            Console.WriteLine(codeInterview.GenerateServed("starters"));
            Console.WriteLine("MAINS");
            Console.WriteLine(codeInterview.GenerateServed("mains"));
            Console.WriteLine("DESSERTS");
            Console.WriteLine(codeInterview.GenerateServed("desserts"));
        }
    }
}
