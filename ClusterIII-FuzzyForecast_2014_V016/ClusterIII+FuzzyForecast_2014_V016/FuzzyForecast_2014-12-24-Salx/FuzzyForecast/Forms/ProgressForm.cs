using System;
using System.Threading;
using System.Windows.Forms;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;

namespace FuzzyForecast {
  public partial class ProgressForm : Form {
    private readonly BackpropagationNetwork network;
    private readonly int cycles;
    private readonly TrainingSet trainingSet;

    public delegate void LearnDelegate();
    public delegate void ProgressDelegate(int iteration, double mse);
    public delegate void EndLearnDelegate();

    private LearnDelegate learn;
    private IAsyncResult asyncRes;
    private bool closing = false;

    public ProgressForm(BackpropagationNetwork network, int cycles, TrainingSet trainingSet) {
      InitializeComponent();
      this.network = network;
      this.cycles = cycles;
      this.trainingSet = trainingSet;
      network.EndEpochEvent += OnEndEpoch;
      learn = Learn;
      AsyncCallback asyncCallback = CallBack;
      asyncRes = learn.BeginInvoke(asyncCallback, null);
    }

    public void CallBack(IAsyncResult ar) {
      if (InvokeRequired) {
        EndLearnDelegate d = EndLearnClose;
        BeginInvoke(d, null);
      } else {
        EndLearnClose();
      }
    }

    public void EndLearn() {
      labelMSE.Text = "MSE: " + network.MeanSquaredError.ToString(Calc.DFormat);
      labelIteration.Text = "Iteration: " + cycles;
    }

    public void EndLearnClose() {
      EndLearn();
      if (!closing) {
        EndLearnDelegate d = Close;
        BeginInvoke(d);
      }
    }

    public void OnEndEpoch(object senderNetwork, TrainingEpochEventArgs args) {
      var bn = senderNetwork as BackpropagationNetwork;
      if (bn == null)
        return;
      DoProgress(args.TrainingIteration, bn.MeanSquaredError);
      //Application.DoEvents();
    }

    public void DoProgress(int iteration, double mse) {
        try
        {
            if (InvokeRequired || progressBar.InvokeRequired || labelMSE.InvokeRequired || labelIteration.InvokeRequired)
            {
                ProgressDelegate pd = DoProgress;
                BeginInvoke(pd, new object[] { iteration, mse });
            }
            else
            {
                var old = progressBar.Value;
                progressBar.Value = (int)(iteration * 100d / cycles);
                if (iteration % 100 == 0)
                {
                    labelMSE.Text = "MSE: " + mse.ToString(Calc.DFormat);
                    labelIteration.Text = "Iteration: " + iteration;
                }
            }
        }
        catch (Exception ex){string WarningShield = ex.ToString();/*#warning Обработка исключений!!!*/}
    }

    private void Learn() {
      network.Learn(trainingSet, cycles);
    }

    private void StopLearning() {
      network.StopLearning();
      learn.EndInvoke(asyncRes);
    }

    private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e) {
      closing = true;
      if (!asyncRes.IsCompleted) {
        StopLearning();
      }
    }

    private void buttonStop_Click(object sender, EventArgs e) {
      StopLearning();
    }
  }
}
