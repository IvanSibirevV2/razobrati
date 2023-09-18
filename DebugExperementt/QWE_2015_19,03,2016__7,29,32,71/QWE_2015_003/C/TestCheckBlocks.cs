using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QWE_2015_003{
    public static class CheckTestBlocks{
        public static void GO()
        {
            string PLog = "";
            string Log = PLog+".CTB_G";//string ParentLog
            C.Log.Go(PLog, "CheckTestBlocks_GO");
            //Test_000(true, PLog);//Исходный текст
            //Test_001(true, PLog);//Данные в формате таблици
            //Test_002(true, PLog);//Редуцированные данные
            //Test_003(true, PLog);//Список незаполненных параметров
            //Test_004(true, PLog);//Данные, залитые средним арифметическим
            Test_005(true, PLog);//Кластеризация центроидным методом CCM_v0;(классика жанра, как есть, без костылей стимуляторов и ускорителей); 
            //Test_006(true, PLog);//Кластеризация метод Варда
            //Test_007(true, PLog);//Кластеризация FCM методом            
            //Test_008(true, PLog);//Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)
            //Test_009(true, PLog);//Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)
            //Test_010(true, PLog);//Алгоритм восстановления данных. Отработка итерации.
            Console.Read();
        }
        /// <summary>Исходный текст</summary>
        private static void Test_000(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_0";//string ParentLog
            C.Log.Go(PLog, "Test_000");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            Console.Write(LocalVariable_PITD); 
        }
        /// <summary>Данные в формате таблици</summary>
        private static void Test_001(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_1";//string ParentLog
            C.Log.Go(PLog, "Test_001");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            C.DT.LLS(LocalVariable_IDCTLLS, 5, Log);
            C.WL.n(2);
        }
        /// <summary>Редуцированные данные</summary>
        private static void Test_002(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_2";//string ParentLog
            C.Log.Go(PLog, "Test_002");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            C.DT.LLS(LocalVariable_NaNR, 5, Log);
            C.WL.n(2);
        }
        /// <summary>Список незаполненных параметров</summary>
        private static void Test_003(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_3";//string ParentLog
            C.Log.Go(PLog, "Test_003");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, Log);
            C.DT.LLS(LocalVariable_GLNaNE, 5, Log);
            C.WL.n(2); 
        }
        /// <summary>Данные, залитые средним арифметическим</summary>
        private static void Test_004(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_4";//string ParentLog
            C.Log.Go(PLog, "Test_004");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log);
            C.DT.LLS(LocalVariable_PRNaNE, 5, Log); 
            C.WL.n(2); 
        }
        /// <summary>Кластеризация центроидным методом CCM_v0;(классика жанра, как есть, без костылей стимуляторов и ускорителей); </summary>
        private static void Test_005(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_5";//string ParentLog
            C.Log.Go(PLog, "Test_005");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log); 
            
            int n = 2;
            List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_v1(LocalVariable_PRNaNE, n, Log);
            C.DT.LLLS(LocalVariable_CCM_v0, 5, Log); 
            
        }
        /// <summary>Кластеризация метод Варда</summary>
        private static void Test_006(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_6";//string ParentLog
            C.Log.Go(PLog, "Test_006");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log); 
            int n = 3;
            List<List<List<string>>> LocalVariable_WM_v0 = Clustering.Ward.GO_v0(LocalVariable_PRNaNE, n, Log);
            C.DT.LLLS(LocalVariable_WM_v0, 5, Log); 
        }
        /// <summary>Кластеризация FCM методом</summary>
        private static void Test_007(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_7";//string ParentLog
            C.Log.Go(PLog, "Test_007");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log); 
            int n = 3;
            List<List<List<string>>> LocalVariable_CCM_v0 = Clustering.Centroid.GO_Viper(LocalVariable_PRNaNE, n, Log);
            C.DT.LLLS(LocalVariable_CCM_v0, 5, Log); 
            Double Q_M = 1.5;
            Double DE = 0.005;
            List<List<string>> LocalVariable_FCM = Clustering.FCM.GO(LocalVariable_CCM_v0, Q_M, DE, Log);
            C.DT.LLS(LocalVariable_FCM, 6, Log); 
        }
        /// <summary>Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)</summary>
        private static void Test_008(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_8";//string ParentLog
            C.Log.Go(PLog, "Test_008");
            C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ЦЕНТРОИДНЫЙ МЕТОД КЛАСТЕРИЗАЦИИ)");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log);
            Double QWSRFTBVC = DCN.DetermineClustersNumber_CentroidsMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);
            C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC));
        }
        /// <summary>Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)</summary>
        private static void Test_009(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_9";//string ParentLog
            C.Log.Go(PLog, "Test_009");
            C.Comment("Определяем колво кластеров ( ИСПОЛЬЗУЕМ ВАРДА МЕТОД КЛАСТЕРИЗАЦИИ)");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LocalVariable_IDCTLLS = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_NaNR = PreProInpDat.NaNReduction(LocalVariable_IDCTLLS, Log);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(LocalVariable_NaNR, Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(LocalVariable_NaNR, Log);
            Double QWSRFTBVC = DCN.DetermineClustersNumber_WardMethod(LocalVariable_GLNaNE, LocalVariable_PRNaNE, Log);
            C.WL.Red("QWSRFTBVC=" + Convert.ToString(QWSRFTBVC));
        }
        /// <summary>Алгоритм восстановления данных. Отработка итерации.</summary>
        private static void Test_010(Boolean TDHF, string PLog)
        {
            string Log = PLog + ".CTB_T_10";//string ParentLog
            C.Log.Go(PLog, "Test_010");
            C.Comment(" Алгоритм восстановления данных. Отработка итерации.");
            string LocalVariable_PITD = PreProInpDat.PlugInputTextData(TDHF, Log);
            List<List<string>> LLS_WData = new List<List<string>>();
            List<List<string>> LocalVariable_IDCTLLS_ = PreProInpDat.ConverD.InputDataToListListString(LocalVariable_PITD, Log);
            List<List<string>> LocalVariable_GLNaNE = PreProInpDat.GetListNaNElements(PreProInpDat.NaNReduction(LocalVariable_IDCTLLS_, Log), Log);
            List<List<string>> LocalVariable_PRNaNE = PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(PreProInpDat.NaNReduction(LocalVariable_IDCTLLS_, Log), Log);
            LLS_WData = LocalVariable_PRNaNE;
            C.DT.LLS(RSD.GO_000(LocalVariable_PRNaNE, LocalVariable_GLNaNE, 60, Log), 5, Log);
            C.DT.LLS(RSD.GO_000_1TURN(LocalVariable_PRNaNE, LocalVariable_GLNaNE, Log), 5, Log);
        }
    }
}
