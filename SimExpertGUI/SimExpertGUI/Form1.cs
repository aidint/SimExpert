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
using SimExpert.Samples;
using System.Reflection;

namespace SimExpertGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Samples = new string[] { "Able&Baker", "Chain", "Inventory", "Decide", "Probability Share", "Shared Queue", "Simple Simulation" };
            comboBox1.Items.AddRange(Samples);
            comboBox1.Text = "Choose a code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sample sample = null;
            string code = comboBox1.SelectedItem.ToString();
            int NumberOfSimulations;
            int.TryParse(textBox1.Text,out NumberOfSimulations);
            switch (code)
            {
                case "Able&Baker":
                    sample = new AbleBaker();
                    break;
                case "Chain":
                    sample = new Chain();
                    break;
                case "Inventory":
                    sample = new InventorySample();
                    break;
                case "Decide":
                    sample = new SimpleDecide();
                    break;
                case "Probability":
                    sample = new SimpleProbShare();
                    break;
                case "Shared Queue":
                    sample = new SimpleSharedQueue();
                    break;
                case "Simple Simulation":
                    sample = new SimpleSimulation();
                    break;
                default:
                    sample = new SimpleSimulation();
                    break;
            }
            List<Statistics> Stats = new List<Statistics>();
            for (int i = 0; i < NumberOfSimulations; i++)
                Stats.Add(sample.run());

            ChartSelection cs = new ChartSelection(Stats,this);
            cs.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
