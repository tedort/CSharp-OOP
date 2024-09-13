namespace Singleton
{
    public class UserSingleton
    {
        private static UserSingleton instance;

        private UserSingleton()
        {
            
        }

        public static UserSingleton Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSingleton();
                }

                return instance;
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
