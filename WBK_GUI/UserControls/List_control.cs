using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WBK_GUI;

namespace WBK_GUI.UserControls
{
    public partial class List_control : UserControl
    {
        public List_control()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Company cpn = SQLiteCommands.LoadInformation("A");

            DataGridViewRow dataRow = new DataGridViewRow();
            List<List<string>> list1 = cpn.PropertiesList(cpn);

            for (int i = 0; i < list1[0].Count; i++)            
                dataGridView1.Rows.Add(list1[0][i], list1[1][i]);
           
                
        }
    }
}
