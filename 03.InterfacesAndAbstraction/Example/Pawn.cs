using Chess.Drawers;

namespace Chess
{
    public class Pawn
    {
        private IDrawer drawer;

        public Pawn(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void Draw()
        {
            drawer.Write("P");
        }
    }
}
