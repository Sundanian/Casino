﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    class Program
    {
        static void Main(string[] args)
        {
            Roulette r = new Roulette();

            r.Spin();

            Console.WriteLine(r.result);
            Console.ReadLine();
        }
    }
}
