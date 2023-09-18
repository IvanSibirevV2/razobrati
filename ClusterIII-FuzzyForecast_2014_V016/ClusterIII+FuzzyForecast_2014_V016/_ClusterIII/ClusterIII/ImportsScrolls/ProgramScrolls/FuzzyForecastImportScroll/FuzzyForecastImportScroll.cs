using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusterIII.Model;
using System.Windows.Forms;
using System.Data;
using ClusterIII.View;
using ClusterIII.ClusterMethods;
using ClusterIII.Converts;
using SavingLoadingNameSpace;


namespace ClusterIII.ImportsScrolls.ProgramScrolls.FuzzyForecastImportScroll
{
    //  Класс - свиток, использования ПО кластеризации программой FuzzyForecast
    public class FuzzyForecastImportScroll
    {
        /// <summary>
        /// Свиток первый
        /// </summary>
        /// <param name="listViewStatisticCrisp">Передаётся один ряд и его параметры из</param>
        /// <param name="NameText"></param>
        public void/*Cluster*/ Scroll1(ListView listViewStatisticCrisp, string NameText)
        {
            ClusterIII.FormMain My_ClusterIII_Form_Main = new ClusterIII.FormMain();
            
            //listViewStatisticCrisp-nf,kbwf lfyys[
            //Пишем название ряда
            //1) Создаём локальную копию данных
            //1.1)Создаём модель данных
            ClusterIII.Model.Cluster LocalCluster = new ClusterIII.Model.Cluster
                (
                    NameText,//Имя Ряда
                    new List<ClusterIII.Model.Group>() ,
                    new List<ClusterIII.Model.Cluster>()
                );
            //1.2)Наполняем модель данных данными =)
            //1.2.1)Создаём шапку данных
            //Создаём группу параметров
            LocalCluster.CGroupList.Add(new ClusterIII.Model.Group("Group № 1",new List<ClusterIII.Model.Param>()));
            //Накидываем список параметров
            for (int i = 1; i < listViewStatisticCrisp.Columns.Count; i++)
            {
                LocalCluster.CGroupList[0].GParamList.Add(new ClusterIII.Model.Param(listViewStatisticCrisp.Columns[i].Text,(double)0));
            }
            //1.2.2)заносим данные
            for (int i = 1; i < listViewStatisticCrisp.Items.Count; i++)
            {
                //Создаём модель данных
                ClusterIII.Model.Cluster Local1Cluster = new ClusterIII.Model.Cluster
                (
                    Convert.ToString(i),//Имя Ряда
                    new List<ClusterIII.Model.Group>(),
                    new List<ClusterIII.Model.Cluster>()
                );
                //Клонируем группы и параметры из шапки
                Local1Cluster.CGroupList.Add(LocalCluster.CGroupList[0].FaceClone());
                //Пишем параметры
                for (int j = 1; j < listViewStatisticCrisp.Items[i].SubItems.Count-1; j++)
                {
                    Local1Cluster.CGroupList[0].GParamList[j].P = 
                        Convert.ToDouble(
                        
                        listViewStatisticCrisp.Items[i].SubItems[j].Text
                        );
                }
                //Отправляем модель данных
                LocalCluster.SCluster.Add(Local1Cluster.FaceClone());
            }

            //2)Отправляем копию данных в ClusterIII
            My_ClusterIII_Form_Main.ProjectsCluster = LocalCluster.FaceClone();
                
            //1.Name = graphControlSeries.GraphPane.Title.Text;
            My_ClusterIII_Form_Main.ShowDialog();            
            //return new Cluster();
        }

        public ClassScroll2 Scroll2 = new ClassScroll2();
        //ClusterIII.ImportsScrolls.ProgramScrolls.FuzzyForecastImportScroll.Scroll2 ;
       
    }
}
