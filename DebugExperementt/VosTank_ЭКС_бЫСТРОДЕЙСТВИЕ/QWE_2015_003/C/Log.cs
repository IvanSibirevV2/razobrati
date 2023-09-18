using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWE_2015_003
{
    /// <summary> Логер, вроде конечная версия</summary>    
    public class Log
    {
        public string FullName = "";
        public string BriefName = "";
        public List<string> ShortPath = new List<string>();
        public Log(){}
        /// <summary>Этот метод позволяет "удалять".</summary><param name="jmax">Сколько строк удалить</param>
        public void DeLog(int jmax)
        {
            System.Threading.Thread.Sleep(0);
            for (int j = 0; j < jmax; j++)
            {
                Console.CursorTop--;
                for (int i = 0; i < 70; i++) 
                    C.WL.Black("-");
                C.WL.n();
                Console.CursorTop--;
            }
        }
        /// <summary>Создание лога</summary><param name="_BriefName">Краткое имя сетода</param><param name="_FullName">Полное имя метода</param>
        public Log(string _BriefName, string _FullName)
        {
            this.FullName = _FullName;
            this.BriefName = _BriefName;
            this.ShortPath.Add(_BriefName);
        }
        /// <summary>Логирование нового метода</summary><param name="_BriefName">Краткое имя метода</param><param name="_FullName">Полное имя метода</param><param name="IsWrite">Писать ли в консоль</param><returns>Экземпляр нового лога для нового метода, для передачи потомкам</returns>
        public Log NewLog(string _BriefName, string _FullName, bool IsWrite)
        {
            Log ThisLog = new Log(_BriefName, _FullName);
            ThisLog.ShortPath = C.COPY.LS(this.ShortPath);
            ThisLog.ShortPath.Add(_BriefName);
            if (IsWrite) 
                ThisLog.write();
            return ThisLog;
        }
        /// <summary>Метод записи в консоль в две строки</summary>
        public void write()
        {
            C.WL.Red("-"); C.WL.Yellow("-"); C.WL.Red("-");
            for (int i = 0; i < this.ShortPath.Count() - 1; i++) 
            {
                C.WL.DarkGray(this.ShortPath[i]);
                C.WL.Red("."); 
            } 
            C.WL.n();C.WL.DarkGreen(this.FullName);C.WL.n();
        }
    }
}