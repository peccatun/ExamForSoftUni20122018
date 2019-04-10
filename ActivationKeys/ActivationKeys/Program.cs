using System;
using System.Text;
using System.Collections.Generic;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wrongKeys = Console.ReadLine().Split('&');
            List<string> validKeys = new List<string>();
            for (int i = 0; i < wrongKeys.Length; i++)
            {
                bool isNotLetterOrDig = true;
                for (int symbol = 0; symbol < wrongKeys[i].Length; symbol++)
                {
                    if (!char.IsLetter(wrongKeys[i][symbol]) && !char.IsDigit(wrongKeys[i][symbol]))
                    {
                        isNotLetterOrDig = false;
                    }
                }
                bool isLong = false;
                if (isNotLetterOrDig)
                {
                    if (wrongKeys[i].Length == 16 || wrongKeys[i].Length == 25)
                    {
                        isLong = true;
                    }
                }
                if (isNotLetterOrDig == true && isLong == true)
                {
                    StringBuilder key = new StringBuilder();
                    if (wrongKeys[i].Length == 16)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            char letter = wrongKeys[i][j];
                            if (char.IsLetter(letter) && char.IsLower(letter))
                            {
                                letter = char.ToUpper(letter);
                                key.Append(letter);
                                continue;
                            }
                            if (char.IsDigit(letter))
                            {
                                int digit = Math.Abs((int)char.GetNumericValue(letter) - 9);
                                key.Append(digit);
                                continue;
                            }
                            key.Append(letter);
                        }
                    }
                    if (wrongKeys[i].Length == 25)
                    {
                        for (int j = 0; j < wrongKeys[i].Length; j++)
                        {
                            char letter = wrongKeys[i][j];
                            if (char.IsLetter(letter) && char.IsLower(letter))
                            {
                                letter = char.ToUpper(letter);
                                key.Append(letter);
                                continue;
                            }
                            if (char.IsDigit(letter))
                            {
                                int digit = Math.Abs((int)char.GetNumericValue(letter) - 9);
                                key.Append(digit);
                                continue;
                            }
                            key.Append(letter);
                        }
                    }
                    int lenght = key.Length;
                    int groubsBy = 0;
                    if (key.Length == 16)
                    {
                        groubsBy = 4;
                    }
                    if (key.Length == 25)
                    {
                        groubsBy = 5;
                    }
                    StringBuilder validKey = new StringBuilder();
                    int count = 0;
                    for (int j = 0; j < lenght; j++)
                    {
                        char letter = key[j];
                        if (count == groubsBy)
                        {
                            validKey.Append('-');
                            count = 0;
                        }
                        count++;
                        validKey.Append(letter);
                    }
                    validKeys.Add(validKey.ToString());
                }
            }
            Console.WriteLine(string.Join(", ",validKeys));
        }
    }
}
