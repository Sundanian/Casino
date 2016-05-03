using IronPython.Hosting;
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

        /*
        TODO:
        Tjek på om man kan lave bet.
        Skrive switchcase.
        Logik med gameloop.
        */

        static void Main(string[] args)
        {
            Setup();

            do
            {
                DrawRouletteTable();
                Console.WriteLine("Enter you bet amount:");
                int bet = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What bet will you make?");
                Console.WriteLine("1: Bet Straight Up\n2: Even/Odd\n3: Low/High\n4: Red/Black\n5: Dozen\n6: Column\n7: Split\n8: Street\n9: Corner\n10: Five\n11: Line");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Enter the number you bet on:");
                        betting.BetStraigthUp(bet, Convert.ToInt32(Console.ReadLine()), roulette.Spin());
                        break;
                    default:
                        Console.WriteLine("I don't understand you input...");
                        break;
                }
                SaveGame(player);
            } while (true);
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
        }
        /// <summary>
        /// Saves the game by updateing the database with the given player.
        /// </summary>
        /// <param name="player">The player that should be updated</param>
        public static void SaveGame(Player player)
        {

            Console.WriteLine("Enter 'n' for new game and 'l' to load an existing game");
            string input = Console.ReadLine().ToUpper();

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
