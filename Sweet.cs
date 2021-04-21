using System;

namespace VendingMachine
{
    class Sweet : Product
    {
        public Sweet(string type, string position, string name, string price)
        {
            SetType(type);
            SetPlace(position);
            SetName(name);
            SetPrice(price);
        }

        public override void PrintProductInstructions()
        {
            Console.WriteLine($"Your sweet {name} is ready to be enjoyed!");
        }

    }
}
