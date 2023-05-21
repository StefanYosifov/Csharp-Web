using System.Diagnostics;

namespace Chronometer
{
    internal class Chronometer : IChronometer.IChronometer
    {
        private readonly Stopwatch stopwatch;

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            Laps = new List<string>();
        }


        public string GetTime => stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");
        public List<string> Laps { get; }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public string Lap()
        {
            Laps.Add(GetTime);
            return GetTime;
        }

        public void Reset()
        {
            stopwatch.Reset();
            Laps.Clear();
        }
    }
}