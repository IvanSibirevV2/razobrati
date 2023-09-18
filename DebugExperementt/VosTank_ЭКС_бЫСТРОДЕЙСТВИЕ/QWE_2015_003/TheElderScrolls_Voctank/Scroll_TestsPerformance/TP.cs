using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QWE_2015_003
{
    public partial class Scroll_TestsPerformance
    {
        public static void GO(Log ThisLog) 
        {
            ThisLog = ThisLog.NewLog("DCN.WM", "DetermineClustersNumber.WardMethod", true);
            Func<List<List<string>>, int, int, List<List<string>>> DataColumnCut = (List<List<string>> INPUTLLS, int DelProc, int j) =>
            {
                List<List<string>> _LLS = C.COPY.LLS(INPUTLLS);
                _LLS[0][0] = "001_" + Convert.ToString(DelProc) + "_" + Convert.ToString(j) + "_";
                int Ank_Count = _LLS.Count() - 1;
                //100   Ank_Count
                //  x   уд
                if ((true) & (DelProc > 0) & (DelProc < 100) & (j > 0) & (j < _LLS[0].Count()))
                {
                    List<int> u = new List<int>();
                    Random rand = new Random();
                    while (u.Count() < (int)((_LLS.Count() - 1) * DelProc / 100))
                    {
                        int rnd = rand.Next(1, _LLS.Count());
                        Boolean flsg = true;
                        foreach (int i in u) if (i == rnd) flsg = false;
                        if (flsg) u.Add(rnd);
                    }
                    u.Sort();
                    for (int i = u.Count() - 1; i > -1; i--) _LLS[u[i]][j] = "NaN";
                }
                return _LLS;
            };
            List<List<string>> LLS_DSXD = PreProInpDat.ConverD.InputDataToListListString(DataSoursXD.Q001(),ThisLog);
            string param1 = "10";/*%*/
            string param2 = "2";/*Column [1,...*/
            Stopwatch watch = new Stopwatch();
            watch.Start();
            {//Погнали
                List<List<string>> DF = C.COPY.LLS(DataColumnCut(LLS_DSXD, Convert.ToInt32(param1), Convert.ToInt32(param2)));
                
                List<List<string>> DF_NaNR = PreProInpDat.NaNReduction(C.COPY.LLS(DF), ThisLog);
                /*List<List<string>> LLs_RSD_10 = QWE_2015_003.RSD_Test.GO_test_000(
                    PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    10, ThisLog);*/
                /*List<List<string>> LLs_RSD_10 = QWE_2015_003.RSD_Test.GO_test_001(
                    PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    10, ThisLog);*/
                /*List<List<string>> LLs_RSD_10 = QWE_2015_003.RSD_Test.GO_test_002(
                    PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    10, ThisLog);*/
                /*List<List<string>> LLs_RSD_10 = QWE_2015_003.RSD_Test.GO_test_003(
                    PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    10, ThisLog);*/
                List<List<string>> LLs_RSD_10 = QWE_2015_003.RSD_Test.GO_test_004(
                    PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                    10, ThisLog);
            }            
            watch.Stop();
            //C.WL.Green("QWE_2015_003.RSD_Test.GO_test_000"); C.WL.n(3);
            //C.WL.Green("QWE_2015_003.RSD_Test.GO_test_001"); C.WL.n(3);
            //C.WL.Green("QWE_2015_003.RSD_Test.GO_test_002"); C.WL.n(3);
            //C.WL.Green("QWE_2015_003.RSD_Test.GO_test_003"); C.WL.n(3);
            C.WL.Green("QWE_2015_003.RSD_Test.GO_test_004"); C.WL.n(3);
            C.WL.Cyan("Времени потрачено в часах = " + Convert.ToString(watch.Elapsed.Hours)); C.WL.n();
            C.WL.Cyan("Времени потрачено в минутах = " + Convert.ToString(watch.Elapsed.Minutes)); C.WL.n();
            C.WL.Cyan("Времени потрачено в секундах = " + Convert.ToString(watch.Elapsed.Seconds)); C.WL.n();
            C.WL.Cyan("Времени потрачено и ещё хрен знает в чём =  \n" + Convert.ToString(watch.Elapsed.Milliseconds)); C.WL.n();
        }
    }
}