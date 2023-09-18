using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    public partial class DCN
    {
        /// <summary>Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber;Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;</summary>
        public static Double DetermineClustersNumber_WardMethod(List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE, string PLog)
        {
            string Log = PLog + ".RSD_DCN_WM";//,string PLog
            C.Log.Go(PLog, "RSD_DetermineClustersNumber_WardMethod");
            int rez = ID_PRNaNE.Count();
            for (rez = ID_PRNaNE.Count(); rez >= 2; rez--)
            {
                List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Ward.GO_v0(ID_PRNaNE, rez, Log);
                Boolean f_razb = true;
                foreach (List<List<string>> LS in LocalVariable_CCM_v0)
                {
                    Boolean f_clust = false;
                    for (int j = 1; j < LS[0].Count(); j++)
                    {
                        Boolean f_param = false;
                        for (int i = 1; i < LS.Count(); i++)
                        {
                            Boolean f_ank = true;
                            for (int k = 0; k < ID_GLNaNE.Count(); k++) if (LS[i][0] == ID_GLNaNE[k][0]) if (LS[0][j] == ID_GLNaNE[k][1]) { f_ank = false; }
                            if (f_ank) { f_param = true; break; }
                        } if (f_param) { f_clust = true; } else { f_clust = false; break; }
                    } if (f_clust) { f_razb = true; } else { f_razb = false; break; }
                } if (f_razb) { break; }
            } return ++rez;
        }
    }
}
