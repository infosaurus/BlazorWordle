using Xunit;
using BlazorWordle.Domain;

namespace BlazorWordle.Tests
{
    public class GameTests
    {
        [Fact]
        public void If_Trial_Fails_Game_Stays_Pending()
        {
            var game = new PendingGame { Trials = 0 };
            var state = Game.Transition(game, TestHelpers.AllMiss);

            Assert.IsType<PendingGame>(state);
            Assert.Equal(1, state.Trials);
        }

        [Fact]
        public void If_Trial_Succeeds_Game_Goes_Won()
        {
            var game = new PendingGame { Trials = 0 };
            var state = Game.Transition(game, TestHelpers.AllHit);

            Assert.IsType<GameWon>(state);
            Assert.Equal(1, state.Trials);
        }        
        
        [Fact]
        public void If_Trial_Fails_And_Max_Reached_Game_Goes_Lost()
        {
            var game = new PendingGame { Trials = Game.MaxTrials - 1 };
            var state = Game.Transition(game, TestHelpers.AllMiss);

            Assert.IsType<GameLost>(state);
        }
    }
}