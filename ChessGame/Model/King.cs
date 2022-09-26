namespace ChessGame.Model
{
    public class King : Piece
    {
        public King(int xpos, int ypos, String color) : base("King", "♔", color, xpos, ypos)
        {


            if (color == "white")
            {
                this.Symbol = ("♚");
                this.Symbol = ("WK");
            }
            else
            {
                this.Symbol = ("BK");
            }
        }


        public override List<int> possibleMoves(ChessBoard board)
        {
            List<int> moves = new List<int>();


            int tempXpos = this.Xpos;
            int tempYpos = this.Ypos;
            int temp;


            tempYpos += 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }

            tempXpos = this.Xpos;
            tempYpos = this.Ypos;

            tempYpos -= 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;

            tempXpos += 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 1;

            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 1;
            tempYpos -= 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos += 1;
            tempYpos += 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 1;
            tempYpos += 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos += 1;
            tempYpos -= 1;
            temp = this.checkMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }





            return moves;
        }
    }
}




