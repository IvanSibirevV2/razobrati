using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Яндекс переводчик онлайн
/// https://translate.yandex.ru
/// Презентаци я метод варда
/// http://www.myshared.ru/slide/214831/
/// http://www.blackwasp.co.uk/VSBookmarks.aspx
/// </summary>
namespace QWE_2015_003{
    static class Program
    {
        
        [STAThread]
        static void Main(string[] args) 
        {
            Log ThisLog = new Log("M", "Main");
            ThisLog.write();
            //CheckTestBlocks.GO_0(ThisLog);//Тестовый скрипт            
            //QWE_2015_003.Scroll_000.GO_0(ThisLog);
            //QWE_2015_003.Scroll_001.GO_0(ThisLog);
            //QWE_2015_003.Scroll_001.GO_1(ThisLog);
            //QWE_2015_003.TheElderScrolls_Voctank.Scroll_TimeSeriesAggregator.GO_0(ThisLog.NewLog("TSA", "TimeSeriesAggregator"));

            QWE_2015_003.Scroll_TestsPerformance.GO(ThisLog);
            C.Read();
        }
    }
}