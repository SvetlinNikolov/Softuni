using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] nameAndAddress = Console.ReadLine()
                .Split(" ");

            string firstAndLastName = $"{nameAndAddress[0]} {nameAndAddress[1]}";
            string address = nameAndAddress[2];
            string town = nameAndAddress[3];

            string[] nameAndLitersOfBeer = Console.ReadLine()
                .Split(" ");

            string nameOfPersonDrinkingBeer = nameAndLitersOfBeer[0];
            int litersOfBeer = int.Parse(nameAndLitersOfBeer[1]);
            bool drunkOrNot = nameAndLitersOfBeer[2] == "drunk" ? true : false;

            string[] integerAndDouble = Console.ReadLine()
                .Split(" ");

            string personNameBankBalance = integerAndDouble[0];
            double accountBalance = double.Parse(integerAndDouble[1]);
            string bankName = integerAndDouble[2];


            Tuple<string, string, string> nameAndAddressTuple =
                new Tuple<string, string, string>(firstAndLastName, address, town);

            Tuple<string, int, bool> nameAndLitersOfBeerTuple =
                new Tuple<string, int, bool>(nameOfPersonDrinkingBeer, litersOfBeer, drunkOrNot);

            Tuple<string, double, string> intAndDoubleTuple =
                new Tuple<string, double, string>(personNameBankBalance, accountBalance, bankName);


            Console.WriteLine(nameAndAddressTuple.GetInfo());
            Console.WriteLine(nameAndLitersOfBeerTuple.GetInfo());
            Console.WriteLine(intAndDoubleTuple.GetInfo());
        }
    }
}
