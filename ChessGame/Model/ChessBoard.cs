using static ChessGame.Model.Piece;

namespace ChessGame.Model
{
    public class ChessBoard
    {


        public ChessBoard()
        {
            this.Board = new Piece[8, 8];
            CreateChessBoard();
        }

        public ChessBoard(Piece[,] board)
        {
            this.Board = board;
        }

        public ChessBoard(string[,] board)
        {
            SetCustomBoard(board);
        }

        public Piece[,] Board { get; set; }
        public void CreateChessBoard()
        {
            String[,] a = {
                 {"br","bk","bb","bK","bq","bb","bk","br"}
                ,{"bp","bp","bp","bp","bp","bp","bp","bp"}
                ,{"-","-","-","-","-","-","-","-"}
                ,{"-","-","-","-","-","-","-","-"}
                ,{"-","-","-","-","-","-","-","-"}
                ,{"-","-","-","-","-","-","-","-"}
                ,{"wp","wp","wp","wp","wp","wp","wp","wp"}
                ,{"wr","wk","wb","wK","wq","wb","wk","wr"}};
            this.SetCustomBoard(a);
        }

        public void SetCustomBoard(String[,] template)
        {
            if (VerifyChessBoardTemplate(template))
            {
                Piece[,] newBoard = new Piece[8, 8];
                for (int row = 0; row < template.GetLength(0); row++)
                {
                    for (int col = 0; col < template.GetLength(1); col++)
                    {
                        if (template[row, col] == "-")
                        {
                            newBoard[row, col] = new Empty(col, row);

                        }
                        else if (template[row, col] == "wr")
                        {
                            newBoard[row, col] = new Rook(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "br")
                        {
                            newBoard[row, col] = new Rook(col, row, PieceColors.Black);
                        }
                        else if (template[row, col] == "wb")
                        {
                            newBoard[row, col] = new Bishop(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "bb")
                        {
                            newBoard[row, col] = new Bishop(col, row, PieceColors.Black);
                        }
                        else if (template[row, col] == "wq")
                        {
                            newBoard[row, col] = new Queen(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "bq")
                        {
                            newBoard[row, col] = new Queen(col, row, PieceColors.Black);
                        }
                        else if (template[row, col] == "wk")
                        {
                            newBoard[row, col] = new Knight(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "bk")
                        {
                            newBoard[row, col] = new Knight(col, row, PieceColors.Black);
                        }
                        else if (template[row, col] == "wK")
                        {
                            newBoard[row, col] = new King(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "bK")
                        {
                            newBoard[row, col] = new King(col, row, PieceColors.Black);
                        }
                        else if (template[row, col] == "wp")
                        {
                            newBoard[row, col] = new Pawn(col, row, PieceColors.White);
                        }
                        else if (template[row, col] == "bp")
                        {
                            newBoard[row, col] = new Pawn(col, row, PieceColors.Black);
                        }
                        else
                        {
                            newBoard[row, col] = new Empty(col, row);
                        }
                    }
                }
                this.Board = newBoard;
            }
            else
            {
                Console.WriteLine("error template not 8x8");
            }
        }

        public bool CheckInRange(int xpos, int ypos)
        {
            if (xpos >= 0 && xpos <= 7 && ypos >= 0 && ypos <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AvoidsCheck(int initialXpos, int initialYpos, int finalXpos, int finalYpos, String color)
        {
            Piece[,] testBoardArray = Board.Clone() as Piece[,];
            testBoardArray[finalYpos, finalXpos] = testBoardArray[initialYpos, initialXpos];
            Piece place = testBoardArray[finalYpos, finalXpos];
            testBoardArray[finalYpos, finalXpos].Xpos = finalXpos;
            testBoardArray[finalYpos, finalXpos].Ypos = finalYpos;
            testBoardArray[initialYpos, initialXpos] = new Empty(initialYpos, initialXpos);
            ChessBoard testBoard = new ChessBoard(testBoardArray);
            Piece king = Find(testBoardArray, "King", color);
            int kingPos = (king.Xpos * 10) + king.Ypos;

            for (int row = 0; row < testBoardArray.GetLength(0); row++)
            {
                for (int col = 0; col < testBoardArray.GetLength(1); col++)
                {
                    Piece a = testBoardArray[row, col];
                    if (a.Color != color)
                    {
                        List<int> possibleMoves = a.PossibleMoves(testBoard);
                        foreach (int move in possibleMoves)
                        {
                            if (move == kingPos)
                            {
                                testBoardArray[initialYpos, initialXpos] = testBoardArray[finalYpos, finalXpos];

                                testBoardArray[initialYpos, initialXpos].Xpos = (initialXpos);
                                testBoardArray[initialYpos, initialXpos].Ypos = (initialYpos);
                                testBoardArray[finalYpos, finalXpos] = place;
                                return false;
                            }
                        }
                    }
                }
            }

            testBoardArray[initialYpos, initialXpos] = testBoardArray[finalYpos, finalXpos];

            testBoardArray[initialYpos, initialXpos].Xpos = (initialXpos);
            testBoardArray[initialYpos, initialXpos].Ypos = (initialYpos);
            testBoardArray[finalYpos, finalXpos] = place;

            return true;

        }
        public bool MovePiece(int initialXpos, int initialYpos, int finalXpos, int finalYpos, String color)
        {
            int finalPos = (finalXpos * 10) + finalYpos;
            if (Board[initialYpos, initialXpos].Color == (color))
            {
                List<int> possibleMoves = Board[initialYpos, initialXpos].PossibleMoves(this);
                if (CanMove(finalPos, possibleMoves))
                {

                    if (AvoidsCheck(initialXpos, initialYpos, finalXpos, finalYpos, color))
                    {
                        Board[finalYpos, finalXpos] = Board[initialYpos, initialXpos];

                        Board[finalYpos, finalXpos].Xpos = (finalXpos);
                        Board[finalYpos, finalXpos].Ypos = (finalYpos);
                        Board[initialYpos, initialXpos] = new Empty(initialYpos, initialXpos);
                        Console.WriteLine("move complete");

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("error you in check");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("error invalid move");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("error not your piece");
                return false;
            }
        }
        public bool CanMove(int finalPos, List<int> possibleMoves)
        {

            foreach (int move in possibleMoves)
            {
                if (move == finalPos)
                {
                    return true;
                }
            }
            return false;
        }
        private Piece Find(Piece[,] SearchBoard, String identify, String color)
        {
            for (int row = 0; row < SearchBoard.GetLength(0); row++)
            {
                for (int col = 0; col < SearchBoard.GetLength(1); col++)
                {
                    Piece a = SearchBoard[row, col];
                    if (a.PieceType == identify && a.Color == color)
                    {
                        return a;
                    }
                }
            }
            return null;
        }


        public int CheckKing()
        {
            int win = 0;
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetLength(1); col++)
                {
                    Piece check = Board[row, col];
                    if (check.PieceType == "King")
                    {
                        if (win > 0)
                        {
                            win = 0;
                        }
                        else
                        {
                            if (check.Color == PieceColors.White)
                            {
                                win = 1;
                            }
                            else
                            {
                                win = 2;
                            }
                        }
                    }

                }
            }
            return win;
        }

        public void PrintChessBoard()
        {
            String border = $" |{new string('-', 39)}|";

            if (VerifyChessBoard(Board))
            {
                Console.WriteLine("    1    2    3    4    5    6    7    8");
                for (int row = 0; row < 8; row++)
                {
                    Console.WriteLine(border);
                    Console.Write(row + 1);
                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("|");
                        Console.Write(" " + Board[row, col].Symbol + " ");
                    }
                    Console.Write("|\n");
                }
                Console.WriteLine(border);
            }
            else
            {
                Console.WriteLine("error invalid chessboard");
            }
        }
        public void PrintReverseChessBoard()
        {
            String border = $" |{new string('-', 39)}|";
            if (VerifyChessBoard(Board))
            {
                Console.WriteLine("    1    2    3    4    5    6    7    8");
                for (int row = Board.GetLength(0) - 1; row > -1; row--)
                {
                    Console.WriteLine(border);
                    Console.Write(row + 1);
                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("|");
                        Console.Write(" " + Board[row, col].Symbol + " ");
                    }
                    Console.Write("|\n");
                }
                Console.WriteLine(border);
            }
            else
            {
                Console.WriteLine("error invalid chessboard");
            }
        }
        public static bool VerifyChessBoardTemplate(String[,] chessBoard)
        {
            return (chessBoard.GetLength(0) == 8 && chessBoard.GetLength(1) == 8);
        }
        public static bool VerifyChessBoard(Piece[,] chessBoard)
        {
            return (chessBoard.GetLength(0) == 8 && chessBoard.GetLength(1) == 8);
        }
    }

}
