using System;
using System.Collections.Generic;

class Program
{
    static bool IsProperlyPlacedParentheses(string sequence)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in sequence)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    static void Main()
    {
        Console.WriteLine("Enter a sequence of parentheses: ");
        string input = Console.ReadLine();

        bool isProperlyPlaced = IsProperlyPlacedParentheses(input);

        if (isProperlyPlaced)
        {
            Console.WriteLine("The parentheses are properly placed.");
        }
        else
        {
            Console.WriteLine("The parentheses are not properly placed.");
        }
    }
}
