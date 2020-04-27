using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    public class GameRecord
    {
        public DateTime Date { get; set; }
        public Queue<Move> MovesHistory { get; set; }
        public GameResult Result { get; set; }
        public int BoardRows { get; set; }
        public int BoardColumns { get; set; }
    }
}
