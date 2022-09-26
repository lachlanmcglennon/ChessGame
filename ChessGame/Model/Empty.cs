namespace ChessGame.Model
{
    internal class Empty : Piece
    {
        public Empty(int xpos, int ypos) : base("empty", "--", PieceColors.Empty, xpos, ypos)
        {

        }
    }
}
