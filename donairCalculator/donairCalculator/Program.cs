/*
 * Name: Holman Gonzalez 
 * Date: June 22, 2025
 * Purpose: Assignment #2, Donair Calculator - Programming Fundamentals
 */



namespace donairCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the Donair Order Calculator!");
            while (true)
            {
                string size;
                double basePrice = 0;
                while (true)
                {
                    Console.Write("Choose a donair size (Regular, Large, Super): ");
                    size = Console.ReadLine().Trim().ToLower();

                    if (size == "regular")
                    {
                        basePrice = 6.50;
                        break;
                    }
                    else if (size == "large")
                    {
                        basePrice = 8.00;
                        break;
                    }
                    else if (size == "super")
                    {
                        basePrice = 9.50;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid size. Please enter Regular, Large, or Super.");
                    }
                }

                bool extraCheese = AskYesNo("Extra cheese? (y/n): ");
                bool extraMeat = AskYesNo("Extra meat? (y/n): ");
                int quantity = 0;

                while (true)
                {
                    Console.Write("How many donairs would you like? ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out quantity) && quantity > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid whole number.");
                    }
                }

                double cheesePrice = 0;
                if (extraCheese)
                {
                    cheesePrice = 1.25;
                }

                double meatPrice = 0;
                if (extraMeat)
                {
                    meatPrice = 2.00;
                }

                double addOnPricePerDonair = cheesePrice + meatPrice;

                double addOnTotal = addOnPricePerDonair * quantity;
                double baseTotal = basePrice * quantity;
                double subtotal = baseTotal + addOnTotal;


                double discount = 0;

                if (subtotal > 40)
                {
                    discount = subtotal * 0.10;
                }

                double subtotalAfterDiscount = subtotal - discount;
                double gst = subtotalAfterDiscount * 0.05;
                double total = subtotalAfterDiscount + gst;

                Console.WriteLine("\n======== RECEIPT ======");
                Console.WriteLine($"Subtotal:          ${subtotal,8:F2}");
                Console.WriteLine($"Discount:        - ${discount,8:F2}");
                Console.WriteLine($"GST (5%):          ${gst,8:F2}");
                Console.WriteLine($"Total:             ${total,8:F2}");
                Console.WriteLine("================================\n");

                if (AskYesNo("Would you like to place another order? (y/n): ") == false)
                {
                    break;
                }
            }

            Console.WriteLine("Thank you! Goodbye");
        }

        static bool AskYesNo(string message)
        {
            while (true)
            {
                Console.Write(message);
                string answer = Console.ReadLine().Trim().ToLower();

                if (answer == "y" || answer == "yes")
                {
                    return true;
                }
                else if (answer == "n" || answer == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                }
            }
        }
    }
}