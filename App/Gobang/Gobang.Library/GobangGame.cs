namespace Gobang.Library
{
    using System.Collections.Generic;

    public class GobangGame
    {
        public GobangGame(GobangChessboard gobangChessboard, IList<Player> players)
        {
            this.GobangChessboard = gobangChessboard;
            this.Players = players;
        }

        public string GameNumber { get; set; }

        public GobangChessboard GobangChessboard { get; set; }

        public IList<Player> Players { get; set; }
    }
}