using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace QWE_2015_003
{
    /// <summary>
    /// Экперимент  000_08,03,2016_23,10,40,77
    /// Загрузка и восстановление данных, вывод их на экран.
    /// "Цель -  проверить работоспособность основных узлов программы.
    /// Вывод - основные узлы программы проверены подправлены. Удачного полёта.
    ///                                                                     Мысль."
    /// </summary>
    public static class Scroll_001
    {
        public static void GO(Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("S1.G", "Scroll_001.GO", true);
            List<List<string>> DF = Scroll_001.Dater(false);
            List<List<string>> DF_NaNR = QWE_2015_003.PreProInpDat.NaNReduction(DF, ThisLog);
            
            List<List<string>> LLs_RSD_50 = QWE_2015_003.RestoreSkipedData.GO_qV000(
                QWE_2015_003.PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(DF_NaNR, ThisLog)
                , QWE_2015_003.PreProInpDat.GetListNaNElements(DF_NaNR, ThisLog)
                , 50, ThisLog);
            int g=16;

            Application.Run(
            new Form1(
                QWE_2015_003.PreProInpDat.ConverD.LLLSToLLS(
                Clustering.Centroid.GO_Viper(
                    QWE_2015_003.PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(DF_NaNR, ThisLog)
                    , g, ThisLog)
                ), "LLLs_PRNaNE_CCM " + Convert.ToString(g))
                );            
            Application.Run(
            new Form1(
                QWE_2015_003.PreProInpDat.ConverD.LLLSToLLS(
                QWE_2015_003.Clustering.Centroid.GO_Viper(
                    QWE_2015_003.PreProInpDat.Replenishment.PrimaryReplenishmentNaNElementsWithZeros(DF_NaNR)
                    , g, ThisLog)
                ), "LLLs_PRNaNEWZ_CCM " + Convert.ToString(g))
                );
            Application.Run(
            new Form1(
                QWE_2015_003.PreProInpDat.ConverD.LLLSToLLS(
                QWE_2015_003.Clustering.Centroid.GO_Viper(LLs_RSD_50, g, ThisLog)
                ), "LLLs_PRNaNEWZ_CCM_RSD_50 " + Convert.ToString(g))
                );              
            //Console.Read();
        }
        public static void GO_1(Log ThisLog)
        {
            ThisLog = ThisLog.NewLog("S1.G1", "Scroll_001.GO_1", true);//Log ThisLog
            string PLog = "";
            Func<List<List<string>>, int, int, List<List<string>>> DataColumnCut = (List<List<string>> INPUTLLS, int DelProc, int j) =>
            {
                List<List<string>> _LLS = C.COPY.LLS(INPUTLLS);
                _LLS[0][0] = "001_" + Convert.ToString(DelProc) +"_" +Convert.ToString(j)+"_";
                int Ank_Count = _LLS.Count() - 1;
                //100   Ank_Count
                //  x   уд
                if ((true) & (DelProc > 0) & (DelProc < 100)& (j > 0)& (j < _LLS[0].Count()))
                {
                    List<int> u = new List<int>();
                    Random rand = new Random();                    
                    while (u.Count() < (int)((_LLS.Count() - 1) * DelProc / 100))
                    {
                        int rnd = rand.Next(1, _LLS.Count() );
                        Boolean flsg = true;
                        foreach (int i in u) if (i == rnd) flsg = false;
                        if (flsg) u.Add(rnd);
                    }
                    u.Sort();
                    for (int i = u.Count()-1 ; i >-1; i--)_LLS[u[i]][j] = "NaN";
                }
                return _LLS; 
            };
            List<List<string>> LLS = PreProInpDat.ConverD.InputDataToListListString(DataSoursXD.Q001(), ThisLog);
            //new Form1(LLS, "Входные данные").GO_0();
            C.WL.DarkRed("Console.Read %"); C.WL.n();
            string param1 = Console.ReadLine();
            
            System.Threading.Thread.Sleep(1000);            
            C.WL.DarkRed("Console.Read Column [1,..."); C.WL.n();
            string param2 = Console.ReadLine();

            LLS = DataColumnCut(LLS, Convert.ToInt32(param1), Convert.ToInt32(param2));
            //Application.Run(new Form1(DF, "DF", Log));
            List<List<string>> DF = C.COPY.LLS(LLS);
            List<List<string>> DF_NaNR = PreProInpDat.NaNReduction(C.COPY.LLS(DF), ThisLog);
            List<List<string>> LLs_RSD_10 = RestoreSkipedData.GO_q001(
                PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), ThisLog), 
                PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), ThisLog),
                10, ThisLog);
            new Form1(LLS, "Обрезанные данные").GO();
            Application.Run(new Form1(LLs_RSD_10, "LLs_RSD_10"));
                      
            
        }
        /// <summary>Функция доступа к данным</summary><param name="correct">Тип доступа к данным( с просмотром и редактированием или просто загрузить)</param><returns>Возвращает LLS_ТаблицуДанных</returns>
        static private List<List<string>> Dater(Boolean correct)
        {
            string pach = "";
            //pach = "Test.XEON";
            pach = "It_Predpr_Ylsk.XEON";//Кластеризация_It_предприятий_ульска данные собраны кажется в 2013, но сохранены в этой версии в рамках Экперимент  000_08,03,2016_23,10,40,77
            if (correct) { return (new TextDataSaveLoadForm(pach)).GO(); }
            else { return (new SaveLoadTextDataTableModel()).LoadTextDataTable(pach); }
        }
    }
}
