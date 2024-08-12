using System;

namespace Calculator
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to my Calculator-inator\n");

            double res = 0;
            double nmb1 = 0;
            double nmb2 = 0;
            string symbol = string.Empty;
            bool isFirstCalculation = true;

            while (true)
            {
                if (isFirstCalculation)
                {
                    Console.WriteLine("\nPlease enter the first number: ");
                    while (true)
                    {
                        try
                        {
                            nmb1 = Convert.ToDouble(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid number entered. Please enter a valid number.");
                        }
                    }
                }
                else
                {
                    nmb1 = res; // Use the result of the previous calculation
                    Console.WriteLine($"Using previous result as first number: {nmb1}");
                }

                Console.WriteLine("Enter operator/symbol to calculate with. Options: (+, -, *, /, %): ");
                while (true)
                {
                    symbol = Console.ReadLine();
                    if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/" || symbol == "%")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid operator/symbol entered. Options: (+, -, *, /, %)");
                    }
                }

                Console.WriteLine("Enter the second number: ");
                while (true)
                {
                    try
                    {
                        nmb2 = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid number entered. Please enter a valid number.");
                    }
                }

                switch (symbol)
                {
                    case "+":
                        res = nmb1 + nmb2;
                        Console.WriteLine("Result is: " + res);
                        break;

                    case "-":
                        res = nmb1 - nmb2;
                        Console.WriteLine("Result is: " + res);
                        break;

                    case "*":
                        res = nmb1 * nmb2;
                        Console.WriteLine("Result is: " + res);
                        break;

                    case "/":
                        if (nmb2 != 0)
                        {
                            res = nmb1 / nmb2;
                            Console.WriteLine("Result is: " + res);
                        }
                        else
                        {
                            Console.WriteLine("Please do not divide by zero.");
                        }
                        break;

                    case "%":
                        res = (nmb1 * nmb2) / 100;
                        Console.WriteLine($"Result is: {nmb1}% of {nmb2} = {res}");
                        break;
                }
                while (true)
                {
                    Console.WriteLine("Press [Enter] to continue with result, [ESC] to exit, or [R] to restart calculation.");
                    var key = Console.ReadKey(intercept: true).Key; // Intercept true to supress echo of keypress
                    if (key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Exiting Calculator in:\n..3");
                        Thread.Sleep(1000);
                        Console.WriteLine("..2");
                        Thread.Sleep(1000);
                        Console.WriteLine("..1!");
                        Thread.Sleep(1000);
                        Console.WriteLine("Goodbye!!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    else if (key == ConsoleKey.R)
                    {
                        isFirstCalculation = true; // Reset to start fresh
                        Console.WriteLine("\nRestarting calculation..\n");
                    }
                    else if (key == ConsoleKey.Enter)
                    {
                        isFirstCalculation = false;
                        Console.WriteLine("\nContinuing calculation with previous result..\n");
                    }
                    else
                    {
                        Console.WriteLine($"{key} is not an option, try again..");
                    }

                }
            }
        }
    }
}
