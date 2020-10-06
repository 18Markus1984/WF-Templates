using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template2
{
    public partial class Dashboard : UserControl
    {
        public int progessBarValue = 65;
        public int earning = 2334;
        public float turn = 0;
        public int pause = 0;
        public Random rnd = new Random();


        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 1;

            chart2.Series.Clear();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = Color.FromArgb(0, 126, 249),
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                BorderWidth = 4,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
            };
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series2",
                //Color = Color.FromArgb(252, 180, 65),
                Color = Color.FromArgb(50, 226, 178),
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                BorderWidth = 4,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
            };

            this.chart2.Series.Add(series1);
            this.chart2.Series.Add(series2);

            for (int i = 0; i < 21; i++)
            {
                series1.Points.AddXY(i, f(i));
                series2.Points.AddXY(i, f(i));
            }
            chart2.Invalidate();
        }

        private double f(int i)
        {
            return rnd.Next(2, 100); 
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (progessBarValue > circularProgressBar1.Value +20 && pause == 0)
            {
                circularProgressBar1.Value += 20;
                pause = 1;
            }
            else if (progessBarValue  > circularProgressBar1.Value + 5 && pause == 0)
            {
                circularProgressBar1.Value += 5;
                pause = 1;
            }
            else if (progessBarValue > circularProgressBar1.Value && pause == 0)
            {
                circularProgressBar1.Value += 1;
                pause = 2;
            }
            else if(progessBarValue != circularProgressBar1.Value)
            {
                pause--; ;
            }
            circularProgressBar1.Text = circularProgressBar1.Value + "%";

            if (turn + 500 < earning)
            {
                turn = turn + 500;
            }
            else if(turn + 100 < earning)
            {
                turn = turn + 100;
            }
            else if (turn + 10 < earning)
            {
                turn = turn + 10;
            }
            else if (turn < earning)
            {
                turn++;
            }
            label5.Text = turn + "$";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form tmp = this.FindForm();
            tmp.Close();
            tmp.Dispose();
        }

        public void reset()
        {
            circularProgressBar1.Value = 0;
            turn = 0;
        }
    }
}
