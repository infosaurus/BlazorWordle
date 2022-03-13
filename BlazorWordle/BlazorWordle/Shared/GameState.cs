using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWordle.Domain;

namespace BlazorWordle.Shared
{
    public class GameState
    {
        private IList<TrialResult> pastTrials = new List<TrialResult>();

        public Game Game { get; set; }
        public IList<TrialResult> PastTrials { get => pastTrials; set => pastTrials = value; }

        public static GameState Init (Guid gameId)
        {
            return new GameState { Game = new PendingGame { Id = gameId } };
        }
    }
}
