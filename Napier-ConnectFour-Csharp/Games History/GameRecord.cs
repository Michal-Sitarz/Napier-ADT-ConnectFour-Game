using System;

namespace Napier_ConnectFour_Csharp
{
    public class GameRecord
    {
        public Move[] MovesHistory { get; set; }
        public DateTime Date { get; set; }
        public GameResult Result { get; set; }
        public int BoardRows { get; set; }
        public int BoardColumns { get; set; }
        public int ConnectedPiecesToWin { get; set; }
    }
}
