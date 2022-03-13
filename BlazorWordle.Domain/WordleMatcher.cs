using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordle.Domain
{
    public class WordleMatcher
    {
        public static TrialResult Match (char[] trial, char[] solution)
        {
            var letters = 
                trial.Select<char, LetterResult>((t, i) => {
                    if (t == solution[i]) return new LetterResult { Letter = t, Result = ResultValue.Hit };
                    else if (solution.Contains(t)) return new LetterResult { Letter = t, Result = ResultValue.Position }; 
                    return new LetterResult { Letter = t, Result = ResultValue.Miss };
                });
            return new TrialResult { Letters = letters.ToArray() };
        }

    }
}
