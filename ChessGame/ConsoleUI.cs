using ChessGame.Model;
using static ChessGame.Model.Piece;

namespace ChessGame
{
    internal class ConsoleUI
    {

        public void Start()
        {
            ChessBoard c = new ChessBoard();

            Game(c);
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
        public static void Move(ChessBoard c, string color)
        {
            while (true)
            {

                Console.WriteLine("input x and y location");
                (var startX, var startY) = GetCoord();

                Piece selected = c.Board[startY - 1, startX - 1];
                Console.WriteLine("you selected: " + selected.PieceType);
                Console.WriteLine("Moves: ");
                foreach (int num in (selected.PossibleMoves(c)))
                {
                    Console.WriteLine((num + 11));
                }
                Console.WriteLine("input x and y final");
                (var finalX, var finalY) = GetCoord();

                var pieceMoved = c.MovePiece(startX - 1, startY - 1, finalX - 1, finalY - 1, color);

                if (pieceMoved)
                {
                    break;
                }
            }
        }
        public static void Game(ChessBoard c)
        {
            String color = "white";
            c.PrintChessBoard();
            while (true)
            {
                Console.WriteLine(color + " turn!\n");
                Move(c, color);
                if (c.CheckKing() > 0)
                {
                    if (c.CheckKing() > 1)
                    {
                        c.PrintReverseChessBoard();
                        Console.WriteLine("black wins");
                        break;
                    }
                    else
                    {
                        c.PrintChessBoard();
                        Console.WriteLine("white wins");
                        break;
                    }
                }
                if (color == PieceColors.White)
                {
                    color = PieceColors.Black;
                    c.PrintReverseChessBoard();
                }
                else
                {
                    color = PieceColors.White;
                    c.PrintChessBoard();
                }
            }
        }
    }
}

