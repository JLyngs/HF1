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

        Console.WriteLine("Number of two 7's are next to each other in first array: " + Two7sNextToEachOther(digits1));
        Console.WriteLine("Number of two 7's are next to each other in second array: " + Two7sNextToEachOther(digits2));
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
                // No need to increment i here, as overlapping pairs should be counted
            }
        }

        return count;
    }
}
