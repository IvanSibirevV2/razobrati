using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;

namespace ClusterIII.Converts
{
    public static class Iimport
    {

        public static Cluster Text_To_Cluster(string text, Cluster InputCluster)
        {
            //Копируем кластер
            Cluster LocalCluster = InputCluster.FaceClone();
            //Оставляем только шапку
            LocalCluster.SCluster.Clear();            
            //Создаём предметную область
            List<string> StringList = new List<string>(text.Split('\n').ToArray());


            //Добавляем пустые предприятия
            for (int i = 1; i < StringList.Count-1; i++)
            {
                List<string> SL1 = new List<string>(StringList[i].Split('\t').ToArray());
                LocalCluster.SCluster.Add(new Cluster());
                LocalCluster.SCluster[i - 1].Name = Convert.ToString(SL1[0]);

                
                 
            }
            //Клонируем шапку
            LocalCluster.SameFaceClone();
            for (int i = 1; i < StringList.Count - 1; i++)
            {
                List<string> SL1 = new List<string>(StringList[i].Split('\t').ToArray());
                int e = 1;
                for (int j = 0; j < LocalCluster.CGroupList.Count; j++)
                {
                    for (int k = 0; k < LocalCluster.CGroupList[j].GParamList.Count; k++)
                    {
                        LocalCluster.SCluster[i - 1].CGroupList[j].GParamList[k].P = Convert.ToDouble(SL1[e]);
                        e++;
                    }

                }
            }

            /*
            LocalCluster.SameFaceClone();
            for (int i = 1; i < StringList.Count; i++)
            {
                int e = 1;
                List<string> SL1 = new List<string>(StringList[i].Split('\t').ToArray());
                LocalCluster.SCluster[i].Name = SL1[0];
                for (int j = 0; j < LocalCluster.CGroupList.Count; j++)
                {
                    for (int k = 0; k < LocalCluster.CGroupList[j].GParamList.Count; k++)
                    {
                        
                        LocalCluster.SCluster[i].CGroupList[j].GParamList[k].P = Convert.ToDouble(SL1[e]);
                    }
                    e++;
                }                
            }
             */ 
            return LocalCluster.FaceClone();
        }

    }
}
