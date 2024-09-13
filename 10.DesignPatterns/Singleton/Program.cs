namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserSingleton userSingleton = UserSingleton.Instance;

            UserSingleton.Instance.Username = "Tedo";
            UserSingleton.Instance.Password = "password";
        }
    }
}
