using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClusterIII.Model
{
    /// <summary>
    /// Класс - Группа
    /// </summary>   
    [Serializable]
    public class Group
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private string TName = "NoName";
        /// <summary>
        /// Название группы
        /// </summary>
        [DisplayName("Имя")]
        [Description("Название группы.(Name)")]
        [Category("Группа параметров(Group)")]
        public string Name
        {
            get { return TName; }
            set { TName = value; }
        }
        /// <summary>
        /// Список параметров
        /// </summary>   
        public List<Param> TGroopParamList = new List<Param>();
        /// <summary>
        /// Список параметров
        /// </summary>     
        [DisplayName("Коллекция параметров")]
        [Description("Коллекция параметров.(Name)")]
        [Category("Группа параметров(Group)")]
        public List<Param> GParamList
        {
            get { return TGroopParamList; }
            set { TGroopParamList = value; }
        }
        #region Основные методы
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="LocatName">Название группы</param>
            /// <param name="LocalGParamList">Список параметров</param>
            public Group(string LocatName, List<Param> LocalGParamList)
            {
                this.Name = LocatName;
                this.GParamList = LocalGParamList;
            }
        
            /// <summary>
            /// Конструктор
            /// </summary>        
            public Group()
            {
            }

            /// <summary>
            /// Метод создания копий класса
            /// </summary>
            public Group FaceClone()
            {
                List<Param> LocalGParamList = new List<Param>();
                LocalGParamList.Clear();
                foreach (Param LocalParam in TGroopParamList)             
                    LocalGParamList.Add(LocalParam.FaceClone());            
                return new Group(TName, LocalGParamList);
            }
        #endregion
        #region Особые методы
            /// <summary>
            /// Метод проверки на соответствие Group
            /// </summary>
            public bool EqualTrue(Group LocalGroup)
            {
                bool rez=true;
                if (!(this.Name == LocalGroup.Name)) 
                    rez = false;
                if (!(new Param().ListEqualTrue(this.GParamList, LocalGroup.GParamList))) 
                    rez = false;
                return rez;
            }

            /// <summary>
            /// Метод проверки на соответствие List(Param)
            /// </summary>        
            public bool ListEqualTrue(List<Group> GroupList1, List<Group> GroupList2)
            {
                bool flag = true;
                if (GroupList1.Count == GroupList2.Count)
                {
                    for (int i = 0; i < GroupList1.Count; i++)
                        if (!GroupList1[i].EqualTrue(GroupList2[i]))
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
            public List<Group> GenList(Group[] GroupArray) 
            {
                List<Group> GroupList = new List<Group>();
                foreach (Group LocalGroup in GroupArray)
                {
                    GroupList.Add(LocalGroup);
                }
                return GroupList;
            }
        #endregion
    }
}
