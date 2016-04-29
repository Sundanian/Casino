using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    interface IBetting
    {
        int BetStraigthUp(int bet, int placementOfBet, int randomNumber); //Sats på et tal
        int BetEvenOrOdd(int bet, int placementOfBet, int randomNumber); //Sats på lige/ulige
        int BetLowOrHigh(int bet, int placementOfBet, int randomNumber); //Sats på Lav/høj
        int BetRedOrBlack(int bet, int placementOfBet, int randomNumber); //Sats på Rød/Sort
        int BetDozen(int bet, int placementOfBet, int randomNumber); //Sats på et dusin (1-12 , 13-24 , 25-36)
        int BetColumn(int bet, int placementOfBet, int randomNumber); //Sats på en vertikal række (1-4-7-10-ect..,2-5-8-11, ect..)
        int BetSplit(int bet, int placementOfBet, int randomNumber); //Sats på 2 numre på én gang (1-2, 2-3, ect..)
        int BetStreet(int bet, int placementOfBet, int randomNumber); //Sats på 3 numre på én gang (1-2-3, 4-5-6, ect..)
        int BetCorner(int bet, int placementOfBet, int randomNumber); //Sats på 4 numre på én gang (1-2-4-5, 2-3-5-6, ect..)
        int BetFive(int bet, int placementOfBet, int randomNumber); //Sats på 5 numre på én gang (KUN, 0-00-1-2-3)
        int BetLine(int bet, int placementOfBet, int randomNumber); //Sats på 6 numre på én gang (1-2-3-4-5-6, 4-5-6-7-8-9, ect..)3
        bool IsNumberZero(int bet, int randomNumber); //Tjekker om randomNumber er 0/00
        int BetCheck(int bet, int payoutNumber, bool winLoseBool); //Udregner hvor meget spilleren skal have ind, på sin balance
    }
}
