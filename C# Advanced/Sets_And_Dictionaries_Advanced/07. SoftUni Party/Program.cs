
namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            string guests = Console.ReadLine();

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            while (guests != "END")
            {
                if (guests == "PARTY")
                {

                    while (true)
                    {
                        string currentGuest = Console.ReadLine();
                        if (currentGuest == "END")
                        {
                            Console.WriteLine(vip.Count + regularGuests.Count);

                            foreach (var vips in vip)
                            {
                                Console.WriteLine(vips);
                            }
                            foreach (var regularGuest in regularGuests)
                            {
                                Console.WriteLine(regularGuest);
                            }
                            return;
                        }

                        if (vip.Contains(currentGuest))
                        {
                            vip.Remove(currentGuest);
                        }
                        if (regularGuests.Contains(currentGuest))
                        {
                            regularGuests.Remove(currentGuest);
                        }
                    }
                }
                if (char.IsDigit(guests[0]))
                {
                    vip.Add(guests);
                }
                else
                {
                    regularGuests.Add(guests);
                }

                guests = Console.ReadLine();
            }
            
        }
    }
}
