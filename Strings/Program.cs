using System.Text;

namespace Strings
{
    internal class Program
    {
        static void Main()
        {
            //Add separator
            Console.WriteLine(AddSeparator("ABCD", "^"));
            Console.WriteLine(AddSeparator("chocolate", "-"));

            //Is palindrome
            Console.WriteLine(IsPalindrome("eye"));
            Console.WriteLine(IsPalindrome("home"));

            //Length of string
            Console.WriteLine(LengthOfString("computer"));
            Console.WriteLine(LengthOfString("ice cream"));

            //String in reverse order
            Console.WriteLine(StringInReverseOrder("qwerty"));
            Console.WriteLine(StringInReverseOrder("oe93 kr"));

            //Number of words
            Console.WriteLine(NumberOfWords("This is sample sentence"));
            Console.WriteLine(NumberOfWords("OK"));

            //Revert words order
            Console.WriteLine(RevertWordsOrder("John Doe."));
            Console.WriteLine(RevertWordsOrder("A, B. C"));

            //How many occurrences
            Console.WriteLine(HowManyOccurrences("do it now", "do"));
            Console.WriteLine(HowManyOccurrences("empty", "d"));

            //Sort characters descending
            Console.WriteLine(SortCharactersDescending("onomatopoeia"));
            Console.WriteLine(SortCharactersDescending("fohjwf42os"));

            //Compress string
            Console.WriteLine(CompressString("kkkktttrrrrrrrrrr"));
            Console.WriteLine(CompressString("p555ppp7www"));
        }

        //Add separator
        static string AddSeparator(string input, string separator)
        {
            return string.Join(separator, input.ToCharArray()) + separator;
        }

        //Is palindrome
        static bool IsPalindrome(string str)
        {
            str = str.ToLower(); //big brain move
            return str.SequenceEqual(str.Reverse());
        }

        //Length of string
        static int LengthOfString(string input)
        {
            int length = 0;

            foreach (char c in input)
            {
                length++;
            }

            return length;
        }

        //String in reverse order
        static string StringInReverseOrder(string input)
        {
            var ReversedString = new string(input.ToCharArray().Reverse().ToArray());

            return ReversedString;
        }

        //Number of words
        static int NumberOfWords(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            int wordCount = 1;

            foreach (char c in input)
            {
                if (c == ' ')
                {
                    wordCount++;
                }
            }

            return wordCount;
        }

        //Revert words order
        static string RevertWordsOrder(string input)
        {
            bool endsWithPeriod = input.EndsWith(".");

            var words = input.TrimEnd('.').Split(' ');

            var result = string.Join(" ", words.Reverse());

            return endsWithPeriod ? result + "." : result;
        }

        //How many occurrences
        static int HowManyOccurrences(string str, string sub)
        {
            var occurrences = str.Split(new[] { sub }, StringSplitOptions.None);
            return occurrences.Length - 1;
        }

        //Sort characters descending
        static string SortCharactersDescending(string input)
        {
            char[] chars = input.ToCharArray();

            Array.Sort(chars);

            Array.Reverse(chars);

            return new string(chars);
        }

        //Compress string
        static string CompressString(string input)
        {
            var compressedString = new StringBuilder();
            int lettercount = 1;

            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    lettercount++;
                }
                else
                {
                    compressedString.Append(input[i - 1]);
                    compressedString.Append(lettercount);
                    lettercount = 1;
                }
            }

            return compressedString.ToString();
        }
    }
}
