using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class Game
    {
        public Game(Chessboard chessboard,Player player)
        {
            this.Chessboard = chessboard;
            this.Player = player;
        }

        public string GameNumber { get; set; }

        public Chessboard Chessboard { get; set; }

        public Player Player { get; set; } 
    }
}
