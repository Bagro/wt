using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace WT
{
    class Worker
    {
        private Timer _timer;
        private static bool _timerPaused;

        private static DateTime _endTime;

        public int WorkHours { get; set; }
        public int WorkMinutes { get; set; }

        public void Start()
        {
            _endTime = new DateTime();
            _endTime = DateTime.Now.AddHours(WorkHours).AddMinutes(WorkMinutes);
            _timerPaused = false;
            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(TimerTick);
            _timer.Interval = 1000;
            _timer.Enabled = true;

            TheLoop();

            _timer.Enabled = false;
        }

        private void TheLoop()
        {
            string key = string.Empty;

            while (key.ToLower() != "q")
            {
                key = Console.ReadKey().KeyChar.ToString();

                switch (key.ToLower())
                {
                    case "p": //pause resume
                        _timerPaused = _timerPaused == true ? false : true;
                        break;
                    case "r":
                        _endTime = DateTime.Now.AddHours(WorkHours).AddMinutes(WorkMinutes);
                        break;
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_timerPaused)
            {
                _endTime = _endTime.AddSeconds(1);
                
            }

            var timeLeft = _endTime - DateTime.Now;
            Console.Clear();
            Console.WriteLine("Dagens slut: " + _endTime.ToString());
            Console.WriteLine("Tid kvar: " + timeLeft.Hours + "h " + timeLeft.Minutes + "m " + timeLeft.Seconds + "s");
        }
    }
}
