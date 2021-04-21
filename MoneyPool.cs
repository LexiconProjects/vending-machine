using System;
using System.Linq;

namespace VendingMachine
{
    class MoneyPool
    {
        public static readonly string[] denominations = { "1", "5", "10", "20", "50", "100", "500", "1000" };
        private string input;
        private int money, credit = 0;

        internal bool ValidateDenomination(string input)
        {
            return denominations.Contains(input);
        }
        
        internal void RequestCredit()
        {

            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine("|     PLEASE ADD DESIRED CREDIT, ONE COIN OR BANKNOTE AT A TIME. WHEN DONE, PRESS n TO CONTINUE.      |");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            do
            {
                Console.Write("| > ");
                input = Console.ReadLine();
                if (int.TryParse(input, out money))
                {
                    if (ValidateDenomination(input))
                    {
                        UpdateCredit(money);
                        Console.WriteLine("Added " + money + " kr to your credit.");
                    }
                    else
                        Console.WriteLine("ERROR: Coin or banknote not accepted,try again!");
                }
                else if (input != "n")
                {
                    Console.WriteLine("ERROR: Please only insert coins or banknotes, one at a time!");
                }

            } while (input != "n");

        }

        internal void UpdateCredit(int m)
        {
            credit += m;
        }

        internal void ReturnChange()
        {
            if (credit > 0)
            {
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
                Console.WriteLine($"|         HERE IS YOUR CHANGE: {credit} KR.                                                              |");
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");

            }
            else
            {
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
                Console.WriteLine("|         YOU SPENT ALL YOUR CREDIT, NO CHANGE IS GIVEN.                                              |");
                Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            }

        }

        internal bool CheckCredit(int productPrice)
        {
            return credit >= productPrice;
        }

        internal void PrintCredit()
        {
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine($"|       YOUR CURRENT CREDIT IS {credit} KR.                                                               |");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");

            if (credit == 0)
                RequestCredit();

        }
    }
}
