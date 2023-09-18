using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003
{
    /// <summary>Console</summary>
    /// <summary>C.</summary>
    public partial class C 
    {   
        public static void Comment(string STR) { }
        
        /// <summary> Логер</summary>
        public static class Log {
            /// <summary> Логер</summary>/// <param name="strParent">Маркер родителя</param>/// <param name="strHeir">Маркер наследника</param>
            public static void Go(string strParent, string strHeir){
                //Boolean LogOn = false;
                Boolean LogOn = true;
                if (LogOn){C.WL.Gray(strParent + "."); C.WL.Cyan(strHeir); C.WL.n();}
            }
        }
    }
}
/*
string Log = PLog + ".C_LS";//,string PLog
C.Log.Go(PLog, "COPY_LS");
*/