using Chess.Drawers;

namespace Chess
{
    public class ChessGame
    {
        private IDrawer drawer;
        private Pawn[] pawns = new Pawn[8];

        public ChessGame(IDrawer drawer)
        {
            this.drawer = drawer;

            for (int i = 0; i < 8; i++)
            {
                pawns[i] = new Pawn(drawer);
            }
        }

        public void Start()
        {
            while (true)
            {
                foreach (Pawn pawn in pawns)
                {
                    pawn.Draw();
                }

                drawer.WriteLine("");
                drawer.WriteLine("------------");
                drawer.WriteLine("------------");
                drawer.WriteLine("------------");
                drawer.WriteLine("------------");
                drawer.WriteLine("------------");
                drawer.WriteLine("------------");

                foreach (Pawn pawn in pawns)
                {
                    pawn.Draw();
                }
                Thread.Sleep(5000);
            }
        }
    }
}
