using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimExpertGUI
{
    public partial class ChartForm : Form
    {
        private string SeriesName;
        private List<double> XY;
        public ChartForm(List<double> XY,string SeriesName,Tuple<string,string> Data)
        {
            this.XY = XY;
            this.SeriesName = SeriesName;
            
            InitializeComponent();
            chart1.Series.First().Name = SeriesName;
            int count = 1;
            foreach (var a in XY)
            {
                chart1.Series[SeriesName].Points.AddXY(count, a);
                count++;
            }
            chart1.Series[SeriesName]["PointWidth"] = "1";
            label1.Text = Data.Item1 + ":" + "\t" + Data.Item2;
            
        }

        public ChartForm(Dictionary<string, long> XY, string SeriesName, Tuple<string, string> Data)
        {
            InitializeComponent();
            chart1.Series.First().Name = SeriesName;
            foreach (string a in XY.Keys)
            {
                chart1.Series[SeriesName].Points.AddXY(a, XY[a]);
                
            }
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
