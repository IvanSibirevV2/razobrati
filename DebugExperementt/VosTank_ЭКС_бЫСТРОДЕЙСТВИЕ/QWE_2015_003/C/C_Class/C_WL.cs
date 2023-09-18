using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class C{
        /// <summary>
        /// LofOff
        /// </summary>
        static private class FC{
            static private void Do(ConsoleColor MyConsoleColor) { Console.ForegroundColor = MyConsoleColor; }
            public static void Black() { Do(ConsoleColor.Black); }
            public static void Blue() { Do(ConsoleColor.Blue); }
            public static void Cyan() { Do(ConsoleColor.Cyan); }
            public static void DarkBlue() { Do(ConsoleColor.DarkBlue); }
            public static void DarkCyan() { Do(ConsoleColor.DarkCyan); }
            public static void DarkGray() { Do(ConsoleColor.DarkGray); }
            public static void DarkGreen() { Do(ConsoleColor.DarkGreen); }
            public static void DarkMagenta() { Do(ConsoleColor.DarkMagenta); }
            public static void DarkRed() { Do(ConsoleColor.DarkRed); }
            public static void DarkYellow() { Do(ConsoleColor.DarkYellow); }
            public static void Gray() { Do(ConsoleColor.Gray); }
            public static void Green() { Do(ConsoleColor.Green); }
            public static void Magenta() { Do(ConsoleColor.Magenta); }
            public static void Red() { Do(ConsoleColor.Red); }
            public static void White() { Do(ConsoleColor.White); }
            public static void Yellow() { Do(ConsoleColor.Yellow); }
            public static void Standart() { Do(ConsoleColor.Gray); }
        } 
        /// <summary>
        /// LogOff
        /// </summary>
        static public class WL{
            static private void Do(string STR) { Console.Write(STR); C.FC.Standart(); }
            public static void Black(string STR) { C.FC.Black(); Do(STR); }
            public static void Blue(string STR) { C.FC.Blue(); Do(STR); }
            public static void Cyan(string STR) { C.FC.Cyan(); Do(STR); }
            public static void DarkBlue(string STR) { C.FC.DarkBlue(); Do(STR); }
            public static void DarkCyan(string STR) { C.FC.DarkCyan(); Do(STR); }
            public static void DarkGray(string STR) { C.FC.DarkGray(); Do(STR); }
            public static void DarkGreen(string STR) { C.FC.DarkGreen(); Do(STR); }
            public static void DarkMagenta(string STR) { C.FC.DarkMagenta(); Do(STR); }
            public static void DarkRed(string STR) { C.FC.DarkRed(); Do(STR); }
            public static void DarkYellow(string STR) { C.FC.DarkYellow(); Do(STR); }
            public static void Gray(string STR) { C.FC.Gray(); Do(STR); }
            public static void Green(string STR) { C.FC.Green(); Do(STR); }
            public static void Magenta(string STR) { C.FC.Magenta(); Do(STR); }
            public static void Red(string STR) { C.FC.Red(); Do(STR); }
            public static void White(string STR) { C.FC.White(); Do(STR); }
            public static void Yellow(string STR) { C.FC.Yellow(); Do(STR); }
            public static void Standart(string STR) { C.FC.Standart(); Do(STR); }
            public static void n() { C.FC.Standart(); Do("\n"); }
            public static void n(int n) { C.FC.Standart(); for (int i = 0; i < n; i++) Do("\n"); }
            public static void SeeAllColors(){
                Standart("Black");
                Black("Black\n");
                Standart("Blue");
                Blue("Blue\n");
                Standart("Cyan");
                Cyan("Cyan\n");
                Standart("DarkBlue");
                DarkBlue("DarkBlue\n");
                Standart("DarkCyan");
                DarkCyan("DarkCyan\n");
                Standart("DarkGray");
                DarkGray("DarkGray\n");
                Standart("DarkGreen");
                DarkGreen("DarkGreen\n");
                Standart("DarkMagenta");
                DarkMagenta("DarkMagenta\n");
                Standart("DarkRed");
                DarkRed("DarkRed\n");
                Standart("DarkYellow");
                DarkYellow("DarkYellow\n");
                Standart("Gray");
                Gray("Gray\n");
                Standart("Green");
                Green("Green\n");
                Standart("Magenta");
                Magenta("Magenta\n");
                Standart("Red");
                Red("Red\n");
                Standart("White");
                White("White\n");
                Standart("Yellow");
                Yellow("Yellow\n");
                Standart("Standart");
                Standart("Standart\n");
            }
        }
    }
}
