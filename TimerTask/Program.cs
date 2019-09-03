using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Handler handler = new Handler();

            timer.StartTimer(1);

            timer.Timeout += handler.OnTimerTimeout;

            timer.StartTimer(5);

            timer.Timeout += handler.OnTimerTimeout;

            Thread.Sleep(6000);

            Console.WriteLine("Timer reached timeout.");
            Console.ReadKey();
        }
    }

    public class Timer
    {
        private Task currentTiming;

        public event EventHandler<TimeoutEventArgs> Timeout;

        public void StartTimer(int seconds)
        {
            currentTiming = new Task(() =>
            {
                Thread.Sleep(seconds * 1000);

                OnTimeout(new Timer(), new TimeoutEventArgs(seconds));
            });

            currentTiming.Start();
        }

        protected virtual void OnTimeout(object sender, TimeoutEventArgs e)
        {
            Timeout(sender, e);
        }
    }

    public class TimeoutEventArgs : EventArgs
    {
        public int Seconds { get; set; }

        public TimeoutEventArgs(int seconds) : base()
        {
            Seconds = seconds;
        }
    }

    class Handler
    {
        public void OnTimerTimeout(object sender, TimeoutEventArgs e)
        {
            Console.WriteLine("First listener: timer {0} reached {1} second timeout.", sender, e.Seconds);
        }
    }
}
