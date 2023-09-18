using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    public partial class DetermineClustersNumber
    {
        /// <summary>Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber; Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements; </summary>
        public static Double CentroidsMethod_GO_v1(List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("DCN.CM","DetermineClustersNumber.CentroidsMethod", true);
            C.Comment("Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber");
            C.Comment("Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;");
            int rez = ID_PRNaNE.Count();
            for (rez = ID_PRNaNE.Count(); rez >= 2; rez--)
            {
                List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_v1(ID_PRNaNE, rez, ThisLog);
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
                } if (f_razb) { break; } else { ThisLog.DeLog(2); }
            } return ++rez;
        }
        /// <summary>Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber; Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements; </summary>
        public static Double CentroidsMethod_GO_Viper(List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("DCN.CM_V", "DetermineClustersNumber.CentroidsMethod_GO_Viper", true);
            C.Comment("Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber");
            C.Comment("Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;");
            int rez = ID_PRNaNE.Count();
            for (rez = ID_PRNaNE.Count(); rez >= 2; rez--)
            {
                List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_Viper(ID_PRNaNE, rez, ThisLog);
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
                } if (f_razb) { break; }else{ThisLog.DeLog(2);}
            } return ++rez;
        }

        /// <summary>Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber; Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements; </summary>
        public static Double DetermineClustersNumber_CentroidsMethod_Viper(List<List<string>> ID_GLNaNE, List<List<string>> ID_PRNaNE)
        {
            C.Comment("Определяем количество кластеров - determine the number of clusters - DetermineClustersNumber");
            C.Comment("Коментарии к входным данным:ID_GLNaNE - InputData_GetListNaNElements;ID_PRNaNE - InputData_PrimaryReplenishmentNaNElements;");
            int rez = 0;
            {
                List<List<string>> LLS = C.COPY.LLS(ID_PRNaNE);
                List<List<string>> distList = new List<List<string>>(); { List<string> d = new List<string>(); d.Add("DistList"); distList.Add(d); }
                List<List<List<string>>> ClusterList = new List<List<List<string>>>();
                Func<List<List<string>>, object> dist_AND_Cluster_ListAdd = (List<List<string>> dfnkld) =>
                {
                    ClusterList.Add(dfnkld);
                    {
                        List<string> g = new List<string>();
                        {
                            g.Add(dfnkld[0][0]);
                            for (int j = 1; j < distList[0].Count(); j++)
                            {
                                Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(dfnkld)[1], Clustering.ClusterCenter(ClusterList[j - 1])[1]);
                                g.Add(Convert.ToString(dist));
                            }
                            distList.Add(g);
                        }
                        distList[0].Add(dfnkld[0][0]);
                        for (int i = 1; i < distList.Count(); i++)
                        {
                            Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(dfnkld)[1], Clustering.ClusterCenter(ClusterList[i - 1])[1]);
                            distList[i].Add(Convert.ToString(dist));
                        }
                    }
                    return new object();
                };
                Func<int, object> dist_AND_Cluster_ListRemoveAt = (int bh) =>
                {
                    ClusterList.RemoveAt(bh);
                    distList.RemoveAt(bh + 1);
                    foreach (List<string> hgjsa in distList) hgjsa.RemoveAt(bh + 1);
                    return new object();
                };
                for (int i = 1; i < LLS.Count(); i++)
                {
                    List<List<string>> L_LLS = new List<List<string>>();
                    List<string> L_LS_Title = new List<string>();
                    List<string> L_LS_Content = new List<string>();
                    for (int j = 0; j < LLS[0].Count(); j++)
                    {
                        L_LS_Title.Add(LLS[0][j]);
                        L_LS_Content.Add(LLS[i][j]);
                    }
                    L_LLS.Add(L_LS_Title);
                    L_LLS.Add(L_LS_Content);
                    L_LLS[0][0] = "C" + Convert.ToString(i);
                    dist_AND_Cluster_ListAdd(L_LLS);
                }
                while (2 < ClusterList.Count())
                {
                    rez = ClusterList.Count();
                    Boolean f_razb = true; foreach (List<List<string>> LS in ClusterList/*LocalVariable_CCM_v0*/)
                    {
                        Boolean f_clust = false; for (int j = 1; j < LS[0].Count(); j++)
                        {
                            Boolean f_param = false; for (int i = 1; i < LS.Count(); i++)
                            {
                                Boolean f_ank = true;
                                for (int k = 0; k < ID_GLNaNE.Count(); k++) if (LS[i][0] == ID_GLNaNE[k][0]) if (LS[0][j] == ID_GLNaNE[k][1]) { f_ank = false; }
                                if (f_ank) { f_param = true; break; }//I_breakER
                            } if (f_param) { f_clust = true; } else { f_clust = false; break; }//J_breakER
                        } if (f_clust) { f_razb = true; } else { f_razb = false; break; }//LS_breakER
                    } if (f_razb) { break; }//WHILE_breakER

                    string progress = " " + Convert.ToString(ClusterList.Count()) + "/?";

                    Double min = Math.Pow(10, 10); int min_i = 0; int min_j = 0;
                    for (int i = 0; i < ClusterList.Count(); i++)
                        for (int j = 0; j < ClusterList.Count(); j++)
                            if (i != j)
                            {
                                Double dist = Convert.ToDouble(distList[i + 1][j + 1]);
                                if (min > dist)
                                {
                                    min = dist;
                                    min_i = i;
                                    min_j = j;
                                }
                            }
                    List<List<string>> newLLS = new List<List<string>>();
                    List<string> qe = new List<string>();
                    for (int j = 0; j < ClusterList[min_i][0].Count(); j++)
                        qe.Add(ClusterList[min_i][0][j]);
                    newLLS.Add(qe);
                    for (int i = 1; i < ClusterList[min_i].Count(); i++)
                    {
                        List<string> qeg = new List<string>();
                        for (int k = 0; k < ClusterList[min_i][i].Count(); k++)
                            qeg.Add(ClusterList[min_i][i][k]);
                        newLLS.Add(qeg);
                    }
                    for (int j = 1; j < ClusterList[min_j].Count(); j++)
                    {
                        List<string> qeg = new List<string>();
                        for (int k = 0; k < ClusterList[min_j][j].Count(); k++)
                            qeg.Add(ClusterList[min_j][j][k]);
                        newLLS.Add(qeg);
                    }
                    if (min_i > min_j)
                    {
                        dist_AND_Cluster_ListRemoveAt(min_i);
                        dist_AND_Cluster_ListRemoveAt(min_j);
                    }
                    else
                    {
                        dist_AND_Cluster_ListRemoveAt(min_j);
                        dist_AND_Cluster_ListRemoveAt(min_i);
                    }
                    dist_AND_Cluster_ListAdd(newLLS);
                }
            }
            return ++rez;
        }
    }
}
