using FuzzyLibrary;
using System;
using System.Collections.Generic;
using System.IO;
//using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace FuzzyForecast
{
    public class header
    {
        private static string _header1 = @"    <style>
        body > div.block {
            border: 1px solid;
            min-height: 450px;
            width: 100%;
            margin-bottom: 10px;
        }

        body > div {
            margin: 30px 0;
        }

        .block > .block > .title {
            margin-bottom: 30px;
        }

        .title_main:hover {
            background-color: #c8c8c8;
        }

        .title > canvas, .title > div {
            margin-top: 20px;
        }
    </style>
    <script src='http://code.jquery.com/jquery-2.1.1.js'></script>

    <script type='text/javascript' src='http://cdnjs.cloudflare.com/ajax/libs/flot/0.8.2/excanvas.min.js'></script>
    <script type='text/javascript' src='http://cdnjs.cloudflare.com/ajax/libs/flot/0.8.2/jquery.flot.min.js'></script>
    <!--<script type='text/javascript' src='http://omnipotent.net/jquery.sparkline/2.1.2/jquery.sparkline.min.js'></script>-->
    <script>
        var jQueryLoaderOptions = null;
        function min(array) {
            var _min = array[0][1];
            for (var i = 0; i < array.length; i++) {
                if (_min > array[i][1])
                    _min = array[i][1];
            }
            return _min;
        }
        function max(array) {
            var _max = array[0][1];
            for (var i = 0; i < array.length; i++) {
                if (_max < array[i][1])
                    _max = array[i][1];
            }
            return _max;
        }
        function ready() {
            $('body>div.block').each(function (index) {
                var _width = $(document).width() - 50;
                var id = $(this).attr('id');
                id = id.replace('.', '');
                var cr = $('#' + id);
                var _tmdiv = $('<div/>').addClass('title_main Hide').html($(this).attr('id'));
                var data = [];
                $($(this).children()).each(function (index) {
                    var datasets = [];
                    var title = $('.title', this).html();
                    $('.block', this).each(function (index) {
                        var tr = [];
                        $($('.tr', this).attr('tr').split(';')).each(function (index) {
                            tr.push([index + 1, parseFloat(this)]);
                        });
                        datasets.push({ 'label': $($('.title', this).html().split(','))[0], 'data': tr });
                        //console.log($($('.title', this).html().split(','))[0]);
                    });
                    var resTr = '';
                    for (var i = datasets[0].data.length - 1; i < datasets[1].data.length - 1; i++) {
                        resTr += datasets[1].data[i][1] + '; ';
                    }
                    $('#' + id + '-item').append($('<div/>').addClass('block').append($('<div/>').addClass('title').html(resTr)));
                    //var cId = id + index;
                    //var _cdiv = $('#' + cId);
                    //var _tdiv = $('<div/>').addClass('title_').html(title);
                    //$(_cdiv).prepend(_tdiv);
                    //var _div = $('#' + cId + 'div');
                    //var _p = $('#' + cId + 'p');

                    // hard-code color indices to prevent them from shifting as
                    // countries are turned on/off

                    var i = 0;
                    $.each(datasets, function (key, val) {
                        val.color = i;
                        ++i;
                    });
                    // insert checkboxes 
                    //var choiceContainer = $('#' + cId + 'p');
                    //console.log('#' + cId + 'p');
                    //console.log(choiceContainer);

                    $('#' + id + '-name').css('height', '400px').css('width', _width).css('margin-bottom', '30px;');
                    $.plot('#' + id + '-name', datasets, {
                        yaxis: {
                            min: 0
                        },
                        xaxis: {
                            tickDecimals: 0
                        },
                        lines: {
                            show: true
                        },
                        yaxis: {
                            min: min(datasets),
                            max: max(datasets)
                        }
                    });
                    console.log(datasets);
                });
            });

        }

        $(document).ready(function () {
            //$('body>div.block>div.block>div.block').hide();
            //$.loader();
            //ready();
            //$('body>div.block').remove();
            //$.loader('close');
            //$('.charts').hide();
            ready();

            return;
        });

    </script>";
        public static string header1
        {
            get
            {
                return _header1;
            }
        }
    }
    public class TR
    {
        //уровень нуля
        private const double Zero = 0.00000001;
        private bool IsZero(double val)
        {
            return Math.Abs(val) < Zero;
        }
        public string Name { get; set; }
        public SPointList ROW { get; set; }
        public double SMAPE_i { get; set; }
        public double SMAPE_e { get; set; }
        public double MSE_i { get; set; }
        public double MSE_e { get; set; }
        public int order { get; set; }
        public int totalTrend { get; set; }
        public int ForecastCount { get; set; }
        public int ActualCount { get; set; }
        public string type { get; set; }
        public TR() { }
        public TR(Series series)
        {
            this.ROW = series.PointList;
            this.ForecastCount = series.ForecastCount;
            this.type = series.type;
            this.Name = series.PointList.Name;
        }
        public TR Clone()
        {
            return new TR()
            {
                Name = this.Name,
                ROW = this.ROW,
                MSE_e = this.MSE_e,
                MSE_i = this.MSE_i,
                order = this.order,
                SMAPE_e = this.SMAPE_e,
                SMAPE_i = this.SMAPE_i,
                totalTrend = this.totalTrend
            };
        }
        public void getError(TR series)
        {
            if (this.ROW.Count < series.ROW.Count)
                return;
            double result_SMAPE = 0.0d;
            double result_MSE = 0.0d;
            int zeroCount = 0;
            for (int i = 0; i < ActualCount; i++)
                if (!IsZero(series.ROW[i].Y))
                {
                    result_SMAPE += Math.Abs(
                        (this.ROW[i].Y - series.ROW[i].Y) /
                        ((this.ROW[i].Y + series.ROW[i].Y) / 2));
                    result_MSE += Math.Pow(this.ROW[i].Y - series.ROW[i].Y, 2d);
                }
                else
                    zeroCount++;
            this.SMAPE_i = (result_SMAPE / (series.ROW.Count - zeroCount)) * 100;
            this.MSE_i = result_MSE;
            result_SMAPE = 0.0d;
            result_MSE = 0.0d;
            for (int i = ActualCount; i < series.ROW.Count; i++)
                if (!IsZero(series.ROW[i].Y))
                {
                    result_SMAPE += Math.Abs(
                        (this.ROW[i].Y - series.ROW[i].Y) /
                        ((this.ROW[i].Y + series.ROW[i].Y) / 2));
                    result_MSE += Math.Pow(this.ROW[i].Y - series.ROW[i].Y, 2d);
                }
                else
                    zeroCount++;
            this.SMAPE_e = (result_SMAPE / (series.ROW.Count - zeroCount)) * 100;
            this.MSE_e = result_MSE;
        }
    }
    public class TRModel
    {
        public string Name { get; set; }
        public List<TR> TR { get; set; }
        public string type { get; set; }
        public int fCount { get; set; }
        public int totalTend { get; set; }
    }
    class _temp
    {
        /// <summary>
        /// Глубина обработки
        /// </summary>
        private const int _order = 2;
        private const int minL = 50;
        public const int t_D = 61;
        public const int t_M = 25;
        public const int t_Q = 9;
        static ModelSeries currentSeries = new ModelSeries();

        public static List<TRModel> last_doit(string fileName)
        {

            List<TRModel> model = new List<TRModel>();
            var series = new Series();
            series.LoadFormFile(fileName);
            series.CalcFunction();
            series.PointList.Name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Length - 1];
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";
            model.Add(get_last_struct(series));

            return model;

        }
        public static TRModel get_last_struct(Series series)
        {
            var _tr = new TR(series);
            var model = new TRModel();
            double b_iSMAPE = 10000000;
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            model.type = _tr.type;
            model.fCount = _tr.ForecastCount;
            model.Name = _tr.Name;
            model.TR = new List<TR>();
            model.TR.Add(new TR() { ROW = series.PointList, Name = "base" });
            model.totalTend = getTend(_tr);
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(series, ats);

            var trModel = new TRModel();
            trModel.fCount = _tr.ForecastCount;
            trModel.Name = _tr.Name;
            trModel.totalTend = getTend(_tr);
            trModel.type = _tr.type;
            trModel.TR = new List<TR>();
            trModel.TR.Add(_tr);

            var fm = new TRModel();
            fm.TR = new List<TR>();
            #region Получение f моделей
            int f_T = 0;
            if (_tr.type == "daily")
            {
                f_T = t_D;
            }
            else if (_tr.type == "monthly")
            {
                f_T = t_M;
            }
            else if (_tr.type == "quarterly")
            {
                f_T = t_Q;
            }

            if ((_tr.ROW.Count > 3 * f_T) && (f_T > 0) && (_tr.ROW.Count > minL))
            {
                _tr.ActualCount = _tr.ROW.Count - _tr.ForecastCount;
                var f = F_Model(_tr, f_T);
                string tmp = "";
                tmp = f.Name;
                f.Name = _tr.Name;
                f.ActualCount = _tr.ActualCount;
                f.ForecastCount = _tr.ForecastCount;
                SaveTRInFile(f, @"\fm\", "_f");
                f.Name = tmp;
                fm.TR.Add(f);
                var fo = FO_model(_tr, f, f_T);
                tmp = fo.Name;
                fo.Name = _tr.Name;
                fo.ActualCount = _tr.ActualCount;
                fo.ForecastCount = _tr.ForecastCount;
                SaveTRInFile(fo, @"\fm\", "_fo");
                fo.Name = tmp;
                fm.TR.Add(fo);

                var best_f = get_best_of_main_struct(f);
                var best_fo = get_best_of_ost_struct(fo);
                var best_summ = SummTR(best_f, best_fo, _tr);
                if (best_summ.SMAPE_i < best_f.SMAPE_i)
                    b_model = best_summ;
                else
                    b_model = best_f;
                b_model.Name += " best";
                trModel.TR.Add(f);
                trModel.TR.Add(fo);
                trModel.TR.Add(best_f);
                trModel.TR.Add(best_fo);
                trModel.TR.Add(best_summ);
                trModel.TR.Add(b_model);
            }
            else
            {
                _tr.ActualCount = _tr.ROW.Count - _tr.ForecastCount;
                b_model = get_best_of_full_struct(_tr);
                trModel.TR.Add(b_model);
            }
            #endregion


            var b = b_model.Clone();
            b.Name = _tr.Name;
            SaveTRInFile(b, @"\best_full_tr", "_full_row");
            var prognos = b_model.Clone();
            prognos.Name = _tr.Name;
            prognos.ROW.RemoveRange(0, _tr.ROW.Count);
            SaveTRInFile(prognos, @"\best_pr_tr", "_pr_row");
            _save(new List<TRModel>() { trModel });
            return model;
        }
        public static TR get_best_of_main_struct(TR tr)
        {
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            var asf = new ACLSettingsForm(tr.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = tr.ROW }, ats);
            #region base model
            //СОНГ
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var str = S_Model(tr, i + 1);
                    listModel.Add(str);
                }
                catch { }
            }
            //Шах-Дегтярёв
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var dtr = D_Model(tr, i + 1);
                    listModel.Add(dtr);
                }
                catch { }
            }
            //Тенденции
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var ttr = T_Model(tr, i + 1);
                    listModel.Add(ttr);
                }
                catch { }
            }
            #endregion
            var listOfTend = new List<TR>();
            foreach (var item in listModel)
            {
                var ost = item.Clone();
                ost.ROW.RemoveRange(0, tr.ForecastCount);
                var tModel = getTend(ost);
                if (new List<int> { getTend(tr), 2, 3, 4 }.Exists(o => o == tModel))
                {
                    listOfTend.Add(item);
                }
            }
            double min = 1000000000;
            listOfTend.ForEach(o => o.getError(tr));
            foreach (var item in listOfTend)
                if (min > (item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i)))
                {
                    b_model = item;
                    min = item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i);
                }
            b_model.type = tr.type;
            b_model.ForecastCount = tr.ForecastCount;
            b_model.getError(tr);
            return b_model;
        }
        public static TR get_best_of_ost_struct(TR tr)
        {
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            var asf = new ACLSettingsForm(tr.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = tr.ROW }, ats);
            #region base model
            //СОНГ
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var str = S_Model(tr, i + 1);
                    listModel.Add(str);
                }
                catch { }
            }
            //Тенденции
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var ttr = T_Model(tr, i + 1);
                    listModel.Add(ttr);
                }
                catch { }
            }
            #endregion
            var listOfTend = new List<TR>();
            foreach (var item in listModel)
            {
                var ost = item.Clone();
                ost.ROW.RemoveRange(0, tr.ForecastCount);
                try
                {
                    var tModel = getTend(ost);
                    if (new List<int> { getTend(tr), 2, 3, 4 }.Exists(o => o == tModel))
                    {
                        listOfTend.Add(item);
                    }
                }
                catch { }
            }
            double min = 1000000000;
            listOfTend.ForEach(o => o.getError(tr));
            foreach (var item in listOfTend)
                if (min > (item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i)))
                {
                    b_model = item;
                    min = item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i);
                }
            b_model.type = tr.type;
            b_model.ForecastCount = tr.ForecastCount;
            b_model.getError(tr);
            return b_model;
        }
        public static TR get_best_of_full_struct(TR tr)
        {
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            var asf = new ACLSettingsForm(tr.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = tr.ROW }, ats);
            #region base model
            //СОНГ
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var str = S_Model(tr, i + 1);
                    listModel.Add(str);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
                //tr.ActualCount--;
            //Шах-Дегтярёв
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var dtr = D_Model(tr, i + 1);
                    listModel.Add(dtr);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
            //Тенденции
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var ttr = T_Model(tr, i + 1);
                    listModel.Add(ttr);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
            #endregion
            var listOfTend = new List<TR>();
            foreach (var item in listModel)
            {
                var ost = item.Clone();
                ost.ROW.RemoveRange(0, tr.ForecastCount);
                var tModel = getTend(ost);
                if (new List<int> { getTend(tr), 2, 3, 4 }.Exists(o => o == tModel))
                {
                    listOfTend.Add(item);
                }
            }
            double min = 1000000000;
            listOfTend.ForEach(o => o.getError(tr));
            foreach (var item in listOfTend)
                if (min > item.SMAPE_i)
                {
                    b_model = item;
                    min = item.SMAPE_i;
                }
            if (min == 1000000000)
            {
                foreach (var item in listModel)
                    if (min > item.SMAPE_i)
                    {
                        b_model = item;
                        min = item.SMAPE_i;
                    }
            }
            b_model.type = tr.type;
            b_model.ForecastCount = tr.ForecastCount;
            b_model.getError(tr);
            return b_model;
        }
        public static TR SummTR(TR tr1, TR tr2, TR tr)
        {
            var _ROW = new SPointList();
            for (int i = 0; i < tr1.ROW.Count; i++)
            {
                _ROW.Add(new SPoint()
                {
                    X = tr1.ROW[i].X,
                    Y = tr1.ROW[i].Y + tr2.ROW[i].Y
                });
            }
            var model = new TR() { ROW = _ROW };
            model.type = tr.type;
            model.ForecastCount = tr.ForecastCount;
            model.ActualCount = tr.ActualCount;
            model.Name = tr1.Name + " + " + tr2.Name;
            model.getError(tr);
            return model;
        }
        public static int getTend(TR series)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            string result = String.Empty;
            int dominateTend = 0;
            int totalTend = 0;
            int lastTend = 0;
            int sum = 0;
            FuzzyForecast.FuzzyTend penultTend = ats.Tends[ats.Tends.Count - 2];

            int[] tendSignificance = { 0, 0, 0 };
            foreach (FuzzyForecast.FuzzyTend tend in ats.Tends)
            {
                if (tend.BaseType == BaseTendType.Increase)
                {
                    tendSignificance[0] += tend.End - tend.Start;
                }
                else if (tend.BaseType == BaseTendType.Decrease)
                {
                    tendSignificance[1] += tend.End - tend.Start;
                }
                else
                {
                    tendSignificance[2] += tend.End - tend.Start;
                }
            }
            sum = tendSignificance[0] + tendSignificance[1] + tendSignificance[2];

            if (sum == 0 && tendSignificance[0] == 0 && tendSignificance[1] == 0 && tendSignificance[2] == 0)
            {
                dominateTend = 2;
            }
            else if (Math.Abs(tendSignificance[0]) > Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                dominateTend = 0;
            }
            else if (Math.Abs(tendSignificance[0]) < Math.Abs(tendSignificance[1]) && (Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) >= 0.5 * Math.Abs(tendSignificance[0]))
            {
                dominateTend = 1;
            }
            else if (((Math.Abs(Math.Abs(tendSignificance[0]) - Math.Abs(tendSignificance[1])) <= Math.Abs(tendSignificance[0]) * 0.1) ||
                  (Math.Abs(Math.Abs(tendSignificance[1]) - Math.Abs(tendSignificance[0])) <= Math.Abs(tendSignificance[1]) * 0.1))
                  && (tendSignificance[0] != 0) && (tendSignificance[1] != 0))
            {
                dominateTend = 3;
            }
            else
            {
                dominateTend = 4;
            }

            //Общая тенденция ряда
            totalTend = dominateTend;
            int tmp = penultTend.End - penultTend.Start;
            if (tmp > 0)
                lastTend = 0;
            else if (tmp < 0)
                lastTend = 1;
            else
                lastTend = 2;

            if (lastTend == dominateTend || dominateTend > 2)
                totalTend = dominateTend;
            else
                if (lastTend != 2)
                    totalTend = lastTend;

            result += "\nОбщая тенденция:";
            return totalTend;
            switch (totalTend)
            {
                case 0: result += "\tРост"; break;
                case 1: result += "\tПадение"; break;
                case 2: result += "\tСтабилизация"; break;
                case 3: result += "\tКолебание"; break;
                case 4: result += "\tХаос"; break;
            }

            //return result;
        }
        public static TR N_Model(TR series, int order)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = series.ROW }, ats);
            var pts = series.ROW;
            var nsf = new NeuralSettingForm(pts.Count);
            nsf.ActualCount = series.ActualCount;
            nsf.ForecastCount = series.ForecastCount;
            nsf.Order = order;
            var neuronModel = nsf.GetNModel(pts);
            neuronModel.ACLSeries = _currentSeries.ACLSeries;
            var n_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.Neural, neuronModel);
            var tr = new TR();
            var xxx = new Series(n_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = n_modelResult
            };
            tr.ROW = xxx.PointList;
            var sd = (ModelResult)xxx.Tag;
            var tret = sd.FillGeneralTendInline();
            tr.SMAPE_i = n_modelResult.ModelReport.Errors[0].SMAPE;
            tr.SMAPE_e = n_modelResult.ModelReport.Errors[1].SMAPE;
            tr.MSE_i = n_modelResult.ModelReport.Errors[0].MSE;
            tr.MSE_e = n_modelResult.ModelReport.Errors[1].MSE;
            tr.ActualCount = series.ActualCount;
            tr.Name = "Нейнонная модель";
            tr.order = order;
            tr.ForecastCount = series.ForecastCount;
            tr.type = series.type;
            return tr;
        }
        public static TR S_Model(TR series, int order)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = series.ROW }, ats);
            var ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(SongForecastModel));
            //ssf.ActualCount = series.ActualCount;
            ssf.Order = order;
            ssf.ForecastCount = series.ForecastCount;
            var songModel = ssf.GetSongModel(_currentSeries.ACLSeries.FTS);
            songModel.ACLSeries = _currentSeries.ACLSeries;
            var s_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.Song, songModel);
            var tr = new TR();
            tr.ROW = new Series(s_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = s_modelResult
            }.PointList;
            tr.SMAPE_i = s_modelResult.ModelReport.Errors[0].SMAPE;
            tr.SMAPE_e = s_modelResult.ModelReport.Errors[1].SMAPE;
            tr.MSE_i = s_modelResult.ModelReport.Errors[0].MSE;
            tr.MSE_e = s_modelResult.ModelReport.Errors[1].MSE;
            tr.ActualCount = series.ActualCount;
            tr.Name = "модель Сонга";
            tr.order = order;
            tr.ForecastCount = series.ForecastCount;
            tr.type = series.type;
            return tr;
        }
        public static TR D_Model(TR series, int order)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = series.ROW }, ats);
            var d_ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(DForecastModel));
            d_ssf.Order = order;
            d_ssf.ActualCount = series.ActualCount;
            d_ssf.ForecastCount = series.ForecastCount;
            var tendModel = d_ssf.GetDModel(_currentSeries.ACLSeries);
            tendModel.ACLSeries = _currentSeries.ACLSeries;
            var d_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.D, tendModel);
            var tr = new TR();
            tr.ROW = new Series(d_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = d_modelResult
            }.PointList;
            tr.SMAPE_i = d_modelResult.ModelReport.Errors[0].SMAPE;
            tr.SMAPE_e = d_modelResult.ModelReport.Errors[1].SMAPE;
            tr.MSE_i = d_modelResult.ModelReport.Errors[0].MSE;
            tr.MSE_e = d_modelResult.ModelReport.Errors[1].MSE;
            tr.ActualCount = series.ActualCount;
            tr.Name = "модель Шах-Дегтярёв";
            tr.order = order;
            tr.ForecastCount = series.ForecastCount;
            tr.type = series.type;
            return tr;
        }
        public static TR T_Model(TR series, int order)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = series.ROW }, ats);
            var t_ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(DForecastModel));
            t_ssf.Order = order;
            t_ssf.ActualCount = series.ActualCount;
            t_ssf.ForecastCount = series.ForecastCount;
            var _tendModel = t_ssf.GetTendModel(_currentSeries.ACLSeries);
            _tendModel.ACLSeries = _currentSeries.ACLSeries;
            var t_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.D, _tendModel);
            var tr = new TR();
            tr.ROW = new Series(t_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = t_modelResult
            }.PointList;
            tr.SMAPE_i = t_modelResult.ModelReport.Errors[0].SMAPE;
            tr.SMAPE_e = t_modelResult.ModelReport.Errors[1].SMAPE;
            tr.MSE_i = t_modelResult.ModelReport.Errors[0].MSE;
            tr.MSE_e = t_modelResult.ModelReport.Errors[1].MSE;
            tr.ActualCount = series.ActualCount;
            tr.Name = "модель Тенденции";
            tr.order = order;
            tr.ForecastCount = series.ForecastCount;
            tr.type = series.type;
            return tr;
        }
        public static TR F_Model(TR series, int fCount)
        {
            var asf = new ACLSettingsForm(series.ROW);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(new Series() { PointList = series.ROW }, ats);
            var fModelSettings = new FForecastModelSettings(_currentSeries);
            var f_Model = fModelSettings.GetFModel(fCount);
            var f_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_Model);
            var f = new TR();
            f.ROW = new Series(f_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = f_modelResult
            }.PointList;
            f.Name = "F-модель сглаживание " + fCount.ToString();
            f.ForecastCount = series.ForecastCount;
            f.type = series.type;
            f.ActualCount = series.ActualCount;
            return f;
        }
        public static TR FO_model(TR tr, TR F_Model, int fCount)
        {
            var _df = new TR();
            _df.ROW = new SPointList();
            for (int i = 0; i < F_Model.ROW.Count; i++)
            {
                _df.ROW.Add(new SPoint() { X = F_Model.ROW[i].X, Y = tr.ROW[i].Y - F_Model.ROW[i].Y });
            }
            _df.Name = "F-модель сглаживание " + fCount + " - остатки";
            _df.ForecastCount = tr.ForecastCount;
            _df.type = tr.type;
            _df.ActualCount = tr.ActualCount;
            return _df;
        }
        public static void SaveTRInFile(TR tr, string path, string addName)
        {
            System.IO.Directory.CreateDirectory(path);
            var _fo = new StreamWriter(new FileStream(path + tr.Name.Split('.')[0] + addName + "." + tr.Name.Split('.')[1], FileMode.Create), Encoding.GetEncoding(65001));
            _fo.WriteLine("{0} {1}", tr.ForecastCount, tr.type);
            _fo.WriteLine(tr.ROW.Count);
            tr.ROW.ForEach(o => _fo.WriteLine("{0}\t{1}", o.X, o.Y));
            _fo.Close();
            _fo.Dispose();
        }


        #region old function
        public static void save(List<TRModel> model)
        {

            var _fo = new StreamWriter(new FileStream(@"d:\out_b2.html", FileMode.Append), Encoding.GetEncoding(65001));
            var fo = new StreamWriter(new FileStream(@"d:\table_b2.html", FileMode.Append), Encoding.GetEncoding(65001));
            //var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(model);
            //MemoryStream stream1 = new MemoryStream();
            //var ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SampleModel));
            //ser.WriteObject(stream1, model);
            //stream1.Position = 0;
            //StreamReader sr = new StreamReader(stream1);
            //fo.WriteLine(sr.ReadToEnd());
            //fo.Close();
            //sr.Close();
            //stream1.Close();

            _fo.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
            foreach (var item in model)
            {
                _fo.WriteLine("<div class=\"block\" id=\"{0}-item\">", item.Name);
                _fo.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}</div>", item.Name, item.Name + " моделирование основного временного ряда", item.fCount, item.type);
                foreach (var tr in item.TR)
                {
                    _fo.WriteLine("<div  class=\"block\" >");
                    _fo.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                    var str = "";
                    tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                    _fo.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                    _fo.WriteLine(@"</div>");
                }
                _fo.WriteLine(@"</div>");
            }
            _fo.WriteLine(@"</div>");

            //fo.WriteLine("<tr><td rowspan=\"{0}\" class=\"name {4}\">{1}, длина прогнозирования:{2} , тип данных:{3}</td>", model.Count, model[0].Name, model[0].fCount, model[0].type, model[0].type);
            //for (int i = 0; i < model.Count; i++)
            //{
            //    if (i != 0)
            //        fo.WriteLine("<tr>");
            //    fo.WriteLine("<td>{0}</td>", model[i].Name);
            //    foreach (var item in model[i].TR)
            //    {
            //        fo.WriteLine("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", item.MSE_i, item.MSE_e, item.SMAPE_i, item.SMAPE_e);
            //    }

            //    fo.WriteLine("</tr>");
            //}

            fo.WriteLine("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td>",
                model[0].Name,
                model[0].type,
                model[0].fCount,
                model[0].TR[1].Name,
                model[0].TR[1].order,
                model[0].TR[1].SMAPE_i,
                model[0].TR[1].SMAPE_e);

            fo.Close();
            _fo.Close();


        }
        public static void _save(List<TRModel> model)
        {
            model.ForEach(o => o.Name = o.Name.Replace('.', '_'));
            model.ForEach(o => o.TR.ForEach(p => p.Name = p.Name.Replace('.', '_')));
            string path = @"d:\test2";
            if (!System.IO.File.Exists(path + @"\out_free.html"))
            {
                var __fo = new StreamWriter(new FileStream(@"d:\test2\out_free.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            if (!System.IO.File.Exists(path + @"\type0.html"))
            {
                var __fo = new StreamWriter(new FileStream(@"d:\test2\type0.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            if (!System.IO.File.Exists(path + @"\type1.html"))
            {
                var __fo = new StreamWriter(new FileStream(path + @"\type1.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            if (!System.IO.File.Exists(path + @"\type2.html"))
            {
                var __fo = new StreamWriter(new FileStream(path + @"\type2.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            if (!System.IO.File.Exists(path + @"\type3.html"))
            {
                var __fo = new StreamWriter(new FileStream(path + @"\type3.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            if (!System.IO.File.Exists(path + @"\type4.html"))
            {
                var __fo = new StreamWriter(new FileStream(path + @"\type4.html", FileMode.Append), Encoding.GetEncoding(65001));
                __fo.WriteLine(header.header1);
                __fo.Close();
                __fo.Dispose();
            }
            var _fo = new StreamWriter(new FileStream(path + @"\out_free.html", FileMode.Append), Encoding.GetEncoding(65001));
            var _fo0 = new StreamWriter(new FileStream(path + @"\type0.html", FileMode.Append), Encoding.GetEncoding(65001));
            var _fo1 = new StreamWriter(new FileStream(path + @"\type1.html", FileMode.Append), Encoding.GetEncoding(65001));
            var _fo2 = new StreamWriter(new FileStream(path + @"\type2.html", FileMode.Append), Encoding.GetEncoding(65001));
            var _fo3 = new StreamWriter(new FileStream(path + @"\type3.html", FileMode.Append), Encoding.GetEncoding(65001));
            var _fo4 = new StreamWriter(new FileStream(path + @"\type4.html", FileMode.Append), Encoding.GetEncoding(65001));
            var fo = new StreamWriter(new FileStream(path + @"\table_free.html", FileMode.Append), Encoding.GetEncoding(65001));
            _fo.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
            foreach (var item in model)
            {

                var strt = "";
                switch (item.totalTend)
                {
                    case 0: strt += "\tРост"; break;
                    case 1: strt += "\tПадение"; break;
                    case 2: strt += "\tСтабилизация"; break;
                    case 3: strt += "\tКолебание"; break;
                    case 4: strt += "\tХаос"; break;
                }
                _fo.WriteLine("<div class=\"block\" id=\"{0}-item\">", item.Name);
                _fo.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", item.Name, item.Name + " моделирование основного временного ряда", item.fCount, item.type, strt);
                foreach (var tr in item.TR)
                {
                    _fo.WriteLine("<div  class=\"block\" >");
                    _fo.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                    var str = "";
                    tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                    _fo.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                    _fo.WriteLine(@"</div>");
                }
                _fo.WriteLine(@"</div>");
            }
            _fo.WriteLine(@"</div>");
            if (model.Count == 1)
            {

                var strt = "";
                switch (model[0].totalTend)
                {
                    case 0: strt += "\tРост"; break;
                    case 1: strt += "\tПадение"; break;
                    case 2: strt += "\tСтабилизация"; break;
                    case 3: strt += "\tКолебание"; break;
                    case 4: strt += "\tХаос"; break;
                }
                switch (model[0].totalTend)
                {
                    case 0:
                        #region Рост
                        _fo0.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
                        _fo0.WriteLine("<div class=\"block\" id=\"{0}-item\">", model[0].Name);
                        _fo0.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", model[0].Name, model[0].Name + " моделирование основного временного ряда", model[0].fCount, model[0].type, strt);
                        foreach (var tr in model[0].TR)
                        {
                            _fo0.WriteLine("<div  class=\"block\" >");
                            _fo0.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                            var str = "";
                            tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                            _fo0.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                            _fo0.WriteLine(@"</div>");
                        }
                        _fo0.WriteLine(@"</div>");
                        _fo0.WriteLine(@"</div>");
                        #endregion
                        break;
                    case 1:
                        #region Падение
                        _fo1.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
                        _fo1.WriteLine("<div class=\"block\" id=\"{0}-item\">", model[0].Name);
                        _fo1.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", model[0].Name, model[0].Name + " моделирование основного временного ряда", model[0].fCount, model[0].type, strt);
                        foreach (var tr in model[0].TR)
                        {
                            _fo1.WriteLine("<div  class=\"block\" >");
                            _fo1.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                            var str = "";
                            tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                            _fo1.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                            _fo1.WriteLine(@"</div>");
                        }
                        _fo1.WriteLine(@"</div>");
                        _fo1.WriteLine(@"</div>");
                        #endregion
                        break;
                    case 2:
                        #region Стабилизация
                        _fo2.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
                        _fo2.WriteLine("<div class=\"block\" id=\"{0}-item\">", model[0].Name);
                        _fo2.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", model[0].Name, model[0].Name + " моделирование основного временного ряда", model[0].fCount, model[0].type, strt);
                        foreach (var tr in model[0].TR)
                        {
                            _fo2.WriteLine("<div  class=\"block\" >");
                            _fo2.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                            var str = "";
                            tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                            _fo2.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                            _fo2.WriteLine(@"</div>");
                        }
                        _fo2.WriteLine(@"</div>");
                        _fo2.WriteLine(@"</div>");
                        #endregion
                        break;
                    case 3:
                        #region Колебание
                        _fo3.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
                        _fo3.WriteLine("<div class=\"block\" id=\"{0}-item\">", model[0].Name);
                        _fo3.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", model[0].Name, model[0].Name + " моделирование основного временного ряда", model[0].fCount, model[0].type, strt);
                        foreach (var tr in model[0].TR)
                        {
                            _fo3.WriteLine("<div  class=\"block\" >");
                            _fo3.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                            var str = "";
                            tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                            _fo3.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                            _fo3.WriteLine(@"</div>");
                        }
                        _fo3.WriteLine(@"</div>");
                        _fo3.WriteLine(@"</div>");
                        #endregion
                        break;
                    case 4:
                        #region Хаос
                        _fo4.WriteLine("<div class=\"block\" id=\"{0}\">", model[0].Name);
                        _fo4.WriteLine("<div class=\"block\" id=\"{0}-item\">", model[0].Name);
                        _fo4.WriteLine("<div class=\"title\" id=\"{0}-name\">{1} , длина прогнозирования:{2} , тип данных:{3}, тип ряда:{4}</div>", model[0].Name, model[0].Name + " моделирование основного временного ряда", model[0].fCount, model[0].type, strt);
                        foreach (var tr in model[0].TR)
                        {
                            _fo4.WriteLine("<div  class=\"block\" >");
                            _fo4.WriteLine("<div class=\"title\">{0}, порядок {5} , iMSE: {1}, eMSE: {2}, iSMAPE: {3}, eSMAPE: {4}</div>", tr.Name, tr.MSE_i, tr.MSE_e, tr.SMAPE_i, tr.SMAPE_e, tr.order);
                            var str = "";
                            tr.ROW.ForEach(o => str += o.Y.ToString() + ";");
                            _fo4.WriteLine("<div  class=\"tr\" tr=\"{0}\" ></div>", str);
                            _fo4.WriteLine(@"</div>");
                        }
                        _fo4.WriteLine(@"</div>");
                        _fo4.WriteLine(@"</div>");
                        #endregion
                        break;
                }

            }
            fo.WriteLine("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td>",
                model[0].Name,
                model[0].type,
                model[0].fCount,
                model[0].TR[1].Name,
                model[0].TR[1].order,
                model[0].TR[1].SMAPE_i,
                model[0].TR[1].SMAPE_e);

            fo.Close();
            _fo.Close();
            _fo0.Close();
            _fo1.Close();
            _fo2.Close();
            _fo3.Close();
            _fo4.Close();


        }
        public static List<TRModel> _doit(string fileName)
        {

            List<TRModel> model = new List<TRModel>();
            var series = new Series();
            series.LoadFormFile(fileName);
            series.CalcFunction();
            series.PointList.Name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Length - 1].Replace('.', '_');
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";
            //try
            //{
            model.Add(get_best_struct(series));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            ////////////////
            return model;

        }
        public static List<TRModel> free_doit(string fileName)
        {

            List<TRModel> model = new List<TRModel>();
            var series = new Series();
            series.LoadFormFile(fileName);
            series.CalcFunction();
            series.PointList.Name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Length - 1].Replace('.', '_');
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";
            //try
            //{
            model.Add(get_free_best_struct(series));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            ////////////////
            return model;

        }
        public static List<TRModel> f_doit(string fileName)
        {

            List<TRModel> model = new List<TRModel>();
            var series = new Series();
            series.LoadFormFile(fileName);
            series.CalcFunction();
            series.PointList.Name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Length - 1].Replace('.', '_');
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";
            //try
            //{
            model.Add(get_fmodel_struct(series));
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            ////////////////
            return model;

        }
        public static List<TRModel> doit(string fileName)
        {

            List<TRModel> model = new List<TRModel>();
            var series = new Series();
            series.LoadFormFile(fileName);
            series.CalcFunction();
            series.PointList.Name = fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[fileName.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Length - 1].Replace('.', '_');
            series.PointList.XName = "Время";
            series.PointList.YName = "Значения ряда";
            try
            {
                model.Add(get_struct(series));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries currentSeries = new ModelSeries(series, ats);
            ////////////////
            if (series.type == "daily")
            {
                /////////////////////
                var fModelSettings = new FForecastModelSettings(currentSeries);
                var f_31_Model = fModelSettings.GetFModel(31);
                var f_31_modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31 = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult
                };
                f_31.PointList.Name = "F-модель сглаживание 31";
                f_31.ForecastCount = series.ForecastCount;
                f_31.type = series.type;
                try
                {
                    model.Add(get_struct(f_31));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                /////////////////////
                var f_31_Model_ = fModelSettings.GetFModel(31);
                f_31_Model_.delta();
                var f_31_modelResult_ = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31_ = new Series(f_31_modelResult_.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult_
                };
                f_31_.PointList.Name = "остатки F-модель сглаживание 31";
                f_31_.ForecastCount = series.ForecastCount;
                f_31_.type = series.type;
                model.Add(get_struct(f_31_));
                /////////////////////
                var f_7_Model = fModelSettings.GetFModel(7);
                var f_7_modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_7_Model);
                var f_7 = new Series(f_7_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_7_modelResult
                };
                f_7.PointList.Name = "F-модель сглаживание 7";
                f_7.ForecastCount = series.ForecastCount;
                f_7.type = series.type;
                try
                {
                    model.Add(get_struct(f_7));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                /////////////////////
                var f_7_Model_ = fModelSettings.GetFModel(31);
                f_7_Model_.delta();
                var f_7_modelResult_ = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_7_Model_);
                var f_7_ = new Series(f_7_modelResult_.ForecastModel.GetForecastSeries())
                {
                    Tag = f_7_modelResult_
                };
                f_7_.PointList.Name = "остатки F-модель сглаживание 7";
                f_7_.ForecastCount = series.ForecastCount;
                f_7_.type = series.type;
                try
                {
                    model.Add(get_struct(f_7_));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (series.type == "monthly")
            {

                /////////////////////
                var fModelSettings = new FForecastModelSettings(currentSeries);
                var f_31_Model = fModelSettings.GetFModel(11);
                var f_31_modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31 = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult
                };
                f_31.PointList.Name = "F-модель сглаживание 11";
                f_31.ForecastCount = series.ForecastCount;
                f_31.type = series.type;
                try
                {
                    model.Add(get_struct(f_31));
                }
                catch { }
                /////////////////////
                var f_31_Model_ = fModelSettings.GetFModel(11);
                f_31_Model_.delta();
                var f_31_modelResult_ = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31_ = new Series(f_31_modelResult_.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult_
                };
                f_31_.PointList.Name = "остатки F-модель сглаживание 11";
                f_31_.ForecastCount = series.ForecastCount;
                f_31_.type = series.type;
                model.Add(get_struct(f_31_));
                /////////////////////
                var f_7_Model = fModelSettings.GetFModel(3);
                var f_7_modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_7_Model);
                var f_7 = new Series(f_7_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_7_modelResult
                };
                f_7.PointList.Name = "остатки F-модель сглаживание 3";
                f_7.ForecastCount = series.ForecastCount;
                f_7.type = series.type;
                try
                {
                    model.Add(get_struct(f_7));
                }
                catch { }
                /////////////////////
                var f_7_Model_ = fModelSettings.GetFModel(3);
                f_7_Model_.delta();
                var f_7_modelResult_ = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_7_Model_);
                var f_7_ = new Series(f_7_modelResult_.ForecastModel.GetForecastSeries())
                {
                    Tag = f_7_modelResult_
                };
                f_7_.PointList.Name = "остатки F-модель сглаживание 3";
                f_7_.ForecastCount = series.ForecastCount;
                f_7_.type = series.type;
                model.Add(get_struct(f_7_));
            }
            else if (series.type == "quarterly")
            {

                /////////////////////
                var fModelSettings = new FForecastModelSettings(currentSeries);
                var f_31_Model = fModelSettings.GetFModel(3);
                var f_31_modelResult = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31 = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult
                };
                f_31.PointList.Name = "F-модель сглаживание 3";
                f_31.ForecastCount = series.ForecastCount;
                f_31.type = series.type;
                try
                {
                    model.Add(get_struct(f_31));
                }
                catch { }
                /////////////////////
                var f_31_Model_ = fModelSettings.GetFModel(3);
                f_31_Model_.delta();
                var f_31_modelResult_ = new ModelResult(currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31_ = new Series(f_31_modelResult_.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult_
                };
                f_31_.PointList.Name = "остатки F-модель сглаживание 3";
                f_31_.ForecastCount = series.ForecastCount;
                f_31_.type = series.type;
                try
                {
                    model.Add(get_struct(f_31_));
                }
                catch { }
            }
            return model;

        }
        public static TRModel get_best_struct(Series series)
        {
            var model = new TRModel();
            double b_iSMAPE = 10000000;
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            model.type = series.type;
            model.fCount = series.ForecastCount;
            model.Name = series.PointList.Name;
            model.TR = new List<TR>();
            model.TR.Add(new TR() { ROW = series.PointList, Name = "base" });
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(series, ats);
            TR tr = new TR(series);
            #region base model
            //нейнонная
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var ntr = N_Model(tr, i + 1);
                    listModel.Add(ntr);
                }
                catch { }
            }
            //Мамдани
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var str = S_Model(tr, i + 1);
                    listModel.Add(str);
                }
                catch { }

            }
            //Шах-Дегтярёв
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var dtr = D_Model(tr, i + 1);
                    listModel.Add(dtr);
                }
                catch { }
            }
            //Тенденции
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var ttr = T_Model(tr, i + 1);
                    listModel.Add(ttr);
                }
                catch { }
            }
            #endregion
            double min = 1000000000;
            foreach (var item in listModel)
                if (min > (item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i)))
                {
                    b_model = item;
                    min = item.SMAPE_i * (Math.Abs(item.SMAPE_i - item.SMAPE_e) / item.SMAPE_i);
                }
            model.TR.Add(b_model);
            return model;
        }
        public static TRModel get_fmodel_struct(Series series)
        {
            var model = new TRModel();
            TR b_model = new TR();
            model.type = series.type;
            model.fCount = series.ForecastCount;
            model.Name = series.PointList.Name;
            model.TR = new List<TR>();
            model.TR.Add(new TR() { ROW = series.PointList, Name = "base" });
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(series, ats);
            if (series.type == "daily")
            {
                var fModelSettings = new FForecastModelSettings(_currentSeries);
                /////////////////////
                var f_31_Model = fModelSettings.GetFModel(31);
                var f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                var f_31 = new TR();
                f_31.ROW = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_31_modelResult
                }.PointList;
                f_31.Name = "F-модель сглаживание 31";
                model.TR.Add(f_31);
                /////////////////////
                var f_7_Model = fModelSettings.GetFModel(7);
                var f_7_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_7_Model);
                var f_7 = new TR();
                f_7.ROW = new Series(f_7_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_7
                }.PointList;
                f_7.Name = "F-модель сглаживание 7";
                model.TR.Add(f_7);
            }
            else if (series.type == "monthly")
            {
                var fModelSettings = new FForecastModelSettings(_currentSeries);
                /////////////////////
                var f_3_Model = fModelSettings.GetFModel(3);
                var f_3_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_3_Model);
                var f_3 = new TR();
                f_3.ROW = new Series(f_3_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_3_modelResult
                }.PointList;
                f_3.Name = "F-модель сглаживание 3";
                model.TR.Add(f_3);
                /////////////////////
                var f_12_Model = fModelSettings.GetFModel(12);
                var f_12_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_12_Model);
                var f_12 = new TR();
                f_12.ROW = new Series(f_12_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_12_modelResult
                }.PointList;
                f_12.Name = "F-модель сглаживание 12";
                model.TR.Add(f_12);
            }
            else if (series.type == "quarterly")
            {
                var fModelSettings = new FForecastModelSettings(_currentSeries);
                /////////////////////
                var f_4_Model = fModelSettings.GetFModel(3);
                var f_4_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_4_Model);
                var f_4 = new TR();
                f_4.ROW = new Series(f_4_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_4_modelResult
                }.PointList;
                f_4.Name = "F-модель сглаживание 4";
                model.TR.Add(f_4);
            }
            else
            {
                var fModelSettings = new FForecastModelSettings(_currentSeries);
                /////////////////////
                var f_5_Model = fModelSettings.GetFModel(5);
                var f_5_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_5_Model);
                var f_5 = new TR();
                f_5.ROW = new Series(f_5_modelResult.ForecastModel.GetForecastSeries())
                {
                    Tag = f_5_modelResult
                }.PointList;
                f_5.Name = "F-модель сглаживание 5";
                model.TR.Add(f_5);
            }
            return model;
        }
        public static TRModel get_free_best_struct(Series series)
        {
            var model = new TRModel();
            double b_iSMAPE = 10000000;
            TR b_model = new TR();
            List<TR> listModel = new List<TR>();
            model.type = series.type;
            model.fCount = series.ForecastCount;
            model.Name = series.PointList.Name;
            model.TR = new List<TR>();
            model.TR.Add(new TR() { ROW = series.PointList, Name = "base" });
            model.totalTend = getTend(new TR(series));
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(series, ats);

            switch (model.totalTend)
            {
                case 0:
                //"\tРост";
                case 1:
                    //"\tПадение"; шах дихтерем 1
                    #region Рост Падение
                    try
                    {
                        var d_ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(DForecastModel));
                        d_ssf.Order = 1;
                        d_ssf.ActualCount = series.ForecastCount;
                        d_ssf.ForecastCount = series.ForecastCount;
                        var tendModel = d_ssf.GetDModel(_currentSeries.ACLSeries);
                        tendModel.ACLSeries = _currentSeries.ACLSeries;
                        var d_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.D, tendModel);
                        var dtr = new TR();
                        dtr.ROW = new Series(d_modelResult.ForecastModel.GetForecastSeries())
                        {
                            Tag = d_modelResult
                        }.PointList;
                        dtr.SMAPE_i = d_modelResult.ModelReport.Errors[0].SMAPE;
                        dtr.SMAPE_e = d_modelResult.ModelReport.Errors[1].SMAPE;
                        dtr.MSE_i = d_modelResult.ModelReport.Errors[0].MSE;
                        dtr.MSE_e = d_modelResult.ModelReport.Errors[1].MSE;
                        dtr.Name = "модель Шах-Дегтярёв";
                        dtr.order = 1;
                        model.TR.Add(dtr);
                    }
                    catch (Exception e) { }
                    #endregion
                    break;
                case 2:
                    #region Стабилизация
                    model.TR.Add(get_best_struct(series).TR[1]);
                    #endregion
                    break;
                case 3:
                case 4:
                    #region Хаос Колебание

                    var fm = new TRModel();
                    fm.TR = new List<TR>();
                    var fmd = new TRModel();
                    fmd.TR = new List<TR>();
                    #region Получение f моделей
                    if (series.type == "daily")
                    {
                        var fModelSettings = new FForecastModelSettings(_currentSeries);
                        /////////////////////
                        var f_31_Model = fModelSettings.GetFModel(31);
                        var f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                        var f_31 = new TR();
                        f_31.ROW = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                        {
                            Tag = f_31_modelResult
                        }.PointList;
                        f_31.Name = "F-модель сглаживание 31";
                        fm.TR.Add(f_31);
                        var _df = new TR();
                        _df.ROW = new SPointList();
                        for (int i = 0; i < f_31.ROW.Count; i++)
                        {
                            _df.ROW.Add(new SPoint() { X = f_31.ROW[i].X, Y = series.PointList[i].Y - f_31.ROW[i].Y });
                        }
                        //var df = fModelSettings.GetFModel(31);
                        //df.delta();
                        //var dfmr = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, df);
                        //var _df = new TR();
                        //_df.ROW = new Series(dfmr.ForecastModel.GetForecastSeries())
                        //{
                        //    Tag = dfmr
                        //}.PointList;
                        _df.Name = "F-модель сглаживание 31 - остатки";
                        fmd.TR.Add(_df);

                    }
                    else if (series.type == "monthly")
                    {
                        var fModelSettings = new FForecastModelSettings(_currentSeries);
                        /////////////////////
                        var f_31_Model = fModelSettings.GetFModel(12);
                        var f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                        var f_31 = new TR();
                        f_31.ROW = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                        {
                            Tag = f_31_modelResult
                        }.PointList;
                        f_31.Name = "F-модель сглаживание 12";
                        fm.TR.Add(f_31);
                        var _df = new TR();
                        _df.ROW = new SPointList();
                        for (int i = 0; i < f_31.ROW.Count; i++)
                        {
                            _df.ROW.Add(new SPoint() { X = f_31.ROW[i].X, Y = series.PointList[i].Y - f_31.ROW[i].Y });
                        }
                        _df.Name = "F-модель сглаживание 12 - остатки";
                        fmd.TR.Add(_df);
                    }
                    else if (series.type == "quarterly")
                    {
                        var fModelSettings = new FForecastModelSettings(_currentSeries);
                        /////////////////////
                        var f_31_Model = fModelSettings.GetFModel(4);
                        var f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, f_31_Model);
                        var f_31 = new TR();
                        f_31.ROW = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
                        {
                            Tag = f_31_modelResult
                        }.PointList;
                        f_31.Name = "F-модель сглаживание 4";
                        fm.TR.Add(f_31);
                        var _df = new TR();
                        _df.ROW = new SPointList();
                        for (int i = 0; i < f_31.ROW.Count; i++)
                        {
                            _df.ROW.Add(new SPoint() { X = f_31.ROW[i].X, Y = series.PointList[i].Y - f_31.ROW[i].Y });
                        }
                        _df.Name = "F-модель сглаживание 4 - остатки";
                        fmd.TR.Add(_df);
                    }
                    else
                    {
                        model.TR.Add(get_best_struct(series).TR[1]);
                        return model;
                    }
                    #endregion
                    #region обработка f моделей rez rezd
                    var rez = get_best_struct(new Series()
                    {
                        type = series.type,
                        Tag = series.Tag,
                        ForecastCount = series.ForecastCount,
                        PointList = fm.TR[0].ROW
                    });
                    var rezd = get_best_struct(new Series()
                    {
                        type = series.type,
                        Tag = series.Tag,
                        ForecastCount = series.ForecastCount,
                        PointList = fmd.TR[0].ROW
                    });
                    #endregion
                    TR tr = new TR();
                    var _ROW = new SPointList();
                    for (int i = 0; i < rez.TR[1].ROW.Count; i++)
                    {
                        _ROW.Add(new SPoint()
                        {
                            X = rez.TR[1].ROW[i].X,
                            Y = rez.TR[1].ROW[i].Y + rezd.TR[1].ROW[i].Y
                        });
                    }
                    tr.ROW = _ROW;
                    tr.MSE_e = rez.TR[1].MSE_e;
                    tr.MSE_i = rez.TR[1].MSE_i;
                    tr.SMAPE_e = rez.TR[1].SMAPE_e;
                    tr.SMAPE_i = rez.TR[1].SMAPE_i;
                    tr.order = rez.TR[1].order;
                    tr.Name = "f-модель:" + rez.TR[1].Name + ", модель остатков:" + rezd.TR[1].Name;
                    //model.TR = new List<TR>();
                    model.TR.Add(fm.TR[0]);
                    model.TR.Add(fmd.TR[0]);
                    model.TR.Add(rez.TR[1]);
                    model.TR.Add(rezd.TR[1]);
                    model.TR.Add(tr);
                    //FillGeneralTendInline(new Series() { PointList = summ.TR[0].ROW });
                    #endregion
                    break;
            }
            return model;
        }
        public static TRModel get_struct(Series series)
        {
            var model = new TRModel();
            model.type = series.type;
            model.fCount = series.ForecastCount;
            model.Name = series.PointList.Name;
            model.TR = new List<TR>();
            model.TR.Add(new TR() { ROW = series.PointList, Name = "base" });
            var asf = new ACLSettingsForm(series.PointList);
            var ats = asf.ACLSeries;
            ModelSeries _currentSeries = new ModelSeries(series, ats);
            #region base model
            //нейнонная
            var pts = series.PointList;
            var nsf = new NeuralSettingForm(pts.Count);
            nsf.ActualCount = series.ForecastCount;
            nsf.ForecastCount = series.ForecastCount;
            nsf.Order = _order;
            var neuronModel = nsf.GetNModel(pts);
            neuronModel.ACLSeries = _currentSeries.ACLSeries;
            var n_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.Neural, neuronModel);
            var ntr = new TR();
            ntr.ROW = new Series(n_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = n_modelResult
            }.PointList;
            ntr.SMAPE_i = n_modelResult.ModelReport.Errors[0].SMAPE;
            ntr.SMAPE_e = n_modelResult.ModelReport.Errors[1].SMAPE;
            ntr.MSE_i = n_modelResult.ModelReport.Errors[0].MSE;
            ntr.MSE_e = n_modelResult.ModelReport.Errors[1].MSE;
            ntr.Name = "Нейнонная модель";
            model.TR.Add(ntr);
            //Мамдани
            var ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(SongForecastModel));
            ssf.ActualCount = series.ForecastCount;
            ssf.Order = _order + 1;
            ssf.ForecastCount = series.ForecastCount;
            var songModel = ssf.GetSongModel(_currentSeries.ACLSeries.FTS);
            songModel.ACLSeries = _currentSeries.ACLSeries;
            var s_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.Song, songModel);
            var str = new TR();
            str.ROW = new Series(s_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = s_modelResult
            }.PointList;
            str.SMAPE_i = s_modelResult.ModelReport.Errors[0].SMAPE;
            str.SMAPE_e = s_modelResult.ModelReport.Errors[1].SMAPE;
            str.MSE_i = s_modelResult.ModelReport.Errors[0].MSE;
            str.MSE_e = s_modelResult.ModelReport.Errors[1].MSE;
            str.Name = "модель Мамдани";
            model.TR.Add(str);
            //Шах-Дегтярёв
            var d_ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(DForecastModel));
            d_ssf.Order = _order;
            d_ssf.ActualCount = series.ForecastCount;
            d_ssf.ForecastCount = series.ForecastCount;
            var tendModel = d_ssf.GetDModel(_currentSeries.ACLSeries);
            tendModel.ACLSeries = _currentSeries.ACLSeries;
            var d_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.D, tendModel);
            var dtr = new TR();
            dtr.ROW = new Series(d_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = d_modelResult
            }.PointList;
            dtr.SMAPE_i = d_modelResult.ModelReport.Errors[0].SMAPE;
            dtr.SMAPE_e = d_modelResult.ModelReport.Errors[1].SMAPE;
            dtr.MSE_i = d_modelResult.ModelReport.Errors[0].MSE;
            dtr.MSE_e = d_modelResult.ModelReport.Errors[1].MSE;
            dtr.Name = "модель Шах-Дегтярёв";
            model.TR.Add(dtr);
            //Тенденции
            var t_ssf = new ModelSettingForm(_currentSeries.series.PointList.Count, typeof(DForecastModel));
            t_ssf.Order = _order;
            t_ssf.ActualCount = series.ForecastCount;
            t_ssf.ForecastCount = series.ForecastCount;
            var _tendModel = t_ssf.GetTendModel(_currentSeries.ACLSeries);
            _tendModel.ACLSeries = _currentSeries.ACLSeries;
            var t_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.D, _tendModel);
            var ttr = new TR();
            ttr.ROW = new Series(t_modelResult.ForecastModel.GetForecastSeries())
            {
                Tag = t_modelResult
            }.PointList;
            ttr.SMAPE_i = t_modelResult.ModelReport.Errors[0].SMAPE;
            ttr.SMAPE_e = t_modelResult.ModelReport.Errors[1].SMAPE;
            ttr.MSE_i = t_modelResult.ModelReport.Errors[0].MSE;
            ttr.MSE_e = t_modelResult.ModelReport.Errors[1].MSE;
            ttr.Name = "модель Тенденции";
            model.TR.Add(ttr);
            #endregion
            //F-модель
            //if (series.type == "daily")
            //{
            //    var fModelSettings = new FForecastModelSettings(_currentSeries);
            //    var fModel = fModelSettings.GetFModel(31);
            //    var f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, fModel);
            //    model.FPoint = new Series(f_31_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = f_31_modelResult
            //    }.PointList;
            //    var d_fModel = fModelSettings.GetFModel(31);
            //    d_fModel.delta();
            //    var f_31_d_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, d_fModel);
            //    model.d_FPoint = new Series(f_31_d_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = f_31_d_modelResult
            //    }.PointList;
            //    //
            //    currentSeries = new ModelSeries(new Series()
            //    {
            //        PointList = model.d_FPoint,
            //        type = series.type,
            //        ForecastCount = series.ForecastCount,
            //        Tag = series.Tag
            //    }, new ACLSettingsForm(model.FPoint).ACLSeries);
            //    ComplexAnalysis bfca = new ComplexAnalysis();
            //    bfca.Setting(series.ForecastCount, series.ForecastCount * 2, _order);
            //    var f_31_best_modelResult = ComplexAnalysis(bfca);
            //    model.best_FPoint = new Series(f_31_best_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = f_31_best_modelResult
            //    }.PointList;
            //    model.i_smape_best_F = f_31_best_modelResult.ModelReport.Errors[0].MAPE;
            //    model.e_smape_best_F = f_31_best_modelResult.ModelReport.Errors[1].MAPE;
            //    model.best_F = f_31_best_modelResult.NameOfModel;
            //    //
            //    currentSeries = new ModelSeries(new Series()
            //    {
            //        PointList = model.FPoint,
            //        type = series.type,
            //        ForecastCount = series.ForecastCount,
            //        Tag = series.Tag
            //    }, new ACLSettingsForm(model.FPoint).ACLSeries);
            //    ComplexAnalysis ca = new ComplexAnalysis();
            //    ca.Setting(series.ForecastCount, series.ForecastCount * 2, _order);
            //    var f_31_d_best_modelResult = ComplexAnalysis(ca);
            //    model.best_d_FPoint = new Series(f_31_d_best_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = f_31_d_best_modelResult
            //    }.PointList;
            //    model.i_smape_best_d_F = f_31_d_best_modelResult.ModelReport.Errors[0].MAPE;
            //    model.e_smape_best_d_F = f_31_d_best_modelResult.ModelReport.Errors[1].MAPE;
            //    model.best_d_F = f_31_best_modelResult.NameOfModel;

            //    ///////////////////////////////////

            //    var _fModel = fModelSettings.GetFModel(7);
            //    var _f_31_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, _fModel);
            //    model.FPoint_ = new Series(_f_31_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = _f_31_modelResult
            //    }.PointList;
            //    var _d_fModel = fModelSettings.GetFModel(7);
            //    _d_fModel.delta();
            //    var _f_31_d_modelResult = new ModelResult(_currentSeries.ACLSeries, ForecastModelType.F, _d_fModel);
            //    model.d_FPoint_ = new Series(_f_31_d_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = _f_31_d_modelResult
            //    }.PointList;
            //    //
            //    currentSeries = new ModelSeries(new Series()
            //    {
            //        PointList = model.d_FPoint_,
            //        type = series.type,
            //        ForecastCount = series.ForecastCount,
            //        Tag = series.Tag
            //    }, new ACLSettingsForm(model.FPoint).ACLSeries);
            //    ComplexAnalysis _bfca = new ComplexAnalysis();
            //    _bfca.Setting(series.ForecastCount, series.ForecastCount * 2, _order);
            //    var _f_31_best_modelResult = ComplexAnalysis(bfca);
            //    model.best_FPoint_ = new Series(_f_31_best_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = _f_31_best_modelResult
            //    }.PointList;
            //    model.i_smape_best_F_ = _f_31_best_modelResult.ModelReport.Errors[0].MAPE;
            //    model.e_smape_best_F_ = _f_31_best_modelResult.ModelReport.Errors[1].MAPE;
            //    model.best_F_ = _f_31_best_modelResult.NameOfModel;
            //    //
            //    currentSeries = new ModelSeries(new Series()
            //    {
            //        PointList = model.FPoint_,
            //        type = series.type,
            //        ForecastCount = series.ForecastCount,
            //        Tag = series.Tag
            //    }, new ACLSettingsForm(model.FPoint).ACLSeries);
            //    ComplexAnalysis _ca = new ComplexAnalysis();
            //    _ca.Setting(series.ForecastCount, series.ForecastCount * 2, _order);
            //    var _f_31_d_best_modelResult = ComplexAnalysis(ca);
            //    model.best_d_FPoint_ = new Series(_f_31_d_best_modelResult.ForecastModel.GetForecastSeries())
            //    {
            //        Tag = _f_31_d_best_modelResult
            //    }.PointList;
            //    model.i_smape_best_d_F_ = _f_31_d_best_modelResult.ModelReport.Errors[0].MAPE;
            //    model.e_smape_best_d_F_ = _f_31_d_best_modelResult.ModelReport.Errors[1].MAPE;
            //    model.best_d_F_ = _f_31_d_best_modelResult.NameOfModel;


            //}

            return model;
        }
        #endregion
        #region add function
        private static ModelResult ComplexAnalysis(ComplexAnalysis ca)
        {
            #region function
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
                                    catch (Exception ex) { }
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
                    return null;
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
            #endregion
            return results[max_index];
            //currentSeries.Results.Add(results[max_index]);
            //currentSeries.ACLSeries.Scale.ISP = results[max_index].aclSeries.Scale.ISP;
        }


        private static ModelResult AddNeuralForecastModel(int order, int fpc, int forecast)
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
        private static ModelResult AddSongForecastModel(bool useRules, int order, int fpc, int forecast)
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
        private static ModelResult AddDForecastModel(bool useRules, int order, int fpc, int forecast)
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
        private static ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc, int isp, int forecast)
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
        private static ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc)
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
        private static ACLTimeSeries GetAclTimeSeries()
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


        private static ModelResult AddTendForecastModel(bool useRules, int type, int order, int fpc, int isp)
        {
            return AddTendForecastModel(useRules, type, order, fpc, isp, 0);
        }

        private static bool useFModels = false;
        #endregion
    }

}
