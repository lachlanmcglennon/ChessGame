using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Model
{
    public class Bishop : Piece
    {
        public Bishop(int xpos, int ypos, String color) : base("Bishop", "♗", color, xpos, ypos)
        {


            if (color == "white")
            {
                this.Symbol = "♝";
                this.Symbol = ("WB");
            }
            else
            {
                this.Symbol = ("BB");
            }
        }


        public override List<int> possibleMoves(ChessBoard board)
        {
            List<int> moves = new List<int>();


            int tempXpos = this.Xpos;
            int tempYpos = this.Ypos;
            int temp;
            while (true)
            {
                tempXpos += 1;
                tempYpos += 1;
                temp = this.checkMove(tempXpos, tempYpos, board);
                if (temp != -404)
                {
                    moves.Add(Math.Abs(temp));
                }
                if (temp < 0)
                {
                    break;
                }
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            while (true)
            {
                tempXpos -= 1;
                tempYpos += 1;
                temp = this.checkMove(tempXpos, tempYpos, board);
                if (temp != -404)
                {
                    moves.Add(Math.Abs(temp));
                }
                if (temp < 0)
                {
                    break;
                }
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            while (true)
            {
                tempYpos -= 1;
                tempXpos -= 1;
                temp = this.checkMove(tempXpos, tempYpos, board);
                if (temp != -404)
                {
                    moves.Add(Math.Abs(temp));
                }
                if (temp < 0)
                {
                    break;
                }
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            while (true)
            {
                tempXpos += 1;
                tempYpos -= 1;
                temp = this.checkMove(tempXpos, tempYpos, board);
                if (temp != -404)
                {
                    moves.Add(Math.Abs(temp));
                }
                if (temp < 0)
                {
                    break;
                }
            }
            return moves;
        }


    }
}
