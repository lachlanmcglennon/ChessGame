using ChessGame.Model;

namespace ChessGame.Test
{
    public class PossibleMovesTest
    {
        [Fact]
        public void Rook_given_a_position_returns_correct_possible_moves()
        {

            String[,] template = {
     {"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","wp","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","wr","-","-","-","bp"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","bp","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}};
            var chessboard = new ChessBoard(template);
            List<int> moves = chessboard.Board[3, 3].PossibleMoves(chessboard);
            Assert.Equal(11, moves.Count);
            Assert.Contains(23, moves);

        }
        [Fact]
        public void Bishop_given_a_position_returns_correct_possible_moves()
        {

            String[,] template = {
     {"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","wp","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","wb","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","bp","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}};
            var chessboard = new ChessBoard(template);
            List<int> moves = chessboard.Board[3, 3].PossibleMoves(chessboard);
            Assert.Equal(10, moves.Count);
            Assert.Contains(44, moves);

        }
        [Fact]
        public void Queen_given_a_position_returns_correct_possible_moves()
        {

            String[,] template = {
     {"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","wp","-","-"}
    ,{"-","bp","-","-","-","-","-","-"}
    ,{"-","-","-","wq","-","wp","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","bp","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}
    ,{"-","-","-","-","-","-","-","-"}};
            var chessboard = new ChessBoard(template);
            List<int> moves = chessboard.Board[3, 3].PossibleMoves(chessboard);
            Assert.Equal(21, moves.Count);
            Assert.Contains(44, moves);

        }
    }
}