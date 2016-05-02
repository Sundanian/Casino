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
        static void Main(string[] args)
        {
            //ScriptEngine se = Python.CreateEngine();
            //se.ExecuteFile("Casion_Python.py");
            DrawRouletteTable();
            var engine = Python.CreateEngine();
            var paths = engine.GetSearchPaths();
            paths.Add(@"Lib");
            engine.SetSearchPaths(paths);
            engine.ExecuteFile("Casion_Python.py");
            SelectUser();
        }

        static void SelectUser()
        {
            var engine = Python.CreateEngine();
            var paths = engine.GetSearchPaths();
            var scope = engine.CreateScope();
            paths.Add(@"Lib");
            engine.SetSearchPaths(paths);
            engine.ExecuteFile("SelectUser.py", scope);

            Console.WriteLine("\nSelect a save file (Write the ID number)");
            string input = Console.ReadLine();

            var User = scope.GetVariable("SelectPlayer");
            var result = User(input);
            int id = scope.GetVariable("playerId");
            string name = scope.GetVariable("playerName");
            int money = scope.GetVariable("playerMoney");
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
