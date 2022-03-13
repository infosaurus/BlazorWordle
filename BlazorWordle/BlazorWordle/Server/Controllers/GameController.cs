using BlazorWordle.Domain;
using BlazorWordle.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWordle.Server.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost]
        [Route("api/games")]
        public void CreateGame(CreateGameCommand command)
        {
            var solution = Lexicon.DrawRandomWord();
            this.HttpContext.Session.SetString(command.GameId.ToString(), solution);
        }

        [HttpGet]
        [Route("api/games/{gameId}/play")]
        public TrialResult GetTrialResult(string gameId, [FromQuery] string trial)
        {
            var solution = HttpContext.Session.GetString(gameId);
            var trialResult = WordleMatcher.Match(trial.ToCharArray(), solution.ToCharArray());
            return trialResult;
        }
    }
}
