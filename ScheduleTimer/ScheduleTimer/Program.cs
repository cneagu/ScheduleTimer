using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            ScheduleTime.GetInstance();
            ScheduleTime.schedule_Timer();
            Console.ReadKey();
        }
    }
}
