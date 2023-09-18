using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QWE_2015_003
{
    public partial class RSD_Test
    {
        /// <summary>Алгоритм восстановления данных.; Отработка итерации. (RSD - Restore Skiped Data);</summary>        
        private static List<List<string>> RestoreSkipedData_1turn(List<List<string>> __LV_PRNaNE, List<List<List<string>>> __LLLS, List<List<string>> __LLS_FCM, List<List<string>> __LocalVariable_GLNaNE)
        {            
            List<List<string>> _LV_PRNaNE = C.COPY.LLS(__LV_PRNaNE);
            List<List<List<string>>> _LLLS = C.COPY.LLLS(__LLLS);
            List<List<string>> _LLS_FCM = C.COPY.LLS(__LLS_FCM);
            List<List<string>> _LV_GLNaNE = C.COPY.LLS(__LocalVariable_GLNaNE);
            Func<string, string, string> _LV_PRNaNE_Get = (string Ank, string Param) => 
            {
                for (int i = 0; i < _LV_PRNaNE.Count(); i++)
                    if (_LV_PRNaNE[i][0] == Ank)
                        for (int j = 0; j < _LV_PRNaNE[i].Count(); j++)
                            if (_LV_PRNaNE[0][j] == Param)
                                return _LV_PRNaNE[i][j];
                MessageBox.Show("_LV_PRNaNE_Get(" + Ank + ";" + Param + ")", "NaN");
                return "NaN"; };
            Func<string, string, string, Object> _LV_PRNaNE_Set = (string Ank, string Param, string Set) => 
            {
                for (int i = 0; i < _LV_PRNaNE.Count(); i++)
                    if (_LV_PRNaNE[i][0] == Ank)
                        for (int j = 0; j < _LV_PRNaNE[i].Count(); j++)
                            if (_LV_PRNaNE[0][j] == Param)
                                _LV_PRNaNE[i][j] = Set;
                return new Object();
            };
            Func<string, string, string, string> _LLLS_Get = (string Clu, string Ank, string Param) =>
            {
                for (int i = 0; i < _LLLS.Count(); i++)
                    if (_LLLS[i][0][0] == Clu)
                        for (int j = 0; j < _LLLS[i].Count(); j++)
                            if (_LLLS[i][j][0] == Ank)
                                for (int k = 0; k < _LLLS[i][j].Count(); k++)
                                    if (_LLLS[i][0][k] == Param)
                                        return _LLLS[i][j][k];
                MessageBox.Show("_LLLS_Get(" + Clu + ";" + Ank + ";" + Param + ")", "NaN");                
                return "NaN";
            };
            Func<string, string, string, string, Object> _LLLS_Set = (string Clu, string Ank, string Param, string Set) => 
            {
                for (int i = 0; i < _LLLS.Count(); i++)
                    if (_LLLS[i][0][0] == Clu)
                        for (int j = 0; j < _LLLS[i].Count(); j++)
                            if (_LLLS[i][j][0] == Ank)
                                for (int k = 0; k < _LLLS[i][j].Count(); k++)
                                    if (_LLLS[i][0][k] == Param)
                                        _LLLS[i][j][k] = Set;
                return new Object();
            };
            Func<string, string, string> _LLS_FCM_Get = (string Ank, string Clu) =>
            {
                for (int i = 1; i < _LLS_FCM.Count(); i++)
                    if (_LLS_FCM[i][0] == Ank)
                        for (int j = 1; j < _LLS_FCM[i].Count(); j++)
                            if (_LLS_FCM[0][j] == Clu)
                                return _LLS_FCM[i][j];
                MessageBox.Show("_LLS_FCM_Get(" + Ank + ";" + Clu + ")", "NaN");
                return "NaN";
            };
            Func<string, string, string, Object> _LLS_FCM_Set = (string Ank, string Clu, string Set) => 
            {
                for (int i = 0; i < _LLS_FCM.Count(); i++)
                    if (_LLS_FCM[i][0] == Ank)
                        for (int j = 0; j < _LLS_FCM[i].Count(); j++)
                            if (_LLS_FCM[0][j] == Clu)
                                _LLS_FCM[i][j] = Set; 
                return new Object();
            };
            Func<string, string, string> _LLLS_P_SR = (string Clu, string Param) =>
            {
                /*Cреднее арифметическое отдельного параметра по отдельному кластеру*/
                double rez = 0;
                int e = 0;
                for (int i = 0; i < _LLLS.Count(); i++)
                {
                    if (_LLLS[i][0][0] == Clu)
                        for (int j = 1; j < _LLLS[i].Count(); j++)
                        {
                            for (int k = 1; k < _LLLS[i][j].Count(); k++)
                                if (_LLLS[i][0][k] == Param)
                                {
                                    rez += Convert.ToDouble(_LLLS[i][j][k]);
                                    e++;
                                }
                        }
                }
                return Convert.ToString(rez / e);
            };
            /*мАКСИМАЛЬНОЕ ЗНАЧЕНИЕ отдельного параметра по отдельному кластеру*/
            Func<string, string> _LLLS_P_MAX = (string Param) =>
            {                
                double MAX = -99999999999999;
                for (int i = 0; i < _LLLS.Count(); i++)
                {
                    for (int j = 1; j < _LLLS[i].Count(); j++)
                    {
                        for (int k = 1; k < _LLLS[i][j].Count(); k++)
                            if (_LLLS[i][0][k] == Param)
                            {
                                if (MAX <= Convert.ToDouble(_LLLS[i][j][k]))
                                    MAX = Convert.ToDouble(_LLLS[i][j][k]);
                            }
                    }
                }
                return Convert.ToString(MAX);
            };
            for (int i = 0; i < _LV_GLNaNE.Count(); i++)
            {
                string Ank = _LV_GLNaNE[i][0];
                string Param = _LV_GLNaNE[i][1];
                double rez = 0;
                for (int j = 1; j < _LLS_FCM[0].Count(); j++)
                {
                    string Clu = _LLS_FCM[0][j];
                    string FCM_ = _LLS_FCM_Get(Ank, Clu);
                    string P_SR = _LLLS_P_SR(Clu, Param);
                    if (Convert.ToDouble(FCM_) <= 1) { rez += Convert.ToDouble(FCM_) * Convert.ToDouble(P_SR); }
                }
                if (Convert.ToDouble(_LLLS_P_MAX(Param)) < rez) { ;}
                _LV_PRNaNE_Set(Ank, Param, Convert.ToString(rez));
            }
            return _LV_PRNaNE;
        }
    }
}