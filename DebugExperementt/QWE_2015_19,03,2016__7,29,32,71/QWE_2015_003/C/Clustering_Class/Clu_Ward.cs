using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class Clustering{
        public static class Ward{
            private static Double TTS(List<List<List<string>>> _LLS, string PLog)
            {
                string Log = PLog + ".C_W_TTS";//,string PLog
                //C.Log.Go(PLog, "Clustering_Ward_TTS");
                Double SUMM = 0;
                for (int k = 1; k < _LLS[0][0].Count(); k++){
                    Double X_СР__k = 0;
                    int e = 0;
                    for (int i = 0; i < _LLS.Count(); i++)
                        for (int j = 1; j < _LLS[i].Count(); j++){
                            X_СР__k += Convert.ToDouble(_LLS[i][j][k]);
                            e++;
                        }
                    X_СР__k = X_СР__k / e;
                    for (int i = 0; i < _LLS.Count(); i++)
                        for (int j = 1; j < _LLS[i].Count(); j++)
                            SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СР__k), 2);
                }
                return SUMM;
            }
            private static Double ESS(List<List<List<string>>> _LLS, string PLog)
            {
                string Log = PLog + ".C_W_ESS";//,string PLog
                //C.Log.Go(PLog, "Clustering_Ward_ESS");
                Double SUMM = 0;
                for (int k = 1; k < _LLS[0][0].Count(); k++){
                    for (int i = 0; i < _LLS.Count(); i++){
                        Double X_СРi_k = 0;
                        int e = 0;
                        for (int j = 1; j < _LLS[i].Count(); j++){
                            X_СРi_k += Convert.ToDouble(_LLS[i][j][k]);
                            e++;
                        }
                        X_СРi_k = X_СРi_k / e;
                        for (int j = 1; j < _LLS[i].Count(); j++)
                            SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СРi_k), 2);
                    }
                }
                return SUMM;
            }
            private static Double r(List<List<List<string>>> __LLS, int _min_i, int _min_j, int _n, string PLog)
            {
                string Log = PLog + ".C_W_r";//,string PLog
                //C.Log.Go(PLog, "Clustering_Ward_r");
                List<List<List<string>>> _LLS = C.COPY.LLLS(__LLS);
                List<List<string>> newLLS = new List<List<string>>();
                {
                    List<string> qeg = new List<string>();
                    for (int j = 0; j < _LLS[_min_i][0].Count(); j++) {
                        string gsdf = _LLS[_min_i][0][j];
                        qeg.Add(gsdf);
                    } 
                    newLLS.Add(qeg);
                }
                for (int i = 1; i < _LLS[_min_i].Count(); i++) {
                    List<string> qeg = new List<string>();
                    for (int k = 0; k < _LLS[_min_i][i].Count(); k++) {
                        string gsdf = _LLS[_min_i][i][k];
                        qeg.Add(gsdf);
                    }
                    newLLS.Add(qeg);
                }
                for (int j = 1; j < _LLS[_min_j].Count(); j++) {
                    List<string> qeg = new List<string>();
                    for (int k = 0; k < _LLS[_min_j][j].Count(); k++) {
                        string gsdf = _LLS[_min_j][j][k];
                        qeg.Add(gsdf);
                    }
                    newLLS.Add(qeg); 
                }
                if (_min_i > _min_j) {
                    _LLS.RemoveAt(_min_i);
                    _LLS.RemoveAt(_min_j);
                }else {
                    _LLS.RemoveAt(_min_j);
                    _LLS.RemoveAt(_min_i);
                }
                _LLS.Add(newLLS);
                return Math.Pow((TTS(_LLS, Log) - ESS(_LLS, Log)) / TTS(_LLS, Log), 2); 
            }            
            /// <summary>кластеризация метод Варда;Прикольно описано на сайте:http://www.myshared.ru/slide/214831/;Xijk - значение k- переменной в j - наблюдении, принадлежащему  i - кластеру.;ошибка суммы квадратов - ESS = sum(j,sum(j,sum(k,sqr(abs(Xijk - X_СРi.k))))); общая сумма квадратов  - TSS = sum(i,sum(j,sum(k,sqr(abs(Xijk - X_СР..k)))));R- квадрат r2 = ( TSS - ESS ) / TSS;минимизация значения r2;/// </summary>
            public static List<List<List<string>>> GO_v0(List<List<string>> LLS, int n, string PLog)
            {
                string Log = PLog + ".C_W_G0";//,string PLog
                C.Log.Go(PLog, "Clustering_Ward_GO_v0");
                List<List<List<string>>> ClusterList = new List<List<List<string>>>();
                { /*go=>*/
                    for (int i = 1; i < LLS.Count(); i++) {
                        List<List<string>> L_LLS = new List<List<string>>(); 
                        {
                            List<string> L_LS_Title = new List<string>();
                            List<string> L_LS_Content = new List<string>();
                            for (int j = 0; j < LLS[0].Count(); j++) {
                                L_LS_Title.Add(LLS[0][j]);
                                L_LS_Content.Add(LLS[i][j]);
                            }
                            L_LLS.Add(L_LS_Title);
                            L_LLS.Add(L_LS_Content);
                        }
                        L_LLS[0][0] = "C" + Convert.ToString(i);
                        ClusterList.Add(L_LLS);
                    }
                }
                if (n >= 2) 
                    while (n < ClusterList.Count())
                    {
                        string progress = " " + Convert.ToString(ClusterList.Count()) + "/" + Convert.ToString(n) +" ";
                        C.Log.Go(PLog, "Clustering_Ward_GO_v0" + progress);
                        Double min = Math.Pow(10, 10);
                        int min_i = 0;
                        int min_j = 0;
                        for (int i = 0; i < ClusterList.Count(); i++) 
                            for (int j = 0; j < ClusterList.Count(); j++) if (i != j){
                                Double dist = r(ClusterList, i, j, ClusterList.Count(), Log + progress);
                                    if (min > dist) { 
                                        min = dist; 
                                        min_i = i; 
                                        min_j = j;
                                    }
                                }
                        { /*go=>*/
                            List<List<string>> newLLS = new List<List<string>>(); 
                            { /*go=>*/
                                List<string> qeg = new List<string>(); 
                                for (int j = 0; j < ClusterList[min_i][0].Count(); j++) {
                                    string gsdf = ClusterList[min_i][0][j];
                                    qeg.Add(gsdf); 
                                } 
                                newLLS.Add(qeg);
                            } 
                            for (int i = 1; i < ClusterList[min_i].Count(); i++) {
                                List<string> qeg = new List<string>();
                                for (int k = 0; k < ClusterList[min_i][i].Count(); k++){
                                    string gsdf = ClusterList[min_i][i][k];
                                    qeg.Add(gsdf);
                                }
                                newLLS.Add(qeg);
                            }
                            for (int j = 1; j < ClusterList[min_j].Count(); j++) {
                                List<string> qeg = new List<string>();
                                for (int k = 0; k < ClusterList[min_j][j].Count(); k++) {
                                    string gsdf = ClusterList[min_j][j][k]; 
                                    qeg.Add(gsdf);
                                }
                                newLLS.Add(qeg);
                            }
                            if (min_i > min_j) {
                                ClusterList.RemoveAt(min_i); 
                                ClusterList.RemoveAt(min_j); 
                            } else { 
                                ClusterList.RemoveAt(min_j);
                                ClusterList.RemoveAt(min_i);
                            } 
                            ClusterList.Add(newLLS); 
                        }
                    }
                return ClusterList;
            }
        }
    }
}
