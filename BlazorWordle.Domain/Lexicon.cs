using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordle.Domain
{
    public class Lexicon
    {
        public static IReadOnlyCollection<string> Words =
            new List<string>
            {
                "asset",
                "bears",
                "cache",
                "drool",
                "emirs",
                "idiom",
                "phase",
                "wordy"
            };

        public static string DrawRandomWord()
        {
            var s = new Random(System.DateTime.Now.Millisecond);
            var index = s.Next(0, Words.Count - 1);
            return Words.ElementAt(index);
        }
    }
}
