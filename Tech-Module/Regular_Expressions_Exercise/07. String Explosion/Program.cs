using System;
using System.Linq;
using System.Collections.Generic;
namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string field = Console.ReadLine();
            List<char> elementsOfField = new List<char>();

            double currentRadius = 0;

            for (int i = 0; i < field.Length; i++)
            {
                elementsOfField.Add(field[i]);
            }

            for (int i = 0; i < elementsOfField.Count; i++)
            {
               
                if (elementsOfField[i] == '>')
                {
                    double radius = char.GetNumericValue(elementsOfField[i + 1]);

                    int currentI = i;

                    for (int j = i + 1; j <= radius + currentI; j++)
                    {

                        if (elementsOfField[j] != '>')
                        {
                            elementsOfField[j] = '#';
  
                        }
                        else if (elementsOfField[j] == '>')
                        {
                            i = j - 1;
                            
                            break;
                        }
                    }
                    
                }
            }
            foreach (var letter in elementsOfField.Where(x => x != '#'))
            {
                if (letter != ' ')
                {
                    Console.Write(letter);
                }
            }
        }
    }
}
