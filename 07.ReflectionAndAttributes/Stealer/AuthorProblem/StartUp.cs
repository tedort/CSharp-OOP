namespace AuthorProblem
{
    [Author("Tedo")]
    public class StartUp
    {
        [Author("Tedo2")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
