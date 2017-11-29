using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace ClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonServiceClient jsonServiceClient = new JsonServiceClient("http://localhost:61401");

            int userInput;
            while(Int32.TryParse(Console.ReadLine(), out userInput)) {
                var response = jsonServiceClient.Post(new Expense { Amount = userInput });

                Console.WriteLine(String.Format("Status: {0} - Withdrawals: {1} (Total: {2}, {3} Withdrawals)", response.Status, response.Amount, response.Total, response.WithdrawalsAmount));
            }
        }
    }
}
