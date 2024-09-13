namespace AuthorProblem
{
    public class StartUp
    {
        [Author("Tedo")]
        public static void Main(string[] args)
        {
            new Tracker().PrintMethodsByAuthor();
        }

        [Author("Tedo1")]
        [Author("Tedo2")]
        [Author("Tedo3")]
        public void NewMethod()
        {

        }
    }
}
