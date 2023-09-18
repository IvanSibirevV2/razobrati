using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWE_2015_003.TheElderScrolls_Voctank
{
    public partial class Scroll_TimeSeriesAggregator
    {
        public static string DataGen()
        {
            string str = "";
            str = "Tабл" + (char)9 + "P1" + (char)9 + "P2" + (char)9 + "P3" + (char)9 + (char)13 + (char)10;
            str += "ts1" + (char)9 + "1" + (char)9 + "2" + (char)9 + "3" + (char)9 + (char)13 + (char)10;
            str += "ts2" + (char)9 + "7" + (char)9 + "8" + (char)9 + "9" + (char)9 + (char)13 + (char)10;
            str += "ts3" + (char)9 + "3" + (char)9 + "4" + (char)9 + "5" + (char)9 + (char)13 + (char)10;
            str += "ts4" + (char)9 + "4" + (char)9 + "3" + (char)9 + "6" + (char)9 + (char)13 + (char)10;
            str += "ts5" + (char)9 + "5" + (char)9 + "4" + (char)9 + "55" + (char)9 + (char)13 + (char)10;
            str += "ts6" + (char)9 + "6" + (char)9 + "6" + (char)9 + "75" + (char)9 + (char)13 + (char)10;
            return str;
        }
        public static List<List<string>> LLSDataGen() 
        {
            return PreProInpDat.ConverD.InputDataToListListString(DataGen(), new Log());
        }
    }
}
