﻿using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casion
{
    class Program
    {
        static ScriptEngine engine;
        static Player player;
        static Roulette roulette;
        static Betting betting;

        static void Main(string[] args)
        {
            Setup();

            Console.WriteLine("Do you want to make bet on the roulette? (y/n)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                GameLoop();
            }
            else
            {
                SaveGame(player);
                EndGame();
            }
        }
        /// <summary>
        /// The gameloop. This methods keeps running in a loop until the user chooses to end it.
        /// </summary>
        public static void GameLoop()
        {
            bool loop = true;
            do
            {
                DrawRouletteTable();
                Console.WriteLine("Your balance: " + player.Money);
                Console.WriteLine("Enter your bet amount:");
                int bet = Convert.ToInt32(Console.ReadLine());
                if (bet <= player.Money)
                {
                    BetThree(bet);
                }
                else
                {
                    Console.WriteLine("Bet too high. Please make another.");
                }
                SaveGame(player);
                Console.WriteLine("Do you want to bet again? (y/n)");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    loop = true;
                }
                else
                {
                    loop = false;
                    EndGame();
                }
            } while (loop);
        }
        /// <summary>
        /// The decision three for what bet the user want to make.
        /// </summary>
        /// <param name="bet">The amount of money the user bets.</param>
        public static void BetThree(int bet)
        {
            DrawRouletteTable();
            Console.WriteLine("What bet will you make?");
            Console.WriteLine("1: Bet Straight Up\n2: Even/Odd\n3: Low/High\n4: Red/Black\n5: Dozen\n6: Column\n7: Split\n8: Street\n9: Corner\n10: Five\n11: Line");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter the number you'll bet on: ");
                    betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "2":
                    Console.WriteLine("Enter 'Even' for even or 'Odd' for odd: ");
                    string evenOrOdd = Console.ReadLine();
                    int evenOrOddNumber = 0;
                    switch (evenOrOdd.ToUpper())
                    {
                        case "EVEN":
                            evenOrOddNumber = 2;
                            break;
                        case "ODD":
                            evenOrOddNumber = 1;
                            break;
                        default:
                            break;
                    }
                    betting.BetEvenOrOdd(bet, evenOrOddNumber, roulette.Spin());
                    break;
                case "3":
                    Console.WriteLine("Enter 18 or below for 'Low', and 19 or higher for 'High': ");
                    betting.BetLowOrHigh(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "4":
                    Console.WriteLine("Enter 'Red' for red or 'Black' for black: ");
                    string redorblack = Console.ReadLine();
                    int redorblacknumber = 0;
                    switch (redorblack.ToUpper())
                    {
                        case "RED":
                            redorblacknumber = 1;
                            break;
                        case "BLACK":
                            redorblacknumber = 2;
                            break;
                        default:
                            break;
                    }
                    betting.BetRedOrBlack(bet, redorblacknumber, roulette.Spin());
                    break;
                case "5":
                    Console.WriteLine("Enter a number between '1-12', '13-24' or '25-36': ");
                    betting.BetDozen(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "6":
                    Console.WriteLine("Enter a coluom number between 1 and 3: ");
                    betting.BetColumn(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "7":
                    Console.WriteLine("Enter the numbers you'll bet on.\nThe Numbers have to be linked to eachother!\n F.x. if you want to bet on '6-3', you enter \"3\" and press 'Enter'..\n Starting with the lowest number: ");
                    betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "8":
                    Console.WriteLine("Enter the street-number you'll bet on.\nYou can just 'enter' a number, which is in the line, that you want to bet on!\n..: ");
                    betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "9":
                    Console.WriteLine("Enter the number you'll bet on.\nYou can just 'enter' the number in the top left corner, of the square you want to bet on!\n..: ");
                    betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                case "10":
                    Console.WriteLine("Betting on the Five (0, 00, 1, 2, 3).\n");
                    betting.BetStraigthUp(bet, 1, roulette.Spin());
                    break;
                case "11":
                    Console.WriteLine("Enter the first number of the two lines, you want to bet on.\nYou can just 'enter' the number in the top left corner, of the lines you want to bet on!\n..: ");
                    betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                    break;
                default:
                    Console.WriteLine("I don't understand your input...");
                    break;
            }
            DrawRouletteTable();
        }
        /// <summary>
        /// Saves the player and ends the game.
        /// </summary>
        public static void EndGame()
        {
            Console.WriteLine("You entered n or something not recognized.");
            Console.WriteLine("Ending game...");
            Console.ReadKey();
        }
        /// <summary>
        /// The important code that needs to run at startup.
        /// </summary>
        private static void Setup()
        {
            engine = Python.CreateEngine();
            CreateDatabase();
            DrawRouletteTable();
            player = StartGame();
            roulette = new Roulette();
            betting = new Betting(player);
            DrawRouletteTable();
        }
        /// <summary>
        /// Saves the game by updateing the database with the given player.
        /// </summary>
        /// <param name="player">The player that should be updated</param>
        public static void SaveGame(Player player)
        {
            dynamic scope = engine.CreateScope();
            engine.ExecuteFile("UpdateDatabase.py", scope);
            var method = scope.GetVariable("Update");
            method(player.Id.ToString(), player.Money.ToString());
        }
        /// <summary>
        /// Prompts the user with the choice of a new game or an existing game. Returns the player created by the user.
        /// </summary>
        public static Player StartGame()
        {
            do
            {
                Console.WriteLine("Enter 'n' for new game or 'l' to load an existing game");
                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "N":
                        return NewUser();
                    case "L":
                        return SelectUser();
                    default:
                        Console.WriteLine("I dont understand your input...");
                        break;
                }
            } while (true);
        }
        /// <summary>
        /// Let the user make a new playerprofile. 
        /// </summary>
        /// <returns>The player the user created</returns>
        public static Player NewUser()
        {
            dynamic scope = engine.CreateScope();
            engine.ExecuteFile("NewUser.py", scope);

            return new Player(scope.GetVariable("playerId"), scope.GetVariable("playerName"), scope.GetVariable("playerMoney"));
        }
        /// <summary>
        /// Lets the user select an existing playerprofile
        /// </summary>
        /// <returns>The player the user choose</returns>
        public static Player SelectUser()
        {
            dynamic scope = engine.CreateScope();
            engine.ExecuteFile("SelectUser.py", scope);

            return new Player(scope.GetVariable("playerId"), scope.GetVariable("playerName"), scope.GetVariable("playerMoney"));
        }
        /// <summary>
        /// Creates the database by running the python script called "DatabaseScript.py".
        /// </summary>
        public static void CreateDatabase()
        {
            var paths = engine.GetSearchPaths();
            paths.Add(@"Lib");
            engine.SetSearchPaths(paths);
            engine.ExecuteFile("DatabaseScript.py");
        }
        /// <summary>
        /// Clears the console and draws the roulette table on a dark green background.
        /// </summary>
        public static void DrawRouletteTable()
        {
            //Draws the background Dark Green
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();

            //Draws the roulette table
            Green("   -----------------------   \n");
            Green("  /    CASINO ROULETTE    \\  \n");
            Green(" /                         \\ \n");
            Green("|-----------|0  |   |00 | < |\n");
            Green("|1-18 |     |"); Red("1  "); Green("|"); Black("2  "); Green("|"); Red("3  "); Green("| < |\n");
            Green("|-----|1st  |"); Black("4  "); Green("|"); Red("5  "); Green("|"); Black("6  "); Green("| < |\n");
            Green("|Odd  |12   |"); Red("7  "); Green("|"); Black("8  "); Green("|"); Red("9  "); Green("| < |\n");
            Green("|-----------|"); Black("10 "); Green("|"); Black("11 "); Green("|"); Red("12 "); Green("| < |\n");
            Green("|"); Red("Red  "); Green("|     |"); Black("13 "); Green("|"); Red("14 "); Green("|"); Black("15 "); Green("| < |\n");
            Green("|-----|2nd  |"); Red("16 "); Green("|"); Black("17 "); Green("|"); Red("18 "); Green("| < |\n");
            Green("|"); Black("Black"); Green("|12   |"); Red("19 "); Green("|"); Black("20 "); Green("|"); Red("21 "); Green("| < |\n");
            Green("|-----------|"); Black("22 "); Green("|"); Red("23 "); Green("|"); Black("24 "); Green("| < |\n");
            Green("|Equal|     |"); Red("25 "); Green("|"); Black("26 "); Green("|"); Red("27 "); Green("| < |\n");
            Green("|-----|3rd  |"); Black("28 "); Green("|"); Black("29 "); Green("|"); Red("30 "); Green("| < |\n");
            Green("|19-36|12   |"); Black("31 "); Green("|"); Red("32 "); Green("|"); Black("33 "); Green("| < |\n");
            Green("|-----------|"); Red("34 "); Green("|"); Black("35 "); Green("|"); Red("36 "); Green("| < |\n");
            Green("|             ^   ^   ^     |\n");
            Green(" \\                         / \n");
            Green("  \\      BY GRUPPE 4      /  \n");
            Green("   -----------------------   \n");
        }
        /// <summary>
        /// Writes given text on a dark green background.
        /// </summary>
        /// <param name="txt">String to write</param>
        public static void Green(string txt)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(txt);
        }
        /// <summary>
        /// Writes given text on a black background with white text.
        /// </summary>
        /// <param name="txt">String to write</param>
        public static void Black(string txt)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(txt);
        }
        /// <summary>
        /// Writes given text on a red background.
        /// </summary>
        /// <param name="txt">String to write</param>
        public static void Red(string txt)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(txt);
        }
    }
}
