namespace ChessGame.Model
{
    public class Knight : Piece
    {
        public Knight(int xpos, int ypos, String color) : base("Knight", "♘", color, xpos, ypos)
        {
            if (color == "white")
            {
                this.Symbol = ("♞");
                this.Symbol = ("WN");
            }
            else
            {
                this.Symbol = ("BN");
            }
        }


        public override List<int> PossibleMoves(ChessBoard board)
        {
            List<int> moves = new List<int>();

            int tempXpos = this.Xpos;
            int tempYpos = this.Ypos;
            int temp;

            tempXpos += 2;
            tempYpos += 1;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }

            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos += 2;
            tempYpos -= 1;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 2;
            tempYpos += 1;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 2;
            tempYpos -= 1;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 1;
            tempYpos -= 2;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos += 1;
            tempYpos -= 2;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos -= 1;
            tempYpos += 2;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }
            tempXpos = this.Xpos;
            tempYpos = this.Ypos;
            tempXpos += 1;
            tempYpos += 2;
            temp = this.CheckMove(tempXpos, tempYpos, board);
            if (temp != -404)
            {
                moves.Add(Math.Abs(temp));
            }

            return moves;
        }
    }
}




