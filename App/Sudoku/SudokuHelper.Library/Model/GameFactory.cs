namespace SudokuHelper.Library.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public static class GameFactory
    {
        private static readonly List<Game> UnFinishedGames = new List<Game>();

        public static Game CreateGame(Player player, string chessManualNumber)
        {
            var chessboard = ChessboardFactory.CreateChessboard(chessManualNumber);
            return new Game(chessboard, player);
        }

        public static Game CreateGame(Player player, Chessboard chessboard)
        {
            return new Game(chessboard, player);
        }

        public static Game ContinueGame(Player player, string gameNumber)
        {
            var game = UnFinishedGames.Single(g => g.Player.Equals(player) && g.GameNumber == gameNumber);
            return game;
        }

        public static void LeaveTheGame(Game game)
        {
            UnFinishedGames.Add(game);
        }
    }
}