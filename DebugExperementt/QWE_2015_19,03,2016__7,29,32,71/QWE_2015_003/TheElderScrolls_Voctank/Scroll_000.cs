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
    public static class Scroll_000
    {
        public static void GO(string PLog){
            string Log = PLog + "S0_G";//,string PLog
            C.Log.Go(PLog, "Scroll_000_GO");
            List<List<string>> DF = Scroll_000.Dater_000(true, Log);
            Application.Run(new Form1(DF, "DF", Log));
            List<List<string>> DF_NaNR = PreProInpDat.NaNReduction(C.COPY.LLS(DF), Log);
            List<List<string>> LLs_RSD_10 = RSD.GO_000(PreProInpDat.Replenishment.PrimaryReplenishmentNaNElements(C.COPY.LLS(DF_NaNR), Log), PreProInpDat.GetListNaNElements(C.COPY.LLS(DF_NaNR), Log), 10, Log);
            Application.Run(new Form1(LLs_RSD_10, "LLs_RSD_10", Log));
        }
        /// <summary>Функция доступа к данным</summary><param name="correct">Тип доступа к данным( с просмотром и редактированием или просто загрузить)</param><returns>Возвращает LLS_ТаблицуДанных</returns>
        private static List<List<string>> Dater_000(Boolean correct, string PLog)
        {
            string Log = PLog + "S0_D0";//,string PLog
            C.Log.Go(PLog, "Scroll_000_Dater_000");
            string pach = "";
            //pach = "Test.XEON";
            pach = "Testor.XEON";
            //pach = "It_Predpr_Ylsk.XEON";//Кластеризация_It_предприятий_ульска данные собраны кажется в 2013, но сохранены в этой версии в рамках Экперимент  000_08,03,2016_23,10,40,77
            if (correct) { return (new TextDataSaveLoadForm(pach)).GO(Log); }
            else { return (new SaveLoadTextDataTableModel()).LoadTextDataTable(pach, Log); }
        }
    }
}
