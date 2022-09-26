using ChessGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessGame.Model.Piece;

namespace ChessGame
{
    internal class ConsoleUI
    {

        public void start()
        {

            ChessBoard c = new ChessBoard();


            game(c);






        }
        private static (int x, int y) GetCoord()
        {
            var input = Console.ReadLine();
            if (input == null || input.Length != 2)
            {
                Console.WriteLine("Invalid Input");
                return GetCoord();
            }
            else
            {
                int x;
                int y;
                try
                {
                    x = Convert.ToInt32(input.Substring(0, 1));
                    y = Convert.ToInt32(input.Substring(1));
                }
                catch
                {
                    Console.WriteLine("Invalid Input");
                    return GetCoord();
                }
                return (x, y);
            }


        }
        public static void move(ChessBoard c, string color)
        {


            while (true)
            {

                Console.WriteLine("input x and y location");
                (var startX, var startY) = GetCoord();



                Piece selected = c.board[startY - 1, startX - 1];
                Console.WriteLine("you selected: " + selected.PieceType);
                Console.WriteLine("Moves: ");
                foreach (int num in (selected.possibleMoves(c)))
                {
                    Console.WriteLine((num + 11));
                }
                Console.WriteLine("input x and y final");
                (var finalX, var finalY) = GetCoord();


                var pieceMoved = c.movePiece(startX - 1, startY - 1, finalX - 1, finalY - 1, color);




                if (pieceMoved)
                {
                    break;
                }
            }
        }
        public static void game(ChessBoard c)
        {
            String color = "white";
            c.printChessBoard();
            while (true)
            {


                Console.WriteLine(color + " turn!\n");
                move(c, color);
                if (c.checkKing() > 0)
                {
                    if (c.checkKing() > 1)
                    {
                        c.printReverseChessBoard();
                        Console.WriteLine("black wins");
                        break;
                    }
                    else
                    {
                        c.printChessBoard();
                        Console.WriteLine("white wins");
                        break;
                    }
                }
                if (color == PieceColors.White)
                {
                    color = PieceColors.Black;
                    c.printReverseChessBoard();
                }
                else
                {
                    color = PieceColors.White;
                    c.printChessBoard();
                }


            }
        }









    }

}

