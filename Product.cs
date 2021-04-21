using System;

namespace VendingMachine
{
    abstract class Product
    {
        protected string position;
        protected string type;
        protected string name;
        protected string price;

        private protected void SetPlace(string place) 
        {
            this.position = place;
        }

        private protected void SetPrice(string price)
        {
            this.price = price;
        }

        private protected void SetType(string type)
        {
            this.type = type;
        }

        private protected void SetName(string name)
        {
            this.name = name;
        }

        internal string GetPrice()
        {
            return price;
        }


        public abstract void PrintProductInstructions();
      
        internal void PrintProductInformation()
        {
            Console.WriteLine(" {0,-5} {1,-11} {2,-20} {3,-3}kr", position, type, name, price);
        }

    }
}
