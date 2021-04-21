using System;

namespace VendingMachine
{
    class Drink : Product
    {
        public Drink(string type, string position, string name, string price)
        {
            SetType(type);
            SetPlace(position);
            SetName(name);
            SetPrice(price);
        }

        public override void PrintProductInstructions()
        {
            Console.WriteLine($"Drink your {name} while it's cold! Grab it now!");
        }

    }
}
