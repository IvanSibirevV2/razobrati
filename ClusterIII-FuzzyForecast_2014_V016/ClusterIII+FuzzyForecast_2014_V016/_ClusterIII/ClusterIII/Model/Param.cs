using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace ClusterIII.Model
{
    /// <summary>
    /// Класс - парамет
    /// </summary>          
    [Serializable]
    public class Param
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private string TName = "NoName";
        /// <summary>
        /// Название кластера
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название параметра.(Param)")]
        [Category("Параметр(Param)")]
        public string Name
        {
            get { return TName; }
            set { TName = value; }

        }
        private double TP = new double();
        /// <summary>
        /// Название параметра
        /// </summary>
        [DisplayName("Сам параметр")]
        [Description("Название параметра.(Param)")]
        [Category("Группа параметров(Group)")]
        public double P
        {
            get { return TP; }
            set { TP = value; }
        }
        #region Основные методы
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="LocalP">Объект</param>
            /// <param name="LocalName">Название параметра</param>
            public Param(string LocalName, double LocalP)
            {
                this.Name = LocalName;
                this.P = LocalP;
            }
            /// <summary>
            /// Конструктор
            /// </summary>
            public Param()
            {
            }

            /// <summary>
            /// Метод создания копий класса
            /// </summary>
            public Param FaceClone()
            {
                return new Param(TName, TP);
            }
        #endregion
        #region Особые методы
            /// <summary>
            /// Метод проверки на соответствие Param
            /// </summary>        
            public bool EqualTrue(Param LocalParam)
            {
                bool flag = true;
                if (this.Name != LocalParam.Name) flag = false;
                if (this.P != LocalParam.P) flag = false;
                return flag;
            }
            /// <summary>
            /// Метод проверки на соответствие List(Param)
            /// </summary>        
            public bool ListEqualTrue(List<Param> ParamList1,List<Param> ParamList2)
            {
                bool flag = true;
                if (ParamList1.Count == ParamList2.Count)
                {
                    for (int i = 0; i < ParamList1.Count; i++)                
                        if (!ParamList1[i].EqualTrue(ParamList2[i]))
                            flag = false;
                }
                else 
                {
                    flag = false;
                }
                return flag;
            }


            /// <summary>
            /// Метод создания списка параметров
            /// </summary>
            public List<Param> GenList(Param[] ParamArray)
            {
                List<Param> ParamList = new List<Param>();
                foreach (Param LocalParam in ParamArray)
                {
                    ParamList.Add(LocalParam);
                }
                return ParamList;
            }
        #endregion
    }
}
