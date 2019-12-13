using System;
using System.Collections.Generic;
using System.Text;

namespace Chrono
{
    public interface IChronometer
    {
        public string GetTime { get; }

        public List<string> Laps { get;  }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}
