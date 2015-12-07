using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimExpert;

namespace SimExpertGUI
{
    public partial class ChartSelection : Form
    {
        private List<Statistics> Stats;
        private Form Parent;
        public ChartSelection(List<Statistics> Stats,Form Parent)
        {
            this.Stats = Stats;
            this.Parent = Parent;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> stat = Stats[0].EntityStatistics.Select(t => t.TotalQueueDelay).ToList();
            double average = stat.Average(t => t);
            Tuple<string,string> Data = new Tuple<string,string>("Average Delay",average.ToString());
            ChartForm cf = new ChartForm(stat,"Delay Time",Data);
            cf.Show();
        }

        private void ChartSelection_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
