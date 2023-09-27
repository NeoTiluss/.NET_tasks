using System;

class CoinChangeCalculator
{
    static int[] availableCoinValues = { 50, 20, 10, 5, 1 };

    static int CalculateMinimumCoins(int amount)
    {
        int coinCount = 0;

        foreach (int coinValue in availableCoinValues)
        {
            while (amount >= coinValue)
            {
                amount -= coinValue;
                coinCount++;
            }
        }

        return coinCount;
    }

    static void Main()
    {
        Console.WriteLine("Coin Change Calculator");
        Console.WriteLine("Enter the amount in tetri: ");
        int amount = int.Parse(Console.ReadLine());

        int minimumCoins = CalculateMinimumCoins(amount);

        Console.WriteLine($"Minimum number of coins needed: {minimumCoins}");
    }
}
