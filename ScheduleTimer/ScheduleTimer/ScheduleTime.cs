using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ScheduleTimer
{
    public sealed class ScheduleTime
    {
        private static readonly ScheduleTime instance = new ScheduleTime();
        private static Timer timer = new Timer();
        //
        private static int NumberOfAparition7 = 0;
        private static int NumberOfAparition5 = 0;
        private static int NumberOfAparition10 = 0;
        private static DateTime nw = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 59, 59, 0);
        //
        private ScheduleTime() { }
        public static ScheduleTime GetInstance()
        {
            return instance;
        }

        public static void schedule_Timer()
        {
            Console.WriteLine("### Timer Started ###");

            DateTime nowTime = nw;
            DateTime sevenHour = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 19, 0, 0, 0);
            DateTime fiveHour = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 5, 0, 0, 0);
            DateTime tenHour = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 10, 0, 0, 0);

            if (nowTime > sevenHour)
            {
                timer.Interval = (double)(fiveHour.AddDays(1) - nowTime).TotalMilliseconds;
                timer.Elapsed += OnFive;
            }
            else if (nowTime <= fiveHour)
            {
                timer.Interval = (double)(fiveHour - nowTime).TotalMilliseconds;
                timer.Elapsed += OnFive;
            }
            else if (nowTime > fiveHour && nowTime <= tenHour)
            {
                timer.Interval = (double)TimeSpan.FromMinutes(10).TotalMilliseconds;
                timer.Elapsed += OnTenMinutes;
            }
            else if (nowTime > tenHour && nowTime <= sevenHour)
            {
                timer.Interval = (double)(sevenHour - nowTime).TotalMilliseconds;
                timer.Elapsed += OnSeven;
            }

            Console.WriteLine(timer.Interval);
            timer.Start();
        }

        static void OnSeven(object sender, ElapsedEventArgs e)
        {
            timer.Elapsed -= OnSeven;
            timer.Stop();
            Console.WriteLine("### Scheduled Task Started ### \n\n");
            Console.WriteLine("Hello seven!!! - Performing scheduled task\n");
            Console.WriteLine(NumberOfAparition7++);
            nw = new DateTime(nw.Year, nw.Month, nw.Day, 4, 59, 59, 0);
            Console.WriteLine("### Task Finished ### \n\n");
            schedule_Timer();
        }

        static void OnFive(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("### Timer Stopped ### \n");
            timer.Elapsed -= OnFive;
            timer.Stop();
            Console.WriteLine("### Scheduled Task Started ### \n\n");
            Console.WriteLine("Hello five!!! - Performing scheduled task\n");
            Console.WriteLine(NumberOfAparition5++);
            nw = new DateTime(nw.Year, nw.Month, nw.Day, 6, 59, 59, 0);
            Console.WriteLine("### Task Finished ### \n\n");
            schedule_Timer();
        }

        static void OnTenMinutes(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("### Timer Stopped ### \n");
            timer.Elapsed -= OnTenMinutes;
            timer.Stop();
            Console.WriteLine("### Scheduled Task Started ### \n\n");
            Console.WriteLine("Hello ten!!! - Performing scheduled task\n");
            Console.WriteLine(NumberOfAparition10++);
            nw = new DateTime(nw.Year, nw.Month, nw.Day, 10, 59, 59, 0);

            Console.WriteLine("### Task Finished ### \n\n");
            schedule_Timer();
        }
    }
}