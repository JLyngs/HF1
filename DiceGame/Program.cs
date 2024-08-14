using DiceGame;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {
                DisplayWelcomeMessage();
                int maxSides = GetMaxSidesFromUser();
                int diceAmount = GetDiceAmountFromUser();

                var diceArray = CreateDiceArray(maxSides, diceAmount);
                var attempts = 0;

                Console.Clear();
                DisplayWelcomeMessage();
                UpdateInduvidualDiceRollNumber(diceArray, attempts);

                while (true)
                {
                    attempts++;
                    RollDice(diceArray);

                    UpdateInduvidualDiceRollNumber(diceArray, attempts);

                    if (CheckIfAllDiceRolledSix(diceArray))
                    {
                        DisplaySuccessMessage(attempts);
                        break;
                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            catch (Exception)
            {
                DisplayInvalidInputMessage();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
    }

    private static int GetMaxSidesFromUser()
    {
        Console.Write("\n\nEnter the max value of sides on the dice: ");
        var maxSides = int.Parse(Console.ReadLine());

        if (maxSides < 6)
        {
            DisplayInvalidMaxSidesMessage();
            return GetMaxSidesFromUser();
        }

        return maxSides;
    }

    private static int GetDiceAmountFromUser()
    {
        Console.Write("\nEnter the amount of dice to throw: ");
        var diceAmount = int.Parse(Console.ReadLine());

        if (diceAmount == 0)
        {
            DisplayInvalidDiceAmountMessage();
            return GetDiceAmountFromUser();
        }

        return diceAmount;
    }

    private static Dice[] CreateDiceArray(int maxSides, int diceAmount)
    {
        var diceArray = new Dice[diceAmount];
        var random = new Random();

        for (int i = 0; i < diceAmount; i++)
        {
            diceArray[i] = new Dice(maxSides, random);
        }

        return diceArray;
    }

    private static void RollDice(Dice[] diceArray)
    {
        foreach (var dice in diceArray)
        {
            dice.Roll();
        }
    }

    private static bool CheckIfAllDiceRolledSix(Dice[] diceArray)
    {
        return diceArray.All(dice => dice.Value == 6);
    }

    private static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Dice Game!\n\n*Objective is to have all dices roll #6 at once*");
    }

    private static void DisplaySuccessMessage(int attempts)
    {
        Console.WriteLine($"\nAll dices landed 6 after {attempts} attempts!");
    }

    private static void DisplayInvalidMaxSidesMessage()
    {
        Console.WriteLine("\nDice must have at least 6 sides.");
        Thread.Sleep(1000);
        Console.Clear();
    }

    private static void DisplayInvalidDiceAmountMessage()
    {
        Console.WriteLine("\nYou must throw at least 1 dice.");
        Thread.Sleep(1000);
        Console.Clear();
    }

    private static void DisplayInvalidInputMessage()
    {
        Console.WriteLine("\nInvalid input. Please try again.");
        Thread.Sleep(1000);
        Console.Clear();
    }

    private static void UpdateInduvidualDiceRollNumber(Dice[] diceArray, int attempts)
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine($"Current total roll attempts: {attempts}");

        for (int i = 0; i < diceArray.Length; i++)
        {
            Console.WriteLine($"Dice {i + 1}: {diceArray[i].Value}");
        }
    }
}