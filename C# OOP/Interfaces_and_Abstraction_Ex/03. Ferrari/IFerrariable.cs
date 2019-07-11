using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IFerrariable
    {
        string Model { get; }
        string Driver { get; }
        string Accelerate();
        string Break();


    }
}
