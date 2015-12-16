using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class ChessboardFactory
    {

        public static Chessboard CreateChessboard(string chessManualNumber)
        {
            return CreateChessboard(ChessManualDataBase.Instanse.GetChessManual(chessManualNumber));
        }

        public static Chessboard CreateChessboard(ChessManual chessManual)
        {
            Chessboard chessboard = new Chessboard();
            foreach (var step in chessManual.StepList)
            {
                SetNumber(chessboard,step);
            }
            return chessboard;
        }

        private static void SetNumber(Chessboard chessboard, Step step)
        {
            chessboard.GetCell(step.Row, step.Column).SetNumber(step.Number);
        }
    }
}
