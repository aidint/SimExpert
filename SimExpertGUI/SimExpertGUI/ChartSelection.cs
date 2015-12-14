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
            List<double> AverageDelayOverall = Stats.Select(t => t.EntityStatistics.Average(z => z.TotalQueueDelay)).ToList();
            Tuple<string, string> Data = new Tuple<string, string>("Average Delay Overall", AverageDelayOverall.Average(t => t).ToString());
            ChartForm cf = new ChartForm(AverageDelayOverall, "Average Delay", Data);
            cf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();
            for (int i = 0; i <= 11; i++) dict.Add((i * 20).ToString(), 0);
            var holder = Stats.Select(t => t.InventoryStatistics).ToList();
            var holder2 = holder.Select(t => t[0].OtherStatistics).ToList();
            double sum = 0;
            foreach (var x in holder2)
            {
                var holder3 = x.Select(t => t.Value).ToList();
                double Profit = holder3.Select(t => t.Last()).Sum(t=>(double) t.StatisticValue);
                sum += Profit;
                dict[(((int)Profit / 20)*20).ToString()] += 1;
            }
            Tuple<string,string> Data = new Tuple<string,string>("Average Profit",(sum/holder2.Count).ToString());
            ChartForm cf = new ChartForm(dict, "Bin Frequencies", Data);
            cf.Show();
        }
    }
}
