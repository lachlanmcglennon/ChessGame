using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    public class Pawn : Piece
    {

        public Pawn(int xpos, int ypos, String color) : base("Pawn", "♙", color, xpos, ypos)
        {


            direction = 1;
            if (Color == PieceColors.White)
            {
                base.Symbol = "♟";
                direction = -1;
                this.Symbol = ("WP");
            }
            else
            {
                this.Symbol = ("BP");

            }
        }
        public int direction { get; set; }

        public override List<int> possibleMoves(ChessBoard board)
        {
            List<int> moves = new List<int>();


            int tempXpos = base.Xpos;
            int tempYpos = base.Ypos;
            int temp;



            tempYpos += direction;
            temp = base.checkMove(tempXpos, tempYpos, board, false);

            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }

            tempXpos = base.Xpos;
            tempYpos = base.Ypos;

            tempYpos += direction;
            tempXpos += 1;
            temp = base.checkMove(tempXpos, tempYpos, board, true);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = base.Xpos;
            tempYpos = base.Ypos;

            tempYpos += direction;
            tempXpos -= 1;
            temp = base.checkMove(tempXpos, tempYpos, board, true);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            if ((base.Color == "white" && base.Ypos == 6) || (base.Color == "black" && base.Ypos == 1))
            {
                tempXpos = base.Xpos;
                tempYpos = base.Ypos;

                tempYpos += (direction + direction);

                temp = base.checkMove(tempXpos, tempYpos, board, false);
                if (temp != -404)
                {
                    moves.Add(Math.Abs(temp));
                }
            }






            return moves;
        }

    }
}

