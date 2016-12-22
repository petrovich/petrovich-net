using System;

namespace NPetrovich.Eval.Helper
{
    public class Timer
    {
        private DateTime Start { get; }

        public Timer()
        {
            Start = DateTime.Now;
        }

        public TimeSpan Duration => DateTime.Now - Start;

        public override string ToString()
        {
            return Duration.ToString();
        }
        
    }
}