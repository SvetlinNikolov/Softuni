using System;

namespace ValidPerson
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Person noName = new Person("Gosho", "4eko perez", 999);
            }
            catch (ArgumentNullException ae)
            {

                Console.WriteLine($"Exception thrown: {ae.Message}");
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine($"Exception thrown: {ae.Message}");
            }  
            
        }
    }
}
