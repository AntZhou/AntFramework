using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class ChessManualDataBase
    {
        private static List<ChessManual> chessManualList  = new List<ChessManual>();

        private ChessManualDataBase()
        {
            AddNo1ChessManual();
        }

        private static void AddNo1ChessManual()
        {
            ChessManual chessManual = new ChessManual { ChessManualNumber = "#1" };
            int i = 1;
            chessManual.StepList.Add(new Step(1,2,3,i++) );
            chessManual.StepList.Add(new Step(1,6,7,i++) );
            chessManual.StepList.Add(new Step(1,7,1,i++) );
            chessManual.StepList.Add(new Step(2,2,1,i++) );
            chessManual.StepList.Add(new Step(2,8,3,i++) );
            chessManual.StepList.Add(new Step(2,9,8,i++) );
            chessManual.StepList.Add(new Step(3,1,9,i++) );
            chessManual.StepList.Add(new Step(3,4,6,i++) );
            chessManual.StepList.Add(new Step(4,1,4,i++) );
            chessManual.StepList.Add(new Step(4,5,8,i++) );
            chessManual.StepList.Add(new Step("479",i++) );
            chessManual.StepList.Add(new Step("544",i++) );
            chessManual.StepList.Add(new Step("563",i++) );
            chessManual.StepList.Add(new Step("631",i++) );
            chessManual.StepList.Add(new Step("655",i++) );
            chessManual.StepList.Add(new Step("692", i++) );
            chessManual.StepList.Add(new Step("768", i++) );
            chessManual.StepList.Add(new Step("795", i++) );
            chessManual.StepList.Add(new Step("816", i++) );
            chessManual.StepList.Add(new Step("824", i++) );
            chessManual.StepList.Add(new Step("888", i++) );
            chessManual.StepList.Add(new Step("933", i++) );
            chessManual.StepList.Add(new Step("942", i++) );
            chessManual.StepList.Add(new Step("984", i) );
            chessManualList.Add(chessManual);
        }

        public static ChessManualDataBase Instanse = new ChessManualDataBase();

        public ChessManual GetChessManual(string chessManualNumber)
        {
            return chessManualList.Single(c => c.ChessManualNumber == chessManualNumber);
        }
    }
}
