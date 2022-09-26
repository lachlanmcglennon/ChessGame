namespace ChessGame.Model
{
    public class Queen : Piece
    {
        public Queen(int xpos, int ypos, String color) : base("Queen", "♕", color, xpos, ypos)
        {
            if (color == "white")
            {
                this.Symbol = ("♛");
                this.Symbol = ("WQ");
            }
            else
            {
                this.Symbol = ("BQ");
            }
        }

        public override List<int> PossibleMoves(ChessBoard board)
        {
            List<int> moves = new List<int>();

            int tempXpos = this.Xpos;
            int tempYpos = this.Ypos;
            int temp;
            while (true)
            {
                tempXpos += 1;
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                tempYpos += 1;
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                tempYpos += 1;
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                temp = this.CheckMove(tempXpos, tempYpos, board);
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
                temp = this.CheckMove(tempXpos, tempYpos, board);
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




