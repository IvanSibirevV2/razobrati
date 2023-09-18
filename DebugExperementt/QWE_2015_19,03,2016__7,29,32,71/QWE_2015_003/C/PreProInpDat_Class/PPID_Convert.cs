using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    public partial class PreProInpDat
    {
        public static class ConverD
        {
            /// <summary>Преобразование входных текстовых данных в таблицы _ InputData_Convert_ToListListString</summary>
            public static List<List<string>> InputDataToListListString(string str, string PLog)
            {
                string Log = PLog + ".PPID_ID C TLLS";//,string PLog
                C.Log.Go(PLog, "PreProInpDat_InputData_Convert_ToListListString");
                List<List<string>> ListListString_Table = new List<List<string>>();
                int IMax = str.Split((char)10).Count() - 1;
                int JMax = str.Split((char)10)[0].Split((char)9).Count() - 1;
                for (int i = 0; i < IMax; i++)
                {
                    List<string> kiss = new List<string>();
                    for (int j = 0; j < JMax; j++)
                        kiss.Add(str.Split((char)10)[i].Split((char)9)[j]);
                    ListListString_Table.Add(kiss);
                }
                return ListListString_Table;
            }
            /// <summary>Преобразование таблицы в входные текстовые данные _ InputData_Convert_ToListListString</summary>
            public static string ListListStringToInputData(List<List<string>> LLS, string PLog)
            {
                string Log = PLog + ".PPID_LLSCTID";//,string PLog
                C.Log.Go(PLog, "PreProInpDat_ListListString_Convert_ToInputData");
                string stolb = "";
                for (int i = 0; i < LLS.Count(); i++)
                {
                    string strok = "";
                    for (int j = 0; j < LLS[i].Count(); j++) strok = strok + LLS[i][j] + (char)9;
                    stolb = stolb + strok + (char)13 + (char)10;
                }
                return stolb;
            }
            /// <summary>Преобразование таблицы в входные текстовые данные _ InputData_Convert_ToListListString</summary>
            public static List<List<string>> LLLSToLLS(List<List<List<string>>> LLLS, string PLog)
            {
                string Log = PLog + ".PPID_LLLSCLLS";//,string PLog
                C.Log.Go(PLog, "PreProInpDat_LLLS_Convert_LLS");
                List<List<string>> LLS = new List<List<string>>();
                for (int i = 0; i < LLLS.Count; i++) for (int j = 0; j < LLLS[i].Count; j++) LLS.Add(C.COPY.LS(LLLS[i][j]));
                return LLS;
            }
        
        }
    }
}
