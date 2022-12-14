namespace ChessGame.Model
{
    public class Piece
    {
        public static class PieceColors
        {
            public const string White = "white";
            public const string Black = "black";
            public const string Empty = "empty";
        }


        public Piece(string type, string symbol, string color, int xpos, int ypos)
        {
            this.PieceType = type;
            this.Symbol = symbol;
            this.Color = color;
            this.Xpos = xpos;
            this.Ypos = ypos;
        }

        public string PieceType { get; set; }

        public string Symbol { get; set; }
        public string Color { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public static bool CanMove(int x, int y, string[][] board)
        {
            return true;
        }

        public string GetOpposingColor()
        {
            if (this.Color == PieceColors.White)
            {
                return PieceColors.Black;
            }
            else if (this.Color == PieceColors.Black)
            {
                return PieceColors.White;
            }
            else
            {
                return PieceColors.Empty;
            }
        }
        public virtual List<int> PossibleMoves(ChessBoard board)
        {
            return new List<int>();
        }
        public int CheckMove(int tempXpos, int tempYpos, ChessBoard board)
        {
            if (board.CheckInRange(tempXpos, tempYpos))
            {
                if (board.Board[tempYpos, tempXpos].PieceType == PieceColors.Empty)
                {

                    return tempXpos * 10 + tempYpos;
                }
                else if (!(board.Board[tempYpos, tempXpos].Color == this.Color))
                {
                    return -(tempXpos * 10 + tempYpos);
                }
                else
                {
                    return -404;
                }
            }
            else
            {
                return -404;
            }
        }
        public int CheckMove(int tempXpos, int tempYpos, ChessBoard board, bool isCapture)
        {
            if (board.CheckInRange(tempXpos, tempYpos))
            {
                if (board.Board[tempYpos, tempXpos].Color == PieceColors.Empty && !isCapture)
                {
                    return tempXpos * 10 + tempYpos;
                }
                else if (board.Board[tempYpos, tempXpos].Color == GetOpposingColor() && isCapture)
                {
                    return -(tempXpos * 10 + tempYpos);
                }
                else
                {
                    return -404;
                }
            }
            else
            {
                return -404;
            }
        }
    }
}