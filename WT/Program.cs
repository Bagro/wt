using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WT
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-h":
                        i++;
                        worker.WorkHours = Convert.ToInt32(args[i]);
                        break;
                    case "-m":
                        i++;
                        worker.WorkMinutes = Convert.ToInt32(args[i]);
                        break;
                }
            }

            if (worker.WorkHours > 0 || worker.WorkMinutes > 0)
                worker.Start();
        }
    }
}
