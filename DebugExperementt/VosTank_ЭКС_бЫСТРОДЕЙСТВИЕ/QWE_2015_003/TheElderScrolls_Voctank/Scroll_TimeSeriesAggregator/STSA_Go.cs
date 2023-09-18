using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003.TheElderScrolls_Voctank
{
    public partial class Scroll_TimeSeriesAggregator
    {
        public static void GO(Log ThisLog) 
        {
            List<List<string>> LLSD = LLSDataGen();
            //List<List<string>> ne = v1(LLSD,true);
            //List<List<string>> ne = v2(LLSD, true);
            List<List<string>> ne = v3_a4(LLSD, false,90);
            //List<List<string>> ne = v3(LLSD, true,25);
            Console.Read();
        }
        /// <summary></summary>
        public static List<List<string>> v3_a4(List<List<string>> LLSD, bool IsTest, int proc)
        {
            if (IsTest) { C.WL.Red("Получение среднего арифметического значения "); C.WL.Red("(среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))"); C.WL.n(); C.WL.Yellow("v1"); C.WL.n(); C.WL.White("Входные данные"); C.WL.n(); C.DT.LLS(LLSD, 5); }
            List<List<string>> rez = new List<List<string>>();
            { /*генерация выходного ряда*/rez.Add(C.COPY.LS(LLSD[0])); rez.Add(C.COPY.LS(LLSD[0])); rez[0][0] = "+"; rez[1][0] = ""; for (int i = 1; i < LLSD.Count(); i++)rez[1][0] += LLSD[i][0] + "+"; for (int j = 1; j < LLSD[0].Count(); j++)rez[1][j] = "0"; }
            { /*наполнение выходного ряда*/
                for (int j_rez = 1; j_rez < rez[0].Count(); j_rez++)
                {
                    List<List<string>> GenDataFoCalc = new List<List<string>>();
                    { /*Генерация данных на обработку*/
                        for (int i = 0; i < LLSD.Count(); i++) 
                        {
                            List<string> xwehjfhkdjschykjsylk = new List<string>();
                            xwehjfhkdjschykjsylk.Add(LLSD[i][0]); 
                            GenDataFoCalc.Add(xwehjfhkdjschykjsylk); 
                        } 
                        for (int i = 0; i < LLSD.Count(); i++)
                            GenDataFoCalc[i].Add(LLSD[i][j_rez]);
                    }
                    List<List<string>> FCM_ = new List<List<string>>();
                    { /*Определение самого многочисленного кластера + fcm изация*/
                        List<List<List<string>>> r1 = Clustering.Centroid.GO_v1(GenDataFoCalc, 2, new Log());
                        Double Q_M = 1.5; Double DE = 0.005; List<List<string>> FCM = Clustering.FCM.GO_V000(r1, Q_M, DE, new Log());
                        if (IsTest) { C.WL.White("FCM таблица"); C.WL.n(); C.DT.LLS(FCM, 5); }
                        int hk = 0; if (r1[0].Count() > r1[1].Count()) { C.WL.White(r1[0][0][0]); C.WL.n(); hk = 0; } if (r1[0].Count() == r1[1].Count()) { C.WL.White(r1[0][0][0]); C.WL.n(); hk = 0; }if (r1[0].Count() < r1[1].Count()) { C.WL.White(r1[1][0][0]); C.WL.n(); hk = 1; } hk++;
                        
                        for (int i = 0; i < FCM.Count(); i++) { List<string> FdsfshkldgjoihCM_ = new List<string>(); FdsfshkldgjoihCM_.Add(FCM[i][0]); FdsfshkldgjoihCM_.Add(FCM[i][hk]); FCM_.Add(FdsfshkldgjoihCM_); } FCM_[0][0] = "FCM_"; for (int i = 2; i < FCM_.Count(); i++) for (int j = 2; j < FCM_.Count(); j++) if (Convert.ToDouble(FCM_[j - 1][1]) >= Convert.ToDouble(FCM_[j][1])) { string ReGan = ""; ReGan = FCM_[j][1]; FCM_[j][1] = FCM_[j - 1][1]; FCM_[j - 1][1] = ReGan; ReGan = FCM_[j][0]; FCM_[j][0] = FCM_[j - 1][0]; FCM_[j - 1][0] = ReGan; }
                        double Border = FCM_.Count() - 1 - (FCM_.Count() - 1) * proc / 100;
                        for (int i = 1; i < Border; i++) FCM_.RemoveAt(1);
                        if (IsTest) { C.WL.White("FCM редуцированная и отсортированая таблица"); C.WL.n(); C.DT.LLS(FCM_, 5); }
                        /*if (rez0_5[0].Count() > rez0_5[1].Count())GenDataFoCalc = C.COPY.LLS(rez0_5[0]); if (rez0_5[0].Count() == rez0_5[1].Count())GenDataFoCalc = C.COPY.LLS(rez0_5[0]);if (rez0_5[0].Count() < rez0_5[1].Count()) GenDataFoCalc = C.COPY.LLS(rez0_5[1]); */
                    }
                    {/*Взаимная радость использования средеарифметического*/
                        double d = 0;
                        int d_Counter = 0;
                        for (int i = 1; i < GenDataFoCalc.Count(); i++)
                            for (int i_search = 1; i_search < FCM_.Count(); i_search++)
                                if (FCM_[i_search][0] == GenDataFoCalc[i][0]){d = d + Convert.ToDouble(GenDataFoCalc[i][1]);d_Counter++;}
                        d = d / d_Counter; 
                        rez[1][j_rez] = Convert.ToString(d); 
                    }
                }
            }
            if (IsTest) { C.WL.White("Результат (наиболее многочисленный кластер)"); C.WL.n(); C.DT.LLS(rez, 5); }
            return rez;
        }
        /// <summary>Получение среднего арифметического значения (среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))</summary>
        public static List<List<string>> v2(List<List<string>> LLSD, bool IsTest)
        {
            if (IsTest) { C.WL.Red("Получение среднего арифметического значения "); C.WL.Red("(среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))"); C.WL.n(); C.WL.Yellow("v1"); C.WL.n(); C.WL.White("Входные данные"); C.WL.n(); C.DT.LLS(LLSD, 5); }
            List<List<string>> rez = new List<List<string>>();
            { /*генерация выходного ряда*/rez.Add(C.COPY.LS(LLSD[0])); rez.Add(C.COPY.LS(LLSD[0])); rez[0][0] = "+"; rez[1][0] = ""; for (int i = 1; i < LLSD.Count(); i++)rez[1][0] += LLSD[i][0] + "+"; for (int j = 1; j < LLSD[0].Count(); j++)rez[1][j] = "0"; }
            { /*наполнение выходного ряда*/
                for (int j_rez = 1; j_rez < rez[0].Count(); j_rez++)
                {
                    List<List<string>> GenDataFoCalc = new List<List<string>>();
                    { /*Генерация данных на обработку*/for (int i = 0; i < LLSD.Count(); i++) { List<string> xwehjfhkdjschykjsylk = new List<string>(); xwehjfhkdjschykjsylk.Add(LLSD[i][0]); GenDataFoCalc.Add(xwehjfhkdjschykjsylk); } for (int i = 0; i < LLSD.Count(); i++)GenDataFoCalc[i].Add(LLSD[i][j_rez]); }
                    { /*Определение самого многочисленного кластера*/List<List<List<string>>> rez0_5 = Clustering.Centroid.GO_v1(GenDataFoCalc, 2, new Log()); if (rez0_5[0].Count() > rez0_5[1].Count()) GenDataFoCalc = C.COPY.LLS(rez0_5[0]); if (rez0_5[0].Count() == rez0_5[1].Count()) GenDataFoCalc = C.COPY.LLS(rez0_5[0]); if (rez0_5[0].Count() < rez0_5[1].Count()) GenDataFoCalc = C.COPY.LLS(rez0_5[1]); }
                    { /*Взаимная радость использования средеарифметического*/double d = 0;for (int i = 1; i < GenDataFoCalc.Count(); i++)d = d + Convert.ToDouble(GenDataFoCalc[i][1]);d = d / (LLSD.Count() - 1);rez[1][j_rez] = Convert.ToString(d);}
                }
            }
            if (IsTest) { C.WL.White("Результат (наиболее многочисленный кластер)"); C.WL.n(); C.DT.LLS(rez, 5); }
            return rez;
        }
        /// <summary>Получение среднего арифметического значения (среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))</summary>
        public static List<List<string>> v1(List<List<string>> LLSD, bool IsTest)
        {
            if (IsTest){C.WL.Red("Получение среднего арифметического значения ");C.WL.Red("(среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))"); C.WL.n();C.WL.Yellow("v1"); C.WL.n();C.WL.White("Входные данные"); C.WL.n();C.DT.LLS(LLSD, 5);}
            List<List<string>> rez = new List<List<string>>();
            { /*генерация выходного ряда*/rez.Add(C.COPY.LS(LLSD[0])); rez.Add(C.COPY.LS(LLSD[0])); rez[0][0] = "+"; rez[1][0] = ""; for (int i = 1; i < LLSD.Count(); i++)rez[1][0] += LLSD[i][0] + "+"; for (int j = 1; j < LLSD[0].Count(); j++)rez[1][j] = "0"; }
            { /*наполнение выходного ряда*/
                for (int j_rez = 1; j_rez < rez[0].Count(); j_rez++)
                {
                    List<List<string>> GenDataFoCalc = new List<List<string>>();
                    {/*Генерация данных на обработку*/for (int i = 0; i < LLSD.Count(); i++){List<string> xwehjfhkdjschykjsylk = new List<string>();xwehjfhkdjschykjsylk.Add(LLSD[i][0]);GenDataFoCalc.Add(xwehjfhkdjschykjsylk);}for (int i = 0; i < LLSD.Count(); i++)GenDataFoCalc[i].Add(LLSD[i][j_rez]);}
                    double d=0;
                    for (int i = 1; i < GenDataFoCalc.Count(); i++)
                        d = d+ Convert.ToDouble(GenDataFoCalc[i][1]);
                    d=d/(LLSD.Count()-1);
                    rez[1][j_rez] = Convert.ToString(d);
                } 
            }
            if (IsTest){C.WL.White("Результат (наиболее многочисленный кластер)"); C.WL.n();C.DT.LLS(rez, 5);}
            return rez;
        }
        
        /// <summary>
        /// Что сейчас делает этот алгоритм
        /// Кластеризует данные, получает фцм
        /// Потом сортирует фцм и обрезает фцм, оставляет только некоторый процент самых типичных данных
        /// Потом заносит самый типичный процент данных для нахождения среднеарифметического
        /// !!!ВНИМАНИЕ!!!
        /// Алгоритм не дописан. Если собераетесь возрождать алгоритм, то сделайте так , чтобы на кластеризацию подавались не все данные а только текущие точки.
        /// И да останется дописать создание выходных данных на их основе.
        /// !!!ВНИМАНИЕ!!!
        /// </summary><summary>
        /// Идей номер 2 
        /// использовать FCM КАК генератор весовых коэффициентов.
        /// </summary>
        public static List<List<string>> v3(List<List<string>> LLSD, bool IsTest, int proc)
        {

            if (IsTest) { C.WL.Red("Получение среднего арифметического значения (среди всех временных рядов (для каждой отдельной точки точки (при y=уi)))"); C.WL.n(); C.WL.Yellow("v3"); C.WL.n(); C.WL.White("Входные данные"); C.WL.n(); C.DT.LLS(LLSD, 5); }
            List<List<string>> r2 = new List<List<string>>();
            List<List<List<string>>> r1 = Clustering.Centroid.GO_v1(LLSD, 2, new Log());
            if (IsTest) { C.WL.White("Накластеризованные данные"); C.WL.n(); C.DT.LLLS(r1, 5); }
            Double Q_M = 1.5;
            Double DE = 0.005;
            List<List<string>> FCM = Clustering.FCM.GO_V000(Clustering.Centroid.GO_v1(LLSD, 2, new Log()), Q_M, DE, new Log());
            
            if (IsTest) { C.WL.White("FCM таблица"); C.WL.n(); C.DT.LLS(FCM, 5); }
            int hk = 0; if (r1[0].Count() > r1[1].Count()) { C.WL.White(r1[0][0][0]); C.WL.n(); hk = 0; } if (r1[0].Count() == r1[1].Count()) { C.WL.White(r1[0][0][0]); C.WL.n(); hk = 0; } if (r1[0].Count() < r1[1].Count()) { C.WL.White(r1[1][0][0]); C.WL.n(); hk = 1; } hk++;
            List<List<string>> FCM_ = new List<List<string>>(); for (int i = 0; i < FCM.Count(); i++) { List<string> FdsfshkldgjoihCM_ = new List<string>(); FdsfshkldgjoihCM_.Add(FCM[i][0]); FdsfshkldgjoihCM_.Add(FCM[i][hk]); FCM_.Add(FdsfshkldgjoihCM_); } FCM_[0][0] = "FCM_"; for (int i = 2; i < FCM_.Count(); i++) for (int j = 2; j < FCM_.Count(); j++) if (Convert.ToDouble(FCM_[j - 1][1]) >= Convert.ToDouble(FCM_[j][1])) { string ReGan = ""; ReGan = FCM_[j][1]; FCM_[j][1] = FCM_[j - 1][1]; FCM_[j - 1][1] = ReGan; ReGan = FCM_[j][0]; FCM_[j][0] = FCM_[j - 1][0]; FCM_[j - 1][0] = ReGan; }
            for (int i = 1; i < (FCM_.Count() - 1 - (FCM_.Count() - 1) * proc / 100); i++) FCM_.RemoveAt(1);

            if (IsTest) { C.WL.White("FCM редуцированная и отсортированая таблица"); C.WL.n(); C.DT.LLS(FCM_, 5); }
            return r2;
        }
    }
}
