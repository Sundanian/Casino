using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    class Betting : IBetting
    {
        public int playerMonies;
        public int randomNumber;
        public int playerBalance;
        public int payoutVariable;
        public bool winLose;
        public bool tableWin;

        public int BetStraigthUp(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 35;
            Console.WriteLine("Your number was: {0} \nThe ball landed on: {1}", placementOfBet, randomNumber);
            // #Pseudo Random funktion, som vælger et tal mellem 0, 00, 1-36
            if (placementOfBet == randomNumber)
            {
                winLose = true;
            }
            else
            {
                winLose = false;
            }
            return BetCheck(bet, payoutVariable, winLose);
        }

        public int BetEvenOrOdd(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 1;
            if (IsNumberZero(bet, randomNumber))
            {
                int guess = placementOfBet % 2;
                int rNumber = randomNumber % 2;
                if (guess == 1)
                {
                    Console.WriteLine("Your betting on 'Odd'");
                }
                if (guess == 0)
                {
                    Console.WriteLine("Your betting on 'Even'");
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
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetLowOrHigh(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 1;
            if (IsNumberZero(bet, randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                if (placementOfBet <= 18)
                {
                    Console.WriteLine("Your betting on 'Low', 18 and below..");
                    guess = false;
                }
                if (placementOfBet >= 19)
                {
                    Console.WriteLine("Your betting on 'High' 19 and above..");
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
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetRedOrBlack(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 1;
            if (IsNumberZero(bet, randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                if (placementOfBet == 1 || placementOfBet == 3 || placementOfBet == 5 || placementOfBet == 7 || placementOfBet == 9 || placementOfBet == 12 || placementOfBet == 14 ||
                    placementOfBet == 16 || placementOfBet == 18 || placementOfBet == 19 || placementOfBet == 21 || placementOfBet == 23 || placementOfBet == 25 || placementOfBet == 27 ||
                    placementOfBet == 30 || placementOfBet == 32 || placementOfBet == 34 || placementOfBet == 36)
                {
                    Console.WriteLine("Your betting on 'Red'..");
                    guess = false;
                }
                else
                {
                    Console.WriteLine("Your betting on 'Black'..");
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
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetDozen(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 2;
            if (IsNumberZero(bet, randomNumber))
            {
                bool guess = false;
                bool rNumber = false;
                if (placementOfBet <= 12)
                {
                    Console.WriteLine("Your betting on a Dozen between '1-12'..");
                    guess = false;
                }
                if (placementOfBet >= 13 && placementOfBet <= 24)
                {
                    Console.WriteLine("Your betting on a Dozen between '13-24'..");
                    guess = true;
                }
                if (placementOfBet >= 25 && placementOfBet <= 36)
                {
                    Console.WriteLine("Your betting on a Dozen between '25-36'..");
                    guess = true;
                }
                if (randomNumber >= 13 && placementOfBet <= 24)
                {
                    Console.WriteLine("The ball landed on: {0}..", randomNumber);
                    rNumber = false;
                }
                if (randomNumber >= 25 && placementOfBet <= 36)
                {
                    Console.WriteLine("The ball landed on: {0}..", randomNumber);
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
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetColumn(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 2;
            if (IsNumberZero(bet, randomNumber))
            {
                int guess = placementOfBet % 3;
                int rNumber = randomNumber % 3;
                if (guess == 2)
                {
                    Console.WriteLine("Your betting on '2nd column");
                }
                if (guess == 1)
                {
                    Console.WriteLine("Your betting on '1st column'");
                }
                if (guess == 0)
                {
                    Console.WriteLine("Your betting on '3rd column'");
                }
                if (rNumber == 2)
                {
                    Console.WriteLine("The roulette is showing {0}, which is in the '2st column'", randomNumber);
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
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetSplit(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 17;
            if (IsNumberZero(bet, randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;

                List<Array> rows = new List<Array>();
                int[] firstRow= new int[] { 1, 2 };
                int[] secondRow = new int[] { 3, 4 };
                int[] thirdRow = new int[] {5, 6 };
                int[] fourthRow = new int[] { 7, 8 };
                int[] fifthRow = new int[] { 9, 10 };
                int[] sixthRow = new int[] { 11, 12 };
                int[] seventhRow = new int[] { 13, 14 };
                int[] eighthRow = new int[] { 15, 16 };
                int[] ninethRow = new int[] { 17, 18 };
                int[] tenthRow = new int[] { 19, 20 };
                int[] eleventhRow = new int[] { 21, 22 };
                int[] twelvethRow = new int[] { 23, 24 };
                int[] thirdteenthRow = new int[] { 25, 26 };
                int[] fourteenthRow = new int[] { 27, 28 };
                int[] fifteenthRow = new int[] { 29, 30 };
                int[] sixteenthRow = new int[] { 31, 32 };
                int[] seventeenthRow = new int[] { 33, 34 };
                int[] eightteenthRow = new int[] { 35, 36 };

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
                rows.Add(thirdteenthRow);
                rows.Add(fourteenthRow);
                rows.Add(fifteenthRow);
                rows.Add(sixteenthRow);
                rows.Add(seventeenthRow);
                rows.Add(eightteenthRow);

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            guess = rowCount;
                        }
                    }
                    rowCount++;
                }

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (randomNumber == numberInRow)
                        {
                            rowRandom = rowCount;
                        }
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bettet on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row: {1}", randomNumber, rowRandom);

                if (guess == rowRandom)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetStreet(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 11;
            if (IsNumberZero(bet, randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;

                List<Array> rows = new List<Array>();
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

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            guess = rowCount;
                        }
                    }
                    rowCount++;
                }

                foreach (Array tableRows in rows)
                {
                    foreach (int numberInRow in tableRows)
                    {
                        if (placementOfBet == numberInRow)
                        {
                            rowRandom = rowCount;
                        }
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bettet number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row {1}", randomNumber, rowRandom);

                if (rowRandom == guess)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetCorner(int bet, int placementOfBet, int randomNumber)
        {
            payoutVariable = 8;
            if (IsNumberZero(bet, randomNumber))
            {
                int guess = 0;
                int rowCount = 0;
                int rowRandom = 0;
                
                List<Array> corners = new List<Array>();
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

                //Leder efter det nummer man satsede på, og går igennem listen med de forskellige mulige corners, som indeholder hver deres sæt af tal
                foreach (Array tableCorner in corners)
                {
                    foreach (int numberInCorner in tableCorner)
                    {
                        if (placementOfBet == numberInCorner)
                        {
                            guess = rowCount;
                        }
                    }
                    rowCount++;
                }

                foreach (Array tableCorners in corners)
                {
                    foreach (int numberInCorner in tableCorners)
                    {
                        if (placementOfBet == numberInCorner)
                        {
                            rowRandom = rowCount;
                        }
                    }
                    rowCount++;
                }

                Console.WriteLine("Your bettet on number: {0}, which is in row: {1}", placementOfBet, guess);
                Console.WriteLine("The ball landed on: {0}, which is in row: {1}", randomNumber, rowRandom);

                if (guess == rowRandom)
                {
                    winLose = true;
                }
                else
                {
                    winLose = false;
                }
                return BetCheck(bet, payoutVariable, winLose);
            }
            else
            {
                return BetCheck(bet, payoutVariable, false);
            }
        }

        public int BetFive(int bet, int placementOfBet, int randomNumber)
        {
            throw new NotImplementedException();
        }

        public int BetLine(int bet, int placementOfBet, int randomNumber)
        {
            throw new NotImplementedException();
        }

        public bool IsNumberZero(int bet, int randomNumber)
        {
            if (randomNumber == 0 || randomNumber == 37)
            {
                //You lost!
                Console.WriteLine("The ball landed on 0 or 00! The House wins");
                return false;
            }
            return true;
        }

        public int BetCheck(int bet, int payout, bool winLoseBool)
        {
            if (winLoseBool)
            {
                //You won!
                Console.WriteLine("You won on your bet!");
                int result = bet + (bet * payout);

                Console.WriteLine("{0} was added to your balance", result);
                return playerBalance += result;
            }
            else
            {
                //You lost!
                Console.WriteLine("You lost on your bet!");
                int result = bet * -1;

                Console.WriteLine("{0} was subtracted from your balance", result);
                return playerBalance += result;
            }
        }
    }
}