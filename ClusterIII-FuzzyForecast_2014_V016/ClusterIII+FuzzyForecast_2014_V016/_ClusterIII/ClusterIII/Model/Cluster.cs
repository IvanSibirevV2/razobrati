using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Diagnostics;
using System.Collections.Specialized;
namespace ClusterIII.Model
{
    /// <summary>
    /// Этот метод груперует два подкластера в один
    /// </summary>     
    [Serializable]
    public class Cluster
    {
        /// <summary>
        /// Истиное имя кластера.
        /// </summary>
        private string TName = "NoName";                
        /// <summary>
        /// Название кластера
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название кластера.(Name)")]
        [Category("Кластер(Cluster)")]
        public string Name
        {
            get { return TName; }
            set { TName = value; }            
        }
        /// <summary>
        /// Центр кластера.
        /// </summary>   
        private List<Group> TClusterCenter = new List<Group>();
        /// <summary>
        /// Центр кластера
        /// </summary>                        
        [DisplayName("Группы")]
        [Description("Группы.(ClusterCenter)")]
        [Category("Кластер(Cluster)")]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public List<Group> CGroupList
        {
            get { return TClusterCenter; }
            set { TClusterCenter = value; }
        }
        /// <summary>
        /// Список подкластеров
        /// </summary>                
        public List<Cluster> TStructureCluster = new List<Cluster>();
        /// <summary>
        /// Список подкластеров
        /// </summary>        
        [DisplayName("Содержимое кластер")]
        [Description("Содержимое кластера.(StructureCluster)")]
        [Category("Кластер(Cluster)")]
        public List<Cluster> SCluster
        {
            get { return TStructureCluster; }
            set { TStructureCluster = value; }
        }
        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="LocalName">Название кластера</param>
        /// <param name="LocalCGroupList">Центр кластера</param>
        /// <param name="LocalSCluster">Список подкластеров</param>
        public Cluster(string LocalName, List<Group> LocalCGroupList, List<Cluster> LocalSCluster)
        {
            this.Name = LocalName;
            this.CGroupList = LocalCGroupList;
            this.SCluster = LocalSCluster;
        }
        /// <summary>
        /// Конструктор
        /// </summary>        
        public Cluster()
        {
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="LocalName">Название кластера</param>
        /// <param name="LocalCGroupList">Центр кластера</param>
        /// <param name="LocalSCluster">Список подкластеров</param>
        public Cluster(string LocalName, int GroupCount, int ParamCount, int SClusterCount)
        {
            Random rng = new Random();
            // Предположим, что здесь много логики
             
            this.Name = LocalName;
            GroupCount = rng.Next(10);
            ParamCount = rng.Next(10);
            this.CGroupList.Clear();
            for (int i = 0; i < GroupCount; i++) 
            {
                this.CGroupList.Add(new Group());
                this.CGroupList[i].Name = "Group № "+Convert.ToString(i);
                for (int j = 0; j < ParamCount; j++)
                {
                    this.CGroupList[i].GParamList.Add(new Param());
                    this.CGroupList[i].GParamList[j].Name = "Param № " + Convert.ToString(j);
                    
                }
            }      
        }


        #endregion
        #region Основные методы
        
        /// <summary>
        /// Метод создания копий класса
        /// </summary>        
        public Cluster FaceClone()
        {
            List<Group> LocalCGroupList = new List<Group>();
            LocalCGroupList.Clear();
            foreach(Group LocalGroupin in CGroupList)
                LocalCGroupList.Add(LocalGroupin.FaceClone());
            List<Cluster> LocalSCluster= new List<Cluster>();
            LocalSCluster.Clear();
            foreach (Cluster LocalCluster in SCluster)
            {
                Cluster LlCluster = new Cluster();
                LlCluster.Name = LocalCluster.Name;
                LlCluster.CGroupList.AddRange(LocalCluster.CGroupList.ToArray());
                LlCluster.SCluster.AddRange(LocalCluster.SCluster.ToArray());
                LocalSCluster.Add(LlCluster.FaceClone());
            }
            return new Cluster(TName, LocalCGroupList, LocalSCluster);            
        }

        /// <summary>
        /// Метод создания копий класса, за исключением SCluster (он затирается), своего рода централизованная смена стиля 
        /// </summary>        
        public Cluster SameFaceClone()
        {
            //Пробегаем все подкластеры
            foreach (Cluster MyCluster in this.SCluster)
            {         
                MyCluster.CGroupList.Clear();
                MyCluster.Name = this.Name;
                for (int i = 0; i < this.CGroupList.Count; i++)                
                    MyCluster.CGroupList.Add(this.CGroupList[i].FaceClone());                                    
            }            
            return this.FaceClone();
        }

        /// <summary>
        /// Этот медод осуществляет пересчет центра если есть по чему пересчитывать.
        /// </summary>
        public void StandartCenterReloader()
        {
            //Обнуляем параметры в кластере
            foreach (Group LocalGroup in this.CGroupList)
                foreach (Param LocalParam in LocalGroup.GParamList)
                    LocalParam.P = 0;
            //Суммируем параметры в подкластере кластере
            foreach (Cluster LocalCluster in this.SCluster)
            {
                int i = 0;
                foreach (Group MyGroup in LocalCluster.CGroupList)
                {
                    int j=0;
                    //this.CGroupList.Add(new Group());//
                    this.CGroupList[i].Name = MyGroup.Name;//
                    foreach (Param MyParam in MyGroup.GParamList)
                    {
                        //this.CGroupList[i].GParamList.Add(new Param());//
                        this.CGroupList[i].GParamList[j].Name = MyParam.Name;//
                        this.CGroupList[i].GParamList[j].P = this.CGroupList[i].GParamList[j].P + MyParam.P;
                        j++;
                    }
                    i++;
                }
            }
            //Получаем среднеорифметическое
            foreach (Group MyGroup in this.CGroupList)
                foreach (Param MyParam in MyGroup.GParamList)
                    MyParam.P = MyParam.P / this.SCluster.Count(); 
        }

        /// <summary>
        /// Этот медод удаления подкластера
        /// </summary>
        private void RemoveAt(int i)
        {
            if ((i >= 0) && (i < this.SCluster.Count))
                this.SCluster.RemoveAt(i);
            //StandartCenterReloader();
        }

        /// <summary>
        /// Данный метод берёт все подкластеры данного кластера.
        /// </summary>
        public List<Cluster> GetInClusterToList()
        {
            //Cluster MyCluster = new Cluster();
            List<Cluster> rezSCluster = new List<Cluster>();
            rezSCluster.Clear();
            if (this.SCluster.Count == 0)
            {
                rezSCluster.Add(this);
            }
            else
                foreach (Cluster MyLocalCluster in this.SCluster)
                {
                    rezSCluster.AddRange(MyLocalCluster.GetInClusterToList());
                }
            return rezSCluster;
        }

        /// <summary>
        /// Данный метод берёт все подкластеры данного кластера.
        /// </summary>
        public List<Cluster> GetInClusterToListTurbo()
        {
            FormProgressBar Progres = new FormProgressBar(0, 0);
            Progres.Text = "TurboGetInClusterToList";
            Progres.Show();
            //Cluster MyCluster = new Cluster();
            List<Cluster> rezSCluster = new List<Cluster>();
            rezSCluster.Clear();
            //Заносим списком все значения
            rezSCluster.AddRange(this.SCluster);
            {
                for (int i = 0; i < rezSCluster.Count; i++)
                {
                    ;
                    Progres.Text = "TurboGetInClusterToList" + Convert.ToString(rezSCluster.Count);
                    if (rezSCluster[i].SCluster.Count == 0)
                    { 
                    }
                    else 
                    {
                        rezSCluster.AddRange(rezSCluster[i].SCluster);
                        rezSCluster.RemoveAt(i);
                        i--;
                    }
                }
                /*
                for (int i = 0; i < rezSCluster.Count; i++)
                {
                    for (int j = 0; j < rezSCluster.Count; j++)
                    {
                        if(i!=j)
                        {
                            ;
                            //if (i == -1) { i = 0; }
                            if (rezSCluster[i].Name == rezSCluster[j].Name)
                            {
                                rezSCluster.RemoveAt(i);
                                i--;
                                j--;                                
                            }
                        }
                    }                 
                }                
                */
            }
            Progres.Close();
            return rezSCluster;
        }

        /// <summary>
        /// Этот метод груперует два подкластера в один
        /// </summary>
        public Cluster RezGrouping(int i, int j, string NewName)
        {
            if (
                (this.SCluster.Count >= 2) &&
                (i >= 0) &&
                (j >= 0) &&
                (i != j) &&
                (i < this.SCluster.Count) &&
                (j < this.SCluster.Count)
                )
            {
                ;
                Cluster MyLocalClusterR = this.SCluster[i].FaceClone();
                MyLocalClusterR.Name = NewName;
                //MyLocalClusterR.SCluster.Clear();               

                MyLocalClusterR.SCluster.Add(this.SCluster[i]);
                MyLocalClusterR.SCluster.Add(this.SCluster[j]);
                MyLocalClusterR.StandartCenterReloader();
          //      this.SCluster.Add(MyLocalClusterR);
                
                if (i < j)
                {
                    this.SCluster.RemoveAt(i);
                    this.SCluster.RemoveAt(j - 1);
                }
                else
                {
                    this.SCluster.RemoveAt(j);
                    this.SCluster.RemoveAt(i - 1);
                }
                return MyLocalClusterR;
            }
            return new Cluster();
        }

        /// <summary>
        /// Этот метод груперует два подкластера в один
        /// </summary>
        public void Grouping(int i, int j, string NewName)
        {
            if (
                (this.SCluster.Count >= 2) &&
                (i >= 0) &&
                (j >= 0) &&
                (i != j) &&
                (i < this.SCluster.Count) &&
                (j < this.SCluster.Count)
                )
            {
                ;
                Cluster MyLocalClusterR = this.SCluster[i].FaceClone();
                MyLocalClusterR.Name = NewName;
                //MyLocalClusterR.SCluster.Clear();               

                MyLocalClusterR.SCluster.Add(this.SCluster[i]);
                MyLocalClusterR.SCluster.Add(this.SCluster[j]);
                MyLocalClusterR.StandartCenterReloader();
                this.SCluster.Add(MyLocalClusterR);
                ;

                if (i < j)
                {
                    this.SCluster.RemoveAt(i);
                    this.SCluster.RemoveAt(j-1);
                }
                else
                {
                    this.SCluster.RemoveAt(j);
                    this.SCluster.RemoveAt(i - 1);
                }
            }            
        }
        /// <summary>
        /// Этот метод 1 предназначен для избегания приравнивания ссылок. Мда Каряво сказано.
        ///Но этот метод позволяет работать с программой долго и стабильно.
        ///
        /// ВОЗМОЖНО УЖЕ НЕГДЕ НЕ ИСПОЛЬЗУЕТСЯ - Заменён на FaceClone()
        /// 
        /// </summary>
        public Cluster Copy()
        {
            Cluster RezCluster = new Cluster();
            RezCluster.Name = this.Name;
            int i = 0;
            foreach (Group MyLocalGroup in this.CGroupList)
            {
                RezCluster.CGroupList.Add(new Group());
                RezCluster.CGroupList[i].Name = MyLocalGroup.Name;
                int j = 0;
                foreach (Param MyLocalParam in MyLocalGroup.GParamList)
                {
                    RezCluster.CGroupList[i].GParamList.Add(new Param());
                    RezCluster.CGroupList[i].GParamList[j].Name = MyLocalParam.Name;
                    RezCluster.CGroupList[i].GParamList[j].P = MyLocalParam.P;
                    j++;
                }
                i++;
            }
            i = 0;
            foreach (Cluster MyLocalCluster in this.SCluster)
            {
                RezCluster.SCluster.Add(MyLocalCluster.Copy());
                i++;
            }
            return RezCluster;
        }
        #endregion
        #region Особые методы
        /// <summary>
        /// Метод проверки на соответствие Cluster
        /// </summary>
        public bool EqualTrue(Cluster LocalCluster)
        {
            bool rez = true;
            //Проверка имени
            if (!(this.Name == LocalCluster.Name))
                rez = false;
            //Проверка списка групп
            if (!(new Group().ListEqualTrue(this.CGroupList, LocalCluster.CGroupList)))
                rez = false;
            //Проверка списка подкластеров            
            if (!(new Cluster().ListEqualTrue(this.SCluster, LocalCluster.SCluster)))
                rez = false;
            
            return rez;
        }

        /// <summary>
        /// Метод проверки на соответствие List(Cluster)
        /// </summary>        
        public bool ListEqualTrue(List<Cluster> ClusterList1, List<Cluster> ClusterList2)
        {
            bool flag = true;
            if (ClusterList1.Count == ClusterList2.Count)
            {
                for (int i = 0; i < ClusterList1.Count; i++)
                    if (!ClusterList1[i].EqualTrue(ClusterList2[i]))
                        flag = false;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Метод создания списка групп
        /// </summary>
        public List<Cluster> GenList(Cluster[] ClusterArray)
        {
            List<Cluster> ClusterList = new List<Cluster>();
            foreach (Cluster LocalGroup in ClusterArray)
            {
                ClusterList.Add(LocalGroup);
            }
            return ClusterList;
        }
        #endregion
    }
}
