using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWordle.Shared
{
    public class CreateGameCommand
    {
        public Guid GameId { get; init; }
    }
}
