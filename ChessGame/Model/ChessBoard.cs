using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Model.Piece;
using static System.Net.Mime.MediaTypeNames;

namespace ChessGame.Model
{
    public class ChessBoard
    {


        public ChessBoard()
        {
            this.board = new Piece[8, 8];
            createChessBoard();
        }
        public ChessBoard(Piece[,] board)
        {
            this.board = board;
        }
        public Piece[,] board { get; set; }
        public void createChessBoard()
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
            this.setCustomBoard(a);
        }


        public void setCustomBoard(String[,] template)
        {
            if (verifyChessBoardTemplate(template))
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
                this.board = newBoard;
            }
            else
            {
                Console.WriteLine("error template not 8x8");
            }
        }

        public bool checkInRange(int xpos, int ypos)
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
        public bool avoidsCheck(int initialXpos, int initialYpos, int finalXpos, int finalYpos, String color)
        {
            Piece[,] testBoardArray = board.Clone() as Piece[,];
            testBoardArray[finalYpos, finalXpos] = testBoardArray[initialYpos, initialXpos];
            Piece place = testBoardArray[finalYpos, finalXpos];
            testBoardArray[finalYpos, finalXpos].Xpos = finalXpos;
            testBoardArray[finalYpos, finalXpos].Ypos = finalYpos;
            testBoardArray[initialYpos, initialXpos] = new Empty(initialYpos, initialXpos);
            ChessBoard testBoard = new ChessBoard(testBoardArray);
            Piece king = find(testBoardArray, "King", color);
            int kingPos = (king.Xpos * 10) + king.Ypos;

            for (int row = 0; row < testBoardArray.GetLength(0); row++)
            {
                for (int col = 0; col < testBoardArray.GetLength(1); col++)
                {
                    Piece a = testBoardArray[row, col];
                    if (a.Color != color)
                    {
                        List<int> possibleMoves = a.possibleMoves(testBoard);
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
        public bool movePiece(int initialXpos, int initialYpos, int finalXpos, int finalYpos, String color)
        {
            int finalPos = (finalXpos * 10) + finalYpos;
            if (board[initialYpos, initialXpos].Color == (color))
            {
                List<int> possibleMoves = board[initialYpos, initialXpos].possibleMoves(this);
                if (canMove(finalPos, possibleMoves))
                {

                    if (avoidsCheck(initialXpos, initialYpos, finalXpos, finalYpos, color))
                    {
                        board[finalYpos, finalXpos] = board[initialYpos, initialXpos];

                        board[finalYpos, finalXpos].Xpos = (finalXpos);
                        board[finalYpos, finalXpos].Ypos = (finalYpos);
                        board[initialYpos, initialXpos] = new Empty(initialYpos, initialXpos);
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
        public bool canMove(int finalPos, List<int> possibleMoves)
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
        private Piece find(Piece[,] SearchBoard, String identify, String color)
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



        public int checkKing()
        {
            int win = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Piece check = board[row, col];
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

        public void printChessBoard()
        {
            String border = $" |{new string('-', 39)}|";

            if (verifyChessBoard(board))
            {
                Console.WriteLine("    1    2    3    4    5    6    7    8");
                for (int row = 0; row < 8; row++)
                {
                    Console.WriteLine(border);
                    Console.Write(row + 1);
                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("|");
                        Console.Write(" " + board[row, col].Symbol + " ");
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
        public void printReverseChessBoard()
        {
            String border = $" |{new string('-', 39)}|";
            if (verifyChessBoard(board))
            {
                Console.WriteLine("    1    2    3    4    5    6    7    8");
                for (int row = board.GetLength(0) - 1; row > -1; row--)
                {
                    Console.WriteLine(border);
                    Console.Write(row + 1);
                    for (int col = 0; col < 8; col++)
                    {
                        Console.Write("|");
                        Console.Write(" " + board[row, col].Symbol + " ");
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
        public static bool verifyChessBoardTemplate(String[,] chessBoard)
        {

            return (chessBoard.GetLength(0) == 8 && chessBoard.GetLength(1) == 8);


        }
        public static bool verifyChessBoard(Piece[,] chessBoard)
        {

            return (chessBoard.GetLength(0) == 8 && chessBoard.GetLength(1) == 8);
        }
    }

}
