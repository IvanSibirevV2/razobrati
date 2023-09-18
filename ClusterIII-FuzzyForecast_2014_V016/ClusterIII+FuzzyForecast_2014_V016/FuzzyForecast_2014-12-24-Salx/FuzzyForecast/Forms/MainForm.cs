using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ZedGraph;
using FuzzyLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace FuzzyForecast
{
    public partial class MainForm : Form
    {

        private Project currentProject;
        private ModelSeries currentSeries;
        private ModelResult currentResult;
        private TreeNode currentModelSeriesTN;

        private readonly string appDir;

        public MainForm()
        {
            InitializeComponent();
            DrawHelper.CleanseGraph(graphControlSeries);
            DrawHelper.CleanseGraph(graphControlTerms);
            DrawHelper.CleanseGraph(graphControlTTend);
            DrawHelper.CleanseGraph(graphControlRTend);
            DrawHelper.CleanseGraph(graphControlDiff);
            DrawHelper.CleanseGraph(graphControlPrecision);

            appDir = Application.StartupPath + "\\";
            AddDefaultProject();

            ShowProgress = true;


            //var filelist = Directory.GetFiles(@"d:\tsN_new_format\");
            //Parallel.ForEach(filelist, currentFile =>
            //    {

            //    });

            //foreach (var item in filelist)
            //{
            //    _temp.save(_temp.doit(item));
            //}

            //foreach (var item in filelist)
            //{
            //    _temp._save(_temp.free_doit(item));
            //}
            //foreach (var item in filelist)
            //{
            //    _temp.last_doit(item);
            //}
        }


        private void ClearSeriesShow()
        {
            tabControlGraphs.Visible = false;
            splitContainerMain.Panel2Collapsed = true;
            toolStripSeries.Visible = false;

            //удаляем все модели
            while (tabControlGraphs.TabPages.Count > 2)
            {
                tabControlGraphs.TabPages.RemoveAt(tabControlGraphs.TabPages.Count - 1);
            }

            listViewSeries.Items.Clear();
            toolStripComboBoxSeriesList.Items.Clear();
            splitContainerTop.Panel2.BackColor = SystemColors.ControlDark;

            currentSeries = null;
            currentResult = null;
            currentModelSeriesTN = null;

            toolStripStatusLabel.Text = "";
        }

        private void ShowCurrentSeries()
        {
            if (currentSeries == null)
            {
                ClearSeriesShow();
                return;
            }

            tabControlGraphs.Visible = true;
            splitContainerMain.Panel2Collapsed = false;
            toolStripSeries.Visible = true;

            //удаляем все модели
            while (tabControlGraphs.TabPages.Count > 2)
            {
                var tp = tabControlGraphs.TabPages[tabControlGraphs.TabPages.Count - 1];
                tabControlGraphs.TabPages.Remove(tp);
            }

            listViewSeries.Items.Clear();
            AddSeriesToList(currentSeries.series);

            //добавляем новые модели
            foreach (ModelResult modelResult in currentSeries.Results)
            {
                var muc = AddModelControl(modelResult);
                if (muc != null)
                {
                    muc.ShowModel();
                    AddSeriesToList(modelResult);
                }
            }

            DrawSeries(currentSeries.series);
            SelectTabPage(0, true);
            DrawACLScale();
        }

        private void DrawACLScale()
        {
            DrawHelper.CleanseGraph(graphControlTerms);
            DrawHelper.CleanseGraph(graphControlTTend);
            DrawHelper.CleanseGraph(graphControlRTend);
            DrawHelper.CleanseGraph(graphControlDiff);
            DrawHelper.CleanseGraph(graphControlPrecision);

            ACLScale aclScale = currentSeries.ACLSeries.Scale;

            DrawHelper.DrawFuzzyVariable(graphControlTerms, aclScale.BaseScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlTTend, aclScale.TendBaseTypesScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlRTend, aclScale.TendIntensityScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlDiff, aclScale.TendDiffScale.Grades);
            DrawHelper.DrawFuzzyVariable(graphControlPrecision, aclScale.TendPrecisionScale.Grades);
        }


        private void DrawSeries(Series f)
        {
            f.CalcFunction();
            DrawHelper.CleanseGraph(graphControlSeries);
            DrawHelper.DrawCraph(graphControlSeries, f, Color.Red, true);
            graphControlSeries.GraphPane.Title.IsVisible = true;
            graphControlSeries.GraphPane.Title.Text = f.PointList.Name;
        }

        private void AddSeriesToGraph(Series f, Color color)
        {
            f.CalcFunction();
            DrawHelper.DrawCraph(graphControlSeries, f, color, false);
        }

        private void DrawSelectedSeries()
        {
            if (toolStripComboBoxSeries.Items.Count == 0)
                return;

            var spl = toolStripComboBoxSeries.SelectedItem as SPointList;

            if (spl == null)
                return;

            DrawHelper.CleanseGraph(graphControlStat);
            graphControlStat.GraphPane.Title.IsVisible = false;
            DrawHelper.DrawPointList(graphControlStat, spl, Color.Blue, SymbolType.Default, true);
        }

        private void ShowSelectedPoints()
        {
            if (toolStripComboBoxSeries.Items.Count == 0)
                return;

            var spl = toolStripComboBoxSeries.SelectedItem as SPointList;

            if (spl == null)
                return;

            var gf = new GraphForm(spl);
            gf.ShowDialog();
        }

        private void FillComboBoxSeries(ModelResult mr)
        {
            toolStripComboBoxSeries.Items.Clear();
            foreach (var pointList in mr.PointLists)
            {
                toolStripComboBoxSeries.Items.Add(pointList);
            }
            toolStripComboBoxSeries.SelectedIndex = 0;
        }

        private void FillStatus(ModelResult mr)
        {
            if (mr.ModelType != ForecastModelType.None)
                toolStripStatusLabel.Text = "Текущая модель: " + mr.ForecastModel.ModelInfoFlat;
            else
                toolStripStatusLabel.Text = "";
        }

        private void ShowModelInfo(ModelResult mr)
        {
            if (mr == null)
                return;

            currentResult = mr;

            listViewStatisticCrisp.Columns.Clear();
            listViewStatisticCrisp.Items.Clear();

            listViewStatisticCrisp.Columns.Add("№");

            listViewStatisticFuzzy.Columns.Clear();
            listViewStatisticFuzzy.Items.Clear();

            listViewStatisticFuzzy.Columns.Add("№");


            foreach (var columnName in mr.ColumnNamesCrisp)
            {
                listViewStatisticCrisp.Columns.Add(columnName, columnName);
            }

            foreach (var columnName in mr.ColumnNamesFuzzy)
            {
                listViewStatisticFuzzy.Columns.Add(columnName, columnName);
            }

            int i = 0;
            foreach (var list in mr.ResultsCrisp)
            {
                var lvi = listViewStatisticCrisp.Items.Add(i.ToString(), i.ToString());
                foreach (var s in list)
                {
                    lvi.SubItems.Add(s);
                }
                i++;
            }

            i = 0;
            foreach (var list in mr.ResultsFuzzy)
            {
                var lvi = listViewStatisticFuzzy.Items.Add(i.ToString(), i.ToString());
                foreach (var s in list)
                {
                    lvi.SubItems.Add(s);
                }
                i++;
            }

            FillComboBoxSeries(mr);
            FillStatus(mr);
        }

        private void AddDefaultProject()
        {
            const string projectName = "Новый проект";
            AddNewProject(projectName);
        }

        private void AddNewProject(string name)
        {
            treeViewSeries.Nodes.Clear();
            var tnPrj = treeViewSeries.Nodes.Add(name, name, 0, 0);
            currentProject = new Project(name);
            tnPrj.Tag = currentProject;
            tabControlGraphs.Visible = false;
            splitContainerMain.Panel2Collapsed = true;
        }

        private void AddModelSeries(ModelSeries ms, bool addToProject)
        {
            currentModelSeriesTN = LoadModelSeries(ms);
            if (addToProject)
            {
                currentProject.seriesList.Add(ms);
                currentProject.WasChanged = true;
            }
            currentSeries = ms;

        }

        private TreeNode LoadModelSeries(ModelSeries ms)
        {
            TreeNode tnPrj = treeViewSeries.Nodes[0];
            var tnMS = tnPrj.Nodes.Add(ms.series.PointList.Name, ms.series.PointList.Name, 1, 1);
            tnMS.Tag = ms;
            tnMS.Nodes.Add("Шкала", "Шкала", 2, 2);
            tnMS.Nodes.Add("Ряд", "Ряд", 3, 3);
            tnPrj.ExpandAll();

            AddModelSeriesToComboBox(ms);
            //AddSeriesToList(ms.series);
            return tnMS;
        }

        private void DeleteModelSeries(TreeNode tnMS)
        {
            treeViewSeries.Nodes[0].Nodes.Remove(tnMS);
            var ms = tnMS.Tag as ModelSeries;
            currentProject.seriesList.Remove(ms);
            currentProject.WasChanged = true;
            DeleteModelSeriesFromComboBox(ms);
            if (currentSeries == ms)
            {
                if (currentProject.seriesList.Count > 0)
                {
                    SetCurrentSeries(currentProject.seriesList[0]);
                }
                else
                {
                    SetCurrentSeries(null as ModelSeries);
                }
            }
            else
            {
                ShowCurrentSeries();
            }
        }

        private void AddModelSeriesToComboBox(ModelSeries ms)
        {
            toolStripComboBoxSeriesList.Items.Add(ms);
            toolStripComboBoxSeriesList.SelectedIndex = toolStripComboBoxSeriesList.Items.Count - 1;
        }

        private void DeleteModelSeriesFromComboBox(ModelSeries ms)
        {
            toolStripComboBoxSeriesList.Items.Remove(ms);
            if (toolStripComboBoxSeriesList.SelectedIndex == -1 && toolStripComboBoxSeriesList.Items.Count > 0)
            {
                toolStripComboBoxSeriesList.SelectedIndex = 0;
            }
        }

        private static bool SetSeriesSettings(Series series)
        {
            var ssf = new SeriesSettingsForm(series);
            if (ssf.ShowDialog() != DialogResult.OK)
                return false;
            series.CalcFunction();
            series.PointList.Name = ssf.SeriesName;
            series.PointList.XName = ssf.XName;
            series.PointList.YName = ssf.YName;
            return true;
        }

        private void AddNewSeries(Series series)
        {
            if (!SetSeriesSettings(series))
                return;

            var asf = new ACLSettingsForm(series.PointList);
            if (asf.ShowDialog() != DialogResult.OK)
                return;

            var ats = asf.ACLSeries;
            var ms = new ModelSeries(series, ats);

            AddModelSeries(ms, true);
            ShowCurrentSeries();
            //DrawACLScale();

            if (currentProject.seriesList.Count == 1)
            {
                splitContainerTop.Panel2.BackColor = SystemColors.Control;
            }
        }

        private void AddNewSeries(Series series, string fileName)
        {
            series.CalcFunction();
            series.PointList.Name = fileName;
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";

            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            var ms = new ModelSeries(series, ats);

            AddModelSeries(ms, true);
            ShowCurrentSeries();
            //DrawACLScale();

            if (currentProject.seriesList.Count == 1)
            {
                splitContainerTop.Panel2.BackColor = SystemColors.Control;
            }
        }


        private void AddSeriesToList(ModelResult mr)
        {
            var series = new Series(mr.ForecastModel.GetForecastSeries()) { Tag = mr };
            var lvi = listViewSeries.Items.Add(series.PointList.Name, 0);
            lvi.Tag = series;
            lvi.Checked = false;
             
        }

        private void UpdateSeriesInList(ModelResult mr)
        {
            var found = FindSeriesInList(mr);
            var series = new Series(mr.ForecastModel.GetForecastSeries()) { Tag = mr };
            found.Text = series.PointList.Name;
            found.Tag = series;
            DrawCheckedSeries();
        }

        private void AddSeriesToList(Series series)
        {
            var lvi = listViewSeries.Items.Add(series.PointList.Name, 0);
            lvi.Tag = series;
            lvi.Checked = true;
        }

        private ListViewItem FindSeriesInList(ModelResult mr)
        {
            ListViewItem found = null;
            foreach (ListViewItem item in listViewSeries.Items)
            {
                var series = item.Tag as Series;
                if (series != null)
                {
                    var modelResult = series.Tag as ModelResult;
                    if (modelResult == mr)
                    {
                        found = item;
                        break;
                    }
                }
            }
            return found;
        }

        private void RemoveSeriesFromList(ModelResult mr)
        {
            var deleted = FindSeriesInList(mr);
            listViewSeries.Items.Remove(deleted);
        }

        private void AddNewSeriesFromFunc()
        {
            var ctsf = new CreatreTimeSeriesForm();
            if (ctsf.ShowDialog() != DialogResult.OK)
                return;
            AddNewSeries(ctsf.series);
        }

        private void AddNewSeriesFromFile()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            foreach (var fileName in openFileDialog.FileNames)
            {
                var series = new Series();
                if (!series.LoadFormFile(fileName))
                {
                    MessageBox.Show("Ошибка загрузки файла " + fileName);
                    return;
                }
                if (openFileDialog.FileNames.Length > 1)
                {
                    AddNewSeries(series, fileName.Split('\\')[fileName.Split('\\').Length - 1]);
                }
                else
                {
                    AddNewSeries(series);
                }

            }

        }

        private ModelUserControl AddModelControl(ModelResult modelResult)
        {
            if (modelResult.ModelType == ForecastModelType.None)
            {
                return null;
            }
            var muc = new ModelUserControl(modelResult, currentSeries);
            string name = modelResult.NameOfModel;
            tabControlGraphs.TabPages.Add(name, name, 4);
            var tp = tabControlGraphs.TabPages[tabControlGraphs.TabPages.Count - 1];
            tp.Tag = modelResult;
            tp.Controls.Add(muc);
            muc.Dock = DockStyle.Fill;

            tabControlGraphs.SelectTab(tp);
            return muc;
        }

        /// <summary>
        ///  Вывод ошибки внешней и внутренней.
        /// </summary>
        /// <param name="mr"></param>
        /// <param name="AddToTabs"></param>
        private void AddModelResultToTree(ModelResult mr, bool AddToTabs)
        {            
            //Если не было загруженных файлов, вычислений, то и результаты не выводим. 
            if (mr.ModelType == ForecastModelType.None)
                return;
            
            var tnMR = currentModelSeriesTN.Nodes.Add(mr.NameOfModel, mr.NameOfModel, 4, 4);
            tnMR.Tag = mr;
            tnMR.Nodes.Add("Настройки", "Настройки", 5, 5);
            tnMR.Nodes.Add("Графики", "Графики", 7, 7);
            tnMR.Nodes.Add("Результаты", "Результаты", 6, 6);
            currentModelSeriesTN.ExpandAll();
                        
            if (AddToTabs)
            {
                AddSeriesToList(mr);
                var muc = AddModelControl(mr);
                //Здесь тот самый вывод на экран
                muc.ShowModel();
            }
            
        }

        private void DeleteSelected()
        {
            TreeNode sel = treeViewSeries.SelectedNode;
            if (sel == null)
            {
                return;
            }
            if (sel.Parent == null)
            {
                return;
            }
            if (sel.ImageIndex == 1)
            {
                if (MessageBox.Show("Удалить ряд " + sel.Text + "?", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                DeleteModelSeries(sel);
            }
            else if (sel.ImageIndex == 4)
            {
                if (MessageBox.Show("Удалить модель " + sel.Text + "?", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
                DeleteModel(sel);
            }
        }

        private void DeleteTab(ModelResult modelResult)
        {
            for (int i = 2; i < tabControlGraphs.TabPages.Count; i++)
            {
                var mr = tabControlGraphs.TabPages[i].Tag as ModelResult;
                if (mr == modelResult)
                {
                    tabControlGraphs.TabPages.Remove(tabControlGraphs.TabPages[i]);
                    break;
                }
            }
        }

        private void DeleteModel(TreeNode tnModel)
        {
            var mr = tnModel.Tag as ModelResult;
            if (mr == null)
                return;
            var ms = tnModel.Parent.Tag as ModelSeries;
            if (ms != null)
                ms.Results.Remove(mr);
            RemoveSeriesFromList(mr);
            tnModel.Parent.Nodes.Remove(tnModel);
            DeleteTab(mr);
            if (mr == currentResult)
            {
                SelectTabPage(0, false);
            }
            currentProject.WasChanged = true;
        }

        private void ACLSettings()
        {
            if (currentSeries == null)
                return;

            var asf = new ACLSettingsForm(currentSeries.ACLSeries);
            if (asf.ShowDialog() != DialogResult.OK)
                return;

            var ats = asf.ACLSeries;
            currentSeries.Update(ats);
            currentProject.WasChanged = true;
            ShowCurrentSeries();
            //DrawACLScale();
        }

        private void SetCurrentSeries(TreeNode tn)
        {
            var ms = tn.Tag as ModelSeries;
            if (ms != currentSeries)
            {
                currentSeries = ms;
                currentModelSeriesTN = tn;
                ShowCurrentSeries();
            }
        }

        private TreeNode FindSeriesNode(ModelSeries ms)
        {
            TreeNode foundNode = null;
            for (int i = 0; i < treeViewSeries.Nodes[0].Nodes.Count; i++)
            {
                if (treeViewSeries.Nodes[0].Nodes[i].Tag as ModelSeries == ms)
                {
                    foundNode = treeViewSeries.Nodes[0].Nodes[i];
                }
            }
            return foundNode;
        }

        private void SetCurrentSeries(ModelSeries ms)
        {
            if (ms != currentSeries)
            {
                currentSeries = ms;
                currentModelSeriesTN = ms != null ? FindSeriesNode(ms) : null;
                ShowCurrentSeries();
            }
        }

        private ModelUserControl SelectModel(ModelResult mr)
        {
            TabPage selected = null;
            int selectedId = -1;
            for (int i = 0; i < tabControlGraphs.TabPages.Count; i++)
            {
                TabPage tabPage = tabControlGraphs.TabPages[i];
                if (tabPage.Tag == mr)
                {
                    selected = tabPage;
                    selectedId = i;
                    break;
                }
            }
            if (selected != null)
            {
                SelectTabPage(selectedId, false);
            }
            else
                return null;

            return selected.Controls[0] as ModelUserControl;
        }

        private void ModelSettings(ModelResult mr)
        {
            switch (mr.ModelType)
            {
                case ForecastModelType.None:
                    return;
                case ForecastModelType.Song:
                    var sfm = mr.ForecastModel as SongForecastModel;
                    if (sfm != null)
                    {
                        var ssf = new ModelSettingForm(sfm.Actual.Count, typeof(SongForecastModel));
                        ssf.Set(sfm);
                        if (ssf.ShowDialog() == DialogResult.OK)
                        {
                            ssf.FillModel(sfm);
                            sfm.Remake(ssf.Order);
                            mr.Refresh();
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case ForecastModelType.Neural:
                    var nfm = mr.ForecastModel as NeuralForecastModel;
                    if (nfm != null)
                    {
                        var nsf = new NeuralSettingForm(nfm.Actual.Count);
                        nsf.Set(nfm);
                        if (nsf.ShowDialog() == DialogResult.OK)
                        {
                            if (!nsf.NotChanged(nfm))
                            {
                                nsf.FillModel(nfm);
                                nfm.Remake();
                                mr.Refresh();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case ForecastModelType.D:
                    var tsf = new ModelSettingForm(0, typeof(DForecastModel));
                    var dfm = mr.ForecastModel as DForecastModel;
                    if (dfm != null)
                    {
                        tsf.Set(dfm);
                        if (tsf.ShowDialog() == DialogResult.OK)
                        {
                            tsf.FillModel(dfm);
                            dfm.Remake(tsf.Order + 1);
                            mr.Refresh();
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case ForecastModelType.Tend:
                    tsf = new ModelSettingForm(0, typeof(TendForecastModel));
                    var tfm = mr.ForecastModel as TendForecastModel;
                    if (tfm != null)
                    {
                        tsf.Set(tfm);
                        if (tsf.ShowDialog() == DialogResult.OK)
                        {
                            tsf.FillModel(tfm);
                            tfm.Remake(tsf.Order + 1);
                            mr.Refresh();
                        }
                        else
                        {
                            return;
                        }
                    }
                    break;
                case ForecastModelType.F:
                //#warning F - ЗАГЛУШКА!!!
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var muc = SelectModel(mr);
            muc.ShowModel();
            ShowModelInfo(mr);
            UpdateSeriesInList(mr);
            currentProject.WasChanged = true;
        }

        private void DoubleClickInTree()
        {
            TreeNode sel = treeViewSeries.SelectedNode;
            if (sel == null)
            {
                return;
            }
            if (sel.Parent == null)
            {
                var psf = new ProjectSettingForm();
                psf.Set(currentProject);
                if (psf.ShowDialog() == DialogResult.OK)
                {
                    currentProject.Name = psf.ProjectName;
                    treeViewSeries.Nodes[0].Text = currentProject.Name;
                }
                return;
            }
            if (sel.ImageIndex == 1)
            {
                //Временной Ряд
                SetCurrentSeries(sel);
            }
            else if (sel.ImageIndex == 2)
            {
                //Шкала
                SetCurrentSeries(sel.Parent);
                SelectTabPage(1, false);
            }
            else if (sel.ImageIndex == 3)
            {
                //Ряд
                SetCurrentSeries(sel.Parent);
                SelectTabPage(0, false);
            }
            else if (sel.ImageIndex == 4)
            {
                //Модель
                SetCurrentSeries(sel.Parent);
                var mr = sel.Tag as ModelResult;
                SelectModel(mr);
            }
            else if (sel.ImageIndex == 5)
            {
                //Настройки
                SetCurrentSeries(sel.Parent.Parent);
                var mr = sel.Parent.Tag as ModelResult;
                ModelSettings(mr);
            }
            else if (sel.ImageIndex == 6)
            {
                //Результаты
                SetCurrentSeries(sel.Parent.Parent);
                var mr = sel.Parent.Tag as ModelResult;
                var muc = SelectModel(mr);
                muc.ShowResult();
            }
            else if (sel.ImageIndex == 7)
            {
            //#warning F ОШИБКА ПРИ ДВОЙНОМ ЩЕЛЧКЕ ПО ЗНАЧКУ В ДЕРЕВЕ ПОСЛЕ ДОБАВЛЕНИЯ РЕЗУЛЬТАТА F ПРЕОБРАЗОВАНИЯ
                //Графики
                SetCurrentSeries(sel.Parent.Parent);
                var mr = sel.Parent.Tag as ModelResult;
                var muc = SelectModel(mr);
                muc.ShowGraphs();
            }
        }

        private void SelectTabPage(int index, bool ignoreMatch)
        {
            if (index == tabControlGraphs.SelectedIndex && ignoreMatch)
            {
                SelectedTabPage(tabControlGraphs.TabPages[index], index);
            }
            else
            {
                tabControlGraphs.SelectTab(index);
            }
        }

        private void SelectedTabPage(Control tp, int index)
        {
            if (tp == null)
                throw new ArgumentNullException("tp");
            if (currentSeries == null)
                return;
            ModelResult mr = index < 2 ? currentSeries.Results[0] : tp.Tag as ModelResult;
            ShowModelInfo(mr);
        }

        private void DrawCheckedSeries()
        {
            DrawHelper.CleanseGraph(graphControlSeries);
            int i = 0;
            foreach (ListViewItem item in listViewSeries.Items)
            {
                if (item.Checked)
                {
                    AddSeriesToGraph(item.Tag as Series, DrawHelper.colors[i]);
                }
                i++;
                if (i >= DrawHelper.colors.Length)
                    i = 0;
            }
        }

        private void AddSelectedSeries()
        {
            if (toolStripComboBoxSeries.Items.Count == 0)
                return;

            var spl = toolStripComboBoxSeries.SelectedItem as SPointList;

            if (spl == null)
                return;

            AddNewSeries(new Series(spl));
        }

        private bool SaveQuestion()
        {
            if (!currentProject.WasChanged)
                return false;
            var dr = MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (dr == DialogResult.Yes);
        }

        private DialogResult SaveQuestion2()
        {
            if (!currentProject.WasChanged)
                return DialogResult.No;
            var dr = MessageBox.Show("Сохранить изменения перед выходом?", "Выход из программы", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            return dr;
        }

        private void SaveProject(bool showDialog)
        {
            if (!currentProject.CheckFileName() || showDialog)
            {
                saveFileDialog.FileName = currentProject.Name + ".xml";
                saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentProject.FileName = saveFileDialog.FileName;
                }
            }
            currentProject.SaveXmlDocument();
            currentProject.WasChanged = false;
        }

        private void ClearProject()
        {
            treeViewSeries.Nodes.Clear();
            ClearSeriesShow();
        }

        private void LoadProject()
        {
            if (SaveQuestion())
            {
                SaveProject(false);
            }
            if (openFileDialogProject.ShowDialog() == DialogResult.OK)
            {
                ClearProject();
                AddDefaultProject();
                currentProject.FileName = openFileDialogProject.FileName;
                try
                {
                    if (!currentProject.LoadXmlDocument())
                        return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки файла\r\n" + ex.Message);
                    return;
                }
                foreach (ModelSeries ms in currentProject.seriesList)
                {
                    AddModelSeries(ms, false);
                    foreach (var modelResult in ms.Results)
                    {
                        AddModelResultToTree(modelResult, false);
                    }
                }
                //ShowCurrentSeries();
                //DrawACLScale();
                if (currentProject.seriesList.Count > 0)
                {
                    splitContainerTop.Panel2.BackColor = SystemColors.Control;
                }
                treeViewSeries.Nodes[0].Text = currentProject.Name;
            }

        }

        private void NewProject()
        {
            var psf = new ProjectSettingForm { ProjectName = "Новый проект" };
            if (psf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            ClearProject();
            AddNewProject(psf.ProjectName);
        }

        private void SaveSeries(SPointList pointList)
        {
            saveFileDialog.FileName = pointList.Name + ".txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Series.Save(pointList, saveFileDialog.FileName);
            }
        }

        private static void SaveImage(ZedGraphControl zgc, string name, string folder)
        {
            Image img = zgc.GraphPane.GetImage(700, 400, 96);
            img.Save(folder + "\\" + name + ".png", ImageFormat.Png);
        }

        private void SaveImages(string folder)
        {
            if (currentResult == null || currentResult.ModelType == ForecastModelType.None)
            {
                SaveImage(graphControlSeries, "Временной ряд", folder);
            }
            else
            {
                var muc = tabControlGraphs.SelectedTab.Controls[0] as ModelUserControl;
                if (muc != null)
                    SaveImage(muc.GraphControl, "Временной ряд", folder);
            }
            SaveImage(graphControlTerms, graphControlTerms.GraphPane.Title.Text, folder);
            SaveImage(graphControlTTend, graphControlTTend.GraphPane.Title.Text, folder);
            SaveImage(graphControlRTend, graphControlRTend.GraphPane.Title.Text, folder);

            if (currentResult == null)
                return;

            var zgc = new ZedGraphControl { Size = new Size(800, 600) };
            foreach (var pointList in currentResult.PointLists)
            {
                DrawHelper.CleanseGraph(zgc);
                zgc.GraphPane.Title.Text = pointList.Name;
                DrawHelper.DrawPointList(zgc, pointList, Color.Blue, SymbolType.Default, true);
                SaveImage(zgc, pointList.Name, folder);
            }
        }

        private void SaveReport()
        {
            if (currentResult == null)
                return;
            var report = "Отчет о применении модели";
            var srdf = new SaveReportForm { ReportName = report, ReportFolder = appDir };
            if (srdf.ShowDialog() != DialogResult.OK)
                return;
            report = srdf.ReportName;
            var reportFolder = srdf.ReportFolder + report;
            int i = 1;
            while (Directory.Exists(reportFolder))
            {
                report = srdf.ReportName + i;
                reportFolder = srdf.ReportFolder + report;
                i++;
            }
            Directory.CreateDirectory(reportFolder);
            SaveImages(reportFolder);
            var fileName = reportFolder + "\\" + srdf.ReportName + ".html";
            switch (currentResult.ModelType)
            {
                case ForecastModelType.None:
                    var xsltLocNone = appDir + "NoneReport.xslt";
                    Project.SaveToHTML(fileName, xsltLocNone, currentResult.SeriesReport);
                    break;
                case ForecastModelType.Song:
                    var xsltLocSong = appDir + "SongReport.xslt";
                    Project.SaveToHTML(fileName, xsltLocSong, currentResult.ModelReport);
                    break;
                case ForecastModelType.Neural:
                    var xsltLocNeural = appDir + "NeuralReport.xslt";
                    Project.SaveToHTML(fileName, xsltLocNeural, currentResult.ModelReport);
                    break;
                case ForecastModelType.D:
                    var xsltLocD = appDir + "DReport.xslt";
                    //Project.SaveToXML("1.xml", currentResult.GetTendReport());
                    Project.SaveToHTML(fileName, xsltLocD, currentResult.ModelReport);
                    break;
                case ForecastModelType.Tend:
                    var xsltLocTend = appDir + "TendReport.xslt";
                    //Project.SaveToXML("1.xml", currentResult.GetTendReport());
                    Project.SaveToHTML(fileName, xsltLocTend, currentResult.ModelReport);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (srdf.ReportShow)
            {
                var rf = new ReportForm(fileName);
                rf.Show();
            }
        }

        private void SaveStat()
        {
            saveFileDialog.FileName = "Информация о модели.html";
            saveFileDialog.Filter = "Html files (*.html)|*.html";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var fileName = saveFileDialog.FileName;
            if (tabControlInfo.SelectedIndex == 0)
                SaveStatCrisp(fileName);
            else
                SaveStatFuzzy(fileName);
        }

        private void SaveStatCrisp(string fileName)
        {
            if (currentResult.ModelType == ForecastModelType.None)
            {
                var xsltLocNone = appDir + "NoneResultCrisp.xslt";
                Project.SaveToHTML(fileName, xsltLocNone, currentResult.SeriesReport.ResultCrisp);
            }
            else
            {
                var xsltLoc = appDir + "ResultCrisp.xslt";
                Project.SaveToHTML(fileName, xsltLoc, currentResult.ModelReport.ResultCrisp);
            }
        }

        private void SaveStatFuzzy(string fileName)
        {
            if (currentResult.ModelType == ForecastModelType.None)
            {
                var xsltLocNone = appDir + "NoneResultFuzzy.xslt";
                Project.SaveToHTML(fileName, xsltLocNone, currentResult.SeriesReport.ResultFuzzy);
            }
            else
            {
                var xsltLoc = appDir + "ResultFuzzy.xslt";
                Project.SaveToHTML(fileName, xsltLoc, currentResult.ModelReport.ResultFuzzy);
            }
        }

        private void CompareModels()
        {
            if (currentSeries == null)
                return;

            var compare = currentSeries.CompareModels();
            if (compare.Count == 0)
                return;

            saveFileDialog.FileName = "Сравнение моделей.html";
            saveFileDialog.Filter = "Html files (*.html)|*.html";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var fileName = saveFileDialog.FileName;

            var xsltLoc = appDir + "Compare.xslt";
            Project.SaveToHTML(fileName, xsltLoc, compare);

            var rf = new ReportForm(fileName);
            rf.Show();
        }

        private void toolStripComboBoxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSelectedSeries();
        }

        private void toolStripButtonShow_Click(object sender, EventArgs e)
        {
            ShowSelectedPoints();
        }

        private void сформироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSeriesFromFunc();
        }

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewSeriesFromFile();
        }

        private void aCLШкалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ACLSettings();
        }

        private void treeViewSeries_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickInTree();
        }

        private void tabControlGraphs_Selected(object sender, TabControlEventArgs e)
        {
            SelectedTabPage(e.TabPage, e.TabPageIndex);
        }

        private void toolStripComboBoxSeriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentSeries(toolStripComboBoxSeriesList.SelectedItem as ModelSeries);
        }

        private void toolStripButtonShowResult_Click(object sender, EventArgs e)
        {
            new ShowTableForm(currentResult).ShowDialog();
        }

        private void listViewSeries_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DrawCheckedSeries();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddSelectedSeries();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProject();
            ACLSettings();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject(false);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject(true);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var dr = SaveQuestion2();
            if (dr == DialogResult.Yes)
            {
                SaveProject(false);
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonSaveSeries_Click(object sender, EventArgs e)
        {
            if (currentSeries != null)
            {
                SaveSeries(currentSeries.series.PointList);
            }
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            if (currentSeries == null)
                return;
            var ssf = new SeriesSettingsForm
            {
                SeriesName = currentSeries.series.PointList.Name,
                XName = currentSeries.series.PointList.XName,
                YName = currentSeries.series.PointList.YName
            };
            if (ssf.ShowDialog() == DialogResult.OK)
            {
                currentSeries.series.PointList.Name = ssf.SeriesName;
                currentSeries.series.PointList.XName = ssf.XName;
                currentSeries.series.PointList.YName = ssf.YName;
                currentModelSeriesTN.Text = currentSeries.series.PointList.Name;
                ShowCurrentSeries();
            }
        }

        private void toolStripButtonReport_Click(object sender, EventArgs e)
        {
            SaveReport();
        }

        private void toolStripButtonStat_Click(object sender, EventArgs e)
        {
            SaveStat();
        }

        private void toolStripButtonModelSettings_Click(object sender, EventArgs e)
        {
            if (currentResult != null && currentResult.ModelType != ForecastModelType.None)
            {
                ModelSettings(currentResult);
            }
        }

        private void toolStripButtonCompare_Click(object sender, EventArgs e)
        {
            CompareModels();
        }

        ////Комплексный анализ моделей тенденций*********************************
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    ShowProgress = false;
        //    ComplexAnalysisTend();
        //    ShowProgress = true;
        //}

        //private void ComplexAnalysisTend()
        //{
        //    int threads = 0;
        //    object locker = new object();

        //    ComplexAnalysisTend ca = new ComplexAnalysisTend();
        //    if (ca.ShowDialog() != DialogResult.OK)
        //    {
        //        return;
        //    }
        //    int methodsCount = 0;

        //    //*** Описание ошибок *****************************************************************
        //    int errorType = ca.ErrorType();
        //    List<ModelResult> results = new List<ModelResult>();
        //    List<double> MSE = new List<double>();
        //    List<double> MAPE = new List<double>();
        //    List<double> RTendFPE = new List<double>();
        //    List<double> TTendFPE = new List<double>();
        //    //*************************************************************************************

        //    for (int k = 0; k <= ca.MaxISP(); k++)
        //    {
        //        for (int j = 0; j < ca.Range(); j++)
        //        {
        //            for (int l = 0; l < (ca.SelectRules() ? 1 : 2); l++)
        //            {
        //                threads++;
        //                int tmpk = k;
        //                ThreadPool.QueueUserWorkItem(delegate(object notUsed)
        //                {
        //                    currentSeries.ACLSeries.Scale.ISP = tmpk;
        //                    var asf = new ACLSettingsForm(currentSeries.ACLSeries);
        //                    asf.Generate();
        //                    var ats = asf.ACLSeries;
        //                    currentSeries.Update(ats);
        //                    try
        //                    {
        //                        results.Add(AddTendForecastModel(l == 0 ? false : true, 0, j, ca.ForecastPointsCount(), tmpk));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }

        //                    lock (locker)
        //                    {
        //                        threads--;
        //                        Monitor.Pulse(locker);
        //                    }
        //                });
        //            }
        //        }
        //    }

        //    ProgressFormForTend pf = new ProgressFormForTend(threads);
        //    pf.SetText("Многопоточная обработка");
        //    pf.Show();

        //    lock (locker)
        //        while (threads > 0)
        //        {
        //            Monitor.Wait(locker);
        //            pf.Incremet();
        //        }

        //    pf.Close();

        //    methodsCount = results.Count;

        //    /*** Оценки критериев качества для каждого метода ************************************/
        //    List<int> score = new List<int>(methodsCount);
        //    List<int> scoreMSE = new List<int>(methodsCount);
        //    List<int> scoreMAPE = new List<int>(methodsCount);
        //    List<int> scoreRTend = new List<int>(methodsCount);
        //    List<int> scoreTTend = new List<int>(methodsCount);
        //    /*************************************************************************************/

        //    for (int i = 0; i < methodsCount; i++)
        //    {
        //        if (results[i] == null)
        //        {
        //            return;
        //        }
        //    }
        //    for (int i = 0; i < methodsCount; i++)
        //    {
        //        score.Add(0);
        //        scoreMSE.Add(0);
        //        scoreMAPE.Add(0);
        //        scoreRTend.Add(0);
        //        scoreTTend.Add(0);
        //        if (ca.UseMSE()) MSE.Add(results[i].ModelReport.Errors[errorType].MSE);
        //        if (ca.UseMAPE()) MAPE.Add(results[i].ModelReport.Errors[errorType].MAPE);
        //        if (ca.UseRTend()) RTendFPE.Add(results[i].ModelReport.FErrors[errorType].RTendFPE);
        //        if (ca.UseTTend()) TTendFPE.Add(results[i].ModelReport.FErrors[errorType].TTendFPE);
        //    }
        //    for (int i = 0; i < methodsCount - 1; i++)
        //    {
        //        for (int j = i + 1; j < methodsCount; j++)
        //        {
        //            if (ca.UseMSE()) { scoreMSE[MSE[i] > MSE[j] ? j : i] += 1; }
        //            if (ca.UseMAPE()) { scoreMAPE[MAPE[i] > MAPE[j] ? j : i] += 1; }
        //            if (ca.UseRTend()) { scoreRTend[RTendFPE[i] > RTendFPE[j] ? j : i] += 1; }
        //            if (ca.UseTTend()) { scoreTTend[TTendFPE[i] > TTendFPE[j] ? j : i] += 1; }
        //        }
        //    }

        //    //** Вывод лучшего результата по комплексной оценке *******************************
        //    int max = 0;
        //    int max_index = 0;
        //    for (int i = 0; i < methodsCount - 1; i++)
        //    {
        //        score[i] = scoreMSE[i] + scoreMAPE[i] + scoreRTend[i] + scoreTTend[i];
        //        if (score[i] > max)
        //        {
        //            max = score[i];
        //            max_index = i;
        //        }
        //    }

        //    currentSeries.Results.Add(results[max_index]);
        //    currentSeries.ACLSeries.Scale.ISP = results[max_index].ISP;

        //    var bestAsf = new ACLSettingsForm(currentSeries.ACLSeries);
        //    bestAsf.Generate();
        //    var bestAts = bestAsf.ACLSeries;
        //    currentSeries.Update(bestAts);

        //    currentProject.WasChanged = true;
        //    AddModelResultToTree(results[max_index], true);
        //}

        //*********************************************************************

        public static bool ShowProgress;
        //Методы обработки*****************************************************************************
        private void toolStripButtonAll_Click(object sender, EventArgs e)
        {
            if (currentSeries == null)
                return;

            ComplexAnalysis ca = new ComplexAnalysis();
            if (ca.ShowDialog() == DialogResult.OK)
            {
                if (ca.UseAllSeries())
                {
                    foreach (TreeNode tn in treeViewSeries.Nodes[0].Nodes)
                    {
                        var ms = tn.Tag as ModelSeries;
                        if (ms != currentSeries)
                        {
                            currentSeries = ms;
                            currentModelSeriesTN = tn;

                            //if(ca.UseFTransform())
                            //    AddFModel(true, true);

                            ShowCurrentSeries();

                            ShowProgress = false;
                            ComplexAnalysis(ca);
                            ShowProgress = true;
                        }
                    }
                }
                else
                {
                    ShowProgress = false;

                    //if (ca.UseFTransform())
                    //{
                    //    ComplexAnalysisWithFTransform(ca);
                    //}
                    //else
                    //{
                    ComplexAnalysis(ca);
                    //}

                    ShowProgress = true;
                }
            }
            else
            {
                return;
            }
        }

        //Использование F моделей
        private bool useFModels = false;

        private void ComplexAnalysis(ComplexAnalysis ca)
        {
            int threads = 0;
            object locker = new object();

            List<ModelResult> results = new List<ModelResult>();

            //*** Описание ошибок *****************************************************************
            int errorType = ca.ErrorType();
            List<double> MSE = new List<double>();
            List<double> MAPE = new List<double>();
            List<double> RTendFPE = new List<double>();
            List<double> TTendFPE = new List<double>();
            //*************************************************************************************

            do
            {
                #region Потоки
                for (int i = 1; i <= ca.ModelRangeDepth(); i++)
                {
                    if (ca.UseNetworks())
                    {
                        threads++;
                        int tmp = i;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddNeuralForecastModel(tmp, ca.ForecastPointsCount(), ca.ForecastCount));//Михаил
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                    }

                    if (ca.UseSong())
                    {
                        threads += 2;
                        int tmp = i;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddSongForecastModel(false, tmp, ca.ForecastPointsCount(), ca.ForecastCount));//Михаил
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddSongForecastModel(true, tmp, ca.ForecastPointsCount(), ca.ForecastCount));//Михаил
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                    }
                    if (ca.UseSD())
                    {
                        threads += 2;
                        int tmp = i;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddDForecastModel(false, tmp, ca.ForecastPointsCount(), ca.ForecastCount));
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddDForecastModel(true, tmp, ca.ForecastPointsCount(), ca.ForecastCount));
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                    }
                    if (ca.UseT())
                    {
                        int tmp = i;

                        for (int k = 0; k <= 3; k++)
                        {
                            for (int j = 1; j < tmp; j++)
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    try
                                    {
                                        threads++;
                                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                                        {
                                            results.Add(AddTendForecastModel(l == 0 ? false : true, 0, j, ca.ForecastPointsCount(), k, ca.ForecastCount));
                                            lock (locker)
                                            {
                                                threads--;
                                                Monitor.Pulse(locker);
                                            }
                                        });
                                    }
                                    catch (Exception ex) { string WarningShield = ex.ToString(); }
                                }
                            }                            
                        }

                        threads++;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddTendForecastModel(false, 1, tmp, ca.ForecastPointsCount(), ca.ForecastCount));//Михаил
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });

                        threads++;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddTendForecastModel(false, 2, tmp, ca.ForecastPointsCount(), ca.ForecastCount));
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });

                        threads++;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddTendForecastModel(true, 1, tmp, ca.ForecastPointsCount(), ca.ForecastCount));
                            lock (locker)
                            {
                                threads -= 1;
                                Monitor.Pulse(locker);
                            }
                        });

                        threads++;
                        ThreadPool.QueueUserWorkItem(delegate(object notUsed)
                        {
                            results.Add(AddTendForecastModel(true, 2, tmp, ca.ForecastPointsCount(), ca.ForecastCount));
                            lock (locker)
                            {
                                threads--;
                                Monitor.Pulse(locker);
                            }
                        });
                    }
                }
                #endregion

                ProgressFormForTend pf = new ProgressFormForTend(threads);
                pf.SetText("Многопоточная обработка");
                pf.Show();

                lock (locker)
                    while (threads > 0)
                    {
                        Monitor.Wait(locker);
                        pf.Incremet();
                    }

                pf.Close();

                useFModels = !useFModels;

            } while (useFModels == ca.UseFTransform());


            //*Вывод результатов***********************************************
            int methodsCount = 0;
            methodsCount = results.Count;

            /*** Оценки критериев качества для каждого метода ************************************/
            List<int> score = new List<int>(methodsCount);
            List<int> scoreMSE = new List<int>(methodsCount);
            List<int> scoreMAPE = new List<int>(methodsCount);
            List<int> scoreRTend = new List<int>(methodsCount);
            List<int> scoreTTend = new List<int>(methodsCount);
            /*************************************************************************************/

            for (int i = 0; i < methodsCount; i++)
            {
                if (results[i] == null)
                {
                    return;
                }
            }
            for (int i = 0; i < methodsCount; i++)
            {
                score.Add(0);
                scoreMSE.Add(0);
                scoreMAPE.Add(0);
                scoreRTend.Add(0);
                scoreTTend.Add(0);
                if (ca.UseMSE()) MSE.Add(results[i].ModelReport.Errors[errorType].MSE);
                if (ca.UseMAPE()) MAPE.Add(results[i].ModelReport.Errors[errorType].MAPE);
                if (ca.UseRTend()) RTendFPE.Add(results[i].ModelReport.FErrors[errorType].RTendFPE);
                if (ca.UseTTend()) TTendFPE.Add(results[i].ModelReport.FErrors[errorType].TTendFPE);
            }
            for (int i = 0; i < methodsCount - 1; i++)
            {
                for (int j = i + 1; j < methodsCount; j++)
                {
                    if (ca.UseMSE()) { scoreMSE[MSE[i] > MSE[j] ? j : i] += 1; }
                    if (ca.UseMAPE()) { scoreMAPE[MAPE[i] > MAPE[j] ? j : i] += 1; }
                    if (ca.UseRTend()) { scoreRTend[RTendFPE[i] > RTendFPE[j] ? j : i] += 1; }
                    if (ca.UseTTend()) { scoreTTend[TTendFPE[i] > TTendFPE[j] ? j : i] += 1; }
                }
            }

            if (ca.UseSeparatedResults() == false)
            {
                //** Вывод лучшего результата по комплексной оценке *******************************
                int max = 0;
                int max_index = 0;
                for (int i = 0; i < methodsCount - 1; i++)
                {
                    score[i] = scoreMSE[i] + scoreMAPE[i] + scoreRTend[i] + scoreTTend[i];
                    if (score[i] > max)
                    {
                        max = score[i];
                        max_index = i;
                    }
                }

                currentSeries.Results.Add(results[max_index]);
                currentSeries.ACLSeries.Scale.ISP = results[max_index].aclSeries.Scale.ISP;

                currentProject.WasChanged = true;
                AddModelResultToTree(results[max_index], true);


                //*************************************************************
                //позор на мою седую голову
                //ok
                TextWriter tw = new StreamWriter("data.txt", true);
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}",
                                results[max_index].ForecastModel.Name,
                                results[max_index].ForecastModel.Actual.Count.ToString(),
                                results[max_index].ModelType.ToString(),
                                results[max_index].ModelReport.ACLInfo,
                                results[max_index].ForecastModel.Order.ToString(),
                                Convert.ToString(results[max_index].ForecastModel.Actual.Count - results[max_index].ForecastModel.ActualCount),
                                results[max_index].ModelReport.Errors[errorType].MSE.ToString(),
                                results[max_index].ModelReport.Errors[errorType].MAPE.ToString(),
                                results[max_index].ModelReport.Errors[errorType].D.ToString(),
                                results[max_index].ModelReport.FErrors[errorType].TTendFPE.ToString(),
                                results[max_index].ModelReport.FErrors[errorType].RTendFPE.ToString());
                tw.WriteLine(sb.ToString());
                tw.Close();
                //*************************************************************
            }
            else
            {
                //** Вывод лучшего результата по каждой оценке отдельно ***************************
                int maxMSE = 0;
                int max_indexMSE = 0;

                int maxMAPE = 0;
                int max_indexMAPE = 0;

                int maxRTend = 0;
                int max_indexRTend = 0;

                int maxTTend = 0;
                int max_indexTTend = 0;

                for (int i = 0; i < methodsCount - 1; i++)
                {
                    if (scoreMSE[i] > maxMSE)
                    {
                        maxMSE = scoreMSE[i];
                        max_indexMSE = i;
                    }
                    if (scoreMAPE[i] > maxMAPE)
                    {
                        maxMAPE = scoreMAPE[i];
                        max_indexMAPE = i;
                    }
                    if (scoreRTend[i] > maxRTend)
                    {
                        maxRTend = scoreRTend[i];
                        max_indexRTend = i;
                    }
                    if (scoreTTend[i] > maxTTend)
                    {
                        maxTTend = scoreTTend[i];
                        max_indexTTend = i;
                    }
                }

                currentSeries.Results.Add(results[max_indexMSE]);
                currentSeries.Results.Add(results[max_indexMAPE]);
                currentSeries.Results.Add(results[max_indexRTend]);
                currentSeries.Results.Add(results[max_indexTTend]);

                currentProject.WasChanged = true;
                AddModelResultToTree(results[max_indexMSE], true);
                AddModelResultToTree(results[max_indexMAPE], true);
                AddModelResultToTree(results[max_indexRTend], true);
                AddModelResultToTree(results[max_indexTTend], true);
            }
            //*****************************************************************

            //MessageBox.Show(DateTime.Now.Subtract(start).TotalMilliseconds.ToString());
            useFModels = false;
        }
        //*****************************************************************************************

        #region Нейросети
        private void прогнозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNeuralForecastModel(true);
        }

        private void AddNeuralForecastModel(bool addToProject)
        {
            if (currentSeries == null)
                return;

            var pts = currentSeries.series.PointList;

            var nsf = new NeuralSettingForm(pts.Count);
            if (nsf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var neuronModel = nsf.GetNModel(pts);
            neuronModel.ACLSeries = currentSeries.ACLSeries;

            var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.Neural, neuronModel);
            ;
            if (addToProject)
            {
                currentSeries.Results.Add(modelResult);
                currentProject.WasChanged = true;
            }
            AddModelResultToTree(modelResult, true);
        }

        private ModelResult AddNeuralForecastModel(int order, int fpc)
        {
            return AddNeuralForecastModel(order, fpc, 0);
        }

        private ModelResult AddNeuralForecastModel(int order, int fpc, int forecast)
        {
            if (currentSeries == null)
                return null;

            var pts = currentSeries.series.PointList;

            var nsf = new NeuralSettingForm(pts.Count);
            nsf.Order = order;
            nsf.ActualCount = fpc;

            //Михаил
            nsf.ForecastCount = forecast;
            //

            var neuronModel = nsf.GetNModel(pts);
            neuronModel.ACLSeries = GetAclTimeSeries();
            neuronModel.UseFTransform = useFModels;

            var modelResult = new ModelResult(GetAclTimeSeries(), ForecastModelType.Neural, neuronModel);

            return modelResult;
        }



        #endregion

        //*****************************************************************************************

        #region Мамдани
        private void прогнозМамдамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSongForecastModel(true);
        }

        private void AddSongForecastModel(bool addToProject)
        {
            if (currentSeries == null)
                return;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(SongForecastModel));
            if (ssf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var songModel = ssf.GetSongModel(currentSeries.ACLSeries.FTS);
            songModel.ACLSeries = currentSeries.ACLSeries;

            var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.Song, songModel);
            if (addToProject)
            {
                currentSeries.Results.Add(modelResult);
                currentProject.WasChanged = true;
            }
            AddModelResultToTree(modelResult, true);
        }

        private ModelResult AddSongForecastModel(bool useRules, int order, int fpc)//Михаил
        {
            return AddSongForecastModel(useRules, order, fpc, 0);
        }
        //forecast - на сколько прогнозировать //Михаил
        private ModelResult AddSongForecastModel(bool useRules, int order, int fpc, int forecast)
        {
            if (currentSeries == null)
                return null;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(SongForecastModel));
            ssf.SelectRules = useRules;
            ssf.Order = order;
            ssf.ActualCount = fpc;
            ssf.ForecastCount = forecast;
            var songModel = ssf.GetSongModel(GetAclTimeSeries().FTS);
            songModel.ACLSeries = GetAclTimeSeries();
            songModel.UseFTransform = useFModels;
            var modelResult = new ModelResult(GetAclTimeSeries(), ForecastModelType.Song, songModel);

            return modelResult;
        }
        #endregion

        //*****************************************************************************************

        #region Шах-Дегтярёв
        private void toolStripButtonD_Click(object sender, EventArgs e)
        {
            AddDForecastModel(true);
        }

        private void AddDForecastModel(bool addToProject)
        {
            if (currentSeries == null)
                return;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(DForecastModel));
            if (ssf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var tendModel = ssf.GetDModel(currentSeries.ACLSeries);

            var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.D, tendModel);
            if (addToProject)
            {
                currentSeries.Results.Add(modelResult);
                currentProject.WasChanged = true;
            }

            AddModelResultToTree(modelResult, true);
        }

        private ModelResult AddDForecastModel(bool useRules, int order, int fpc)
        {
            return AddDForecastModel(useRules, order, fpc, 0);
        }
        private ModelResult AddDForecastModel(bool useRules, int order, int fpc, int forecast)
        {
            if (currentSeries == null)
                return null;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(DForecastModel));
            ssf.SelectRules = useRules;
            ssf.Order = order;
            ssf.ActualCount = fpc;
            ssf.ForecastCount = forecast;

            var DModel = ssf.GetDModel(GetAclTimeSeries());
            DModel.UseFTransform = useFModels;
            var modelResult = new ModelResult(GetAclTimeSeries(), ForecastModelType.D, DModel);

            return modelResult;
        }
        #endregion

        //*****************************************************************************************

        #region Тенденции
        private void модельНаОсновеТенденцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTendForecastModel(true);
        }

        private void AddTendForecastModel(bool addToProject)
        {
            if (currentSeries == null)
                return;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(TendForecastModel));
            if (ssf.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var tendModel = ssf.GetTendModel(currentSeries.ACLSeries);

            var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.Tend, tendModel);
            if (addToProject)
            {
                currentSeries.Results.Add(modelResult);
                currentProject.WasChanged = true;
            }

            AddModelResultToTree(modelResult, true);
        }


        private ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc)
        {
            if (currentSeries == null)
                return null;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(TendForecastModel));
            ssf.SelectRules = useRules;
            ssf.SetMethodType = type;
            ssf.Order = order;
            ssf.ActualCount = fpc;

            var tendModel = ssf.GetTendModel(GetAclTimeSeries());
            tendModel.UseFTransform = useFModels;
            var modelResult = new ModelResult(GetAclTimeSeries(), ForecastModelType.Tend, tendModel);

            return modelResult;
        }

        private ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc, int isp)
        {
            return AddTendForecastModel(useRules, type, order, fpc, isp, 0);
        }
        private ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc, int isp, int forecast)
        {
            if (currentSeries == null)
                return null;

            var ssf = new ModelSettingForm(currentSeries.series.PointList.Count, typeof(TendForecastModel));
            ssf.SelectRules = useRules;
            ssf.SetMethodType = type;
            ssf.Order = order;
            ssf.ActualCount = fpc;
            ssf.ForecastCount = forecast;


            var tendModel = ssf.GetTendModel(GetAclTimeSeries());
            tendModel.UseFTransform = useFModels;
            var modelResult = new ModelResult(GetAclTimeSeries(), ForecastModelType.Tend, tendModel);
            modelResult.ISP = isp;

            return modelResult;
        }
        #endregion

        //*****************************************************************************************

        #region F-преобразования
        private void toolStripF_Click(object sender, EventArgs e)
        {
            AddFModel(true, false);
        }

        private void AddFModel(bool addToProject, bool autoHandle)
        {
            if (currentSeries == null)
                return;

            var fModelSettings = new FForecastModelSettings(currentSeries);

            //Автоматическая обработка / Ручная обработка
            if (autoHandle)
            {
                fModelSettings.AddResultToProject = true;

                var fModel = fModelSettings.GetFModel();
                var _fModel = fModelSettings.GetFModel();
                _fModel.delta();

                var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, fModel);

                if (addToProject)
                {
                    currentSeries.Results.Add(modelResult);
                    currentProject.WasChanged = true;
                }

                AddModelResultToTree(modelResult, true);

                if (fModelSettings.AddResultToProject)
                    AddNewSeries(
                        new Series(fModel.GetForecastSeries()),
                        currentModelSeriesTN.Name + "[F]");
            }
            else
            {
                if (fModelSettings.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var fModel = fModelSettings.GetFModel();
                var _fModel = fModelSettings.GetFModel();
                _fModel.delta();

                var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, fModel);
                var _modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType._F, _fModel);

                if (addToProject)
                {
                    currentSeries.Results.Add(modelResult);
                    currentSeries.Results.Add(_modelResult);
                    currentProject.WasChanged = true;
                }

                AddModelResultToTree(modelResult, true);
                AddModelResultToTree(_modelResult, true);

                if (fModelSettings.AddResultToProject)
                {
                    AddNewSeries(
                        new Series(fModel.GetForecastSeries()));
                    AddNewSeries(
                        new Series(_fModel.GetForecastSeries()));
                }
            }

        }

        private void AddFModel(Report<CrispResultRow, FuzzyResultRow> report)
        {
            if (currentSeries == null)
                return;

            var fModelSettings = new FForecastModelSettings(currentSeries);

            fModelSettings.AddResultToProject = true;

            var fModel = fModelSettings.GetFModel();

            var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, fModel);

            modelResult.ModelReport = report;

            currentSeries.Results.Add(modelResult);
            currentProject.WasChanged = true;

            AddModelResultToTree(modelResult, true);
        }

        private ACLTimeSeries GetAclTimeSeries()
        {
            if (useFModels)
            {
                var fModelSettings = new FForecastModelSettings(currentSeries);
                fModelSettings.AddResultToProject = true;
                var fModel = fModelSettings.GetFModel();
                var modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, fModel);
                return modelResult.aclSeries;
            }
            else
                return currentSeries.ACLSeries;
        }

        #endregion

        //*****************************************************************************************

        #region О программе

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm newForm = new AboutForm();
            if (newForm.ShowDialog(this) == DialogResult.OK)
            {
                return;
            }
        }
        #endregion

        //*****************************************************************************************

        #region Пример

        private void примерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandText = @"Пример.pdf";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        #endregion

        private void listViewSeries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scroll2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Как выяснилось передать всю предметную область как есть не возможно.
            //Класс данных ссылается на всё что можно.
            //По этому передаём значения ряда в List<List<string>>что в свою очередь передаём далее

            List<List<double>> DataSet = new List<List<double>>();
            DataSet.Clear();
            List<string> DataNameSet = new List<string>();
            DataNameSet.Clear();
            List<string> DataTypeSet = new List<string>();
            DataTypeSet.Clear();
            List<string> DataKSet = new List<string>();
            DataKSet.Clear();

            //Перибераем ряды
            for (int i = 0; i < this.currentProject.seriesList.Count; i++)
            {
                ;
                List<double> DataSetPointList = new List<double>();
                DataSetPointList.Clear();
                for (int j = 0; j < this.currentProject.seriesList[i].series.pointList.Count; j++)
                {
                    DataSetPointList.Add(this.currentProject.seriesList[i].series.pointList[j].Y);
                }
                ;
                DataSet.Add(DataSetPointList);
                DataNameSet.Add(this.currentProject.seriesList[i].ToString());
                DataTypeSet.Add(this.currentProject.seriesList[i].series.type);
                DataKSet.Add(Convert.ToString(this.currentProject.seriesList[i].series.ForecastCount));
                ;

            }
            ;

            new ClusterIII.ImportsScrolls.ImportsScrolls().FuzzyForecastImport.Scroll2.Run
                    (DataSet, DataNameSet, DataTypeSet, DataKSet);
        }

        //*********************************************************************************************
    }
}
