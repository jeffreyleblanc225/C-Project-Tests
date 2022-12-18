using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * GetFactorial(n - 1);
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items.Length == 0)
            {
                return string.Empty;
            }
            if (items.Length == 1)
            {
                return items[0];
            }

            var result = string.Empty;
            for (int i = 0; i < items.Length; i++)
            {
                result += items[i];
                if (i == items.Length - 2)
                {
                    result += " and ";
                }
                else if (i < items.Length - 2)
                {
                    result += ", ";
                }
            }

            return result;
        }
    }
}