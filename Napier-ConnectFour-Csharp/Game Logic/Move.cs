using System;
using System.Collections.Generic;
using System.Text;

namespace Napier_ConnectFour_Csharp
{
    public struct Move
    {
        public readonly int Player { get; }
        public readonly int BoardColumn { get; }
        public readonly int BoardRow { get; }
        
        public Move(int player, int boardColumn, int boardRow)
        {
            Player = player;
            BoardColumn = boardColumn;
            BoardRow = boardRow;
        }

    }
}
