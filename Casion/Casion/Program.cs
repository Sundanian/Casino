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

        static void Main(string[] args)
        {
            engine = Python.CreateEngine();
            CreateDatabase();
            DrawRouletteTable();
            StartGame();
        }
        public static void StartGame()
        {
            Console.WriteLine("Enter 'n' for new game og 'l' to load an existing game");
            string input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "N":
                    NewUser();
                    break;
                case "L":
                    SelectUser();
                    break;
                default:
                    Console.WriteLine("I dont understand your input...");
                    break;
            }

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
        /// Creates our databse by running the python script called "DatabaseScript.py".
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
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            
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
        /// Writes given text on dark green background.
        /// </summary>
        /// <param name="txt">String to write</param>
        public static void Green(string txt)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(txt);
        }
        /// <summary>
        /// Writes given text on black background with white text.
        /// </summary>
        /// <param name="txt">String to write</param>
        public static void Black(string txt)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(txt);
        }
        /// <summary>
        /// Writes given text on red background.
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
