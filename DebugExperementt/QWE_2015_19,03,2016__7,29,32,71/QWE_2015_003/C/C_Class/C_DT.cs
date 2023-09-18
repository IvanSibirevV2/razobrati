using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class C{
        /// <summary>DisplayTable</summary>/// <summary>.DT</summary>
        public static class DT{
            /// <summary> C.Comment("Ограничитель и подгонятель текста под конкретную длинну"); </summary>        
            public static string SLimiter(string str, int n, string PLog)
            {
                string Log = PLog + ".DT_SL";if(false)C.Log.Go(PLog, "DT_SLimiter");
                while (str.Length < n) str += " ";
                while (str.Length > n){
                    string qwe = "";
                    for (int i = 0; i < str.Length - 1; i++)
                        qwe = qwe + str[i];
                    str = qwe;
                }
                return str;
            }
            /// <summary> Хитроумный вывод таблици на экран </summary>
            private static void DisplayTable_1(List<List<string>> LLS, int LengthLimiter, string PLog)
            {
                string Log = PLog + ".DT_DT_1"; if (false) C.Log.Go(PLog, "DT_DisplayTable_1");
                if ((LLS.Count() > 1) && (LLS[0].Count() > 1)){
                    for (int j = 0; j < LLS[0].Count(); j++)
                        C.WL.Cyan(C.DT.SLimiter(LLS[0][j], LengthLimiter, Log) + " ");
                    C.WL.n();
                    for (int i = 1; i < LLS.Count(); i++){
                        for (int j = 0; j < LLS[0].Count(); j++){
                            string str = "";
                            try{
                                string _LLS = LLS[i][j];
                                Double __LLS = Convert.ToDouble(_LLS);
                                Double ___LLS = Math.Round(__LLS, 3);
                                str = Convert.ToString(___LLS);
                            }catch { str = LLS[i][j]; }
                            if (LLS[i][j] == "NaN") {
                                C.WL.Yellow(C.DT.SLimiter(str, LengthLimiter, Log) + " ");
                            }else
                                if (j == 0) {
                                    C.WL.Red(C.DT.SLimiter(str, LengthLimiter, Log) + " "); 
                                }else {
                                    C.WL.Green(C.DT.SLimiter(str, LengthLimiter, Log) + " "); 
                                }
                        }
                        C.WL.n();
                    }
                }
            }
            ///<summary> C.Comment("Хитроумный вывод таблицS на экран"); </summary>        
            public static void LLS(List<List<string>> _LLS, int LengthLimiter, string PLog)
            {
                string Log = PLog + ".DT_LLS"; if (false) C.Log.Go(PLog, "DT_LLS");
                C.DT.DisplayTable_1(_LLS, LengthLimiter, Log);
                C.WL.n(2);
            }
            ///<summary> C.Comment("Хитроумный вывод списка таблиц на экран"); </summary>        
            public static void LLLS(List<List<List<string>>> _LLLS, int LengthLimiter, string PLog)
            {
                string Log = PLog + ".DT_LLLS"; if (false) C.Log.Go(PLog, "DT_LLLS");
                foreach (List<List<string>> L_LLS in _LLLS)
                    C.DT.DisplayTable_1(L_LLS, LengthLimiter, Log);
                C.WL.n(2);
            }
        }
    }
}
