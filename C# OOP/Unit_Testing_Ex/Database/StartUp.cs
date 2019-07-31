using System;

namespace DatabaseProject
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Database database = new Database(1,2,3);
            database.Remove();

        }
    }
}
