namespace MoneyTransactions
{
    public class BankAccount
    {
        private int accountNumber;
        private double balance;

        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int AccountNumber 
        { 
            get => accountNumber;
            private set
            {
                accountNumber = value;
            }
        }
        public double Balance 
        {
            get => balance;
            private set
            {
                balance = value;
            }
        }

        public void Deposit(double sum)
        {
            Balance += sum;
            Console.WriteLine($"Account {AccountNumber} has new balance: {Balance:f2}");
        }

        public void Withdraw(double sum)
        {
            if (sum > Balance)
            {
                throw new ArgumentException("Insufficient balance!");
            }
            Balance -= sum;
            Console.WriteLine($"Account {AccountNumber} has new balance: {Balance:f2}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            string[] inputTokens = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputTokens.Length; i++)
            {
                string[] bankTokens = inputTokens[i].Split('-', StringSplitOptions.RemoveEmptyEntries);
                BankAccount bankAccount = new BankAccount(int.Parse(bankTokens[0]), double.Parse(bankTokens[1]));
                bankAccounts.Add(bankAccount);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (commandTokens[0] == "Deposit")
                    {
                        BankAccount bankAccount = bankAccounts.Find(b => b.AccountNumber == int.Parse(commandTokens[1]));
                        bankAccount.Deposit(double.Parse(commandTokens[2]));
                    }
                    else if (commandTokens[0] == "Withdraw")
                    {
                        BankAccount bankAccount = bankAccounts.Find(b => b.AccountNumber == int.Parse(commandTokens[1]));
                        bankAccount.Withdraw(double.Parse(commandTokens[2]));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
