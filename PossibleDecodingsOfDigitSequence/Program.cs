using System;

namespace PossibleDecodingsOfDigitSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Possible Decodings of a digit sequence!");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine();
            PrintDecodingsOfDigitSequence();

            Console.ReadLine();
        }

        private static void PrintDecodingsOfDigitSequence() {

            Console.WriteLine("Enter the digit sequence");
            try
            {
                var digitSequence = Console.ReadLine().Trim();
                _PrintDecodings(digitSequence.ToCharArray());

            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is " +
                    exception.Message);
            }

        }

        private static void _PrintDecodings(Char[] charArray) {
            int[] count = new int[charArray.Length+1];

            count[0] = count[1] = 1;

            for (int index = 2; index <= charArray.Length; index++) {
                count[index] = 0;

                if (charArray[index - 1] > '0') {
                    count[index] += count[index - 1];
                }

                if ((charArray[index - 2] == '1' || charArray[index - 2] == '2')
                    && charArray[index - 1] < '7') {
                    count[index] += count[index-2];
                }
            }

            Console.WriteLine("Possible decodings :" + count[charArray.Length]);
        }
    }
}
