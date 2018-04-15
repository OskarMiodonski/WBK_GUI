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
        private Company cpn;

        private void List_control_Load(object sender, EventArgs e)
        {
            Company[] cpnList = new Company[30];
            Task.Run(() => {
             cpnList = Company.GenerateListOfCompanies(30);
            for (int i = 0; i < 30; i++)
            {
                SQLiteCommands.LoadToDatabase(cpnList[i]);
            } });

            List<string> listOne = SQLiteCommands.LoadCompanies();
            for (int i = 0; i < listOne.Count; i++)
            {
                comboBox1.Items.Add(listOne[i]);
                comboBox2.Items.Add(listOne[i]);
            }

            cpn = SQLiteCommands.LoadInformation("DEREHAM SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ");
            List<List<string>> listTwo = cpn.PropertiesList(cpn);
            for (int i = 0; i < listTwo[0].Count; i++)
            {
                dataGridView3.Rows.Add(listTwo[0][i].ToString(), listTwo[1][i].ToString());
            }


        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cpn = SQLiteCommands.LoadInformation(comboBox1.SelectedItem.ToString());
            List<List<string>> listTwo = cpn.PropertiesList(cpn);
            for (int i = 0; i < listTwo[0].Count; i++)
            {
                dataGridView1.Rows.Add(listTwo[0][i].ToString(), listTwo[1][i].ToString());

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cpn = SQLiteCommands.LoadInformation(comboBox2.SelectedItem.ToString());
            List<List<string>> listTwo = cpn.PropertiesList(cpn);
            for (int i = 0; i < listTwo[0].Count; i++)
            {
                dataGridView2.Rows.Add(listTwo[0][i].ToString(), listTwo[1][i].ToString());

            }

        }
    }
}
