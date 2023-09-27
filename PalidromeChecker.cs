using System;

class PalindromeChecker
{
    static bool IsPalindrome(string input)
    {
        // Remove spaces and convert to lowercase for case-insensitive comparison
        string cleanedInput = input.Replace(" ", "").ToLower();

        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Palindrome Checker");
        Console.WriteLine("Enter a text: ");
        string textToCheck = Console.ReadLine();

        if (IsPalindrome(textToCheck))
        {
            Console.WriteLine("The input is a palindrome.");
        }
        else
        {
            Console.WriteLine("The input is not a palindrome.");
        }
    }
}
