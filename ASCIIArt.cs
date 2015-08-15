using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace CGC
{
    class Letters
    {
        public Letters(int h)
        {
            letter = new Letter[chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                letter[i] = new Letter(h);
            }
        }
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        public char[] chars = letters.ToCharArray();
        public Letter[] letter { get; set; }
    }

    class Letter
    {
        public Letter(int h)
        {
            asciiletter = new string[h];
            letter = "";
        }
        public string letter { get; set; }
        public string[] asciiletter { get; set; }
    }
    class Solution
    {

        public static Letters letters;

        static void init(int h)
        {
            letters = new Letters(h);
        }

        static void parseRow(int l, int h, string row)
        {
            int start = 0;
            for (int i = 0; i < letters.letter.Length; i++)
            {
                string hashes = row.Substring(start, l);
                start += l;
                letters.letter[i].letter = letters.chars[i].ToString();
                letters.letter[i].asciiletter[h] = hashes;
            }

        }

        static string[] getLetter(char whatletter)
        {
            Letter letter = letters.letter.FirstOrDefault(f => f.letter == whatletter.ToString().ToUpper());
            if (letter == null)
            {
                letter = letters.letter.FirstOrDefault(f => f.letter == "?");
            }
            return letter.asciiletter;
        }

        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            int H = int.Parse(Console.ReadLine());
            string T = Console.ReadLine();
            init(H);
            for (int i = 0; i < H; i++)
            {
                string ROW = Console.ReadLine();
                parseRow(L, i, ROW);
            }

            char[] phrase = T.ToCharArray();
            string[] result = new string[phrase.Length];
            for (int i = 0; i < H; i++)
            {
                for (int x = 0; x < phrase.Length; x++)
                {
                    result[x] = getLetter(phrase[x])[i];
                }
                Console.WriteLine(String.Join("", result));
            }

        }
    }
}
