namespace Gobang.Library
{
    using System.Collections.Generic;
    using System.Linq;

    public static class GobangGameFactory
    {
        private static readonly List<GobangGame> UnFinishedGames = new List<GobangGame>();

        public static GobangGame CreateGame(IList<Player> players)
        {
            var chessboard = GobangChessboardFactory.CreateGobangChessboard();
            return new GobangGame(chessboard, players);
        }

        public static GobangGame CreateGame(IList<Player> players, GobangChessboard gobangChessboard)
        {
            return new GobangGame(gobangChessboard, players);
        }

        public static GobangGame ContinueGame(IList<Player> players, string gameNumber)
        {
            var game = UnFinishedGames.Single(g => g.GameNumber == gameNumber);
            return game;
        }

        public static void LeaveTheGame(GobangGame gobangGame)
        {
            UnFinishedGames.Add(gobangGame);
        }
    }
}