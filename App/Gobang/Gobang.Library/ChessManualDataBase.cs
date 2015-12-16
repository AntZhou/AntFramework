namespace Gobang.Library
{
    using System.Collections.Generic;
    using System.Linq;


    public class ChessManualDataBase
    {
        private static readonly List<ChessManual> ChessManualList  = new List<ChessManual>();

        private ChessManualDataBase()
        {
            AddNo1ChessManual();
        }

        private static void AddNo1ChessManual()
        {
            ChessManual chessManual = new ChessManual { ChessManualNumber = "#1" };
            int i = 1;
            chessManual.StepList.Add(new Step("111", i) );
            ChessManualList.Add(chessManual);
        }

        public static ChessManualDataBase Instanse = new ChessManualDataBase();

        public ChessManual GetChessManual(string chessManualNumber)
        {
            return ChessManualList.Single(c => c.ChessManualNumber == chessManualNumber);
        }
    }
}
