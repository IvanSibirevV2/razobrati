using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClusterIII.View;
using ClusterIII.Model;
using ClusterIII.ClusterMethods.CH;
using ClusterIII.Converts;

namespace ClusterIII
{
    public partial class FormResult : Form
    {        
        public FormResult()
        {
            InitializeComponent();
        }

        public FormResult(Cluster SuperCluster, int N,int SuperE)
        {//CH
            //Cluster sSuperCluster = SuperCluster.FaceClone();
            InitializeComponent();
            DataTable MyDataTableGridView1 = new DataTable();
            //DataTable MyDataTableGridView2 = ViewConvert.ClusterToDataTableV0(SuperCluster);
            DataTable MyDataTableGridView2 = ViewConvert.ClusterToDataTableV0(ClusterConvertTo.NormCluster( SuperCluster));
            this.dataGridView2.DataSource = MyDataTableGridView2;
            
            #warning fahasgfga
            ///ClusterConvertTo

            #region Сценарий Центройдного метода кластеризации
            if (SuperE == 1)
            {
                this.Text = "Центройдный метод";

                CHclassV001 CH = new CHclassV001();
                //получаем таблицу результатов кластеризации
                MyDataTableGridView1 = ViewConvert.ClusterToDataTableV1(CH.TurboWeighedGroups(SuperCluster.FaceClone(), N), SuperCluster.FaceClone());
                this.dataGridView1.DataSource = MyDataTableGridView1;
                //this.dataGridView2.DataSource = ViewConvert.ClusterToDataTableV0(SuperCluster);
                #region Сбор статистики  и вывод на экран.
                //Заранее извиняюсь за эту лапшу. Не нащёл другого БЫСТРОГО и ПРОСТОГО способа сбора статистических данных КРОМЕ КАК В ЛОБ....
                //Комментарии !!!НЕ УДАЛЯТЬ!!!, а то в коде потеряется последняя искра смысла и он станет непроходимым болотом для читателя.=)
                //Можно написать и короче и красивее, но нет времени на чтение справочников !!!Час ночи!!!...
                #region План действий:
                //1) Получить список предприятий кластера
                //2) Получить не повторяющийся список значений параметра
                //3) Подсчитать кол-во вхождений каждого параметра и вывести это на экран
                #endregion
                //Сюда скидываем всю нашу информацию по статистике
                List<string> RezStringList = new List<string>();
                //перебираем кластеры
                for (int Cluster_I_ = 1; Cluster_I_ < MyDataTableGridView1.Columns.Count; Cluster_I_++)
                {
                    RezStringList.Add("Кластер C" + Convert.ToString(Cluster_I_));
                    RezStringList.Add("В данный кластер вошли: ");
                    //1) Получить список предприятий кластера
                    //Сюда кидаем предприятия этого кластера
                    Cluster ThisCluster = new Cluster();
                    //перебираем все предприятия В экранной таблице
                    for (int EnterPrise_I_ = 0; EnterPrise_I_ < MyDataTableGridView1.Rows.Count; EnterPrise_I_++)
                    {
                        //Если коэффициент принадлежности 1 то это предприятие нашего кластера
                        if (Convert.ToString(MyDataTableGridView1.Rows[EnterPrise_I_][Cluster_I_]) == "1") 
                        { 
                            //Мы нашли предприятие, принадлежащие этому кластеру, давайти найдём этот объект и скопируем
                            foreach (Cluster LSCluster in SuperCluster.SCluster)
                            {                                
                                // ищем
                                if (LSCluster.Name == Convert.ToString(MyDataTableGridView1.Rows[EnterPrise_I_][0]))
                                {
                                    //копируем, когда нашли
                                    ThisCluster.SCluster.Add(LSCluster);
                                    RezStringList.Add(LSCluster.Name+";");
                                }
                            }
                        }
                    }
                    //Мы получили список предприятий в кластере
                    RezStringList.Add("<Далее>");
                    //2)получить не повторяющийся список значений параметра
                    if (ThisCluster.SCluster.Count>0)
                    {                        
                        //2.1)Нужно скопировать стиль в центр кластера
                        //перебираем группы                            
                        ThisCluster.CGroupList.Clear();
                        for(int Local_000_I_ = 0; Local_000_I_ < ThisCluster.SCluster[0].CGroupList.Count; Local_000_I_++)
                        {
                            //пишем группы в кластер
                            ThisCluster.CGroupList.Add
                                (
                                    ThisCluster.SCluster[0].CGroupList[Local_000_I_].FaceClone()
                                );
                        }
                        //Центр кластера скопирован (стиль, то есть параметры и их группы)
                        //2.2)перебираем наши чудо параметры                        
                        //Перибераем группы
                        //foreach (Group Enterprise_Group_ in ThisCluster.CGroupList)
                        for (int Local_001_I_ = 0; Local_001_I_ < ThisCluster.CGroupList.Count; Local_001_I_++)
                        {
                            //перебираем параметры
                            //foreach (Param Enterprise_Param_ in Enterprise_Group_.GParamList)
                            for (int Local_002_I_ = 0; Local_002_I_ < ThisCluster.CGroupList[Local_001_I_].GParamList.Count; Local_002_I_++)
                            {
                                RezStringList.Add
                                    (
                                        "В данном кластере встречаются значения параметра <" + 
                                        ThisCluster.CGroupList[Local_001_I_].Name+ ">.<" 
                                        + ThisCluster.CGroupList[Local_001_I_].GParamList[Local_002_I_].Name + ">"
                                    );
                                //Мы получили "координаты параметра"
                                //2.2.1)Смотрим этот самый параметр в предприятиях
                                //Сюда складываем наши значения параметра
                                List<double> DoubleList = new List<double>();
                                //Перибираем предприятия
                                foreach (Cluster Enterprise_Cluster_ in ThisCluster.SCluster)
                                {
                                    //Наш параметр
                                    DoubleList.Add
                                        (
                                            Enterprise_Cluster_.CGroupList[Local_001_I_].GParamList[Local_002_I_].P
                                        );
                                }
                                //Значения параметра собраны                                                                
                                //2.2.2)Получаем не повторяющийся список значений параметра
                                //Копируем на всякий случай
                                List<double> DoubleListClone = new List<double>();
                                DoubleListClone.AddRange(DoubleList);
                                
                                //Смотрим исходный спиок значений параметра
                                foreach (double DClone in DoubleListClone)
                                {                                    
                                    //Этот цикл на случай исли итераций будет недостаточно, то есть полно одинаковых значений параметра
                                    foreach (double CClone in DoubleListClone)
                                    {
                                        int E = 0;
                                        //В цикле ищем второе вхождение данного параметра
                                        for (int i = 0; i < DoubleList.Count; i++)
                                        {
                                            if (DClone == DoubleList[i])
                                                E++;
                                            if (E >= 2)
                                                DoubleList.RemoveAt(i);
                                        }
                                    }
                                }
                                //По идее мы должны получит не повторяющийся список значений параметра в DoubleList                                
                                //foreach(double d in DoubleList)RezStringList.Add(Convert.ToString(d));
                                //3)Подсчитать кол-во вхождений значений каждого параметра и вывести это на экран
                                //прерибераем не повторяющиеся значения
                                foreach(double d in DoubleList)
                                {
                                    int e = 0;
                                    //перибекраем все значения
                                    foreach (double DClone in DoubleListClone)
                                    {
                                        //считаем кол-во вхождений значения
                                        if (d == DClone)
                                        {
                                            e++;
                                        }                                    
                                    }
                                    //мы получили в e кол-во вхождений значений каждого параметра 
                                    RezStringList.Add(Convert.ToString(d)+" ("+Convert.ToString(100*e/ThisCluster.SCluster.Count)+"%)");
                                    //осталось нормировать на кол-во предприятий в кластере
//#warning  Работаю здесь
                                }
                            }                            
                        }
                    }
                    ThisCluster.SCluster.Clear();
                }
                this.listBox1.Items.AddRange(RezStringList.ToArray());
                #endregion
            }
            #endregion
            #region Сценарий FCM метода кластеризации
            if (SuperE == 2)
            {
                this.Text = "Ошибка. Данный метод не работоспособен =(";
                /*
                this.dataGridView1.DataSource = FCMClass.FCM
                (
                    N,
                    1.6,
                    CHclass.WeighedGroups(SuperCluster.FaceClone(), N),
                    SuperCluster
                );
                 * */        
            }
            #endregion
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            FormResult_SizeChanged(null, null);            
        }

        private void FormResult_SizeChanged(object sender, EventArgs e)
        {            
            FormSupport.SizeChanged.MasterSlave1(this, this.tabControl1, 5, 5, 5, 5);            
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            int UpShift=5;
            int DownShift=40;
            int LeftShift=5;
            int RightShift=10;
            FormSupport.SizeChanged.MasterSlave1(this.tabControl1,this.dataGridView1, UpShift, DownShift, LeftShift, RightShift);
            FormSupport.SizeChanged.MasterSlave1(this.tabControl1, this.dataGridView2, UpShift, DownShift, LeftShift, RightShift);
            FormSupport.SizeChanged.MasterSlave1(this.tabControl1, this.listBox1, UpShift, DownShift, LeftShift, RightShift);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
