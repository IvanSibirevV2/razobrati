using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    public partial class RSD_Test
    {
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_test_000(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD_Test.Gt0", "RSD_Test.GO_test_000", true);
            for (int i = 0; i < n; i++)
            {
                string progress = ThisLog.FullName + " : " + Convert.ToString(i + 1) + "/" + Convert.ToString(n);
                ThisLog.DeLog(1); C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                Double DCN_WM = DetermineClustersNumber.CentroidsMethod_GO_v1(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
                List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_v1(LocalVariable_PRNaNE, (int)DCN_WM, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                
                LocalVariable_PRNaNE = QWE_2015_003.RSD_Test.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_test_001(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD_Test.Gt0", "RSD_Test.GO_test_000", true);
            Double DCN_WM = DetermineClustersNumber.CentroidsMethod_GO_v1(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
            string progress = ThisLog.FullName + " : " + /*Convert.ToString(i + 1) +*/ "/" + Convert.ToString(n);
            //ThisLog.DeLog(1); 
            //C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
            for (int i = 0; i < n; i++)
            {
                List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_v1(LocalVariable_PRNaNE, (int)DCN_WM, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                
                LocalVariable_PRNaNE = QWE_2015_003.RSD_Test.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_test_002(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD_Test.Gt0", "RSD_Test.GO_test_000", true);
            Double DCN_WM = DetermineClustersNumber.CentroidsMethod_GO_Viper(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
            string progress = ThisLog.FullName + " : " + /*Convert.ToString(i + 1) +*/ "/" + Convert.ToString(n);
            //ThisLog.DeLog(1); 
            //C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
            for (int i = 0; i < n; i++)
            {
                List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, (int)DCN_WM, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);

                LocalVariable_PRNaNE = QWE_2015_003.RSD_Test.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_test_003(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD_Test.Gt0", "RSD_Test.GO_test_000", true);
            for (int i = 0; i < n; i++)
            {
                string progress = ThisLog.FullName + " : " + Convert.ToString(i + 1) + "/" + Convert.ToString(n);
                C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                List<List<List<string>>> LocalVariable_WM_v0 = DetermineClustersNumber.Gebgid_Viper_CentroidsMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                LocalVariable_PRNaNE = QWE_2015_003.RSD_Test.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
        /// <summary>Алгоритм восстановления данных.;(RSD - Restore Skiped Data);</summary><param name="LocalVariable_IDCTLLS">Входная таблица не совсем заполненных данных</param><param name="LocalVariable_GLNaNE">Список незаполненных параметров</param><param name="n">Кол-во итерация данного алгоритма</param><returns></returns>
        public static List<List<string>> GO_test_004(List<List<string>> LocalVariable_PRNaNE, List<List<string>> LocalVariable_GLNaNE, int n, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("RSD_Test.Gt0", "RSD_Test.GO_test_000", true);
            for (int i = 0; i < n; i++)
            {
                string progress = ThisLog.FullName + " : " + Convert.ToString(i + 1) + "/" + Convert.ToString(n);
                C.WL.Blue("-"); C.WL.Green("-"); C.WL.Blue("-"); C.WL.DarkGreen(progress); C.WL.n();
                List<List<List<string>>> LocalVariable_WM_v0 = DetermineClustersNumber.Gebgid_Viper_CentroidsMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
                List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_Viper/*GO_V000*/(LocalVariable_WM_v0, /*Q_M_FCM*/1.5, /*DE_FCM*/0.005, ThisLog);
                LocalVariable_PRNaNE = QWE_2015_003.RSD_Test.RestoreSkipedData_1turn(LocalVariable_PRNaNE, LocalVariable_WM_v0, LocalVariable_FCM, LocalVariable_GLNaNE);
            }
            return C.COPY.LLS(LocalVariable_PRNaNE);
        }
    }
}