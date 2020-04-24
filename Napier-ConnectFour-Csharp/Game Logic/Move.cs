namespace Napier_ConnectFour_Csharp
{
    public struct Move
    {
        public readonly int BoardColumn { get; }
        public readonly int BoardRow { get; }
        public readonly int Player { get; }
        
        public Move(int boardColumn, int boardRow, int player)
        {
            BoardColumn = boardColumn;
            BoardRow = boardRow;
            Player = player;
        }

    }
}
