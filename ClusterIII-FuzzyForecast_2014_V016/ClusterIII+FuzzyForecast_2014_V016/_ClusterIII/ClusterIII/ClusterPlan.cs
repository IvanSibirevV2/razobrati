using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClusterIII.Model;
using ClusterIII.View;

namespace ClusterIII
{
    public partial class ClusterPlan : Form
    {
        /// <summary>
        /// Наши данные
        /// </summary>        
        public Cluster MyRealCluster = new Cluster();
        /// <summary>
        /// План кластеризации - выбранные группы и параметры
        /// </summary>
        public List<Group> MyRealGroupList = new List<Group>();   
        /// <summary>
        /// Конструктор формы плана кластеризации
        /// </summary>
        /// <param name="MyCluster">Входящая предметная область</param>
        public ClusterPlan(Cluster MyCluster)
        {
            InitializeComponent();
            MyRealCluster = MyCluster.FaceClone();
            //0)Если нет входных данных то создаём заглушку
            {
                //0.1)Проверка на баги
                bool flag = true;
                if (MyRealCluster.CGroupList.Count == 0)
                {
                    flag = false;
                    MessageBox.Show("Нет групп параметров", "Не фатальная ошибка", MessageBoxButtons.OK);
                }
                if (MyRealCluster.SCluster.Count == 0)
                {
                    flag = false;
                    MessageBox.Show("Нет объектов кластеризации", "Не фатальная ошибка", MessageBoxButtons.OK);
                }
                //0.2)Исправление багов заглушкой
                if (!flag) 
                {
                    MessageBox.Show("Не фатальная ошибка \nГенерирую предметную область", "Ня ^_^", MessageBoxButtons.OK);                    
                    //0.2.1)Создание шапки заглушки
                    MyRealCluster = new Cluster("GenCluster",new Group().GenList(new Group[] {
                                new Group("Group №1",new Param().GenList(new Param[]{new Param("Param №1",(double)0),new Param("Param №2",(double)0)})),
                                new Group("Group №2",new Param().GenList(new Param[]{new Param("Param №1",(double)0),new Param("Param №2",(double)0)})),
                                new Group("Group №3",new Param().GenList(new Param[]{new Param("Param №1",(double)0),new Param("Param №2",(double)0)}))
                            }),new List<Cluster>());
                    //0.2.2)Создание списка подкластеров заглушки
                    MyRealCluster.SCluster.Add(new Cluster());
                    MyRealCluster.SCluster.Add(new Cluster());
                    MyRealCluster.SCluster.Add(new Cluster());
                    MyRealCluster.SCluster.Add(new Cluster());
                    //0.2.3)Некоторое мордатое клонирование ;)
                    MyRealCluster.SameFaceClone();
                    //0.2.4)Присвоение прикольных имён подкластерам
                    for (int i = 0; i < MyRealCluster.SCluster.Count; i++)                    
                        MyRealCluster.SCluster[i].Name = "PidCluster №" + Convert.ToString(i);                    
                }
            }
            //1)Создаём список групп
            MyRealGroupList.Clear();
            foreach (Group LocalGroup in MyRealCluster.CGroupList)
                MyRealGroupList.Add(LocalGroup.FaceClone());
            //2)Периименовываем все названия групп и параметров            
            foreach (Group LocalGroup in MyRealGroupList)
            {
                LocalGroup.Name = Convert.ToString((bool)true);
                foreach (Param LocalParam in LocalGroup.GParamList)
                    LocalParam.Name = Convert.ToString((bool)true);
            }
            //3)Заносим данные на экранн.            
            //3.1)Заносим список групп
            this.checkedListBox1.Items.Clear();            
            for (int i = 0; i < MyRealGroupList.Count; i++)            
                this.checkedListBox1.Items.Add(MyRealCluster.CGroupList[i].Name, Convert.ToBoolean(MyRealGroupList[i].Name));            
        }        
        /// <summary>
        /// Метод загрузки формы
        /// </summary>        
        private void ClusterPlan_Load(object sender, EventArgs e)
        {
            // Изменение размеров формы (В данном случае по умолчанию)
            ClusterPlan_SizeChanged(null, null);
            // Ввода только числа в toolStripTextBox1 - дословно. Это будет 2. (В данном случае по умолчанию)
            toolStripTextBox1_TextChanged(null, null);            
        }
        /// <summary>
        /// Изменение размеров формы
        /// </summary>        
        private void ClusterPlan_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave2(this, this.menuStrip1, this.groupBox1, 5, 5, 5, 5);
        }
        /// <summary>
        /// Изменение размеров рамки groupBox1
        /// </summary>        
        private void groupBox1_SizeChanged(object sender, EventArgs e)
        {
            FormSupport.SizeChanged.MasterSlave3(this.groupBox1, this.checkedListBox1, this.checkedListBox2, 25, 5, 5, 5);
        }
        /// <summary>
        /// Метод подтверждения данных
        /// </summary>        
        private void подтвердитьToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            //1)Создааём изменённую в соответсявии с планом кластеризации предметную область
            Cluster NewCluster = new Cluster();
            //1.1) Копируем название предметной области
            NewCluster.Name = this.MyRealCluster.Name;
            //1.2) Создаём шапку предметной области
            //Перибераем группы
            for (int i = 0; i < this.MyRealCluster.CGroupList.Count; i++)
            {
                Group IGroup = new Group();
                IGroup.Name = this.MyRealCluster.CGroupList[i].Name;
                //Перибераем параметры
                for (int j = 0; j < this.MyRealCluster.CGroupList[i].GParamList.Count; j++)                
                    //Копируем параметр если
                    if(Convert.ToBoolean(this.MyRealGroupList[i].GParamList[j].Name))
                        IGroup.GParamList.Add(this.MyRealCluster.CGroupList[i].GParamList[j].FaceClone());
                //Копируем группы если да
                if (Convert.ToBoolean(this.MyRealGroupList[i].Name))
                    NewCluster.CGroupList.Add(IGroup);
            }
            NewCluster.SCluster.Clear();
            //1.3) Копируем список всего остального
            //Перебираем подкластеры
            for( int i = 0; i < this.MyRealCluster.SCluster.Count ; i ++)
            {
                Cluster ICluster = new Cluster();
                //Копируем название подкластера
                ICluster.Name = this.MyRealCluster.SCluster[i].Name;
                //Перибераем группы
                for (int j = 0; j < this.MyRealCluster.SCluster[i].CGroupList.Count; j++) 
                {
                    Group IGroup = new Group();
                    IGroup.Name = this.MyRealCluster.SCluster[i].CGroupList[j].Name;
                    //Перибераем параметры
                    for (int k = 0; k < this.MyRealCluster.SCluster[i].CGroupList[j].GParamList.Count; k++)
                    {
                        //Копируем параметр если
                        if (Convert.ToBoolean(this.MyRealGroupList[j].GParamList[k].Name))
                            IGroup.GParamList.Add(this.MyRealCluster.SCluster[i].CGroupList[j].GParamList[k].FaceClone());
                    }
                    //Копируем группы если да
                    if (Convert.ToBoolean(this.MyRealGroupList[j].Name))
                        ICluster.CGroupList.Add(IGroup);
                }
                //Перебераем ещё раз параметры - а фиг, не положено =)
                ICluster.SCluster.Clear();
                //Отправляем на луну
                NewCluster.SCluster.Add(ICluster);
            }
            //2)Передаём данные и подтверждаем их
            this.MyRealCluster = NewCluster.FaceClone();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Метод ввода только числа в toolStripTextBox1 - дословно
        /// </summary>        
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (char ch in toolStripTextBox1.Text)            
                if ((Convert.ToInt32(ch) < Convert.ToInt32('0')) || (Convert.ToInt32(ch) > Convert.ToInt32('9')))                
                    toolStripTextBox1.Text = "";                            
            if (toolStripTextBox1.Text.Length == 0) toolStripTextBox1.Text = "2";
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //0)Вывод на экран выбранного, выделенного и чекнутого
            //MessageBox.Show("Выбран №" + Convert.ToString(this.checkedListBox1.SelectedIndex + 1) + " это " + this.checkedListBox1.SelectedItem.ToString() + " он " + Convert.ToString(this.checkedListBox1.CheckedItems.Contains(this.checkedListBox1.SelectedItem)), "Очень большой ня ^_^", MessageBoxButtons.OK);
            //1)Чтение списка групп в соответствии счекнутостью                        
            for (int i = 0; i < this.MyRealGroupList.Count; i++)
                //проверяется содержит ли список чекнутых групп текущюю группу
                if (this.checkedListBox1.CheckedItems.Contains(this.checkedListBox1.Items[i]))
                {
                    this.MyRealGroupList[i].Name = Convert.ToString((bool)true);
                }
                else
                {
                    this.MyRealGroupList[i].Name = Convert.ToString((bool)false);
                }
            //2)Вывод на экран списка параметров в соответствии с выделенной группой
            {
                //Номер выбранной группы
                int qwerty = this.checkedListBox1.SelectedIndex;
                //Перибераем  параметры в выбранной группе
                this.checkedListBox2.Items.Clear();
                for (int i = 0; i < this.MyRealGroupList[qwerty].GParamList.Count; i++)
                {   
                    this.checkedListBox2.Items.Add
                        (
                            MyRealCluster.CGroupList[qwerty].GParamList[i].Name,  
                            Convert.ToBoolean(MyRealGroupList[qwerty].GParamList[i].Name)
                        );
                }
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int qwerty = this.checkedListBox1.SelectedIndex;
            //1)Чтение списка параметров в соответствии счекнутостью                        
            for (int i = 0; i < this.MyRealGroupList[qwerty].GParamList.Count; i++)
                //проверяется содержит ли список чекнутых параметров текущюю группу
                if (this.checkedListBox2.CheckedItems.Contains(this.checkedListBox2.Items[i]))
                {
                    this.MyRealGroupList[qwerty].GParamList[i].Name = Convert.ToString((bool)true);
                }
                else
                {
                    this.MyRealGroupList[qwerty].GParamList[i].Name = Convert.ToString((bool)false);
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
