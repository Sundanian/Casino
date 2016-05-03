using System;
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

            int result = r.Spin();

            Console.WriteLine(result);

            Betting myBet = new Betting();

            int r0 = myBet.BetCorner(5, 2, result);
            //int r1 = myBet.BetDozen(5, 12, 10);
            //int r2 = myBet.BetEvenOrOdd(5, 2, 0);
            //int r3 = myBet.BetFive(6, 0, 37);
            //int r4 = myBet.BetLine(5, 1, 0);
            //int r5 = myBet.BetLowOrHigh(1, 1, 37);
            //int r6 = myBet.BetRedOrBlack(1, 1, 36);
            //int r7 = myBet.BetSplit(17, 3, 0);
            //int r8 = myBet.BetStraigthUp(35, 2, 2);
            //int r9 = myBet.BetStreet(11, 1, 15);
            //int r10 = myBet.BetColumn(2, 1, 22);


            Console.ReadKey();
        }
    }
}
