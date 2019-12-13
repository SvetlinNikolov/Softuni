using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Chrono
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
    
        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
          

            this.Laps = new List<string>();
        }

        public string GetTime => this.stopwatch.Elapsed.ToString();
        public List<string> Laps { get; private set; } 

        public string Lap()
        {
            TimeSpan currentElapsed = stopwatch.Elapsed;

            this.Laps.Add(currentElapsed.ToString());
            return currentElapsed.ToString();
        }

        public void Reset()
        {
            this.stopwatch = new Stopwatch();
            this.Laps = new List<string>();
        }

        public void Start()
        {

            stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        
        }
    }
}
