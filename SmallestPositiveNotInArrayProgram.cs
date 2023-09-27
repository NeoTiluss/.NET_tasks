using System;
using System.Linq;

class SmallestPositiveNotInArrayProgram
{
    static int FindSmallestPositiveNotInArray(int[] array)
    {
        // Remove negative numbers and zeros from the array
        array = array.Where(x => x > 0).ToArray();

        // If the array is empty or does not contain 1, return 1 as the smallest positive integer
        if (!array.Contains(1))
        {
            return 1;
        }

        // Sorting
        Array.Sort(array);

        // Iterate through the sorted array to find the smallest missing positive integer
        int smallestMissing = 1;
        foreach (int number in array)
        {
            if (number == smallestMissing)
            {
                smallestMissing++;
            }
            else if (number > smallestMissing)
            {
                return smallestMissing;
            }
        }

        return smallestMissing;
    }

    static void Main()
    {
        Console.WriteLine("Enter the array of integers (comma-separated): ");
        string input = Console.ReadLine();

        // Split the user input by commas and parse it into an integer array
        int[] array = input.Split(',').Select(int.Parse).ToArray();

        int result = FindSmallestPositiveNotInArray(array);

        Console.WriteLine($"The smallest positive integer not in the array is: {result}");
    }
}
