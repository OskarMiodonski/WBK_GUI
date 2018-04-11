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
        private List<Button> Charts_Left = new List<Button>(7);
        private List<Button> Charts_Right = new List<Button>(7);

        private void Charts_control_Load(object sender, EventArgs e)
        {
            Charts_Left[0] = Chart1_Left;
            Charts_Left[1] = Chart2_Left;
            Charts_Left[2] = Chart3_Left;
            Charts_Left[3] = Chart4_Left;
            Charts_Left[4] = Chart5_Left;
            Charts_Left[5] = Chart6_Left;
            Charts_Left[6] = Chart7_Left;

            Charts_Right[0] = Chart1_Right;
            Charts_Right[1] = Chart2_Right;
            Charts_Right[2] = Chart3_Right;
            Charts_Right[3] = Chart4_Right;
            Charts_Right[4] = Chart5_Right;
            Charts_Right[5] = Chart6_Right;
            Charts_Right[6] = Chart7_Right;

            for (int i = 0; i < 7; i++)
            {
                Random rd = new Random();
                rd.Next();
                Color c = new Color();
                foreach(Color ge in c)
                Charts_Left[i].BackColor = 
            }
        }
    }
}
