using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
namespace QWE_2015_003
{
    [Serializable]
    class SaveLoadTextDataTableModel
    {
        public List<List<string>> TextDataTable = new List<List<string>>();
        public SaveLoadTextDataTableModel(string strDataTable, string PLog)
        {
            string Log = PLog + "SLTDTM_SLTDTM";//,string PLog
            C.Log.Go(PLog, "SaveLoadTextDataTableModel_SaveLoadTextDataTableModel");
            TextDataTable = PreProInpDat.ConverD.InputDataToListListString(strDataTable, Log);
        }
        public SaveLoadTextDataTableModel(){}
        public void SaveTextDataTable(string pathway, string PLog)
        {
            string Log = PLog + "SLTDTM_STDT";//,string PLog
            C.Log.Go(PLog, "SaveLoadTextDataTableModel_SaveTextDataTable");
            try {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.FileStream filestream = new System.IO.FileStream(pathway, System.IO.FileMode.Create, System.IO.FileAccess.Write);//Если файл уже существует, то он будет пересоздан или перезаписан.
                formatter.Serialize(filestream, this);
                filestream.Close();
            }catch {MessageBox.Show("SaveTextDataTable - неудача", "SaveTextDataTable - неудача");}
        }
        public List<List<string>> LoadTextDataTable(string pathway, string PLog)
        {
            string Log = PLog + "SLTDTM_LTDT";//,string PLog
            C.Log.Go(PLog, "SaveLoadTextDataTableModel_LoadTextDataTable");
            List<List<string>> rez_ =new List<List<string>>();
            try{
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.FileStream filestream = new System.IO.FileStream(pathway, System.IO.FileMode.Open, System.IO.FileAccess.Read);                
                rez_ = ((SaveLoadTextDataTableModel)formatter.Deserialize(filestream)).TextDataTable;
                this.TextDataTable = C.COPY.LLS(rez_);
                filestream.Close();
            }
            catch (System.IO.FileNotFoundException){ //если файл не существует
                new SaveLoadTextDataTableModel(PreProInpDat.PlugInputTextData(false, Log), Log).SaveTextDataTable(pathway, Log);//создаём новый файл.
                rez_ = C.COPY.LLS((new SaveLoadTextDataTableModel()).LoadTextDataTable(pathway, Log));//Читаем только что созданный файл файл, снимаем с него на всякий случай копию и отправляем в результат
            }
            return rez_;
        }        
    }    
}
