using BlazorWordle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlazorWordle.Tests
{
    public class WordleMatcherTests
    {
        [Fact]
        public void TrialResult_All_Misses()
        {
            var trial = new char[] { 'a','a','a','a','a' };
            var solution = new char[] { 's','p','i','c','y' };

            var actual = WordleMatcher.Match(trial, solution);
            Assert.True(actual.Letters.All(l => l.Result == ResultValue.Miss));
        }

        [Fact]
        public void TrialResult_All_Hits()
        {
            var trial = new char[] { 's','p','i','c','y' };
            var solution = new char[] { 's','p','i','c','y' };

            var actual = WordleMatcher.Match(trial, solution);
            Assert.True(actual.Letters.All(l => l.Result == ResultValue.Hit));
        }        
        
        [Fact]
        public void TrialResult_Partial_Hit()
        {
            var trial = new char[] { 's','p','i','c','e' };
            var solution = new char[] { 's','p','i','c','y' };

            var actual = WordleMatcher.Match(trial, solution);
            Assert.True(actual.Letters[0].Result == ResultValue.Hit);
            Assert.True(actual.Letters[1].Result == ResultValue.Hit);
            Assert.True(actual.Letters[2].Result == ResultValue.Hit);
            Assert.True(actual.Letters[3].Result == ResultValue.Hit);
            Assert.True(actual.Letters[4].Result == ResultValue.Miss);
        }

        [Fact]
        public void TrialResult_Position()
        {
            var trial = new char[] { 'c', 'h', 'i', 'm', 'e' };
            var solution = new char[] { 's', 'p', 'i', 'c', 'y' };

            var actual = WordleMatcher.Match(trial, solution);
            Assert.True(actual.Letters[0].Result == ResultValue.Position);
            Assert.True(actual.Letters[1].Result == ResultValue.Miss);
            Assert.True(actual.Letters[2].Result == ResultValue.Hit);
            Assert.True(actual.Letters[3].Result == ResultValue.Miss);
            Assert.True(actual.Letters[4].Result == ResultValue.Miss);
        }
    }
}
