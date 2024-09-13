using System;
using Chainblock.Models;

namespace Chainblock
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Transaction transaction = new Transaction(1, "from", "to", 100m);
            Console.WriteLine(transaction.Status);
        }
    }
}
