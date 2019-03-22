using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string encryptedText = string.Empty;

            for (char i = char.MinValue; i < text.Length; i++)
            {
                int value = text[i] + 3;
                encryptedText += ((char)value);
            }
            Console.WriteLine(encryptedText);
        }
    }
}
