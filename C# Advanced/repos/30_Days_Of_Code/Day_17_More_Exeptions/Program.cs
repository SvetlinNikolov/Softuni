using System;

namespace Day_17_More_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator myCalculator = new Calculator();

            int numberOfInputs = int.Parse(Console.ReadLine());

            while (numberOfInputs-- > 0)
            {
                string[] input = Console.ReadLine().Split();
                int n = int.Parse(input[0]);
                int p = int.Parse(input[1]);

                try
                {
                    int ans = myCalculator.power(n, p);
                    Console.WriteLine(ans);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    class Calculator
    {
        public int n;
        public int p;

        public Calculator() { }
        public Calculator(int n, int p)
        {
            this.n = n;
            this.p = p;
        }

        public int power(int n, int p)
        {
            if (n < 0 || p < 0)
            {
                throw new Exception("n and p should be non-negative");
            }

            int result = 1;

            for (int i = 0; i < p; i++)
            {
                result *= n;
            }

            return result;
        }
    }
}