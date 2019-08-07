using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Enigne engine = new Enigne();
            engine.Run();

        }
    }
}
