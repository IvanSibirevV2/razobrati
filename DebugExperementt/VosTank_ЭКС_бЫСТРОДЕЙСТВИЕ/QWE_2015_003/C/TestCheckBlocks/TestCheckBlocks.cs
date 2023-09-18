using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ThisLog.NewLog("PPID.C.IDTLLS", "PreProInpDat.ConverD.InputDataToListListString", true)
namespace QWE_2015_003{
    public static class CheckTestBlocks{
        public static void GO_0(Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.G0", "CheckTestBlocks.GO_0", true);
            //CheckTestBlocks.Test_000(true, ThisLog);//Исходный текст
            //CheckTestBlocks.Test_001(true, ThisLog);//Данные в формате таблици
            //CheckTestBlocks.Test_002(true, ThisLog);//Редуцированные данные
            //CheckTestBlocks.Test_003(true, ThisLog);//Список незаполненных параметров
            //CheckTestBlocks.Test_004(true, ThisLog);//Данные, залитые средним арифметическим
            //CheckTestBlocks.Test_005(true, ThisLog);//Кластеризация центроидным методом CCM_v0;(классика жанра, как есть, без костылей стимуляторов и ускорителей); 
            //CheckTestBlocks.Test_006(true, ThisLog);//Кластеризация метод Варда
            CheckTestBlocks.Test_007(true, ThisLog);//Кластеризация FCM методом
            //CheckTestBlocks.Test_008(true, ThisLog);//Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)
            //CheckTestBlocks.Test_009(true, ThisLog);//Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)
            //CheckTestBlocks.Test_010(true, ThisLog);//Алгоритм восстановления данных. Отработка итерации.            
            Console.Read();
        }
        /// <summary>Исходный текст</summary>
        private static void Test_000(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T0", "CheckTestBlocks.Test_000", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            Console.Write(LocalVariable_PITD);            
        }
        /// <summary>Данные в формате таблици</summary>
        private static void Test_001(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T1", "CheckTestBlocks.Test_001", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            C.DT.LLS(LocalVariable_IDCTLLS, 5);
            C.WL.n(2);
        }
        /// <summary>Редуцированные данные</summary>
        private static void Test_002(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T2", "CheckTestBlocks.Test_002", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            C.DT.LLS(LocalVariable_NaNR, 5);
            C.WL.n(2);
        }
        /// <summary>Список незаполненных параметров</summary>
        private static void Test_003(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T3", "CheckTestBlocks.Test_003", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, ThisLog);
            C.DT.LLS(LocalVariable_GLNaNE, 5);
            C.WL.n(2); 
        }
        /// <summary>Данные, залитые средним арифметическим</summary>
        private static void Test_004(Boolean TDHF, Log ThisLog)
        {            
            ThisLog = ThisLog.NewLog("CTB.T4", "CheckTestBlocks.Test_004", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog);
            C.DT.LLS(LocalVariable_PRNaNE, 5); 
            C.WL.n(2); 
        }
        /// <summary>Кластеризация центроидным методом CCM_v0;(классика жанра, как есть, без костылей стимуляторов и ускорителей); </summary>
        private static void Test_005(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T5", "CheckTestBlocks.Test_005", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog);
            int n = 2;
            //List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_v1(LocalVariable_PRNaNE, n, ThisLog);
            List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, n, ThisLog);
            C.DT.LLLS(LocalVariable_CCM_v0, 5);
        }
        /// <summary>Кластеризация метод Варда</summary>
        private static void Test_006(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T6", "CheckTestBlocks.Test_006", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog);
            int n = 3;
            List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, n, ThisLog);
            C.DT.LLLS(LocalVariable_WM_v0, 5); 
        }
        /// <summary>Кластеризация FCM методом</summary>
        private static void Test_007(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T7", "CheckTestBlocks.Test_007", true);
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog); 
            int n = 3;
            List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, n, ThisLog);
            C.DT.LLLS(LocalVariable_CCM_v0, 5); 
            Double Q_M = 1.5;
            Double DE = 0.005;
            //List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_V000(LocalVariable_CCM_v0, Q_M, DE, ThisLog);
            List<List<string>> LocalVariable_FCM = Clustering.FCM.GO_Viper(LocalVariable_CCM_v0, Q_M, DE, ThisLog);
            C.DT.LLS(LocalVariable_FCM, 6);             
        }
        /// <summary>Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)</summary>
        private static void Test_008(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T8", "CheckTestBlocks.Test_008", true);
            C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog);
            Double QWSRFTBVC = DetermineClustersNumber.CentroidsMethod_GO_v1(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
            C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC));
        }
        /// <summary>Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)</summary>
        private static void Test_009(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T9", "CheckTestBlocks.Test_009", true);
            C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, ThisLog);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, ThisLog);
            Double QWSRFTBVC = DetermineClustersNumber.WardMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, ThisLog);
            C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC));
        }
        /// <summary>Алгоритм восстановления данных. Отработка итерации.</summary>
        private static void Test_010(Boolean TDHF, Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("CTB.T10", "CheckTestBlocks.Test_010", true);
            C.Comment(" Алгоритм восстановления данных. Отработка итерации.");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, ThisLog);
            List<List<string>> LLS_WData = new List<List<string>>();
            List<List<string>> LocalVariable_IDCTLLS_ = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, ThisLog);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(PreProInpDat.NaNReduction(LocalVariable_IDCTLLS_, ThisLog), ThisLog);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(PreProInpDat.NaNReduction(LocalVariable_IDCTLLS_, ThisLog), ThisLog);
            LLS_WData = LocalVariable_PRNaNE;
            C.DT.LLS(RestoreSkipedData.GO_qV000(LocalVariable_PRNaNE, LocalVariable_GLNaNE, 60, ThisLog), 5);
            C.DT.LLS(RestoreSkipedData.GO_V000_1TURN(LocalVariable_PRNaNE, LocalVariable_GLNaNE, new Log()), 5);
        }
    }
}
