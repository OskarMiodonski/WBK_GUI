using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using WBK_GUI.UserControls;

namespace WBK_GUI
{
    public static class SQLiteCommands
    {
        private static SQLiteConnection SQLite = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\..\\..\\DB\\DB_Companies.db");

        public static SQLiteDataReader SelectCommand(string command)
        {

            SQLiteCommand sqlc = new SQLiteCommand(command, SQLite);

            SQLiteDataReader sQLiteData = sqlc.ExecuteReader();
            sQLiteData.Read();
            return sQLiteData;


        }

        public static void InsertCommand(string command)
        {
            SQLiteCommand SQLcommand = new SQLiteCommand(command, SQLite);
            SQLiteDataReader sqlReader = SQLcommand.ExecuteReader();              
        }

        public static void LoadToDatabase(Company cpn)
        {
            SQLite.Open();
            SQLiteDataReader dtr;

            InsertCommand($"Insert into Company (ID, KRSID, Name) values(0,\"{cpn.Id}\",\"{cpn.Name}\");");
            dtr = SelectCommand($"Select ID from Company where KRSID=\"{cpn.Id}\";");

            InsertCommand($"Insert into Company_Cooperations (ID, ClientsCount, PartnersCount) values({dtr["ID"]},{cpn.ClientsCount},{cpn.PartnersCount});");
            InsertCommand($"Insert into Company_Information (ID, NetValue, CompanyType, EmployeesHired, CreationDate) values({dtr["ID"]},{cpn.NetValue}, \"{cpn.CompanyType}\", {cpn.EmployeesHired}, \"{cpn.RegistrationDate}\");");
            InsertCommand($"Insert into Company_Location_Info (ID, Country, Province, Town, Address) values({dtr["ID"]},\"{cpn.Country}\", \"{cpn.Province}\", \"{cpn.Town}\", \"{cpn.RegistrationDate}\");");
            SQLite.Close();

        }

        public static List<string> LoadCompanies()
        {
            SQLite.Open();
            List<string> list = new List<string>();
            SQLiteDataReader sqlRead;

            sqlRead = SelectCommand("Select Name from Company");
            sqlRead.Read();

            foreach (var item in sqlRead)
            {
                list.Add(item.ToString());
            }
            SQLite.Close();

            return list;
        }

        public static Company LoadInformation(string CompanyName)
        {
            Company mCompany = new Company();
            int CurrentId = 0;
            
            SQLite.Open();

            SQLiteDataReader sQLiteData;
            
            sQLiteData = SelectCommand("Select * From Company where Name=\"" + CompanyName + "\";");
            
            CurrentId = int.Parse(sQLiteData["ID"].ToString());
            mCompany.Name = sQLiteData["Name"].ToString();
            mCompany.Id = int.Parse(sQLiteData["KRSID"].ToString());

            sQLiteData = SelectCommand("Select * From Company_Cooperations where ID=\"" + CurrentId + "\";");
            //mCompany.ClientsCount = (int)sQLiteData["ClientsCount"];
            mCompany.PartnersCount = int.Parse(sQLiteData["PartnersCount"].ToString());

            sQLiteData = SelectCommand("Select * From Company_Information where ID=\"" + CurrentId + "\";");
            mCompany.EmployeesHired = int.Parse(sQLiteData["EmployeesHired"].ToString());
            mCompany.NetValue = int.Parse(sQLiteData["NetValue"].ToString());
            mCompany.CompanyType = sQLiteData["CompanyType"].ToString();
            mCompany.RegistrationDate = sQLiteData["CreationDate"].ToString();

            sQLiteData = SelectCommand("Select * From Company_Location_Info where ID=\"" + CurrentId + "\";");
            mCompany.Country = sQLiteData["Country"].ToString();
            mCompany.Province = sQLiteData["Province"].ToString();
            mCompany.Town = sQLiteData["Town"].ToString();
            mCompany.Address = sQLiteData["Address"].ToString();

            SQLite.Close();

            return mCompany;
        }


    }
}
