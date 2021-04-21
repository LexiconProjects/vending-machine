using System;

namespace VendingMachine
{
    class Snack : Product
    {
        public Snack(string type, string position, string name, string price)
        {
            SetType(type);
            SetPlace(position);
            SetName(name);
            SetPrice(price);
        }

        public override void PrintProductInstructions()
        {
            Console.WriteLine($"Snack on your bag of {name} now!");
        }

    }
}
