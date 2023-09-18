using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class C{
        /// <summary>COPY</summary>
        /// /// <summary>C.COPY</summary>
        public static class COPY{
            public static List<string> LS(List<string> _LS)
            {
                List<string> rez = new List<string>();
                for (int i = 0; i < _LS.Count(); i++)
                    rez.Add(Convert.ToString(_LS[i]));
                return rez;
            }
            public static List<List<string>> LLS(List<List<string>> _LLS)
            {
                List<List<string>> rez = new List<List<string>>();
                for (int i = 0; i < _LLS.Count(); i++)
                    rez.Add(LS(_LLS[i]));
                return rez;
            }
            public static List<List<List<string>>> LLLS(List<List<List<string>>> _LLLS)
            {
                List<List<List<string>>> rez = new List<List<List<string>>>();
                for (int i = 0; i < _LLLS.Count(); i++)
                    rez.Add(LLS(_LLLS[i]));
                return rez;
            }
        }
    }
}
