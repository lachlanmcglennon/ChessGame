using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    internal class Empty : Piece
    {
        public Empty(int xpos, int ypos) : base("empty", "--", PieceColors.Empty, xpos, ypos)
        {

        }
    }
}
