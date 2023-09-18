using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    /// <summary>Clustering</summary>/// <summary>Clustering.</summary>
    public partial class Clustering{       
        /// <summary> Получение центра кластера </summary>
        public static List<List<string>> ClusterCenter(List<List<string>> L_LLS)
        {
            List<List<string>> rez = new List<List<string>>();
            {
                List<string> LS0 = new List<string>();
                List<string> LS1 = new List<string>();
                for (int i = 0; i < L_LLS[0].Count(); i++)
                {
                    string s = L_LLS[0][i];
                    LS0.Add(s);
                    s = L_LLS[1][i];
                    LS1.Add(s);
                }
                for (int j = 1; j < LS1.Count(); j++) LS1[j] = "0";
                rez.Add(LS0);
                rez.Add(LS1);
            }
            for (int i = 1; i < L_LLS.Count(); i++) for (int j = 1; j < L_LLS[i].Count(); j++) rez[1][j] = Convert.ToString(Convert.ToDouble(rez[1][j]) + Convert.ToDouble(L_LLS[i][j]));
            for (int j = 1; j < rez[1].Count(); j++) rez[1][j] = Convert.ToString(Convert.ToDouble(rez[1][j]) / (L_LLS.Count() - 1));
            return rez;
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary> Получение расстояния между двумя точками (передаются обычно координаты центров кластера) </summary>
        public static Double DistanceCentClusterLS(List<string> CentClusterA, List<string> CentClusterB)
        {
            List<string> CCA = CentClusterA;
            List<string> CCB = CentClusterB;
            Double rez = 0;
            for (int i = 1; i < CCA.Count(); i++) rez = rez + System.Math.Pow(Convert.ToDouble(CCA[i]) - Convert.ToDouble(CCB[i]), 2);
            return System.Math.Sqrt(rez);
        }
        /*----------------------------------------------------------------------------------------*/
    }
}
