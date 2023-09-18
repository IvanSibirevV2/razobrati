using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003
{
    public partial class PreProInpDat
    {
        /// <summary> Заполнение NaN элементов _ replenishment NaN elements// .Replenishment</summary>
        static public class Replenishment
        {
            /// <summary> первичное заполнение NaN элементов _ primary replenishment NaN elements </summary>
            public static List<List<string>> PrimaryReplenishmentNaNElements(List<List<string>> LLS, string PLog)
            {
                string Log = PLog + ".PPID_PRNaNE";//,string PLog
                C.Log.Go(PLog, "PreProInpDat_PrimaryReplenishmentNaNElements");
                List<Double> LSS = new List<Double>();
                List<int> LSSC = new List<int>();
                for (int j = 0; j < LLS[0].Count(); j++)
                {
                    LSS.Add(0);
                    LSSC.Add(0);
                }
                for (int j = 1; j < LLS[0].Count(); j++)
                {
                    string w = "";
                    for (int i = 1; i < LLS.Count(); i++)
                    {
                        w = LLS[i][j];
                        if (LLS[i][j] != "NaN")
                        {
                            LSS[j] = LSS[j] + Convert.ToDouble(LLS[i][j]);
                            LSSC[j]++;
                        }
                    }
                }
                for (int j = 1; j < LSS.Count(); j++) LSS[j] = LSS[j] / LSSC[j];
                for (int j = 1; j < LLS[0].Count(); j++) for (int i = 1; i < LLS.Count(); i++) if (LLS[i][j] == "NaN") LLS[i][j] = Convert.ToString(LSS[j]);
                return LLS;
            }
            /// <summary> первичное заполнение NaN элементов нулями _ primary replenishment NaN elements with zeros </summary>
            public static List<List<string>> PrimaryReplenishmentNaNElementsWithZeros(List<List<string>> LLS, string PLog){
                string Log = PLog + ".PPID_PRNaNEWZ";//,string PLog
                C.Log.Go(PLog, "PreProInpDat_PrimaryReplenishmentNaNElementsWithZeros");
                for (int j = 1; j < LLS[0].Count(); j++)
                    for (int i = 1; i < LLS.Count(); i++)
                        if (LLS[i][j] == "NaN")
                            LLS[i][j] = Convert.ToString((int)0);
                return LLS;
            }
        }        
    }
}
