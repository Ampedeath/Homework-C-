
namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number(number should be less than 1 000 000 000): ");
            int num = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Sum of the digits of a number: {SumOfDigits(num)}");

            Console.WriteLine($"Number of units in binary notation: {CountOnesInBinary(num)}");

            Console.WriteLine($"The result of digitizing the number N!: {Digitization(num)}");
        }


        static int SumOfDigits( int num) 
        {
            int sum = 0;
            while (num > 0) 
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        static int CountOnesInBinary(int num) 
        {
            int count = 0;

            while (num > 0) 
            {
                if((num & 1) == 1) 
                {
                    count++;
                }
                num >>=1;
            }
            return count;
        }

        static int Digitization(int num)
        {
            if (num == 1 || num == 0) return 1;
            if (num == 2) return 2;
            if (num == 3 || num == 4) return 6;
            if (num == 5) return 3;
            return 9;
        }
    }
}
