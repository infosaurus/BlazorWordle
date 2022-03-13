using BlazorWordle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordle.Tests
{
    public class TestHelpers
    {
        public static LetterResult miss = new LetterResult { Letter = 'w', Result = ResultValue.Miss };
        public static LetterResult hit = new LetterResult { Letter = 'w', Result = ResultValue.Hit };
        public static TrialResult AllMiss = new TrialResult { Letters = new LetterResult[] { miss, miss, miss, miss, miss } };
        public static TrialResult AllHit = new TrialResult { Letters = new LetterResult[] { hit, hit, hit, hit, hit } };
    }
}
