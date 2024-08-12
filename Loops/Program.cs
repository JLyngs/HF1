using System;
using System.Collections.Generic;
namespace Loops
{

    internal class Program
    {
        static void Main()
        {
            // Multiplication table
            MultiplicationTable();

            // The biggest number
            int[] array1 = { 190, 291, 145, 209, 280, 200 };
            int[] array2 = { -9, -2, -7, -8, -4 };

            Console.WriteLine("The biggest number in the first array: " + TheBiggestNumber(array1));
            Console.WriteLine("The biggest number in the second array: " + TheBiggestNumber(array2));

            // Two 7s next to each other
            int[] digits1 = { 8, 2, 5, 7, 9, 0, 7, 7, 3, 1 };
            int[] digits2 = { 9, 4, 5, 3, 7, 7, 7, 3, 2, 5, 7, 7 };

            Console.WriteLine("Number of two 7's are next to each other in the first array: " + Two7sNextToEachOther(digits1));
            Console.WriteLine("Number of two 7's are next to each other in the second array: " + Two7sNextToEachOther(digits2));

            // Three increasing adjacent
            int[] numbers1 = { 45, 23, 44, 68, 65, 70, 80, 81, 82 };
            int[] numbers2 = { 7, 3, 5, 8, 9, 3, 1, 4 };

            Console.WriteLine("Three increasing adjacent numbers in the first array: " + ThreeIncreasingAdjacent(numbers1));
            Console.WriteLine("Three increasing adjacent numbers in the second array: " + ThreeIncreasingAdjacent(numbers2));

            // Sieve of Eratosthenes
            int n = 30;
            Console.WriteLine("Prime numbers up to " + n + ": " + string.Join(", ", SieveOfEratosthenes(n)));

            // Extract string M
            Console.WriteLine("Extracted string: " + ExtractString("##abc##def"));
            Console.WriteLine("Extracted string: " + ExtractString("12####78"));
            Console.WriteLine("Extracted string: " + ExtractString("gar##d#en"));
            Console.WriteLine("Extracted string: " + ExtractString("++##--##++"));

            //Full Sequence of letters M
            Console.WriteLine(FullSequenceOfLetters("ds"));
            Console.WriteLine(FullSequenceOfLetters("or"));

            //Sum and average
            Console.WriteLine(SumAndAverage(11, 66));
            Console.WriteLine(SumAndAverage(-10, 0));

            //Draw triangle
            DrawTriangle();

            //To The power of
            Console.WriteLine("ToThePowerOf(-2, 3): " + ToThePowerOf(-2, 3));
            Console.WriteLine("ToThePowerOf(5, 5): " + ToThePowerOf(5, 5));

        }

        // Multiplication table
        static void MultiplicationTable()
        {
            int size = 10;

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Console.Write((i * j).ToString().PadRight(4));
                }
                Console.WriteLine();
            }
        }

        // The biggest number
        static int TheBiggestNumber(int[] numbers)
        {
            int biggest = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > biggest)
                {
                    biggest = numbers[i];
                }
            }

            return biggest;
        }

        // Two 7s next to each other
        static int Two7sNextToEachOther(int[] digits)
        {
            int count = 0;

            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == 7 && digits[i + 1] == 7)
                {
                    count++;
                }
            }

            return count;
        }

        // Three increasing adjacent
        static bool ThreeIncreasingAdjacent(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i + 1] == numbers[i] + 1 && numbers[i + 2] == numbers[i + 1] + 1)
                {
                    return true;
                }
            }

            return false;
        }

        // Sieve of Eratosthenes
        static List<int> SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            List<int> primes = new List<int>();

            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        // Extract string M
        static string ExtractString(string input)
        {
            int firstDoubleHash = input.IndexOf("##");

            if (firstDoubleHash == -1 || firstDoubleHash >= input.Length - 2)
            {
                return string.Empty;
            }

            int secondDoubleHash = input.IndexOf("##", firstDoubleHash + 2);

            if (secondDoubleHash == -1)
            {
                return string.Empty;
            }

            return input.Substring(firstDoubleHash + 2, secondDoubleHash - firstDoubleHash - 2);
        }

        //Full sequence of letters M
        static string FullSequenceOfLetters(string input)
        {
            char firstChar = input[0];
            char lastChar = input[1];

            string result = string.Empty;

            for (char c = firstChar; c <= lastChar; c++)
            {
                result += c;
            }

            return result;
        }

        //Sum and average
        static string SumAndAverage(int n, int m)
        {
            int count = m - n + 1;
            int sum = (count * (n + m)) / 2;
            double average = (double)sum / count;

            return $"Sum: {sum}, Average: {average}";
        }

        static void DrawTriangle()
        {
            int numberOfRows = 9; // Number of rows in the triangle

            for (int i = 0; i < numberOfRows; i++)
            {
                // Print leading spaces
                for (int j = 0; j < numberOfRows - i - 1; j++)
                {
                    Console.Write(" ");
                }

                // Print stars
                for (int k = 0; k < 2 * i + 1; k++)
                {
                    Console.Write("*");
                }

                // Move to the next line
                Console.WriteLine();
            }
        }

        static int ToThePowerOf(int baseNumber, int exponent)
        {
            int result = 1;
            for (int i = 0; i < Math.Abs(exponent); i++)
            {
                result *= baseNumber;
            }
            if (exponent < 0)
            {
                return 1 / result;
            }

            return result;
        }
    }
}
