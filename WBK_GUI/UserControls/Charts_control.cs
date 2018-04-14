using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WBK_GUI.UserControls
{
    public partial class Charts_control : UserControl
    {
        public Charts_control()
        {
            InitializeComponent();
        }
        private IList<Button> Charts_Left = new List<Button>();
        private IList<Button> Charts_Right = new List<Button>();
        private IList<Array> Charts_Values = new List<Array>();
        private double[] Charts_array_left = new double[7];
        private int[] Charts_array_right = new int[7];

        private void Charts_control_Load(object sender, EventArgs e)
        {
            Charts_Left.Add(Chart1_Left);
            Charts_Left.Add(Chart2_Left);
            Charts_Left.Add(Chart3_Left);
            Charts_Left.Add(Chart4_Left);
            Charts_Left.Add(Chart5_Left);
            Charts_Left.Add(Chart6_Left);
            Charts_Left.Add(Chart7_Left);

            Charts_Right.Add(Chart1_Right);
            Charts_Right.Add(Chart2_Right);
            Charts_Right.Add(Chart3_Right);
            Charts_Right.Add(Chart4_Right);
            Charts_Right.Add(Chart5_Right);
            Charts_Right.Add(Chart6_Right);
            Charts_Right.Add(Chart7_Right);

            timer1.Interval = 100;
            Random rd = new Random();
            for (int i = 0; i < 7; i++)
            {
                Charts_array_left[i] = rd.Next(1, 50000);
                Charts_array_right[i] = rd.Next(1, 50000);

                Color col = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255));
                Charts_Left[i].BackColor = col;
                Charts_Right[i].BackColor = col;

                if (Charts_array_left[i] > Charts_array_right[i])
                {
                    Charts_Left[i].Location = new Point(Charts_Left[i].Location.X - (450 - Charts_Left[i].Width), Charts_Left[i].Location.Y);
                    Charts_Left[i].Width = 450;
                    Charts_Left[i].Text = Charts_array_left[i].ToString();
                    Charts_Right[i].Width = (int)(450 * (Charts_array_right[i] / Charts_array_left[i]));
                    Charts_Right[i].Text = Charts_array_right[i].ToString();
                }
                else
                {
                    Charts_Right[i].Width = 450;
                    Charts_Right[i].Text = Charts_array_right[i].ToString();

                    Charts_Left[i].Location = new Point(Charts_Left[i].Location.X+(Charts_Left[i].Width- (int)(450 * (Charts_array_left[i] / Charts_array_right[i]))), Charts_Left[i].Location.Y);
                    Charts_Left[i].Width = (int)(450 * (Charts_array_left[i] / Charts_array_right[i]));
                    Charts_Left[i].Text = Charts_array_left[i].ToString();
                }


            }



        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
