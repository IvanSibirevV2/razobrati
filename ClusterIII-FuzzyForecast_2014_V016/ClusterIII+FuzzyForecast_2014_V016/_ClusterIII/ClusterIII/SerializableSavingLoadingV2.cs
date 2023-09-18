using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ClusterIII.Model;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SavingLoadingNameSpace;




namespace SavingLoadingNameSpace
{
    public static class SLSerializableService
    {
        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="MyCluster">Записываемые данные</param>
        /// <param name="spath">Путь к файлу</param>
        public static void StreamSaver(Cluster MyCluster)
        {
            string spath = SaveFileDialogString();
            if (spath != "000")
            {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(spath, FileMode.Create);
            formatter.Serialize(fileStream, MyCluster);
            fileStream.Close();
            }
        }
        /// <summary>
        /// Загрузка из файла
        /// </summary>
        /// <param name="spath">Путь к файлу</param>
        /// <returns>Загруженные данные</returns>
        public static Cluster StreamLoader()
        {
            string spath = OpenFileDialogString();
            if (spath == "000")
            {
                return new Cluster("Ошибка загрузки",new List<Group>(),new List<Cluster>());
            }
         
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(spath, FileMode.Open);
            Cluster MyCluster = ((Cluster)formatter.Deserialize(fileStream)).FaceClone();           
            fileStream.Close();
            return MyCluster;
        }

        public static string OpenFileDialogString()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML files|*.SOF";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return "000";
            return fileDialog.FileName;
        }

        public static string SaveFileDialogString()
        {            
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "NoName";
            fileDialog.Filter = "XML files|*.SOF";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return "000";
            return fileDialog.FileName;
        }   
    }
}