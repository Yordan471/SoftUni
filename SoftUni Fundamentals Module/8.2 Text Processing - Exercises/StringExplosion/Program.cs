using System;
using System.Buffers;

namespace StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            string[] seqSplit = sequence.Split('>');

            int bombStrength = 0;
            int strengthLeft = 0;

            for (int i = 1; i < seqSplit.Length; i++)
            {
                bombStrength = int.Parse("" + seqSplit[i][0]) + strengthLeft;
                strengthLeft = bombStrength - seqSplit[i].Length;

                if (bombStrength > seqSplit[i].Length)
                {
                    bombStrength = seqSplit[i].Length;
                }

                seqSplit[i] = seqSplit[i].Substring(bombStrength);

                if (strengthLeft < 0)
                {
                    strengthLeft = 0;
                }
            }

            Console.WriteLine(string.Join('>', seqSplit));
        }
    }
}
