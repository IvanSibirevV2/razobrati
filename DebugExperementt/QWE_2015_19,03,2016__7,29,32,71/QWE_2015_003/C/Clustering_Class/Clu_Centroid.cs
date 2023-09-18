using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
namespace QWE_2015_003{
    public partial class Clustering{
        public static class Centroid{/// <summary>C.Comment("CCM - кластеризация центроидным методом_ClusteringCentroidsMethod"); (классика жанра, как есть, без костылей стимуляторов и ускорителей) </summary>
            public static List<List<List<string>>> GO_v1(List<List<string>> LLS, int n, string PLog)
            {
                string Log = PLog + ".C_C_G0";//,string PLog
                //C.Log.Go(PLog, "Clustering_Centroid_GO_v0");
                List<List<List<string>>> ClusterList = new List<List<List<string>>>();                
                for (int i = 1; i < LLS.Count(); i++) {
                    List<List<string>> L_LLS = new List<List<string>>();                         
                    List<string> L_LS_Title = new List<string>(); 
                    List<string> L_LS_Content = new List<string>(); 
                    for (int j = 0; j < LLS[0].Count(); j++) {
                        L_LS_Title.Add(LLS[0][j]); 
                        L_LS_Content.Add(LLS[i][j]); 
                    }
                    L_LLS.Add(L_LS_Title); 
                    L_LLS.Add(L_LS_Content);
                    L_LLS[0][0] = "C" + Convert.ToString(i); 
                    ClusterList.Add(L_LLS); 
                }
                if (n >= 2)
                    while (n < ClusterList.Count()){
                        string progress = " "+Convert.ToString(ClusterList.Count()) + "/" + Convert.ToString(n);
                        C.Log.Go(PLog, "Clustering_Centroid_GO_v0" + progress);
                        Double min = Math.Pow(10, 10); int min_i = 0; int min_j = 0;
                        for (int i = 0; i < ClusterList.Count(); i++) 
                            for (int j = 0; j < ClusterList.Count(); j++) if (i != j){
                                Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(ClusterList[i])[1], Clustering.ClusterCenter(ClusterList[j])[1]);
                                    if (min > dist){
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
                        for (int i = 1; i < ClusterList[min_i].Count(); i++) {
                            List<string> qeg = new List<string>();
                            for (int k = 0; k < ClusterList[min_i][i].Count(); k++) 
                                qeg.Add(ClusterList[min_i][i][k]); 
                            newLLS.Add(qeg); 
                        } 
                        for (int j = 1; j < ClusterList[min_j].Count(); j++) {
                            List<string> qeg = new List<string>(); 
                            for (int k = 0; k < ClusterList[min_j][j].Count(); k++) 
                                qeg.Add(ClusterList[min_j][j][k]); 
                            newLLS.Add(qeg); 
                        } 
                        if (min_i > min_j) 
                        {
                            ClusterList.RemoveAt(min_i); 
                            ClusterList.RemoveAt(min_j);
                        } else { 
                            ClusterList.RemoveAt(min_j);
                            ClusterList.RemoveAt(min_i);
                        }
                        ClusterList.Add(newLLS);
                    }
                return ClusterList;
            }


            public static List<List<List<string>>> GO_Viper(List<List<string>> LLS, int n, string PLog)
            {
                string Log = PLog + ".C_C_GV";//,string PLog//C.Log.Go(PLog, "Clustering_Centroid_GO_Viper");
                List<List<string>> distList = new List<List<string>>();{ List<string> d = new List<string>(); d.Add("DistList"); distList.Add(d); }                
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
                                Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(dfnkld)[1],Clustering.ClusterCenter(ClusterList[j-1])[1]);
                                g.Add(Convert.ToString(dist));
                            }
                            distList.Add(g);
                        }
                        distList[0].Add(dfnkld[0][0]);
                        for (int i = 1; i < distList.Count(); i++)
                        {
                            Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(dfnkld)[1],Clustering.ClusterCenter(ClusterList[i-1])[1]);
                            distList[i].Add(Convert.ToString(dist));
                        }
                    }
                    return new object();
                };
                
                Func<int, object> dist_AND_Cluster_ListRemoveAt = (int bh) =>
                {
                    ClusterList.RemoveAt(bh);
                    distList.RemoveAt(bh+1);
                    foreach (List<string> hgjsa in distList)hgjsa.RemoveAt(bh+1);
                    return new object();
                };
                
                for (int i = 1; i < LLS.Count(); i++){
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
                if (n >= 2)
                    while (n < ClusterList.Count())
                    {
                        string progress = " " + Convert.ToString(ClusterList.Count()) + "/" + Convert.ToString(n); C.Log.Go(PLog, "Clustering_Centroid_GO_Viper" + progress);

                        Double min = Math.Pow(10, 10); int min_i = 0; int min_j = 0;
                        for (int i = 0; i < ClusterList.Count(); i++)
                            for (int j = 0; j < ClusterList.Count(); j++) 
                                if (i != j)
                                {
                                    Double dist = Convert.ToDouble(distList[i+1][j+1]);
                                    if (min > dist){
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
                return ClusterList;
            }

            private static void QWE(){}
        }
    }
}