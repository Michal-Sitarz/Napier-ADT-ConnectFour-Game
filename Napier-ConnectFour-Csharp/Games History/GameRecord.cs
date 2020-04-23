using System;
using System.Collections.Generic;
using System.Text;

namespace Napier_ConnectFour_Csharp
{
    public class GameRecord
    {
        public DateTime Date { get; set; }
        public Queue<Move> MovesHistory { get; set; }
        public GameResult Result { get; set; }
    }
}
