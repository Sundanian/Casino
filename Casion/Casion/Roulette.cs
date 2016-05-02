using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{ 
    class Roulette
    {
        public string result = "";
        static Random random = new Random();

        public string Spin()
        {
            int randomNumber = random.Next(1, 39);

            switch (randomNumber)
            {
                case 1:
                    result = "Green 0";
                    break;
                case 2:
                    result = "Green 00";
                    break;
                case 3:
                    result = "Red 1";
                    break;
                case 4:
                    result = "Black 2";
                    break;
                case 5:
                    result = "Red 3";
                    break;
                case 6:
                    result = "Black 4";
                    break;
                case 7:
                    result = "Red 5";
                    break;
                case 8:
                    result = "Black 6";
                    break;
                case 9:
                    result = "Red 7";
                    break;
                case 10:
                    result = "Black 8";
                    break;
                case 11:
                    result = "Red 9";
                    break;
                case 12:
                    result = "Black 10";
                    break;
                case 13:
                    result = "Black 11";
                    break;
                case 14:
                    result = "Red 12";
                    break;
                case 15:
                    result = "Black 13";
                    break;
                case 16:
                    result = "Red 14";
                    break;
                case 17:
                    result = "Black 15";
                    break;
                case 18:
                    result = "Red 16";
                    break;
                case 19:
                    result = "Black 17";
                    break;
                case 20:
                    result = "Red 18";
                    break;
                case 21:
                    result = "Red 19";
                    break;
                case 22:
                    result = "Black 20";
                    break;
                case 23:
                    result = "Red 21";
                    break;
                case 24:
                    result = "Black 22";
                    break;
                case 25:
                    result = "Red 23";
                    break;
                case 26:
                    result = "Black 24";
                    break;
                case 27:
                    result = "Red 25";
                    break;
                case 28:
                    result = "Black 26";
                    break;
                case 29:
                    result = "Red 27";
                    break;
                case 30:
                    result = "Black 28";
                    break;
                case 31:
                    result = "Black 29";
                    break;
                case 32:
                    result = "Red 30";
                    break;
                case 33:
                    result = "Black 31";
                    break;
                case 34:
                    result = "Red 32";
                    break;
                case 35:
                    result = "Black 33";
                    break;
                case 36:
                    result = "Red 34";
                    break;
                case 37:
                    result = "Black 35";
                    break;
                case 38:
                    result = "red 36";
                    break;
            }
            return result;
        }
    }
}
