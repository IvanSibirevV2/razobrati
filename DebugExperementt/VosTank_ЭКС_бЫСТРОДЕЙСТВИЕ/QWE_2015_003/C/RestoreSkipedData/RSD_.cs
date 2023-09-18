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
    public partial class RestoreSkipedData
    {        
        
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_qV000(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD.G0", "RestoreSkipedData.GO_V000", true);
            Double DCN_WM = DetermineClustersNumber.DetermineClustersNumber_CentroidsMethod_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE);
            for (int i = 0; i < n; i++)
            {
                string progress = ThisLog.FullName + " : " + Convert.ToString(i+1) + "/" + Convert.ToString(n);
                Console.CursorTop--; C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, (int)DCN_WM, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                ThisLog.DeLog(4);
                LocalVariable_PRNaNE = RestoreSkipedData.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_q001(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD.G1", "RestoreSkipedData.GO_001", true);//Log ThisLog
            //Double DCN_WM = DCN.DetermineClustersNumber_CentroidsMethod_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);
            for (int i = 0; i < n; i++)
            {
                C.WL.Cyan("RSD.GO_000 " + Convert.ToString(i) + "/" + Convert.ToString(n)); C.WL.n();
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                //List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, (int)DCN_WM, Log);
                List<List<List<string>>> LocalVariable_WM_v0 = DetermineClustersNumber.Gebgid_Viper_CentroidsMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                LocalVariable_PRNaNE = RestoreSkipedData.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;гНАТЬ ОДНУ ИТЕРАЦИЮ(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_V000_1TURN(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD.G0_1T", "RestoreSkipedData.GO_V000_1TURN", true);
            return GO_qV000(LocalVariable_PRNaNE, LocalVariable_GLNaNE, 1, new Log());
        }
    }
}
