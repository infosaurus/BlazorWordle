using System.Linq;

namespace BlazorWordle.Domain
{
    public abstract class Game
    {
        public const int MaxTrials = 6;

        public int Trials { get; set; }
        public Guid Id { get; init; }

        public static Game Transition(Game previousState, TrialResult trialResult)
        {
            var newTrials = previousState.Trials + 1;

            if (trialResult.Letters.All(l => l.Result == ResultValue.Hit))
                return new GameWon { Trials = newTrials, Id = previousState.Id };

            if (newTrials == MaxTrials)
                return new GameLost { Trials = newTrials, Id = previousState.Id };

            return new PendingGame { Trials = newTrials, Id = previousState.Id };
        }
    }

    public class PendingGame : Game { }

    public class GameWon : Game { }

    public class GameLost : Game { }

}