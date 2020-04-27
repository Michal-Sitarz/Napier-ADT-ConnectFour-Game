using System;
using System.Collections.Generic;
using System.Text;

namespace Napier_ConnectFour_Csharp
{
    public class LatestGames
    {
        public GameRecord[] CircularList { get; private set; }
        public int Count { get; private set; }
        public int Latest { get; private set; }

        private const int size = 9;

        public LatestGames()
        {
            CircularList = new GameRecord[size];
            Latest = -1;
            Count = 0;
        }

        public void Add(GameRecord game)
        {
            if (Count < size - 1)
            {
                Latest++;
                CircularList[Latest] = game;
                Count++;
            }
            else if (Latest == size - 1)
            {
                Latest = 0;
                CircularList[Latest] = game;
            }
            else
            {
                Latest++;
                CircularList[Latest] = game;
            }
        }

        public GameRecord[] ToOrderedArray()
        {
            var allRecordsOrdered = new GameRecord[size];
            int index = 0;
            for (int i = Latest; i >= 0; i--)
            {
                allRecordsOrdered[index] = CircularList[i];
                index++;
            }
            for (int j = size - 1; j > Latest; j--)
            {
                allRecordsOrdered[index] = CircularList[j];
                index++;
            }
            return allRecordsOrdered;
        }
    }
}
