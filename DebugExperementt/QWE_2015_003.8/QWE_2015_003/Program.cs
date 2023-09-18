using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Яндекс переводчик онлайн
/// https://translate.yandex.ru
/// Презентаци я метод варда
/// http://www.myshared.ru/slide/214831/
/// 
/// http://www.blackwasp.co.uk/VSBookmarks.aspx
/// 
/// 
/// 
/// </summary>
namespace QWE_2015_003
{
    class Program
    {
        static public class C { static public class FC { static private void Do(ConsoleColor MyConsoleColor) { Console.ForegroundColor = MyConsoleColor; } public static void Black() { Do(ConsoleColor.Black); } public static void Blue() { Do(ConsoleColor.Blue); } public static void Cyan() { Do(ConsoleColor.Cyan); } public static void DarkBlue() { Do(ConsoleColor.DarkBlue); } public static void DarkCyan() { Do(ConsoleColor.DarkCyan); } public static void DarkGray() { Do(ConsoleColor.DarkGray); } public static void DarkGreen() { Do(ConsoleColor.DarkGreen); } public static void DarkMagenta() { Do(ConsoleColor.DarkMagenta); } public static void DarkRed() { Do(ConsoleColor.DarkRed); } public static void DarkYellow() { Do(ConsoleColor.DarkYellow); } public static void Gray() { Do(ConsoleColor.Gray); } public static void Green() { Do(ConsoleColor.Green); } public static void Magenta() { Do(ConsoleColor.Magenta); } public static void Red() { Do(ConsoleColor.Red); } public static void White() { Do(ConsoleColor.White); } public static void Yellow() { Do(ConsoleColor.Yellow); } public static void Standart() { Do(ConsoleColor.Gray); } } static public class WL { static private void Do(string STR) { Console.Write(STR); C.FC.Standart(); } public static void Black(string STR) { C.FC.Black(); Do(STR); } public static void Blue(string STR) { C.FC.Blue(); Do(STR); } public static void Cyan(string STR) { C.FC.Cyan(); Do(STR); } public static void DarkBlue(string STR) { C.FC.DarkBlue(); Do(STR); } public static void DarkCyan(string STR) { C.FC.DarkCyan(); Do(STR); } public static void DarkGray(string STR) { C.FC.DarkGray(); Do(STR); } public static void DarkGreen(string STR) { C.FC.DarkGreen(); Do(STR); } public static void DarkMagenta(string STR) { C.FC.DarkMagenta(); Do(STR); } public static void DarkRed(string STR) { C.FC.DarkRed(); Do(STR); } public static void DarkYellow(string STR) { C.FC.DarkYellow(); Do(STR); } public static void Gray(string STR) { C.FC.Gray(); Do(STR); } public static void Green(string STR) { C.FC.Green(); Do(STR); } public static void Magenta(string STR) { C.FC.Magenta(); Do(STR); } public static void Red(string STR) { C.FC.Red(); Do(STR); } public static void White(string STR) { C.FC.White(); Do(STR); } public static void Yellow(string STR) { C.FC.Yellow(); Do(STR); } public static void Standart(string STR) { C.FC.Standart(); Do(STR); } public static void n() { C.FC.Standart(); Do("\n"); }public static void n(int n) { C.FC.Standart();for (int i = 0; i < n;i++ ) Do("\n"); } public static void SeeAllColors() { Standart("Black");Black("Black\n"); Standart("Blue"); Blue("Blue\n");Standart("Cyan");Cyan("Cyan\n");Standart("DarkBlue"); DarkBlue("DarkBlue\n");Standart("DarkCyan"); DarkCyan("DarkCyan\n"); Standart("DarkGray");DarkGray("DarkGray\n"); Standart("DarkGreen");DarkGreen("DarkGreen\n");Standart("DarkMagenta");DarkMagenta("DarkMagenta\n");Standart("DarkRed");DarkRed("DarkRed\n");Standart("DarkYellow");DarkYellow("DarkYellow\n");Standart("Gray");Gray("Gray\n");Standart("Green");Green("Green\n");Standart("Magenta");Magenta("Magenta\n"); Standart("Red"); Red("Red\n"); Standart("White"); White("White\n");Standart("Yellow"); Yellow("Yellow\n"); Standart("Standart"); Standart("Standart\n"); }}public static void Comment(string STR) { }}
        static void Main(string[] args)
        {
#pragma warning disable
            Func<string, int, string> SLimiter = (string str, int n) => { C.Comment("Ограничитель и подгонятель текста под конкретную длинну"); while (str.Length < n) str += " "; while (str.Length > n) { string qwe = ""; for (int i = 0; i < str.Length - 1; i++) qwe = qwe + str[i]; str = qwe; } return str; };
            Func<List<List<string>>, int, Object> DisplayTable_M1 = (List<List<string>> LLS, int LengthLimiter) => 
            {
                C.Comment("Хитроумный вывод таблици на экран");
                if (LLS.Count() > 1)if (LLS[0].Count() > 1) 
                {
                    for (int j = 0; j < LLS[0].Count(); j++)
                        C.WL.Cyan(SLimiter(LLS[0][j], LengthLimiter) + " ");
                    C.WL.n();
                    for (int i = 1; i < LLS.Count(); i++) 
                    {
                        for (int j = 0; j < LLS[0].Count(); j++)
                        {
                            string str = "";
                            try
                            {
                                string _LLS = LLS[i][j];
                                Double __LLS = Convert.ToDouble(_LLS);
                                Double ___LLS = Math.Round(__LLS, 3);
                                str = Convert.ToString(___LLS);
                            }
                            catch
                            {
                                str = LLS[i][j];
                            }
                            if (LLS[i][j] == "NaN") 
                                C.WL.Yellow(SLimiter(str, LengthLimiter) + " "); 
                            else 
                                if (j == 0)
                                    C.WL.Red(SLimiter(str, LengthLimiter) + " "); 
                                else 
                                    C.WL.Green(SLimiter(str, LengthLimiter) + " "); 
                        }
                        C.WL.n(); 
                    }
                } 
                return new Object(); 
            };
            Func<List<List<string>>, int, Object> DisplayTable = (List<List<string>> LLS, int LengthLimiter) => { DisplayTable_M1(LLS, LengthLimiter); C.WL.n(2); return new Object(); };
            Func<List<List<List<string>>>, int, Object> DisplayListTable = (List<List<List<string>>> LLLS, int LengthLimiter) => { C.Comment("Хитроумный вывод списка таблиц на экран"); foreach (List<List<string>> L_LLS in LLLS) { DisplayTable_M1(L_LLS, LengthLimiter); } C.WL.n(2); return new Object(); };
            Func<List<string>, List<string>> LS_Copy = (List<string> _LS) => { List<string> rez = new List<string>(); for (int i = 0; i < _LS.Count(); i++)rez.Add(Convert.ToString(_LS[i])); return rez; };
            Func<List<List<string>>, List<List<string>>> LLS_Copy = (List<List<string>> _LLS) => { List<List<string>> rez = new List<List<string>>(); for (int i = 0; i < _LLS.Count(); i++)rez.Add(LS_Copy(_LLS[i])); return rez; };
            Func<List<List<List<string>>>, List<List<List<string>>>> LLLS_Copy = (List<List<List<string>>> _LLLS) => { List<List<List<string>>> rez = new List<List<List<string>>>(); for (int i = 0; i < _LLLS.Count(); i++)rez.Add(LLS_Copy(_LLLS[i])); return rez; }; 
            Func<Boolean, string> PlugInputTextData = (Boolean TestDataHardFlag) =>
            {
                C.Comment("ЗаглушкаВходныеТекстовыеДанные_PlugInputTextData"); string str = "";
                if (TestDataHardFlag){
                    if (false){
                        str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 + "П4" + (char)9 + "П5" + (char)9 + (char)13 + (char)10;
                        str += "A1" + (char)9 + "NaN" + (char)9 + "1" + (char)9 + "2" + (char)9 + "3" + (char)9 + "4" + (char)9 + (char)13 + (char)10;
                        str += "A2" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "5" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                        str += "A3" + (char)9 + "NaN" + (char)9 + "6" + (char)9 + "7" + (char)9 + "8" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                        str += "A4" + (char)9 + "NaN" + (char)9 + "9" + (char)9 + "NaN" + (char)9 + "1" + (char)9 + "1" + (char)9 + (char)13 + (char)10;
                        str += "A5" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                        str += "A6" + (char)9 + "NaN" + (char)9 + "0" + (char)9 + "4" + (char)9 + "0" + (char)9 + "6" + (char)9 + (char)13 + (char)10;
                    }else{ 
                        str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 +"П4" + (char)9+ "П5"+ (char)9 + "П6" + (char)9 + (char)13 + (char)10;
                        str += "A1" + (char)9 + "1" + (char)9 +  "65" + (char)9 + "3" + (char)9 + "NaN"+ (char)9 +  "14" + (char)9 +  "5" + (char)9 + (char)13 + (char)10;
                        str += "A2" + (char)9 + "NaN" + (char)9 + "23" + (char)9+ "72" + (char)9 + "NaN" + (char)9+"7"+ (char)9 +"26" + (char)9 + (char)13 + (char)10;
                        str += "A3" + (char)9 + "1" + (char)9 + "23" + (char)9 +  "43" + (char)9 + "NaN" + (char)9 + "NaN"+ (char)9 +"52" + (char)9 + (char)13 + (char)10;
                        str += "A4" + (char)9 + "124" + (char)9 + "45" + (char)9 +  "NaN" + (char)9+"NaN" + (char)9 + "57"+ (char)9 +  "NaN" + (char)9 + (char)13 + (char)10;
                        str += "A5" + (char)9 + "NaN" + (char)9 + "23" + (char)9+ "72" + (char)9+"NaN" + (char)9+"23"+ (char)9 +"35" + (char)9 + (char)13 + (char)10;
                        str += "A6" + (char)9 + "59" + (char)9 + "56" + (char)9 +  "43" + (char)9 + "NaN" + (char)9 + "45"+ (char)9 +  "12" + (char)9 + (char)13 + (char)10;
                        str += "A7" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 +  "NaN" + (char)9 + "NaN" + (char)9 + "NaN"+ (char)9 +  "NaN" + (char)9 + (char)13 + (char)10;
                    }
                }else{
                    str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 + (char)13 + (char)10;
                    str += "A1" + (char)9 + "1" + (char)9 + "2" + (char)9 + "3" + (char)9 + (char)13 + (char)10;
                    str += "A2" + (char)9 + "7" + (char)9 + "8" + (char)9 + "9" + (char)9 + (char)13 + (char)10;
                    str += "A3" + (char)9 + "3" + (char)9 + "4" + (char)9 + "5" + (char)9 + (char)13 + (char)10;
                }return str;
            };
            Func<string, List<List<string>>> InputData_Convert_ToListListString = (string str) => { C.Comment("Преобразование входных текстовых данных в таблицы _ InputData_Convert_ToListListString"); List<List<string>> ListListString_Table = new List<List<string>>(); int IMax = str.Split((char)10).Count() - 1; int JMax = str.Split((char)10)[0].Split((char)9).Count() - 1; for (int i = 0; i < IMax; i++) { List<string> kiss = new List<string>(); for (int j = 0; j < JMax; j++) kiss.Add(str.Split((char)10)[i].Split((char)9)[j]); ListListString_Table.Add(kiss); } return ListListString_Table; };
            Func<List<List<string>>, List<List<string>>> NaNReduction = (List<List<string>> LLS) => { C.Comment("редукция NaN _ NaN reduction"); for (int i = 0; i < LLS.Count(); i++) { Boolean flag = true; for (int j = 1; j < LLS[i].Count(); j++) if (LLS[i][j] != "NaN") { flag = false; } if (flag) { LLS.RemoveAt(i); i--; } } for (int j = 1; j < LLS[0].Count(); j++) { Boolean flag = true; for (int i = 1; i < LLS.Count(); i++) if (LLS[i][j] != "NaN") { flag = false; } if (flag) for (int i = 0; i < LLS.Count(); i++) LLS[i].RemoveAt(j); } return LLS; };
            Func<List<List<string>>, List<List<string>>> GetListNaNElements = (List<List<string>> LLS) => { C.Comment("Получение списка NaN элементов _ Get List NaN Elements"); List<List<string>> LLSAP = new List<List<string>>(); for (int i = 0; i < LLS.Count(); i++)for (int j = 1; j < LLS[i].Count(); j++) if (LLS[i][j] == "NaN") { List<string> LS = new List<string>(); LS.Add(LLS[i][0]); C.Comment("A"); LS.Add(LLS[0][j]); C.Comment("П"); LLSAP.Add(LS); } return LLSAP; };
            Func<List<List<string>>, List<List<string>>> PrimaryReplenishmentNaNElements = (List<List<string>> LLS) => { C.Comment("первичное заполнение NaN элементов _ primary replenishment NaN elements"); List<Double> LSS = new List<Double>(); List<int> LSSC = new List<int>(); for (int j = 0; j < LLS[0].Count(); j++) { LSS.Add(0); LSSC.Add(0); } for (int j = 1; j < LLS[0].Count(); j++) { string w = ""; for (int i = 1; i < LLS.Count(); i++) { w = LLS[i][j]; if (LLS[i][j] != "NaN") { LSS[j] = LSS[j] + Convert.ToDouble(LLS[i][j]); LSSC[j]++; } } } for (int j = 1; j < LSS.Count(); j++) LSS[j] = LSS[j] / LSSC[j]; for (int j = 1; j < LLS[0].Count(); j++) for (int i = 1; i < LLS.Count(); i++) if (LLS[i][j] == "NaN") LLS[i][j] = Convert.ToString(LSS[j]); return LLS; };
            Func<List<List<string>>, List<List<string>>> ClusterCenter = (List<List<string>> L_LLS) => { C.Comment("Получение центра кластера"); List<List<string>> rez = new List<List<string>>(); { List<string> LS0 = new List<string>(); List<string> LS1 = new List<string>(); for (int i = 0; i < L_LLS[0].Count(); i++) { string s = L_LLS[0][i]; LS0.Add(s); s = L_LLS[1][i]; LS1.Add(s); } for (int j = 1; j < LS1.Count(); j++)LS1[j] = "0"; rez.Add(LS0); rez.Add(LS1); } for (int i = 1; i < L_LLS.Count(); i++)for (int j = 1; j < L_LLS[i].Count(); j++)rez[1][j] = Convert.ToString(Convert.ToDouble(rez[1][j]) + Convert.ToDouble(L_LLS[i][j])); for (int j = 1; j < rez[1].Count(); j++)rez[1][j] = Convert.ToString(Convert.ToDouble(rez[1][j]) / (L_LLS.Count() - 1)); return rez; };
            Func<List<string>, List<string>, Double> DistanceCentClusterLS = (List<string> CentClusterA, List<string> CentClusterB) => { C.Comment("Получение расстояния между двумя точками (передаются обычно координаты центров кластера)"); List<string> CCA = CentClusterA; List<string> CCB = CentClusterB; Double rez = 0; for (int i = 1; i < CCA.Count(); i++)rez = rez + System.Math.Pow(Convert.ToDouble(CCA[i]) - Convert.ToDouble(CCB[i]), 2); return System.Math.Sqrt(rez); }; 
            Func<List<List<string>>, int, List<List<List<string>>>> ClusteringCentroidsMethod_v0 = (List<List<string>> LLS, int n) => { C.Comment("CCM - кластеризация центроидным методом_ClusteringCentroidsMethod"); C.Comment("(классика жанра, как есть, без костылей стимуляторов и ускорителей)"); List<List<List<string>>> ClusterList = new List<List<List<string>>>(); { for (int i = 1; i < LLS.Count(); i++) { List<List<string>> L_LLS = new List<List<string>>(); { List<string> L_LS_Title = new List<string>(); List<string> L_LS_Content = new List<string>(); for (int j = 0; j < LLS[0].Count(); j++) { L_LS_Title.Add(LLS[0][j]); L_LS_Content.Add(LLS[i][j]); } L_LLS.Add(L_LS_Title); L_LLS.Add(L_LS_Content); } L_LLS[0][0] = "C" + Convert.ToString(i); ClusterList.Add(L_LLS); } } if (n >= 2)while (n < ClusterList.Count()) { Double min = Math.Pow(10, 10); int min_i = 0; int min_j = 0; for (int i = 0; i < ClusterList.Count(); i++)for (int j = 0; j < ClusterList.Count(); j++)if (i != j) { Double dist = DistanceCentClusterLS(ClusterCenter(ClusterList[i])[1], ClusterCenter(ClusterList[j])[1]); if (min > dist) { min = dist; min_i = i; min_j = j; } } { List<List<string>> newLLS = new List<List<string>>(); { List<string> qe = new List<string>(); for (int j = 0; j < ClusterList[min_i][0].Count(); j++)qe.Add(ClusterList[min_i][0][j]); newLLS.Add(qe); for (int i = 1; i < ClusterList[min_i].Count(); i++) { List<string> qeg = new List<string>(); for (int k = 0; k < ClusterList[min_i][i].Count(); k++)qeg.Add(ClusterList[min_i][i][k]); newLLS.Add(qeg); } for (int j = 1; j < ClusterList[min_j].Count(); j++) { List<string> qeg = new List<string>(); for (int k = 0; k < ClusterList[min_j][j].Count(); k++)qeg.Add(ClusterList[min_j][j][k]); newLLS.Add(qeg); } } if (min_i > min_j) { ClusterList.RemoveAt(min_i); ClusterList.RemoveAt(min_j); } else { ClusterList.RemoveAt(min_j); ClusterList.RemoveAt(min_i); } ClusterList.Add(newLLS); } } return ClusterList; };
            Func<List<List<string>>, int, List<List<List<string>>>> ClusteringWardMethod_v0 = (List<List<string>> LLS, int n) => { C.Comment("кластеризация метод Варда"); C.Comment("Прикольно описано на сайте:http://www.myshared.ru/slide/214831/ "); C.Comment("Xijk - значение k- переменной в j - наблюдении, принадлежащему  i - кластеру."); C.Comment("ошибка суммы квадратов - ESS = sum(j,sum(j,sum(k,sqr(abs(Xijk - X_СРi.k)))))"); C.Comment("общая сумма квадратов  - TSS = sum(i,sum(j,sum(k,sqr(abs(Xijk - X_СР..k)))))"); C.Comment("R- квадрат r2 = ( TSS - ESS ) / TSS"); C.Comment("минимизация значения r2"); Func<List<List<List<string>>>, Double> TTS = (List<List<List<string>>> _LLS) => { Double SUMM = 0; for (int k = 1; k < _LLS[0][0].Count(); k++) { Double X_СР__k = 0; int e = 0; for (int i = 0; i < _LLS.Count(); i++)for (int j = 1; j < _LLS[i].Count(); j++) { X_СР__k += Convert.ToDouble(_LLS[i][j][k]); e++; } X_СР__k = X_СР__k / e; for (int i = 0; i < _LLS.Count(); i++)for (int j = 1; j < _LLS[i].Count(); j++)SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СР__k), 2); } return SUMM; }; Func<List<List<List<string>>>, Double> ESS = (List<List<List<string>>> _LLS) => { Double SUMM = 0; for (int k = 1; k < _LLS[0][0].Count(); k++) { for (int i = 0; i < _LLS.Count(); i++) { Double X_СРi_k = 0; int e = 0; for (int j = 1; j < _LLS[i].Count(); j++) { X_СРi_k += Convert.ToDouble(_LLS[i][j][k]); e++; } X_СРi_k = X_СРi_k / e; for (int j = 1; j < _LLS[i].Count(); j++)SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СРi_k), 2); } } return SUMM; }; Func<List<List<List<string>>>, int, int, int, Double> r = (List<List<List<string>>> __LLS, int _min_i, int _min_j, int _n) => { List<List<List<string>>> _LLS = LLLS_Copy(__LLS); { List<List<string>> newLLS = new List<List<string>>(); { List<string> qeg = new List<string>(); for (int j = 0; j < _LLS[_min_i][0].Count(); j++) { string gsdf = _LLS[_min_i][0][j]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int i = 1; i < _LLS[_min_i].Count(); i++) { List<string> qeg = new List<string>(); for (int k = 0; k < _LLS[_min_i][i].Count(); k++) { string gsdf = _LLS[_min_i][i][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int j = 1; j < _LLS[_min_j].Count(); j++) { List<string> qeg = new List<string>(); for (int k = 0; k < _LLS[_min_j][j].Count(); k++) { string gsdf = _LLS[_min_j][j][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } if (_min_i > _min_j) { _LLS.RemoveAt(_min_i); _LLS.RemoveAt(_min_j); } else { _LLS.RemoveAt(_min_j); _LLS.RemoveAt(_min_i); } _LLS.Add(newLLS); } return Math.Pow((TTS(_LLS) - ESS(_LLS)) / TTS(_LLS), 2); }; List<List<List<string>>> ClusterList = new List<List<List<string>>>(); { for (int i = 1; i < LLS.Count(); i++) { List<List<string>> L_LLS = new List<List<string>>(); { List<string> L_LS_Title = new List<string>(); List<string> L_LS_Content = new List<string>(); for (int j = 0; j < LLS[0].Count(); j++) { L_LS_Title.Add(LLS[0][j]); L_LS_Content.Add(LLS[i][j]); } L_LLS.Add(L_LS_Title); L_LLS.Add(L_LS_Content); } L_LLS[0][0] = "C" + Convert.ToString(i); ClusterList.Add(L_LLS); } } if (n >= 2) while (n < ClusterList.Count()) { Double min = Math.Pow(10, 10); int min_i = 0; int min_j = 0; for (int i = 0; i < ClusterList.Count(); i++)for (int j = 0; j < ClusterList.Count(); j++)if (i != j) { Double dist = r(ClusterList, i, j, ClusterList.Count()); if (min > dist) { min = dist; min_i = i; min_j = j; } } { List<List<string>> newLLS = new List<List<string>>(); { List<string> qeg = new List<string>(); for (int j = 0; j < ClusterList[min_i][0].Count(); j++) { string gsdf = ClusterList[min_i][0][j]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int i = 1; i < ClusterList[min_i].Count(); i++) { List<string> qeg = new List<string>(); for (int k = 0; k < ClusterList[min_i][i].Count(); k++) { string gsdf = ClusterList[min_i][i][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int j = 1; j < ClusterList[min_j].Count(); j++) { List<string> qeg = new List<string>(); for (int k = 0; k < ClusterList[min_j][j].Count(); k++) { string gsdf = ClusterList[min_j][j][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } if (min_i > min_j) { ClusterList.RemoveAt(min_i); ClusterList.RemoveAt(min_j); } else { ClusterList.RemoveAt(min_j); ClusterList.RemoveAt(min_i); } ClusterList.Add(newLLS); } } return ClusterList; }; 
            Func<List<List<List<string>>>, Double, Double, List<List<string>>> FCM = (List<List<List<string>>> L_LLLS, Double m, Double E) => { C.Comment("FCM - метод нечёткой кластеризации. !!Внимание. Этот метод работает только в связке с обычным методом кластеризации. Один он не работает!!"); Double RLAST = Math.Pow(10, 10); Double R = 0; Boolean FLAG = true; List<List<string>> L_U = new List<List<string>>(); { C.Comment("Генерация L_U"); List<string> ClusterNameList = new List<string>(); List<string> AnkNameList = new List<string>(); ClusterNameList.Add("FCM"); foreach (List<List<string>> L_LLS in L_LLLS) { ClusterNameList.Add(Convert.ToString(L_LLS[0][0])); for (int i = 1; i < L_LLS.Count(); i++)AnkNameList.Add(Convert.ToString(L_LLS[i][0])); } L_U.Add(ClusterNameList); for (int y = 0; y < AnkNameList.Count(); y++) { List<string> newqwe = new List<string>(); newqwe.Add(AnkNameList[y]); for (int i = 1; i < ClusterNameList.Count(); i++) { Boolean qwe = false; for (int j = 0; j < L_LLLS.Count; j++)if (L_LLLS[j][0][0] == ClusterNameList[i])for (int k = 1; k < L_LLLS[j].Count(); k++)if (L_LLLS[j][k][0] == AnkNameList[y])qwe = true; if (qwe)newqwe.Add("1"); else newqwe.Add("0"); } L_U.Add(newqwe); } } List<List<string>> L_C = new List<List<string>>(); { C.Comment("Генерация L_C"); List<List<string>> L_CC = new List<List<string>>(); L_CC.Add(L_LLLS[0][0]); for (int i = 0; i < L_LLLS.Count(); i++) { List<List<string>> centr = ClusterCenter(L_LLLS[i]); centr[1][0] = L_LLLS[i][0][0]; L_CC.Add(centr[1]); } foreach (List<string> rgb in L_CC) { List<string> qdr = new List<string>(); foreach (string v in rgb)qdr.Add(v); L_C.Add(qdr); } L_C[0][0] = "Centr"; } List<List<string>> L_X = new List<List<string>>(); { C.Comment("Генерация L_X"); L_X.Add(new List<string>()); for (int i = 0; i < L_LLLS[0][0].Count(); i++)L_X[0].Add(L_LLLS[0][0][i]); foreach (List<List<string>> CL in L_LLLS) { for (int i = 1; i < CL.Count(); i++) { List<string> asd = new List<string>(); foreach (string seg in CL[i])asd.Add(seg); L_X.Add(asd); } } } while (FLAG) { R = 0; for (int ANK = 1; ANK < L_U.Count(); ANK++)for (int CLUST = 1; CLUST < L_C.Count(); CLUST++)R = R + Math.Pow(Convert.ToDouble(L_U[ANK][CLUST]), m) * DistanceCentClusterLS(L_X[ANK], L_C[CLUST]); Double qwsd = Math.Abs(R - RLAST); if (E > qwsd) FLAG = false; RLAST = R; { C.Comment("пересчёт L_C"); for (int K = 1; K < L_C.Count(); K++)for (int P = 1; P < L_C[K].Count(); P++) { Double ch = 0; Double zn = 0; for (int I = 1; I < L_X.Count; I++) { ch = ch + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m) * Convert.ToDouble(L_X[I][P]); zn = zn + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m); } L_C[K][P] = Convert.ToString(ch / zn); } } { C.Comment("пересчёт L_U"); for (int i = 1; i < L_U.Count(); i++) { Boolean Bigflag = false; int stopset = 0; for (int j = 1; j < L_U[i].Count(); j++)if (DistanceCentClusterLS(L_X[i], L_C[j]) == 0) { Bigflag = true; stopset = j; } if (Bigflag) { for (int j = 1; j < L_U[i].Count(); j++) { if (j == stopset)L_U[i][j] = "1"; if (j != stopset)L_U[i][j] = "0"; } } else { for (int j = 1; j < L_U[i].Count(); j++) { Double zn = 0; for (int L = 1; L < L_C.Count(); L++)zn = zn + System.Math.Pow(DistanceCentClusterLS(L_X[i], L_C[j]) / DistanceCentClusterLS(L_X[i], L_C[L]), 2 / (m - 1)); L_U[i][j] = Convert.ToString((1 / zn)); } } } } } return L_U; };
            Func<List<List<string>>, List<List<string>>, Double> DetermineClustersNumber_CentroidsMethod = (List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE) => { C.Comment("Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber"); C.Comment("Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;"); int rez = ID_PRNaNE.Count(); for (rez = ID_PRNaNE.Count(); rez >= 2; rez--) { List<List<List<string>>> LocalVariable_CCM_v0 = ClusteringCentroidsMethod_v0(ID_PRNaNE, rez); Boolean f_razb = true; foreach (List<List<string>> LS in LocalVariable_CCM_v0) { Boolean f_clust = false; for (int j = 1; j < LS[0].Count(); j++) { Boolean f_param = false; for (int i = 1; i < LS.Count(); i++) { Boolean f_ank = true; for (int k = 0; k < ID_GLNaNE.Count(); k++) if (LS[i][0] == ID_GLNaNE[k][0])if (LS[0][j] == ID_GLNaNE[k][1]) { f_ank = false; } if (f_ank) { f_param = true; break; } } if (f_param) { f_clust = true; } else { f_clust = false; break; } } if (f_clust) { f_razb = true; } else { f_razb = false; break; } } if (f_razb) { break; } } return ++rez; };
            Func<List<List<string>>, List<List<string>>, Double> DetermineClustersNumber_WardMethod = (List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE) => { C.Comment("Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber"); C.Comment("Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;"); int rez = ID_PRNaNE.Count(); for (rez = ID_PRNaNE.Count(); rez >= 2; rez--) { List<List<List<string>>> LocalVariable_CCM_v0 = ClusteringWardMethod_v0(ID_PRNaNE, rez); Boolean f_razb = true; foreach (List<List<string>> LS in LocalVariable_CCM_v0) { Boolean f_clust = false; for (int j = 1; j < LS[0].Count(); j++) { Boolean f_param = false; for (int i = 1; i < LS.Count(); i++) { Boolean f_ank = true; for (int k = 0; k < ID_GLNaNE.Count(); k++) if (LS[i][0] == ID_GLNaNE[k][0])if (LS[0][j] == ID_GLNaNE[k][1]) { f_ank = false; } if (f_ank) { f_param = true; break; } } if (f_param) { f_clust = true; } else { f_clust = false; break; } } if (f_clust) { f_razb = true; } else { f_razb = false; break; } } if (f_razb) { break; } } return ++rez; };
            Func<List<List<string>>, List<List<List<string>>>, List<List<string>>, List<List<string>>, List<List<string>>> RestoreSkipedData
                = (List<List<string>> __LV_PRNaNE, List<List<List<string>>> __LLLS, List<List<string>> __LLS_FCM, List<List<string>> __LocalVariable_GLNaNE) => 
                {
                    C.Comment(" Алгоритм восстановления данных.");
                    C.Comment(" Отработка итерации. (RSD - Restore Skiped Data)");
                    //методы получения значений соответствующих таблиц по названиям анкет и параметров.
                    List<List<string>> _LV_PRNaNE = LLS_Copy(__LV_PRNaNE);
                    List<List<List<string>>> _LLLS = LLLS_Copy(__LLLS);
                    List<List<string>> _LLS_FCM = LLS_Copy(__LLS_FCM);
                    List<List<string>> _LV_GLNaNE = LLS_Copy(__LocalVariable_GLNaNE);
                    //DisplayTable(_LV_PRNaNE, 5);DisplayListTable(_LLLS, 5);DisplayTable(_LLS_FCM, 5);DisplayTable(_LV_GLNaNE, 5);

                    Func<string, string, string> _LV_PRNaNE_Get = (string Ank, string Param) => {for (int i = 0; i < _LV_PRNaNE.Count(); i++) if (_LV_PRNaNE[i][0] == Ank)for (int j = 0; j < _LV_PRNaNE[i].Count(); j++) if (_LV_PRNaNE[0][j] == Param)return _LV_PRNaNE[i][j];MessageBox.Show("_LV_PRNaNE_Get(" + Ank + ";" + Param + ")", "NaN");System.Threading.Thread.Sleep(1000);return "NaN";};
                    Func<string, string, string, Object> _LV_PRNaNE_Set = (string Ank, string Param, string Set) => {for (int i = 0; i < _LV_PRNaNE.Count(); i++)if (_LV_PRNaNE[i][0] == Ank)for (int j = 0; j < _LV_PRNaNE[i].Count(); j++)if (_LV_PRNaNE[0][j] == Param)_LV_PRNaNE[i][j] = Set; return new Object(); };
                    Func<string, string, string, string> _LLLS_Get = (string Clu, string Ank, string Param) => {for (int i = 0; i < _LLLS.Count(); i++) if (_LLLS[i][0][0] == Clu)for (int j = 0; j < _LLLS[i].Count(); j++) if (_LLLS[i][j][0] == Ank)for (int k = 0; k < _LLLS[i][j].Count(); k++) if (_LLLS[i][0][k] == Param)return _LLLS[i][j][k];MessageBox.Show("_LLLS_Get(" +Clu+";"+Ank+ ";" + Param + ")", "NaN");System.Threading.Thread.Sleep(1000);return "NaN";};
                    Func<string, string, string, string, Object> _LLLS_Set = (string Clu, string Ank, string Param, string Set) => {for (int i = 0; i < _LLLS.Count(); i++)if (_LLLS[i][0][0] == Clu)for (int j = 0; j < _LLLS[i].Count(); j++)if (_LLLS[i][j][0] == Ank)for (int k = 0; k < _LLLS[i][j].Count(); k++)if (_LLLS[i][0][k] == Param)_LLLS[i][j][k] = Set;return new Object();};
                    Func<string, string, string> _LLS_FCM_Get = (string Ank, string Clu) => {for (int i = 1; i < _LLS_FCM.Count(); i++)if (_LLS_FCM[i][0] == Ank)for (int j = 1; j < _LLS_FCM[i].Count(); j++)return _LLS_FCM[i][j];MessageBox.Show("_LLS_FCM_Get(" + Ank + ";" + Clu + ")", "NaN");System.Threading.Thread.Sleep(1000);return "NaN";};
                    Func<string, string, string, Object> _LLS_FCM_Set = (string Ank, string Clu, string Set) => {for (int i = 0; i < _LLS_FCM.Count(); i++)if (_LLS_FCM[i][0] == Ank)for (int j = 0; j < _LLS_FCM[i].Count(); j++)if (_LLS_FCM[0][j] == Clu)_LLS_FCM[i][j] = Set; return new Object();};
                    Func<string, string, string> _LLLS_P_SR = (string Clu, string Param) => {C.Comment("Cреднее арифметическое отдельного параметра по отдельному кластеру");double rez=0;int e = 0;for (int i = 0; i < _LLLS.Count(); i++) if (_LLLS[i][0][0] == Clu)for (int j = 1; j < _LLLS[i].Count(); j++)for (int k = 1; k < _LLLS[i][j].Count(); k++)if (_LLLS[i][0][k] == Param){rez += Convert.ToDouble(_LLLS[i][j][k]);e++;}return Convert.ToString(rez/e);};
                    
                        for (int i = 0; i < _LV_GLNaNE.Count(); i++) 
                        {   
                            string Ank=_LV_GLNaNE[i][0];
                            string Param=_LV_GLNaNE[i][1];
                            double rez = 0;
                            for (int j = 1; j < _LLS_FCM[0].Count(); j++) 
                            {
                                string Clu = _LLS_FCM[0][j];
                                string FCM_ = _LLS_FCM_Get(Ank, Clu);
                                string P_SR = _LLLS_P_SR(Clu, Param);
                                rez += Convert.ToDouble(FCM_) * Convert.ToDouble(P_SR);
                            }
                            _LV_PRNaNE_Set(Ank, Param, Convert.ToString(rez));
                        }
                    return _LV_PRNaNE;
                };

#pragma warning restore
            {
                //Boolean TDHF = false;
                Boolean TDHF = true;
                //{C.Comment("Исходный текст");string LocalVariable_PITD = PlugInputTextData(TDHF);Console.Write(LocalVariable_PITD);}
                //{C.Comment("Данные в формате таблици");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);DisplayTable(LocalVariable_IDCTLLS, 5);C.WL.n(2);}
                //{C.Comment("Редуцированные данные");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);DisplayTable(LocalVariable_NaNR, 5);C.WL.n(2);}
                //{C.Comment("Список незаполненных параметров");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);List<List<string>> LocalVariable_GLNaNE = GetListNaNElements(LocalVariable_NaNR);DisplayTable(LocalVariable_GLNaNE, 5);C.WL.n(2);}
                //{C.Comment("Данные, залитые средним арифметическим"); string LocalVariable_PITD = PlugInputTextData(TDHF); List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD); List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS); List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR); DisplayTable(LocalVariable_PRNaNE, 5); C.WL.n(2); }
                //{C.Comment("Кластеризация центроидным методом CCM_v0");C.Comment("(классика жанра, как есть, без костылей стимуляторов и ускорителей)");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR);int n = 2;List<List<List<string>>> LocalVariable_CCM_v0 = ClusteringCentroidsMethod_v0(LocalVariable_PRNaNE, n);DisplayListTable(LocalVariable_CCM_v0, 5);}
                //{C.Comment("Кластеризация метод Варда");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR);int n = 3;List<List<List<string>>> LocalVariable_WM_v0 = ClusteringWardMethod_v0(LocalVariable_PRNaNE, n);DisplayListTable(LocalVariable_WM_v0, 5);}
                //{C.Comment("Кластеризация FCM методом ");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR);int n = 3;List<List<List<string>>> LocalVariable_CCM_v0 = ClusteringCentroidsMethod_v0(LocalVariable_PRNaNE, n);DisplayListTable(LocalVariable_CCM_v0, 5);Double Q_M = 1.5;Double DE = 0.005;List<List<string>> LocalVariable_FCM = FCM(LocalVariable_CCM_v0, Q_M, DE);DisplayTable(LocalVariable_FCM, 6);}
                //{ C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)"); string LocalVariable_PITD = PlugInputTextData(TDHF); List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD); List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS); List<List<string>> LocalVariable_GLNaNE = GetListNaNElements(LocalVariable_NaNR); List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR); Double QWSRFTBVC = DetermineClustersNumber_CentroidsMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE); C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC)); }
                //{C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)");string LocalVariable_PITD = PlugInputTextData(TDHF);List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);List<List<string>> LocalVariable_GLNaNE = GetListNaNElements(LocalVariable_NaNR);List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR);Double QWSRFTBVC = DetermineClustersNumber_WardMethod(LocalVariable_GLNaNE,LocalVariable_PRNaNE);C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC));}
                {
                    C.Comment(" Алгоритм восстановления данных. Отработка итерации.");
                    string LocalVariable_PITD = PlugInputTextData(TDHF);
                    List<List<string>> LocalVariable_IDCTLLS = InputData_Convert_ToListListString(LocalVariable_PITD);
                    List<List<string>> LocalVariable_NaNR = NaNReduction(LocalVariable_IDCTLLS);
                    List<List<string>> LocalVariable_GLNaNE = GetListNaNElements(LocalVariable_NaNR);
                    List<List<string>> LocalVariable_PRNaNE = PrimaryReplenishmentNaNElements(LocalVariable_NaNR);

                    while (true)
                    {
                        C.Comment("Определяем колво кластеров - (DetermineClustersNumber_WardMethod)");
                        Double DCN_WM = DetermineClustersNumber_WardMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE);

                        C.Comment("Кластеризация метод Варда");
                        int n_Ward = (int)DCN_WM;
                        List<List<List<string>>> LocalVariable_WM_v0 = ClusteringWardMethod_v0(LocalVariable_PRNaNE, n_Ward);

                        C.Comment("Кластеризация FCM методом ");
                        Double Q_M_FCM = 1.5;
                        Double DE_FCM = 0.005;
                        List<List<string>> LocalVariable_FCM = FCM(LocalVariable_WM_v0, Q_M_FCM, DE_FCM);

                        C.Comment(" ( RSD - Restore Skiped Data).");
                        LocalVariable_PRNaNE = RestoreSkipedData(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
                        DisplayTable(LocalVariable_PRNaNE, 5);
                        System.Threading.Thread.Sleep(2000);
                    }
                }
                Console.Read();
            }
        }
    }
}