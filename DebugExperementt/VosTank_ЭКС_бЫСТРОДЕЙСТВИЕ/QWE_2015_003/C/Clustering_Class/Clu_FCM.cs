using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public partial class Clustering{
        public static class FCM{
            private static List<List<string>> Gen_L_U(List<List<List<string>>> L_LLLS)
            {
                List<List<string>> L_U = new List<List<string>>();//Генерация L_U
                List<string> ClusterNameList = new List<string>();
                List<string> AnkNameList = new List<string>();
                ClusterNameList.Add("FCM");
                foreach (List<List<string>> L_LLS in L_LLLS){
                    ClusterNameList.Add(Convert.ToString(L_LLS[0][0]));
                    for (int i = 1; i < L_LLS.Count(); i++)
                        AnkNameList.Add(Convert.ToString(L_LLS[i][0]));
                }
                L_U.Add(ClusterNameList);
                for (int y = 0; y < AnkNameList.Count(); y++){
                    List<string> newqwe = new List<string>();
                    newqwe.Add(AnkNameList[y]);
                    for (int i = 1; i < ClusterNameList.Count(); i++){
                        Boolean qwe = false;
                        for (int j = 0; j < L_LLLS.Count; j++)
                            if (L_LLLS[j][0][0] == ClusterNameList[i])
                                for (int k = 1; k < L_LLLS[j].Count(); k++)
                                    if (L_LLLS[j][k][0] == AnkNameList[y])
                                        qwe = true;
                        if (qwe){newqwe.Add("1");}else{newqwe.Add("0");}
                    }
                    L_U.Add(newqwe);
                }
                return L_U;
            }
            private static List<List<string>> Gen_L_C(List<List<List<string>>> L_LLLS)
            {
                List<List<string>> L_C = new List<List<string>>(); 
                List<List<string>> L_CC = new List<List<string>>();
                L_CC.Add(L_LLLS[0][0]);
                for (int i = 0; i < L_LLLS.Count(); i++){
                    List<List<string>> centr = Clustering.ClusterCenter(L_LLLS[i]);
                    centr[1][0] = L_LLLS[i][0][0];
                    L_CC.Add(centr[1]);
                }
                foreach (List<string> rgb in L_CC){
                    List<string> qdr = new List<string>();
                    foreach (string v in rgb)
                        qdr.Add(v);
                    L_C.Add(qdr);
                }
                L_C[0][0] = "Centr";
                return L_C; 
            }
            private static List<List<string>> Gen_L_X(List<List<List<string>>> L_LLLS)
            {
                List<List<string>> L_X = new List<List<string>>();     
                L_X.Add(new List<string>());
                for (int i = 0; i < L_LLLS[0][0].Count(); i++)L_X[0].Add(L_LLLS[0][0][i]);
                foreach (List<List<string>> CL in L_LLLS)  
                    for (int i = 1; i < CL.Count(); i++) { 
                        List<string> asd = new List<string>(); 
                        foreach (string seg in CL[i])
                            asd.Add(seg); 
                        L_X.Add(asd); 
                    }
                return L_X;
            }
            /// <summary>FCM - метод нечёткой кластеризации. !!Внимание. Этот метод работает только в связке с обычным методом кластеризации. Один он не работает!! </summary>
            public static List<List<string>> GO_V000(List<List<List<string>>> L_LLLS, Double m, Double E, Log ThisLog)
            {
                ThisLog = ThisLog.NewLog("Clu.FCM.G", "Clustering.FCM.GO", true);
                int IterCounter = 1;
                Double RLAST = Math.Pow(10, 10);
                Double R = 0;
                Boolean FLAG = true;
                List<List<string>> L_U = FCM.Gen_L_U(L_LLLS);
                List<List<string>> L_C = FCM.Gen_L_C(L_LLLS);
                List<List<string>> L_X = FCM.Gen_L_X(L_LLLS);
                while (FLAG){
                    R = 0;
                    for (int ANK = 1; ANK < L_U.Count(); ANK++) 
                        for (int CLUST = 1; CLUST < L_C.Count(); CLUST++)
                            R = R + Math.Pow(Convert.ToDouble(L_U[ANK][CLUST]), m) * Clustering.DistanceCentClusterLS(L_X[ANK], L_C[CLUST]);
                    Double qwsd = Math.Abs(R - RLAST);
                    if (E > qwsd) FLAG = false;
                    string progress = ThisLog.FullName + " : " + Convert.ToString(qwsd) + "/" + Convert.ToString(E) + "  Iter № " + Convert.ToString(IterCounter);
                    ThisLog.DeLog(1);
                    C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                    RLAST = R;
                    {//пересчёт L_C >>
                        for (int K = 1; K < L_C.Count(); K++)
                            for (int P = 1; P < L_C[K].Count(); P++) {
                                Double ch = 0;
                                Double zn = 0;
                                for (int I = 1; I < L_X.Count; I++) {
                                    ch = ch + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m) * Convert.ToDouble(L_X[I][P]);
                                    zn = zn + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m);
                                } 
                                L_C[K][P] = Convert.ToString(ch / zn); 
                            }
                    }//пересчёт L_C <<
                    {//пересчёт L_U >>
                        for (int i = 1; i < L_U.Count(); i++) {
                            Boolean Bigflag = false;
                            int stopset = 0;
                            for (int j = 1; j < L_U[i].Count(); j++)
                                if (Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) == 0)
                                {
                                    Bigflag = true; 
                                    stopset = j; 
                                } 
                            if (Bigflag) {
                                for (int j = 1; j < L_U[i].Count(); j++) {
                                    if (j == stopset)L_U[i][j] = "1";
                                    if (j != stopset)L_U[i][j] = "0"; 
                                }
                            } else { 
                                for (int j = 1; j < L_U[i].Count(); j++) { 
                                    Double zn = 0; 
                                    for (int L = 1; L < L_C.Count(); L++)
                                        zn = zn + System.Math.Pow(Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) / Clustering.DistanceCentClusterLS(L_X[i], L_C[L]), 2 / (m - 1));
                                    L_U[i][j] = Convert.ToString((1 / zn)); 
                                }
                            }
                        }
                    }//пересчёт L_U <<
                    IterCounter++;
                }
                return L_U;
            }
            /// <summary>FCM - метод нечёткой кластеризации. !!Внимание. Этот метод работает только в связке с обычным методом кластеризации. Один он не работает!! </summary>
            public static List<List<string>> GO_Viper(List<List<List<string>>> L_LLLS, Double m, Double E, Log ThisLog)
            {
                ThisLog = ThisLog.NewLog("Clu.FCM.G", "Clustering.FCM.GO", true);
                int IterCounter = 1;
                Double RLAST = Math.Pow(10, 10);
                Double R = 0;
                Boolean FLAG = true;
                List<List<string>> L_U = FCM.Gen_L_U(L_LLLS);
                List<List<string>> L_C = FCM.Gen_L_C(L_LLLS);
                List<List<string>> L_X = FCM.Gen_L_X(L_LLLS);
                List<List<string>> distListLXLC = new List<List<string>>();
                {/*Генерация табли-ци или -цы,уже задолбался и запутался!!!*/ { /*Шапка*/ List<string> d = new List<string>(); d.Add("DistList"); for (int L_Cj = 1; L_Cj < L_C.Count; L_Cj++) d.Add(L_C[L_Cj][0]); distListLXLC.Add(d); } { /*Таблица генератор сама*/for (int i = 1; i < L_X.Count(); i++) { distListLXLC.Add(C.COPY.LS(distListLXLC[0])); distListLXLC[i][0] = L_X[i][0]; for (int j = 1; j < L_C.Count(); j++) distListLXLC[i][j] = Convert.ToString(Clustering.DistanceCentClusterLS(L_X[i], L_C[j])); } } }
                while (FLAG)
                {
                    R = 0;
                    for (int ANK = 1; ANK < L_U.Count(); ANK++)
                        for (int CLUST = 1; CLUST < L_C.Count(); CLUST++)
                            R = R + Math.Pow(Convert.ToDouble(L_U[ANK][CLUST]), m) * Convert.ToDouble(distListLXLC[ANK][CLUST]);
                            //R = R + Math.Pow(Convert.ToDouble(L_U[ANK][CLUST]), m) * Clustering.DistanceCentClusterLS(L_X[ANK], L_C[CLUST]);
                    Double qwsd = Math.Abs(R - RLAST);
                    if (E > qwsd) FLAG = false;
                    string progress = ThisLog.FullName + " : " + Convert.ToString(qwsd) + "/" + Convert.ToString(E) + "  Iter № " + Convert.ToString(IterCounter);
                    ThisLog.DeLog(1);
                    C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                    RLAST = R;
                    {//пересчёт L_C >>
                        for (int K = 1; K < L_C.Count(); K++)
                            for (int P = 1; P < L_C[K].Count(); P++)
                            {
                                Double ch = 0;
                                Double zn = 0;
                                for (int I = 1; I < L_X.Count; I++)
                                {
                                    ch = ch + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m) * Convert.ToDouble(L_X[I][P]);
                                    zn = zn + System.Math.Pow(Convert.ToDouble(L_U[I][K]), m);
                                }
                                L_C[K][P] = Convert.ToString(ch / zn);
                            }
                    }//пересчёт L_C <<
                    distListLXLC.Clear();
                    { /*Генерация табли-ци или -цы,уже задолбался и запутался!!!*/ { /*Шапка*/ List<string> d = new List<string>(); d.Add("DistList"); for (int L_Cj = 1; L_Cj < L_C.Count; L_Cj++) d.Add(L_C[L_Cj][0]); distListLXLC.Add(d); } { /*Таблица генератор сама*/for (int i = 1; i < L_X.Count(); i++) { distListLXLC.Add(C.COPY.LS(distListLXLC[0])); distListLXLC[i][0] = L_X[i][0]; for (int j = 1; j < L_C.Count(); j++) distListLXLC[i][j] = Convert.ToString(Clustering.DistanceCentClusterLS(L_X[i], L_C[j])); } } }
                    {//пересчёт L_U >>
                        for (int i = 1; i < L_U.Count(); i++)
                        {
                            Boolean Bigflag = false;
                            int stopset = 0;
                            for (int j = 1; j < L_U[i].Count(); j++)
                                if (Convert.ToDouble(distListLXLC[i][j]) == 0)
                                //if (Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) == 0)
                                {
                                    Bigflag = true;
                                    stopset = j;
                                }
                            if (Bigflag)
                            {
                                for (int j = 1; j < L_U[i].Count(); j++)
                                {
                                    if (j == stopset) L_U[i][j] = "1";
                                    if (j != stopset) L_U[i][j] = "0";
                                }
                            }
                            else
                            {
                                for (int j = 1; j < L_U[i].Count(); j++)
                                {
                                    Double zn = 0;
                                    for (int L = 1; L < L_C.Count(); L++)
                                        zn = zn + System.Math.Pow(Convert.ToDouble(distListLXLC[i][j]) / Convert.ToDouble(distListLXLC[i][L]), 2 / (m - 1));
                                        //zn = zn + System.Math.Pow(Clustering.DistanceCentClusterLS(L_X[i], L_C[j]) / Clustering.DistanceCentClusterLS(L_X[i], L_C[L]), 2 / (m - 1));
                                    L_U[i][j] = Convert.ToString((1 / zn));
                                }
                            }
                        }
                    }//пересчёт L_U <<
                    IterCounter++;
                }
                return L_U;
            }
        }
    }
}