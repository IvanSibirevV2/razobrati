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
            string PLog = "N";
            string Log = PLog + ".M";//string ParentLog
            C.Log.Go(PLog, "Main");
            //new Priority().ShowDialog();
            //CheckTestBlocks.GO();//Тестовый скрипт
            //QWE_2015_003.Scroll_000.GO();
            //QWE_2015_003.Scroll_001.GO();
            
            QWE_2015_003.Scroll_001.GO_1();
            
        }
    }
}