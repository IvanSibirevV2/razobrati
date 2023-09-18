using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QWE_2015_003
{
    /// <summary>RestoreSkipedData</summary>
    /// <summary>RSD.</summary>
    public partial class RSD
    {
        //Func<List<List<string>>, List<List<List<string>>>, List<List<string>>, List<List<string>>, List<List<string>>> RestoreSkipedData = (List<List<string>> __LV_PRNaNE, List<List<List<string>>> __LLLS, List<List<string>> __LLS_FCM, List<List<string>> __LocalVariable_GLNaNE) =>
        /// <summary>Алгоритм восстановления данных.; Отработка итерации. (RSD - Restore Skiped Data);</summary>        
        private static List<List<string>> RestoreSkipedData_1turn(List<List<string>> __LV_PRNaNE, List<List<List<string>>> __LLLS, List<List<string>> __LLS_FCM, List<List<string>> __LocalVariable_GLNaNE, string PLog)
        {
            string Log = PLog + ".RSD_RSD1t";//,string PLog
            C.Log.Go(PLog, "RSD_RestoreSkipedData_1turn");
            //Алгоритм восстановления данных.//Отработка итерации. (RSD - Restore Skiped Data)//методы получения значений соответствующих таблиц по названиям анкет и параметров.
            List<List<string>> _LV_PRNaNE = C.COPY.LLS(__LV_PRNaNE);
            List<List<List<string>>> _LLLS = C.COPY.LLLS(__LLLS);
            List<List<string>> _LLS_FCM = C.COPY.LLS(__LLS_FCM);
            List<List<string>> _LV_GLNaNE = C.COPY.LLS(__LocalVariable_GLNaNE);
            Func<string, string, string> _LV_PRNaNE_Get = (string Ank, string Param) => { for (int i = 0; i < _LV_PRNaNE.Count(); i++) if (_LV_PRNaNE[i][0] == Ank)for (int j = 0; j < _LV_PRNaNE[i].Count(); j++) if (_LV_PRNaNE[0][j] == Param)return _LV_PRNaNE[i][j]; MessageBox.Show("_LV_PRNaNE_Get(" + Ank + ";" + Param + ")", "NaN"); System.Threading.Thread.Sleep(1000); return "NaN"; };
            Func<string, string, string, Object> _LV_PRNaNE_Set = (string Ank, string Param, string Set) => { for (int i = 0; i < _LV_PRNaNE.Count(); i++)if (_LV_PRNaNE[i][0] == Ank)for (int j = 0; j < _LV_PRNaNE[i].Count(); j++)if (_LV_PRNaNE[0][j] == Param)_LV_PRNaNE[i][j] = Set; return new Object(); };
            Func<string, string, string, string> _LLLS_Get = (string Clu, string Ank, string Param) => { for (int i = 0; i < _LLLS.Count(); i++) if (_LLLS[i][0][0] == Clu)for (int j = 0; j < _LLLS[i].Count(); j++) if (_LLLS[i][j][0] == Ank)for (int k = 0; k < _LLLS[i][j].Count(); k++) if (_LLLS[i][0][k] == Param)return _LLLS[i][j][k]; MessageBox.Show("_LLLS_Get(" + Clu + ";" + Ank + ";" + Param + ")", "NaN"); System.Threading.Thread.Sleep(1000); return "NaN"; };
            Func<string, string, string, string, Object> _LLLS_Set = (string Clu, string Ank, string Param, string Set) => { for (int i = 0; i < _LLLS.Count(); i++)if (_LLLS[i][0][0] == Clu)for (int j = 0; j < _LLLS[i].Count(); j++)if (_LLLS[i][j][0] == Ank)for (int k = 0; k < _LLLS[i][j].Count(); k++)if (_LLLS[i][0][k] == Param)_LLLS[i][j][k] = Set; return new Object(); };
            Func<string, string, string> _LLS_FCM_Get = (string Ank, string Clu) => { 
                for (int i = 1; i < _LLS_FCM.Count(); i++)
                    if (_LLS_FCM[i][0] == Ank)
                        for (int j = 1; j < _LLS_FCM[i].Count(); j++)
                            if (_LLS_FCM[0][j] == Clu)
                            return _LLS_FCM[i][j]; 
                MessageBox.Show("_LLS_FCM_Get(" + Ank + ";" + Clu + ")", "NaN"); System.Threading.Thread.Sleep(1000);
                return "NaN"; 
            };
            Func<string, string, string, Object> _LLS_FCM_Set = (string Ank, string Clu, string Set) => { for (int i = 0; i < _LLS_FCM.Count(); i++)if (_LLS_FCM[i][0] == Ank)for (int j = 0; j < _LLS_FCM[i].Count(); j++)if (_LLS_FCM[0][j] == Clu)_LLS_FCM[i][j] = Set; return new Object(); };
            Func<string, string, string> _LLLS_P_SR = (string Clu, string Param) => {
                C.Comment("Cреднее арифметическое отдельного параметра по отдельному кластеру"); 
                double rez = 0; 
                int e = 0;
                for (int i = 0; i < _LLLS.Count(); i++)
                {
                    if (_LLLS[i][0][0] == Clu)
                        for (int j = 1; j < _LLLS[i].Count(); j++)
                        {
                            for (int k = 1; k < _LLLS[i][j].Count(); k++)
                                if (_LLLS[i][0][k] == Param)
                                {
                                    rez += Convert.ToDouble(_LLLS[i][j][k]);
                                    e++;
                                }
                        }
                }
                return Convert.ToString(rez / e); 
            };
            Func<string, string> _LLLS_P_MAX = ( string Param) =>
            {
                C.Comment("мАКСИМАЛЬНОЕ ЗНАЧЕНИЕ отдельного параметра по отдельному кластеру");
                double rez = 0;
                double MAX = -99999999999999;
                for (int i = 0; i < _LLLS.Count(); i++)
                {                    
                        for (int j = 1; j < _LLLS[i].Count(); j++)
                        {
                            for (int k = 1; k < _LLLS[i][j].Count(); k++)
                                if (_LLLS[i][0][k] == Param)
                                {
                                    if (MAX <= Convert.ToDouble(_LLLS[i][j][k]))
                                        MAX = Convert.ToDouble(_LLLS[i][j][k]);
                                }
                        }
                }
                return Convert.ToString(MAX);
            };
            /*
            C.DT.LLS(__LLS_FCM, 5,"");
            C.DT.LLS(__LocalVariable_GLNaNE, 5, "");
            */
            for (int i = 0; i < _LV_GLNaNE.Count(); i++)
            {
                string Ank = _LV_GLNaNE[i][0];
                string Param = _LV_GLNaNE[i][1];
                double rez = 0;
                //C.WL.Red("Param=" + Param + " ; Ank=" + Ank); C.WL.n();
                for (int j = 1; j < _LLS_FCM[0].Count(); j++)
                {
                    string Clu = _LLS_FCM[0][j];
                    string FCM_ = _LLS_FCM_Get(Ank, Clu);
                    string P_SR = _LLLS_P_SR(Clu, Param);
                    if (Convert.ToDouble(FCM_) <= 1)
                    {
                        //C.WL.Cyan("FCM_=" + FCM_ + " ; P_SR=" + P_SR + "; Clu=" + Clu); C.WL.n();
                        rez += Convert.ToDouble(FCM_) * Convert.ToDouble(P_SR); 
                    }
                }
                if (Convert.ToDouble(_LLLS_P_MAX(Param)) < rez)
                {
                    
                    ;
                }
                _LV_PRNaNE_Set(Ank, Param, Convert.ToString(rez));
            }
            return _LV_PRNaNE;
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_000(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, string PLog)
        {
            string Log = PLog + ".RSD_G0";//,string PLog
            C.Log.Go(PLog, "RSD_GO_000");
            Double DCN_WM = DCN.DetermineClustersNumber_CentroidsMethod_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);
            for (int i = 0; i < n; i++)
            {
                C.WL.Cyan("RSD.GO_000 " + Convert.ToString(i) + "/" + Convert.ToString(n)); C.WL.n();
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, Log);
                LocalVariable_PRNaNE = RSD.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE, Log);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_001(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, string PLog)
        {
            string Log = PLog + ".RSD_G0";//,string PLog
            C.Log.Go(PLog, "RSD_GO_000");
            //Double DCN_WM = DCN.DetermineClustersNumber_CentroidsMethod_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);
            for (int i = 0; i < n; i++)
            {
                C.WL.Cyan("RSD.GO_000 " + Convert.ToString(i) + "/" + Convert.ToString(n)); C.WL.n();
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                List<List<List<string>>> LocalVariable_WM_v0 = DCN.DetermineClustering_CentroidsMethod_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);

                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, Log);
                LocalVariable_PRNaNE = RSD.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE, Log);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;гНАТЬ ОДНУ ИТЕРАЦИЮ(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_000_1TURN(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, string PLog)
        {
            string Log = PLog + ".RSD_G01T";//,string PLog
            C.Log.Go(PLog, "RSD_GO_000_1TURN");
            return GO_000(LocalVariable_PRNaNE, LocalVariable_GLNaNE, 1, Log);
        }
    }
}
