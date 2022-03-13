using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordle.Domain
{
    public class TrialResult
    {
        public LetterResult[] Letters { get; set; } = new LetterResult[5];
    }

    public class LetterResult {

        public char Letter { get; set; }
        public ResultValue Result { get; set; }
    }

    public enum ResultValue { Hit, Miss, Position}
}
