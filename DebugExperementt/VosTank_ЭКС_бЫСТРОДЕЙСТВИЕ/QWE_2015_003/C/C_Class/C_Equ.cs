using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class C {
        /// <summary>Equivalence</summary>
        /// <summary>.Equ</summary>
        public static class Equ{
            /// <summary>Equivalence.String</summary>/// <summary>.Equ.S</summary>/// <param name="S1">string №1</param>/// <param name="S2">string №2</param>/// <returns>Boolean rez</returns>
            public static Boolean S(string S1, string S2)
            {
                
                Boolean rez = true;
                if (S1.Length == S2.Length){Boolean q = true;
                    for (int i = 0; i < S1.Length; i++)if (S1[i] == S2[i]){q = q && true;}else { q = q && false; }
                    rez = rez && q;
                }else { rez = false; }
                return rez;
            }
            public static Boolean LS(List<string> LS1, List<string> LS2)
            {
                Boolean rez = true;
                if (LS1.Count() == LS2.Count()){
                    for (int i = 0; i < LS1.Count(); i++) rez = rez && S(LS1[i], LS2[i]);
                }else { rez = false; }
                return rez;
            }
            public static Boolean LLS(List<List<string>> LLS1, List<List<string>> LLS2)
            {
                Boolean rez = true;
                if (LLS1.Count() == LLS2.Count()){
                    for (int i = 0; i < LLS1.Count(); i++) rez = rez && LS(LLS1[i], LLS2[i]);
                }else { rez = false; }
                return rez;
            }
            public static Boolean LLLS(List<List<List<string>>> LLLS1, List<List<List<string>>> LLLS2)
            {
                Boolean rez = true;
                if (LLLS1.Count() == LLLS2.Count()){
                    for (int i = 0; i < LLLS1.Count(); i++) rez = rez && LLS(LLLS1[i], LLLS2[i]);
                }else { rez = false; }
                return rez;
            }
        }
    }
}