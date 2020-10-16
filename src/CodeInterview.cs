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

        public void Run()
        {
            Console.WriteLine("Hello");
        }
    }
}
