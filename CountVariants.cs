using System;

class Program
{
    static int CountVariants(int stairCount)
    {
        // Create an array to store the number of ways to reach each floor
        int[] ways = new int[stairCount + 1];

        // There is one way to reach the ground floor (base case)
        ways[0] = 1;

        // There is one way to reach the first floor (base case)
        ways[1] = 1;

        // Calculate the number of ways for each floor from the bottom up
        for (int i = 2; i <= stairCount; i++)
        {
            ways[i] = ways[i - 1] + ways[i - 2];
        }

        return ways[stairCount];
    }

    static void Main()
    {
        Console.WriteLine("Enter the number of stairs: ");
        int stairCount = int.Parse(Console.ReadLine());

        int variants = CountVariants(stairCount);

        Console.WriteLine($"Number of ways to climb {stairCount} stairs: {variants}");
    }
}
