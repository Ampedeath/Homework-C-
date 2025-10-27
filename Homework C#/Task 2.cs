
namespace Homework
{
    internal class Task_2
    {
        public static void Main()  
        {
            // Task 1
            Console.WriteLine("Task 1: Enter 10 positive numbers (through a space):");

            int[] arr1 = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            Console.WriteLine($"\nTask 1 result: {Task1(arr1)}");

            // Task 2
            Console.WriteLine("\nTask 2: Enter 10 numbers (through a space):");

            int[] arr2 = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            Console.WriteLine($"\nTask 2 result: {Task2(arr2)}");

            // Task 3
            Console.WriteLine("\nTask 3: Enter the elements of a 4x4 matrix (16 numbers separated by spaces):");

            int[] arr3 = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            if (arr3.Length != 16)
            {
                Console.WriteLine("Error: you must enter exactly 16 numbers for a 4x4 matrix!");
                return;
            }

            int[,] matrix = new int[4, 4];
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = arr3[index++];
                }
            }

            (int oddSum, int negCount) = Task3(matrix);
            Console.WriteLine($"Task 3: The sum of odd elements above the main diagonal: {oddSum}");
            Console.WriteLine($"Task 3: Number of negative elements below the main diagonal: {negCount}");
        }

        static int Task1(int[] arr)
        {
            if (arr.Length == 0) return 0;

            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex]) minIndex = i;
                if (arr[i] > arr[maxIndex]) maxIndex = i;
            }

            int start = Math.Min(minIndex, maxIndex);
            int end = Math.Max(minIndex, maxIndex);

            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                if (arr[i] % 2 == 0) 
                    sum += arr[i];
            }

            return sum;
        }

        static int Task2(int[] arr)
        {
            int firstNeg = -1;
            int secondNeg = -1;

            for (int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] < 0)
                {
                    if (firstNeg == -1) firstNeg = i;
                    else { secondNeg = i; break; }
                }
            }

            if (firstNeg == -1 || secondNeg == -1)
                return 0;

            int count = 0;
            for (int i = firstNeg + 1; i < secondNeg; i++)
            {
                if (arr[i] > 0)
                    count++;
            }

            return count;
        }

        static (int oddSum, int negCount) Task3(int[,] matrix)
        {
            int oddSum = 0;
            int negCount = 0;
            int size = 4;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j > i && matrix[i, j] % 2 != 0)
                        oddSum += matrix[i, j];

                    if (j < i && matrix[i, j] < 0)
                        negCount++;
                }
            }

            return (oddSum, negCount);
        }
    }
}