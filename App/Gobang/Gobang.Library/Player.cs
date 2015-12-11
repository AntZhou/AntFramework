using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public string LoginName { get; set; }

        public string PassWord { get; set; }


        protected bool Equals(Player other)
        {
            return string.Equals(this.Name, other.Name);
        }

        public override int GetHashCode()
        {
            return this.Name?.GetHashCode() ?? 0;
        }
    }
}
