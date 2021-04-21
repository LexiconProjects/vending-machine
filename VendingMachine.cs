using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    class VendingMachine
    {

        public static readonly string[] productPosition = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        public static readonly string[,] productNameAndPrice = new string[12, 2] { { "Coca-Cola", "15" }, { "Trocadero", "15" },{ "Orange Juice","25" },{ "Monster Energy","15" },
            { "OLW Chips", "20" },{ "Salted Popcorn","15" },{ "Nut Mix Classic", "25" },{ "Doritos Nacho","15" },
            { "Protein Bar","25" },{ "Bounty Double", "15" },{"Kexchoklad","10" },{"Kinder Bueno","20" } };

        private Dictionary<string, Drink> drinks = new Dictionary<string, Drink>();
        private Dictionary<string, Snack> snacks = new Dictionary<string, Snack>();
        private Dictionary<string, Sweet> sweets = new Dictionary<string, Sweet>();
            
        private MoneyPool transaction = new MoneyPool();

        private Drink drink;
        private Snack snack;
        private Sweet sweet;

        private string input;
        private int productPrice;

        public VendingMachine()
        {
            FillVendingMachine();
            PrintMenu();
            transaction.RequestCredit();
            GetSelection();
            PrintExitMessage();
        } 

        private void FillVendingMachine()
        {
            foreach(string position in productPosition)
            {
                int index = Convert.ToInt32(position)-1;
                switch (position)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        drink = new Drink("drink", position, productNameAndPrice[index, 0], productNameAndPrice[index, 1]);
                        drinks.Add(position, drink);
                        break;

                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        snack = new Snack("snack", position, productNameAndPrice[index, 0], productNameAndPrice[index, 1]);
                        snacks.Add(position, snack);
                        break;

                    case "9":
                    case "10":
                    case "11":
                    case "12":
                        sweet = new Sweet("sweet",position, productNameAndPrice[index, 0], productNameAndPrice[index, 1]);
                        sweets.Add(position, sweet);
                        break;

                }
                
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            Console.WriteLine("Vending Machine was stocked with the following products:\n");
            Console.WriteLine(" ID    Type        Name                 Price");

            foreach(KeyValuePair<string,Drink>productPair in drinks)
            {   
                drink = productPair.Value;
                drink.PrintProductInformation();
            }

            foreach (KeyValuePair<string, Snack> productPair in snacks)
            {    
                snack = productPair.Value;
                snack.PrintProductInformation();
            }

            foreach (KeyValuePair<string, Sweet> productPair in sweets)
            {
                sweet = productPair.Value;
                sweet.PrintProductInformation();
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

        }

        private void PrintMenu()
        {
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine("|                       HAVE A BREAK! Grab a snack before you continue your work!                     |");
            Console.WriteLine("|    First add your credit. We accept only 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr.       |");
            Console.WriteLine("|                            Then pick one of the following treats!                                   |");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------D R I N K S----------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("-  _____________________    _____________________    _____________________    _____________________  -");
            Console.WriteLine("- |    (1) Coca-Cola    |  |    (2) Trocadero    |  |  (3) Orange Juice   |  | (4) Monster Energy  | -");
            Console.WriteLine("- |_________15kr________|  |_________15kr________|  |_________25kr________|  |_________15kr________| -");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------S N A C K S----------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("-  _____________________    _____________________    _____________________    _____________________  -");
            Console.WriteLine("- |    (5) OLW Chips    |  | (6) Salted Popcorn  |  | (7) Nut Mix Classic |  |  (8) Doritos Nacho  | -");
            Console.WriteLine("- |_________20kr________|  |_________15kr________|  |_________25kr________|  |_________15kr________| -");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------S W E E T S---------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("-  _____________________    _____________________    _____________________    _____________________  -");
            Console.WriteLine("- |   (9) Protein Bar   |  | (10) Bounty Double  |  |  (11) Kexchoklad    |  |  (12) Kinder Bueno  | -");
            Console.WriteLine("- |________25kr_________|  |_________15kr________|  |________10kr_________|  |_________20kr________| -");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
        }   

        private void GetSelection()
        {

            do
            {
                transaction.PrintCredit();
                PrintSelectionMessage();

                input = Console.ReadLine();
                if (int.TryParse(input, out int selection))
                {
                    if (ValidateSelection(input))
                    {
                        switch (input)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                                drink = drinks[input];
                                productPrice = Convert.ToInt32(drink.GetPrice());

                                if (AffordProduct())
                                    drink.PrintProductInstructions();
                                break;

                            case "5":
                            case "6":
                            case "7":
                            case "8":
                                snack = snacks[input];
                                productPrice = Convert.ToInt32(snack.GetPrice());

                                if (AffordProduct())
                                    snack.PrintProductInstructions();
                                break;

                            case "9":
                            case "10":
                            case "11":
                            case "12":
                                sweet = sweets[input];
                                productPrice = Convert.ToInt32(sweet.GetPrice());

                                if (AffordProduct())
                                    sweet.PrintProductInstructions();
                                break;

                        }

                    }
                    else
                        Console.WriteLine("ERROR: Press a button between 1 and 12 to get correspondent product.");

                }
                else if(input !="c")
                    Console.WriteLine("ERROR: Invalid choice,please try again!");


            } while (input != "c");

            transaction.ReturnChange();

        }


        private void PrintSelectionMessage()
        {
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine("|       PLEASE SELECT A PRODUCT (1-12) OR PRESS c TO RETURN CREDIT.                                   |");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.Write("| > ");
        }

        private bool ValidateSelection(string input)
        {
            return productPosition.Contains(input);
        }

        private bool AffordProduct()
        {
            if (transaction.CheckCredit(productPrice))
            {
                transaction.UpdateCredit(-productPrice);
                return true;
            }
            else
            {
                Console.WriteLine("Not enough credit for the selected product.");
                transaction.RequestCredit();
                return false;
            }
        }      

        private void PrintExitMessage()
        {
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine($"|         THANK YOU FOR USING OUR VENDING MACHINE! COME BACK WHENEVER YOU PLEASE!                    |");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
            Console.WriteLine(" ----------------------------------------------------------------------------------------------------- ");
        }

    }
}
