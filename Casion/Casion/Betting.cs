using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    class Betting : IBetting
    {
        //int randomNumber = r.Spin();//Er Roulettens Random genererede tal
        Player player;
        private int payoutVariable; //Bliver brugt til at definere hvor meget hver type BET, giver tilbage
        public bool winLose; //Bliver brugt i BetCheck()
        bool isChecked = false;

        public Betting(Player player)
        {
            this.player = player;
        }

        public int PayoutVariable
        {
            get
            {
                return payoutVariable;
            }

            set
            {
                payoutVariable = value;
            }
        }

        /// <summary>
        /// Sats på 'ét' nummer! Kan også være 0 eller 00!
        /// Vinder 35*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetStraigthUp(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 35;
            Console.WriteLine("Your number was: {0} \nThe ball landed on: {1}", placementOfBet, randomNumber);
            if (placementOfBet == randomNumber)
            {
                winLose = true;
            }
            else
            {
                winLose = false;
            }
            return BetCheck(bet, PayoutVariable, winLose);
        }
       
        /// <summary>
        /// Sats på 'Lige' eller 'Ulige'!
        /// Taber på 0 eller 00
        /// Vinder 1*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetEvenOrOdd(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 1;
            if (IsNumberZero(randomNumber))
            {
                int guess = placementOfBet % 2;
                int rNumber = randomNumber % 2;
                if (guess == 1)
                {
                    Console.WriteLine("You're betting on 'Odd'");
                }
                if (guess == 0)
                {
                    Console.WriteLine("You're betting on 'Even'");
                }
                if (rNumber == 1)
                {
                    Console.WriteLine("The roulette is showing 'Odd'");
                }
                if (rNumber == 0)
                {
                    Console.WriteLine("The roulette is showing 'Even'");
                }
                
                if (guess == rNumber)
                {
                    winLose = true;
                }
                else if (guess != rNumber)
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på 'Lav' eller 'Høj'!
        /// Taber på 0 eller 00
        /// Vinder 1*1 bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetLowOrHigh(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 1;
            if (IsNumberZero(randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                if (placementOfBet <= 18)
                {
                    Console.WriteLine("You're betting on 'Low', 18 and below..");
                    guess = false;
                }
                if (placementOfBet >= 19)
                {
                    Console.WriteLine("You're betting on 'High' 19 and above..");
                    guess = true;
                }
                if (randomNumber <= 18)
                {
                    Console.WriteLine("The ball landed on: {0}, which is 'Low'..", randomNumber);
                    rNumber = false;
                }
                if (randomNumber >= 19)
                {
                    Console.WriteLine("The ball landed on: {0}, which is 'High'..", randomNumber);
                    rNumber = true;
                }

                if (guess == rNumber)
                {
                    winLose = true;
                }
                else if (guess != rNumber)
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på 'Rød' eller 'Sort'!
        /// Taber på 'Grøn' og 0 eller 00
        /// Vinder 1*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetRedOrBlack(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 1;
            if (IsNumberZero(randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                if (placementOfBet == 1 || placementOfBet == 3 || placementOfBet == 5 || placementOfBet == 7 || placementOfBet == 9 || placementOfBet == 12 || placementOfBet == 14 ||
                    placementOfBet == 16 || placementOfBet == 18 || placementOfBet == 19 || placementOfBet == 21 || placementOfBet == 23 || placementOfBet == 25 || placementOfBet == 27 ||
                    placementOfBet == 30 || placementOfBet == 32 || placementOfBet == 34 || placementOfBet == 36)
                {
                    Console.WriteLine("You're betting on 'Red'..");
                    guess = false;
                }
                else
                {
                    Console.WriteLine("You're betting on 'Black'..");
                    guess = true;
                }

                if (randomNumber == 1 || randomNumber == 3 || randomNumber == 5 || randomNumber == 7 || randomNumber == 9 || randomNumber == 12 || randomNumber == 14 ||
                    placementOfBet == 16 || randomNumber == 18 || randomNumber == 19 || randomNumber == 21 || randomNumber == 23 || randomNumber == 25 || randomNumber == 27 ||
                    randomNumber == 30 || randomNumber == 32 || randomNumber == 34 || randomNumber == 36)
                {
                    Console.WriteLine("The ball landed on: {0}, which is 'Red'..", randomNumber);
                    rNumber = false;
                }
                else
                {
                    Console.WriteLine("The ball landed on: {0}, which is 'Black'..", randomNumber);
                    rNumber = true;
                }

                if (guess == rNumber)
                {
                    winLose = true;
                }
                else if (guess != rNumber)
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på en af 3 mulige valg. 1-12, 13-24 eller 25-36!
        /// Taber på 0 eller 00
        /// Vinder 2*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetDozen(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 2;
            if (IsNumberZero(randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                bool is12 = false;
                bool is24 = false;
                bool is36 = false;
                if (placementOfBet <= 12)
                {
                    Console.WriteLine("You're betting on a Dozen between '1-12'..");
                    guess = true;
                    is12 = true;
                }
                if (placementOfBet >= 13 && placementOfBet <= 24)
                {
                    Console.WriteLine("You're betting on a Dozen between '13-24'..");
                    guess = true;
                    is24 = true;
                }
                if (placementOfBet >= 25 && placementOfBet <= 36)
                {
                    Console.WriteLine("You're betting on a Dozen between '25-36'..");
                    guess = true;
                    is36 = true;
                }
                if (randomNumber <= 12)
                {
                    Console.WriteLine("The ball landed on: {0}..", randomNumber);
                    if (is12)
                    {
                        rNumber = true;
                    }
                }
                if (randomNumber >= 13 && randomNumber <= 24)
                {
                    Console.WriteLine("The ball landed on: {0}..", randomNumber);
                    if (is24)
                    {
                        rNumber = true;
                    }
                }
                if (randomNumber >= 25 && randomNumber <= 36)
                {
                    Console.WriteLine("The ball landed on: {0}..", randomNumber);
                    if (is36)
                    {
                        rNumber = true;
                    }
                }

                if (guess == rNumber)
                {
                    winLose = true;
                }
                else if (guess != rNumber)
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på en af 3 mulige valg. Kolonne 1, 2 eller 3
        /// Taber på 0 eller 00
        /// Vinder 2*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetColumn(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 2;
            if (IsNumberZero(randomNumber))
            {
                int guess = placementOfBet % 3;
                int rNumber = randomNumber % 3;
                if (guess == 2)
                {
                    Console.WriteLine("You're betting on '2nd column");
                }
                if (guess == 1)
                {
                    Console.WriteLine("You're betting on '1st column'");
                }
                if (guess == 0)
                {
                    Console.WriteLine("You're betting on '3rd column'");
                }
                if (rNumber == 2)
                {
                    Console.WriteLine("The roulette is showing {0}, which is in the '2nd column'", randomNumber);
                }
                if (rNumber == 1)
                {
                    Console.WriteLine("The roulette is showing {0}, which is in the '1st column'", randomNumber);
                }
                if (rNumber == 0)
                {
                    Console.WriteLine("The roulette is showing {0}, which is in the '3rd column'", randomNumber);
                }

                if (guess == rNumber)
                {
                    winLose = true;
                }
                else if (guess != rNumber)
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på to sammenhængende numre! 1 og 2, eller 2 og 3, eller 1 og 4, ect.!
        /// Taber på 0 eller 00
        /// Vinder 17*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetSplit(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 17;
            if (IsNumberZero(randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;
                isChecked = false;

                List<Array> rows = new List<Array>();
                #region Arrays
                int[] aRow = new int[] { 1, 2 };
                int[] bRow = new int[] { 1, 4 };
                int[] cRow = new int[] { 2, 3 };
                int[] dRow = new int[] { 2, 5 };
                int[] eRow = new int[] { 3, 6 };
                int[] fRow = new int[] { 4, 5 };
                int[] gRow = new int[] { 4, 7 };
                int[] hRow = new int[] { 5, 6 };
                int[] iRow = new int[] { 5, 8 };
                int[] jRow = new int[] { 6, 9 };
                int[] kRow = new int[] { 7, 8 };
                int[] lRow = new int[] { 7, 10 };
                int[] mRow = new int[] { 8, 9 };
                int[] nRow = new int[] { 8, 11 };
                int[] oRow = new int[] { 9, 12 };
                int[] pRow = new int[] { 10, 11 };
                int[] qRow = new int[] { 10, 13 };
                int[] rRow = new int[] { 11, 12 };
                int[] sRow = new int[] { 11, 14 };
                int[] tRow = new int[] { 12, 15 };
                int[] uRow = new int[] { 13, 14 };
                int[] vRow = new int[] { 13, 16 };
                int[] wRow = new int[] { 14, 15 };
                int[] xRow = new int[] { 14, 17 };
                int[] yRow = new int[] { 15, 18 };
                int[] zRow = new int[] { 16, 17 };

                int[] aaRow = new int[] { 16, 19 };
                int[] abRow = new int[] { 17, 18 };
                int[] acRow = new int[] { 17, 20 };
                int[] adRow = new int[] { 18, 21 };
                int[] aeRow = new int[] { 19, 20 };
                int[] afRow = new int[] { 19, 22 };
                int[] agRow = new int[] { 20, 21 };
                int[] ahRow = new int[] { 20, 23 };
                int[] aiRow = new int[] { 21, 24 };
                int[] ajRow = new int[] { 22, 23 };
                int[] akRow = new int[] { 22, 25 };
                int[] alRow = new int[] { 23, 24 };
                int[] amRow = new int[] { 23, 26 };
                int[] anRow = new int[] { 24, 27 };
                int[] aoRow = new int[] { 25, 26 };
                int[] apRow = new int[] { 25, 28 };
                int[] aqRow = new int[] { 26, 27 };
                int[] arRow = new int[] { 26, 29 };
                int[] asRow = new int[] { 27, 30 };
                int[] atRow = new int[] { 28, 29 };
                int[] auRow = new int[] { 28, 31 };
                int[] avRow = new int[] { 29, 30 };
                int[] awRow = new int[] { 29, 32 };
                int[] axRow = new int[] { 30, 33 };
                int[] ayRow = new int[] { 31, 32 };
                int[] azRow = new int[] { 31, 34 };

                int[] baRow = new int[] { 32, 33 };
                int[] bbRow = new int[] { 32, 35 };
                int[] bcRow = new int[] { 33, 36 };
                int[] bdRow = new int[] { 34, 35 };
                int[] beRow = new int[] { 35, 36 };
                #endregion
                #region add Arrays to list 'rows'
                rows.Add(aRow);
                rows.Add(bRow);
                rows.Add(cRow);
                rows.Add(dRow);
                rows.Add(eRow);
                rows.Add(fRow);
                rows.Add(gRow);
                rows.Add(hRow);
                rows.Add(iRow);
                rows.Add(jRow);
                rows.Add(kRow);
                rows.Add(lRow);
                rows.Add(mRow);
                rows.Add(nRow);
                rows.Add(oRow);
                rows.Add(pRow);
                rows.Add(qRow);
                rows.Add(rRow);
                rows.Add(sRow);
                rows.Add(tRow);
                rows.Add(uRow);
                rows.Add(vRow);
                rows.Add(wRow);
                rows.Add(xRow);
                rows.Add(yRow);
                rows.Add(zRow);

                rows.Add(aaRow);
                rows.Add(abRow);
                rows.Add(acRow);
                rows.Add(adRow);
                rows.Add(aeRow);
                rows.Add(afRow);
                rows.Add(agRow);
                rows.Add(ahRow);
                rows.Add(aiRow);
                rows.Add(ajRow);
                rows.Add(akRow);
                rows.Add(alRow);
                rows.Add(amRow);
                rows.Add(anRow);
                rows.Add(aoRow);
                rows.Add(apRow);
                rows.Add(aqRow);
                rows.Add(arRow);
                rows.Add(asRow);
                rows.Add(atRow);
                rows.Add(auRow);
                rows.Add(avRow);
                rows.Add(awRow);
                rows.Add(axRow);
                rows.Add(ayRow);
                rows.Add(azRow);

                rows.Add(baRow);
                rows.Add(bbRow);
                rows.Add(bcRow);
                rows.Add(bdRow);
                rows.Add(beRow);
                #endregion

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            guess = rowCount;
                        }
                        if (randomNumber == numberInRow)
                        {
                            rowRandom = rowCount;
                            isChecked = true;
                        }
                    }
                    if (isChecked)
                    {
                        break;
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bet was on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row: {1}", randomNumber, rowRandom);

                if (guess == rowRandom)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Stas på én række af tre numre! 1-2-3 eller 4-5-6, ect.
        /// Taber på 0 eller 00
        /// Vinder 11*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetStreet(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 11;
            if (IsNumberZero(randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;
                isChecked = false;

                List<Array> rows = new List<Array>();
                #region Arrays
                int[] firstRow = new int[] { 1, 2, 3 };
                int[] secondRow = new int[] { 4, 5, 6 };
                int[] thirdRow = new int[] { 7, 8, 9 };
                int[] fourthRow = new int[] { 10, 11, 12 };
                int[] fifthRow = new int[] { 13, 14, 15 };
                int[] sixthRow = new int[] { 16, 17, 18 };
                int[] seventhRow = new int[] { 19, 20, 21 };
                int[] eighthRow = new int[] { 22, 23, 24 };
                int[] ninethRow = new int[] { 25, 26, 27 };
                int[] tenthRow = new int[] { 28, 29, 30 };
                int[] eleventhRow = new int[] { 31, 32, 33 };
                int[] twelvethRow = new int[] { 34, 35, 36 };
                #endregion
                #region add arrays to list 'rows'
                rows.Add(firstRow);
                rows.Add(secondRow);
                rows.Add(thirdRow);
                rows.Add(fourthRow);
                rows.Add(fifthRow);
                rows.Add(sixthRow);
                rows.Add(seventhRow);
                rows.Add(eighthRow);
                rows.Add(ninethRow);
                rows.Add(tenthRow);
                rows.Add(eleventhRow);
                rows.Add(twelvethRow);
                #endregion

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            guess = rowCount;
                        }
                        if (randomNumber == numberInRow)
                        {
                            rowRandom = rowCount;
                            isChecked = true;
                        }
                    }
                    if (isChecked)
                    {
                        break;
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bet was on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row {1}", randomNumber, rowRandom);

                if (rowRandom == guess)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på et 'Corner' af fire sammenhængende tal! 1-2-4-5 eller 2-3-5-6, ect.
        /// Taber på 0 eller 00
        /// Vinder 8*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetCorner(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 8;
            if (IsNumberZero(randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;
                isChecked = false;
                
                List<Array> corners = new List<Array>();
                #region Arrays
                int[] firstCorner = new int[] { 1, 2, 4, 5 };
                int[] secondCorner = new int[] { 2, 3, 5, 6 };
                int[] thirdCorner = new int[] { 4, 5, 7, 8 };
                int[] fourCorner = new int[] { 5, 6, 8, 9 };
                int[] fiveCorner = new int[] { 7, 8, 10 ,11 };
                int[] sixCorner = new int[] { 8, 9, 11, 12 };
                int[] sevenCorner = new int[] { 10, 11, 13, 14 };
                int[] eightCorner = new int[] { 11, 12, 14, 15 };
                int[] nineCorner = new int[] { 13, 14, 16, 17 };
                int[] tenCorner = new int[] { 14, 15, 17, 17 };
                int[] elevenCorner = new int[] { 16, 17, 19, 20 };
                int[] twelveCorner = new int[] { 17, 18, 20, 21 };
                int[] thirdteenCorner = new int[] { 19, 20, 22, 23 };
                int[] fourteenCorner = new int[] { 20, 21, 23, 24 };
                int[] fifteenCorner = new int[] { 22, 23, 25, 26 };
                int[] sixteenCorner = new int[] { 23, 24, 26, 27 };
                int[] seventeenCorner = new int[] { 25, 26, 28, 29 };
                int[] eightteenCorner = new int[] { 26, 27, 29, 30};
                int[] nineteenCorner = new int[] { 28, 29, 31, 32 };
                int[] twentyCorner = new int[] { 29, 30, 32, 33 };
                int[] twentyOneCorner = new int[] { 31, 32, 34, 35 };
                int[] twentyTwoCorner = new int[] { 32, 33, 35, 36 };
                #endregion
                #region Add arrays to list 'corners'
                corners.Add(firstCorner);
                corners.Add(secondCorner);
                corners.Add(thirdCorner);
                corners.Add(fourCorner);
                corners.Add(fiveCorner);
                corners.Add(sixCorner);
                corners.Add(sevenCorner);
                corners.Add(eightCorner);
                corners.Add(nineCorner);
                corners.Add(tenCorner);
                corners.Add(elevenCorner);
                corners.Add(twelveCorner);
                corners.Add(thirdteenCorner);
                corners.Add(fourteenCorner);
                corners.Add(fifteenCorner);
                corners.Add(sixteenCorner);
                corners.Add(seventeenCorner);
                corners.Add(eightteenCorner);
                corners.Add(nineteenCorner);
                corners.Add(twentyCorner);
                corners.Add(twentyOneCorner);
                corners.Add(twentyTwoCorner);
                #endregion


                //Leder efter det nummer man satsede på, og går igennem listen med de forskellige mulige corners, som indeholder hver deres sæt af tal
                foreach (Array tableCorner in corners)
                {
                    foreach (int numberInCorner in tableCorner)
                    {
                        if (placementOfBet == numberInCorner)
                        {
                            guess = rowCount;
                        }
                        if (randomNumber == numberInCorner)
                        {
                            rowRandom = rowCount;
                            isChecked = true;
                        }
                    }

                    rowCount++;
                    if (isChecked)
                    {
                        break;
                    }
                }

                Console.WriteLine("Your bet was on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row: {1}", randomNumber, rowRandom);

                if (guess == rowRandom)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Sats på 'Toppen af pladen, bestående af 0, 00, 1, 2 og 3!
        /// Taber på andre numre
        /// Vinder 6*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetFive(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 6;
            if (placementOfBet <= 3 || placementOfBet == 37)
            {
                Console.WriteLine("Your bet was on one of 'The Five': {0}", placementOfBet);
                Console.WriteLine("The ball landed on: {0}", randomNumber);
                if (randomNumber <= 3 || randomNumber == 37)
                {
                    winLose = true;
                    return BetCheck(bet, PayoutVariable, winLose);
                }
            }

            winLose = false;
            return BetCheck(bet, PayoutVariable, winLose);

        }

        /// <summary>
        /// Sats på 6 sammenhængende numre (2 sammenhængende rækker)! 1-2-3 og 4-5-6 eller 4-5-6 og 7-8-9, ect.
        /// Taber på 0 eller 00
        /// Vinder 5*bet + bet igen
        /// </summary>
        /// <param name="bet">Hvor meget spilleren satser</param>
        /// <param name="placementOfBet">Hvilken tal, som spilleren har satset på</param>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En 'int', som er afhængig af funktionen 'BetCheck(bet, payoutVariable, winLose)'</returns>
        public int BetLine(int bet, int placementOfBet, int randomNumber)
        {
            PayoutVariable = 5;
            if (IsNumberZero(randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;

                List<Array> rows = new List<Array>();
                #region Arrays
                int[] firstRow = new int[] { 1, 2, 3, 4, 5, 6 };
                int[] secondRow = new int[] { 4, 5, 6, 7, 8, 9 };
                int[] thirdRow = new int[] { 7, 8, 9, 10, 11, 12 };
                int[] fourthRow = new int[] { 10, 11, 12, 13, 14, 15 };
                int[] fifthRow = new int[] { 13, 14, 15, 16, 17, 18 };
                int[] sixthRow = new int[] { 16, 17, 18, 19, 20, 21 };
                int[] seventhRow = new int[] { 19, 20, 21, 22, 23, 24 };
                int[] eighthRow = new int[] { 22, 23, 24, 25, 26, 27 };
                int[] ninethRow = new int[] { 25, 26, 27, 28, 29, 30 };
                int[] tenthRow = new int[] { 28, 29, 30, 31, 32, 33 };
                int[] eleventhRow = new int[] { 31, 32, 33, 34, 35, 36 };
                #endregion
                #region add arrays to list 'rows'
                rows.Add(firstRow);
                rows.Add(secondRow);
                rows.Add(thirdRow);
                rows.Add(fourthRow);
                rows.Add(fifthRow);
                rows.Add(sixthRow);
                rows.Add(seventhRow);
                rows.Add(eighthRow);
                rows.Add(ninethRow);
                rows.Add(tenthRow);
                rows.Add(eleventhRow);
                #endregion
                isChecked = false;
                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            guess = rowCount;
                        }
                        if (randomNumber == numberInRow)
                        {
                            rowRandom = rowCount;
                            isChecked = true;
                        }
                    }
                    if (isChecked)
                    {
                        break;
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bet was on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row {1}", randomNumber, rowRandom);

                if (rowRandom == guess)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, PayoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, PayoutVariable, false);
            }
        }

        /// <summary>
        /// Tjekker på om Roulettens tal er 0 eller 37(00), og retunere en bool, som bestemmer om den skal gå ind i bet-funktionens udregning eller springe den over. 
        /// </summary>
        /// <param name="randomNumber">Roulettens Tal</param>
        /// <returns>En bool, som bestemmer om bettet skal fortsætte, baseret på om Roulettens RANDOM tal er 0 eller 37(00)
        /// True, den fortsætter
        /// False, den kalder Betcheck(bet, payout, FALSE)</returns>
        public bool IsNumberZero(int randomNumber)
        {
            if (randomNumber == 0 || randomNumber == 37)
            {
                //You lost!
                Console.WriteLine("The ball landed on 0 or 00! The House wins");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Bliver kaldt i slutningen af ethvert bet.
        /// Laver udregningen for et vundet eller tabt spil.
        /// </summary>
        /// <param name="bet">Hvor meget spilleren har satset</param>
        /// <param name="payout">Bestemmer hvor mange gange spilleren skal have sit sats igen</param>
        /// <param name="winLoseBool">En bool der bliver brugt i de forskellige bets, som afgiver + / - </param>
        /// <returns>En 'int', som bliver beregnet udfra om det er et vundet eller tabt spil.
        /// Tager spillerens penge(balance) og tilføjer eller trækker fra og returnere den nye balance</returns>
        public int BetCheck(int bet, int payout, bool winLoseBool)
        {
            if (winLoseBool)
            {
                //You won!
                Console.WriteLine("You won on your bet!");
                int result = bet + (bet * payout);

                Console.WriteLine("{0} was added to your balance", result);
                return player.Money += result;
            }
            else
            {
                //You lost!
                Console.WriteLine("You lost on your bet!");
                int result = bet * -1;

                Console.WriteLine("{0} was subtracted from your balance", result);
                return player.Money += result;
            }
        }
    }
}