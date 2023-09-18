using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FuzzyLibrary;
using System.Xml.Serialization;

namespace FuzzyForecast {
  public partial class MFEdit : UserControl {

    private List<TFuzzyTermInfo> termInfos = new List<TFuzzyTermInfo>();
    public bool EditScale { get; set; }

    public string ScaleName {
      get { return groupBoxMain.Text;  }
      set { groupBoxMain.Text = value; }
    }

    public MFEdit() {
      InitializeComponent();
      EditScale = true;
    }

    public void Set(string title, List<FuzzyTerm> terms, bool editScale) {
      groupBoxMain.Text = title;
      EditScale = editScale;
      SetTermInfo(terms);
      FillGrid();
      toolStripButtonAdd.Enabled = EditScale;
      toolStripButtonDelete.Enabled = EditScale;
      toolStripButtonLoad.Enabled = EditScale;
    }

    private void FillGrid() {
      ColumnX1.ReadOnly = !EditScale;
      ColumnX2.ReadOnly = !EditScale;
      ColumnX3.ReadOnly = !EditScale;
      ColumnX4.ReadOnly = !EditScale;
      dataGridViewTerms.DataSource = null;
      dataGridViewTerms.DataSource = termInfos;
    }

    private void SetTermInfo(IEnumerable<FuzzyTerm> terms) {
      termInfos.Clear();
      foreach (var fuzzyTerm in terms) {
        var tft = new TFuzzyTermInfo(fuzzyTerm);
        termInfos.Add(tft);
      }
    }

    private void AddTerm() {
      var term = new FuzzyTerm("Новый терм", new TrapezoidMembershipFunction());
      var tft = new TFuzzyTermInfo(term);
      termInfos.Add(tft);
      FillGrid();
    }

    private void DeleteTerm() {
      if (dataGridViewTerms.CurrentRow == null)
        return;
      var tft = dataGridViewTerms.CurrentRow.DataBoundItem as TFuzzyTermInfo;
      termInfos.Remove(tft);
      FillGrid();
    }

    private void toolStripButtonAdd_Click(object sender, System.EventArgs e) {
      AddTerm();
    }

    private void toolStripButtonDelete_Click(object sender, System.EventArgs e) {
      DeleteTerm();
    }

    public List<FuzzyTerm> GetTerms() {
      var terms = new List<FuzzyTerm>();
      foreach (var termInfo in termInfos) {
        terms.Add(termInfo.CreateTerm());
      }
      return terms;
    }

    private void toolStripButtonDraw_Click(object sender, System.EventArgs e) {
      var tf = new TermsForm(GetTerms(), ScaleName);
      tf.ShowDialog();
    }

    private void SaveToFile() {
      saveFileDialog.FileName = "Нечеткие термы.xml";
      if (saveFileDialog.ShowDialog() != DialogResult.OK) {
        return;
      }
      var fileName = saveFileDialog.FileName;
      var s = new XmlSerializer(typeof(List<TFuzzyTermInfo>));
      try {
        TextWriter writer = new StreamWriter(fileName);
        s.Serialize(writer, termInfos);
        writer.Close();
      } catch (Exception ex) {
        MessageBox.Show("Ошибка обработки файла\r\n" + ex.Message);
      }
    }

    private void LoadFormFile() {
      if (openFileDialog.ShowDialog() != DialogResult.OK) {
        return;
      }
      var fileName = openFileDialog.FileName;
      var s = new XmlSerializer(typeof(List<TFuzzyTermInfo>));
      try {
        TextReader tr = new StreamReader(fileName);
        termInfos = (List<TFuzzyTermInfo>) s.Deserialize(tr);
        FillGrid();
        tr.Close();
      } catch (Exception ex) {
        MessageBox.Show("Ошибка обработки файла\r\n" + ex.Message);
      }
    }

    private void toolStripButtonSave_Click(object sender, EventArgs e) {
      SaveToFile();
    }

    private void toolStripButtonLoad_Click(object sender, EventArgs e) {
      LoadFormFile();
    }
  }
}
