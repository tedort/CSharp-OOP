using Chess.Drawers;

namespace Chess
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDrawer drawer = new ConsoleDrawer();
            ChessGame chessGame = new ChessGame(drawer);
            chessGame.Start();
        }
    }
}
