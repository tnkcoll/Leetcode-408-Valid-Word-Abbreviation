using System.Data.SqlTypes;
using System;

namespace Leetcode_408_Valid_Word_Abbreviation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ValidWordAbbreviation("internationalization", "i12iz4n"));
        }

        public static bool ValidWordAbbreviation(string word, string abbr)
        {
            string num = "";
            int i = 0;
            int j = 0;

            while (i < word.Length && j < abbr.Length)
            {
                if (char.IsDigit(abbr[j]))
                {
                    num = num + abbr[j++];
                }
                else
                {
                    if (num.Length > 0)
                    {
                        if (num[0] == '0')
                        {
                            return false;
                        }

                        i = i + Int32.Parse(num);
                        num = "";
                    }

                    if (i >= word.Length || word[i] != abbr[j])
                        return false;

                    i++;
                    j++;
                }
            }

            if (num.Length > 0)
            {
                if (num[0] == '0')
                    return false;

                i = i + Int32.Parse(num);
            }

            return i == word.Length && j == abbr.Length;
        }
    }
}
