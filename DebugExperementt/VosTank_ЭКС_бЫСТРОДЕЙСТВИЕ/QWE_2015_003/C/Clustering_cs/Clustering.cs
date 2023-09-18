using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    /// <summary>Clustering</summary>
    /// <summary>Clustering.</summary>
    public static class Clustering
    {
        /// <summary> Получение центра кластера </summary>
        public static List<List<string>> ClusterCenter (List<List<string>> L_LLS)
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
        private static Double DistanceCentClusterLS (List<string> CentClusterA, List<string> CentClusterB)
        {
            List<string> CCA = CentClusterA;
            List<string> CCB = CentClusterB;
            Double rez = 0;
            for (int i = 1; i < CCA.Count(); i++) rez = rez + System.Math.Pow(Convert.ToDouble(CCA[i]) - Convert.ToDouble(CCB[i]), 2);
            return System.Math.Sqrt(rez);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>C.Comment("CCM - кластеризация центроидным методом_ClusteringCentroidsMethod"); (классика жанра, как есть, без костылей стимуляторов и ускорителей) </summary>
        public static List<List<List<string>>> ClusteringCentroidsMethod_v0(List<List<string>> LLS, int n)
        {            
            List<List<List<string>>> ClusterList = new List<List<List<string>>>();
            {/*go=>*/for (int i = 1; i < LLS.Count(); i++) { List<List<string>> L_LLS = new List<List<string>>(); { List<string> L_LS_Title = new List<string>(); List<string> L_LS_Content = new List<string>(); for (int j = 0; j < LLS[0].Count(); j++) { L_LS_Title.Add(LLS[0][j]); L_LS_Content.Add(LLS[i][j]); } L_LLS.Add(L_LS_Title); L_LLS.Add(L_LS_Content); } L_LLS[0][0] = "C" + Convert.ToString(i); ClusterList.Add(L_LLS); } }
            if (n >= 2)while (n < ClusterList.Count()){
                C.WL.Cyan("ClusteringWardMethod_v0 " + Convert.ToString(ClusterList.Count()) + "/" + Convert.ToString(n)); C.WL.n();
                Double min = Math.Pow(10, 10);int min_i = 0;int min_j = 0;
                    for (int i = 0; i < ClusterList.Count(); i++)for (int j = 0; j < ClusterList.Count(); j++)if (i != j){
                                Double dist = Clustering.DistanceCentClusterLS(Clustering.ClusterCenter(ClusterList[i])[1], Clustering.ClusterCenter(ClusterList[j])[1]);
                                if (min > dist){min = dist;min_i = i;min_j = j;}
                            }
                    {/*go=>*/List<List<string>> newLLS = new List<List<string>>();{/*go=>*/List<string> qe = new List<string>();for (int j = 0; j < ClusterList[min_i][0].Count(); j++) qe.Add(ClusterList[min_i][0][j]);newLLS.Add(qe);for (int i = 1; i < ClusterList[min_i].Count(); i++){List<string> qeg = new List<string>();for (int k = 0; k < ClusterList[min_i][i].Count(); k++) qeg.Add(ClusterList[min_i][i][k]);newLLS.Add(qeg);}for (int j = 1; j < ClusterList[min_j].Count(); j++){List<string> qeg = new List<string>();for (int k = 0; k < ClusterList[min_j][j].Count(); k++) qeg.Add(ClusterList[min_j][j][k]);newLLS.Add(qeg);}if (min_i > min_j){ClusterList.RemoveAt(min_i);ClusterList.RemoveAt(min_j);}else{ClusterList.RemoveAt(min_j);ClusterList.RemoveAt(min_i);}}ClusterList.Add(newLLS);}
            }
            return ClusterList;
        }
        /// <summary>кластеризация метод Варда;Прикольно описано на сайте:http://www.myshared.ru/slide/214831/;Xijk - значение k- переменной в j - наблюдении, принадлежащему  i - кластеру.;ошибка суммы квадратов - ESS = sum(j,sum(j,sum(k,sqr(abs(Xijk - X_СРi.k))))); общая сумма квадратов  - TSS = sum(i,sum(j,sum(k,sqr(abs(Xijk - X_СР..k)))));R- квадрат r2 = ( TSS - ESS ) / TSS;минимизация значения r2;/// </summary>
        public static List<List<List<string>>> ClusteringWardMethod_v0(List<List<string>> LLS, int n)
        {
            Func<List<List<List<string>>>, Double> TTS = (List<List<List<string>>> _LLS) => {Double SUMM = 0; for (int k = 1; k < _LLS[0][0].Count(); k++) {Double X_СР__k = 0; int e = 0; for (int i = 0; i < _LLS.Count(); i++)for (int j = 1; j < _LLS[i].Count(); j++) {X_СР__k += Convert.ToDouble(_LLS[i][j][k]);e++;}X_СР__k = X_СР__k / e;for (int i = 0; i < _LLS.Count(); i++) for (int j = 1; j < _LLS[i].Count(); j++) SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СР__k), 2);} return SUMM; }; 
            Func<List<List<List<string>>>, Double> ESS = (List<List<List<string>>> _LLS) => {Double SUMM = 0;for (int k = 1; k < _LLS[0][0].Count(); k++){ for (int i = 0; i < _LLS.Count(); i++) {Double X_СРi_k = 0; int e = 0; for (int j = 1; j < _LLS[i].Count(); j++) {X_СРi_k += Convert.ToDouble(_LLS[i][j][k]); e++; }X_СРi_k = X_СРi_k / e; for (int j = 1; j < _LLS[i].Count(); j++)SUMM += Math.Pow(Math.Abs(Convert.ToDouble(_LLS[i][j][k]) - X_СРi_k), 2); }} return SUMM;};
            Func<List<List<List<string>>>, int, int, int, Double> r = (List<List<List<string>>> __LLS, int _min_i, int _min_j, int _n) => { List<List<List<string>>> _LLS = C.COPY.LLLS(__LLS); List<List<string>> newLLS = new List<List<string>>(); { List<string> qeg = new List<string>(); for (int j = 0; j < _LLS[_min_i][0].Count(); j++) { string gsdf = _LLS[_min_i][0][j]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int i = 1; i < _LLS[_min_i].Count(); i++) { List<string> qeg = new List<string>(); for (int k = 0; k < _LLS[_min_i][i].Count(); k++) { string gsdf = _LLS[_min_i][i][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } for (int j = 1; j < _LLS[_min_j].Count(); j++) { List<string> qeg = new List<string>(); for (int k = 0; k < _LLS[_min_j][j].Count(); k++) { string gsdf = _LLS[_min_j][j][k]; qeg.Add(gsdf); } newLLS.Add(qeg); } if (_min_i > _min_j) { _LLS.RemoveAt(_min_i); _LLS.RemoveAt(_min_j); } else { _LLS.RemoveAt(_min_j); _LLS.RemoveAt(_min_i); } _LLS.Add(newLLS); return Math.Pow((TTS(_LLS) - ESS(_LLS)) / TTS(_LLS), 2); };
            /*---------------------------------*/
            List<List<List<string>>> ClusterList = new List<List<List<string>>>(); 
            {/*go=>*/for (int i = 1; i < LLS.Count(); i++){ List<List<string>> L_LLS = new List<List<string>>(); {List<string> L_LS_Title = new List<string>(); List<string> L_LS_Content = new List<string>();for (int j = 0; j < LLS[0].Count(); j++) {L_LS_Title.Add(LLS[0][j]); L_LS_Content.Add(LLS[i][j]); }L_LLS.Add(L_LS_Title); L_LLS.Add(L_LS_Content);}L_LLS[0][0] = "C" + Convert.ToString(i);ClusterList.Add(L_LLS); }}
            if (n >= 2) while (n < ClusterList.Count()) {
                C.WL.Cyan("ClusteringWardMethod_v0 " + Convert.ToString(ClusterList.Count()) + "/" + Convert.ToString(n)); C.WL.n();
                Double min = Math.Pow(10, 10);int min_i = 0;int min_j = 0;
                    for (int i = 0; i < ClusterList.Count(); i++)for (int j = 0; j < ClusterList.Count(); j++)if (i != j){ 
                                Double dist = r(ClusterList, i, j, ClusterList.Count()); 
                                if (min > dist){min = dist;min_i = i;min_j = j;} 
                            }
                    {/*go=>*/List<List<string>> newLLS = new List<List<string>>();{/*go=>*/List<string> qeg = new List<string>(); for (int j = 0; j < ClusterList[min_i][0].Count(); j++){ string gsdf = ClusterList[min_i][0][j]; qeg.Add(gsdf); } newLLS.Add(qeg); }for (int i = 1; i < ClusterList[min_i].Count(); i++) {List<string> qeg = new List<string>(); for (int k = 0; k < ClusterList[min_i][i].Count(); k++) {string gsdf = ClusterList[min_i][i][k];qeg.Add(gsdf);}newLLS.Add(qeg);}for (int j = 1; j < ClusterList[min_j].Count(); j++) {List<string> qeg = new List<string>();for (int k = 0; k < ClusterList[min_j][j].Count(); k++) {string gsdf = ClusterList[min_j][j][k];qeg.Add(gsdf); }newLLS.Add(qeg); }if (min_i > min_j) {ClusterList.RemoveAt(min_i); ClusterList.RemoveAt(min_j); } else{ ClusterList.RemoveAt(min_j); ClusterList.RemoveAt(min_i); }ClusterList.Add(newLLS);}
                }
            return ClusterList;
        }        
        /// <summary>FCM - метод нечёткой кластеризации. !!Внимание. Этот метод работает только в связке с обычным методом кластеризации. Один он не работает!! </summary>
        public static List<List<string>> FCM(List<List<List<string>>> L_LLLS, Double m, Double E)
        {            
            Double RLAST = Math.Pow(10, 10); Double R = 0; Boolean FLAG = true; 
            List<List<string>> L_U = new List<List<string>>(); {/*GO=>*/C.Comment("Генерация L_U"); List<string> ClusterNameList = new List<string>(); List<string> AnkNameList = new List<string>(); ClusterNameList.Add("FCM"); foreach (List<List<string>> L_LLS in L_LLLS) {ClusterNameList.Add(Convert.ToString(L_LLS[0][0])); for (int i = 1; i < L_LLS.Count(); i++)AnkNameList.Add(Convert.ToString(L_LLS[i][0])); }L_U.Add(ClusterNameList); for (int y = 0; y < AnkNameList.Count(); y++) {List<string> newqwe = new List<string>();newqwe.Add(AnkNameList[y]);for (int i = 1; i < ClusterNameList.Count(); i++){Boolean qwe = false;for (int j = 0; j < L_LLLS.Count; j++)if (L_LLLS[j][0][0] == ClusterNameList[i])for (int k = 1; k < L_LLLS[j].Count(); k++)if (L_LLLS[j][k][0] == AnkNameList[y])qwe = true;if (qwe){ newqwe.Add("1"); }else{ newqwe.Add("0"); }}L_U.Add(newqwe);}}
            List<List<string>> L_C = new List<List<string>>();{/*GO=>*/C.Comment("Генерация L_C");List<List<string>> L_CC = new List<List<string>>();L_CC.Add(L_LLLS[0][0]);for (int i = 0; i < L_LLLS.Count(); i++){ List<List<string>> centr = Clustering.ClusterCenter(L_LLLS[i]); centr[1][0] = L_LLLS[i][0][0];L_CC.Add(centr[1]);} foreach (List<string> rgb in L_CC) {List<string> qdr = new List<string>(); foreach (string v in rgb)qdr.Add(v);L_C.Add(qdr);} L_C[0][0] = "Centr";} 
            List<List<string>> L_X = new List<List<string>>(); {/*go=>*/C.Comment("Генерация L_X");L_X.Add(new List<string>());for (int i = 0; i < L_LLLS[0][0].Count(); i++)L_X[0].Add(L_LLLS[0][0][i]);foreach (List<List<string>> CL in L_LLLS) {for (int i = 1; i < CL.Count(); i++) {List<string> asd = new List<string>(); foreach (string seg in CL[i])asd.Add(seg);L_X.Add(asd); }}}
            while (FLAG) {R = 0; 
                for (int ANK = 1; ANK < L_U.Count(); ANK++)for (int CLUST = 1; CLUST < L_C.Count(); CLUST++)R= R + Math.Pow(Convert.ToDouble(L_U[ANK][CLUST]), m) * Clustering.DistanceCentClusterLS(L_X[ANK], L_C[CLUST]);
                Double qwsd = Math.Abs(R - RLAST);if (E > qwsd)FLAG = false;RLAST = R;
                {/*go=>*/C.Comment("пересчёт L_C");for (int K = 1; K < L_C.Count(); K++)for (int P = 1; P < L_C[K].Count(); P++) {Double ch = 0;Double zn = 0;for (int I = 1; I < L_X.Count; I++){ch = ch + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m) * Convert.ToDouble(L_X[I][P]);zn = zn + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m);}L_C[K][P] = Convert.ToString(ch / zn);}}
                {/*go=>*/C.Comment("пересчёт L_U"); for (int i = 1; i < L_U.Count(); i++) {Boolean Bigflag = false;int stopset = 0;for (int j = 1; j < L_U[i].Count(); j++)if (Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) == 0) {Bigflag = true; stopset = j; }if (Bigflag) {for (int j = 1; j < L_U[i].Count(); j++) {if (j == stopset)L_U[i][j] = "1";if (j != stopset)L_U[i][j] = "0"; }}else {for (int j = 1; j < L_U[i].Count(); j++) {Double zn = 0;for (int L = 1; L < L_C.Count(); L++)zn = zn + System.Math.Pow(Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) / Clustering.DistanceCentClusterLS(L_X[i], L_C[L]), 2 / (m - 1)); L_U[i][j] = Convert.ToString((1 / zn)); }}}}
            }
            return L_U;
        }
    }
}
