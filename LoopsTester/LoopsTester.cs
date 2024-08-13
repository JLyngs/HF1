using Loops;
using Xunit;
namespace LoopsTester
{
    public class LoopsTester
    {
        [Fact]
        public void LoopsTestFullSequenceOfLetters()
        {
            //Arrange
            Console.WriteLine(FullSequenceOfLetters("ds"));
            Console.WriteLine(FullSequenceOfLetters("or"));
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
            string Expected = "defghijklmnopqrs";

            string Expected2 = "opqr";


            //Act
            string Actual = FullSequenceOfLetters("ds");
            string Actual2 = FullSequenceOfLetters("or");

            //Assert
            Assert.Equal(Expected, Actual);
            Assert.Equal(Expected2, Actual2);
        }
    }
}