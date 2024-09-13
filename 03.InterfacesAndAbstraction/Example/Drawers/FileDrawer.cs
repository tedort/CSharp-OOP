namespace Chess.Drawers
{
    public class FileDrawer : IDrawer
    {
        private string path = "../../../chess.txt";

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
