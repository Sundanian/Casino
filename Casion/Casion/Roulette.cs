using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{ 
    class Roulette
    {
        Random random = new Random();

        private int intResult;

        public int IntResult
        {
            get
            {
                return intResult;
            }

            set
            {
                intResult = value;
            }
        }

        public int Spin()
        {
            int randomNumber = random.Next(1, 39);

            switch (randomNumber)
            {
                case 1:
                    IntResult = 0;
                    break;
                case 2:
                    IntResult = 37;
                    break;
                case 3:
                    IntResult = randomNumber - 2;
                    break;
                case 4:
                    IntResult = randomNumber - 2;
                    break;
                case 5:
                    IntResult = randomNumber - 2;
                    break;
                case 6:
                    IntResult = randomNumber - 2;
                    break;
                case 7:
                    IntResult = randomNumber - 2;
                    break;
                case 8:
                    IntResult = randomNumber - 2;
                    break;
                case 9:
                    IntResult = randomNumber - 2;
                    break;
                case 10:
                    IntResult = randomNumber - 2;
                    break;
                case 11:
                    IntResult = randomNumber - 2;
                    break;
                case 12:
                    IntResult = randomNumber - 2;
                    break;
                case 13:
                    IntResult = randomNumber - 2;
                    break;
                case 14:
                    IntResult = randomNumber - 2;
                    break;
                case 15:
                    IntResult = randomNumber - 2;
                    break;
                case 16:
                    IntResult = randomNumber - 2;
                    break;
                case 17:
                    IntResult = randomNumber - 2;
                    break;
                case 18:
                    IntResult = randomNumber - 2;
                    break;
                case 19:
                    IntResult = randomNumber - 2;
                    break;
                case 20:
                    IntResult = randomNumber - 2;
                    break;
                case 21:
                    IntResult = randomNumber - 2;
                    break;
                case 22:
                    IntResult = randomNumber - 2;
                    break;
                case 23:
                    IntResult = randomNumber - 2;
                    break;
                case 24:
                    IntResult = randomNumber - 2;
                    break;
                case 25:
                    IntResult = randomNumber - 2;
                    break;
                case 26:
                    IntResult = randomNumber - 2;
                    break;
                case 27:
                    IntResult = randomNumber - 2;
                    break;
                case 28:
                    IntResult = randomNumber - 2;
                    break;
                case 29:
                    IntResult = randomNumber - 2;
                    break;
                case 30:
                    IntResult = randomNumber - 2;
                    break;
                case 31:
                    IntResult = randomNumber - 2;
                    break;
                case 32:
                    IntResult = randomNumber - 2;
                    break;
                case 33:
                    IntResult = randomNumber - 2;
                    break;
                case 34:
                    IntResult = randomNumber - 2;
                    break;
                case 35:
                    IntResult = randomNumber - 2;
                    break;
                case 36:
                    IntResult = randomNumber - 2;
                    break;
                case 37:
                    IntResult = randomNumber - 2;
                    break;
                case 38:
                    IntResult = randomNumber - 2;
                    break;
            }
            return intResult;
        }
    }
}
