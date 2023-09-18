using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{    
    /// <summary>PreProcessingInputData</summary>
    /// <summary>PreProInpDat.</summary>
    public partial class PreProInpDat
    {
        /// <summary> ЗаглушкаВходныеТекстовыеДанные_PlugInputTextData</summary>
        public static string PlugInputTextData(Boolean TestDataHardFlag, string PLog)
        {
            string Log = PLog + ".PPID_PITD";//,string PLog
            C.Log.Go(PLog, "PreProInpDat_PlugInputTextData");
            string str = "";
            if (TestDataHardFlag)
            {
                if (false)
                {
                    str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 + "П4" + (char)9 + "П5" + (char)9 + (char)13 + (char)10;
                    str += "A1" + (char)9 + "NaN" + (char)9 + "1" + (char)9 + "2" + (char)9 + "3" + (char)9 + "4" + (char)9 + (char)13 + (char)10;
                    str += "A2" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "5" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                    str += "A3" + (char)9 + "NaN" + (char)9 + "6" + (char)9 + "7" + (char)9 + "8" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                    str += "A4" + (char)9 + "NaN" + (char)9 + "9" + (char)9 + "NaN" + (char)9 + "1" + (char)9 + "1" + (char)9 + (char)13 + (char)10;
                    str += "A5" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                    str += "A6" + (char)9 + "NaN" + (char)9 + "0" + (char)9 + "4" + (char)9 + "0" + (char)9 + "6" + (char)9 + (char)13 + (char)10;
                }
                else
                {
                    str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 + "П4" + (char)9 + "П5" + (char)9 + "П6" + (char)9 + (char)13 + (char)10;
                    str += "A1" + (char)9 + "1" + (char)9 + "65" + (char)9 + "3" + (char)9 + "NaN" + (char)9 + "14" + (char)9 + "5" + (char)9 + (char)13 + (char)10;
                    str += "A2" + (char)9 + "NaN" + (char)9 + "23" + (char)9 + "72" + (char)9 + "NaN" + (char)9 + "7" + (char)9 + "26" + (char)9 + (char)13 + (char)10;
                    str += "A3" + (char)9 + "1" + (char)9 + "23" + (char)9 + "43" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "52" + (char)9 + (char)13 + (char)10;
                    str += "A4" + (char)9 + "124" + (char)9 + "45" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "57" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                    str += "A5" + (char)9 + "NaN" + (char)9 + "23" + (char)9 + "72" + (char)9 + "NaN" + (char)9 + "23" + (char)9 + "35" + (char)9 + (char)13 + (char)10;
                    str += "A6" + (char)9 + "59" + (char)9 + "56" + (char)9 + "43" + (char)9 + "NaN" + (char)9 + "45" + (char)9 + "12" + (char)9 + (char)13 + (char)10;
                    str += "A7" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + "NaN" + (char)9 + (char)13 + (char)10;
                }
            }
            else
            {
                str = "Tабл" + (char)9 + "П1" + (char)9 + "П2" + (char)9 + "П3" + (char)9 + (char)13 + (char)10;
                str += "A1" + (char)9 + "1" + (char)9 + "2" + (char)9 + "3" + (char)9 + (char)13 + (char)10;
                str += "A2" + (char)9 + "7" + (char)9 + "8" + (char)9 + "9" + (char)9 + (char)13 + (char)10;
                str += "A3" + (char)9 + "3" + (char)9 + "4" + (char)9 + "5" + (char)9 + (char)13 + (char)10;
            }
            return str;
        }
        /// <summary> редукция NaN _ NaN reduction </summary>
        public static List<List<string>> NaNReduction(List<List<string>> LLS, string PLog)
        {
            string Log = PLog + ".PPID_NNR";//,string PLog
            C.Log.Go(PLog, "PreProInpDat_NaNReduction");
            for (int i = 0; i < LLS.Count(); i++)
            {
                Boolean flag = true;
                for (int j = 1; j < LLS[i].Count(); j++) if (LLS[i][j] != "NaN") flag = false;
                if (flag)
                {
                    LLS.RemoveAt(i);
                    i--;
                }
            }
            for (int j = 1; j < LLS[0].Count(); j++)
            {
                Boolean flag = true;
                for (int i = 1; i < LLS.Count(); i++) if (LLS[i][j] != "NaN") flag = false;
                if (flag) for (int i = 0; i < LLS.Count(); i++) LLS[i].RemoveAt(j);
            }
            return LLS;
        }
        /// <summary> Получение списка NaN элементов _ Get List NaN Elements </summary>
        public static List<List<string>> GetListNaNElements(List<List<string>> LLS, string PLog)
        {
            string Log = PLog + ".PPID_GLNaNE";//,string PLog
            C.Log.Go(PLog, "PreProInpDat_GetListNaNElements");
            List<List<string>> LLSAP = new List<List<string>>();
            for (int i = 0; i < LLS.Count(); i++)
                for (int j = 1; j < LLS[i].Count(); j++)
                    if (LLS[i][j] == "NaN")
                    {
                        List<string> LS = new List<string>();
                        LS.Add(LLS[i][0]);
                        C.Comment("A");
                        LS.Add(LLS[0][j]);
                        C.Comment("П");
                        LLSAP.Add(LS);
                    }
            return LLSAP;
        }
        
    }
}
