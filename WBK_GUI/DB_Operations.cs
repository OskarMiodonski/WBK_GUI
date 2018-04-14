using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WBK_GUI
{
    public static class SQLiteCommands
    {
        private static SQLiteConnection SQLite = new SQLiteConnection("Data Source="+Environment.CurrentDirectory + "\\..\\..\\DB\\DB_Companies.db");

        public static SQLiteDataReader SelectCommand(string command)
        {
            SQLite.Open();
            SQLiteCommand sqlc = new SQLiteCommand(command, SQLite);
            
            SQLiteDataReader sQLiteData = sqlc.ExecuteReader();
            SQLite.Close();
            return sQLiteData;
           

        }
        public static SQLiteDataReader InsertItem(string item)
        {
            SQLite.Open();
            SQLiteCommand sqlc = new SQLiteCommand("Select * From Company;", SQLite);

            SQLiteDataReader sQLiteData = sqlc.ExecuteReader();
            SQLite.Close();
            return sQLiteData;
        }

        public static Company LoadInformation(string CompanyName)
        {
            Company mCompany = new Company();

            SQLiteDataReader sQLiteData;
            sQLiteData = SelectCommand("Select * From Company;");
            mCompany.Name = sQLiteData["Name"].ToString();
            mCompany.Id = (int)sQLiteData["KRSID"];

            sQLiteData = SelectCommand("Select * From Company_Cooperations;");
            //mCompany.ClientsCount = (int)sQLiteData["ClientsCount"];
            mCompany.PartnersCount = (int)sQLiteData["PartnersCount"];

            sQLiteData = SelectCommand("Select * From Company_Information;");
            mCompany.EmployeesHired = (int)sQLiteData["EmployeesHired"];
            mCompany.NetValue = (int)sQLiteData["NetValue"];
            mCompany.CompanyType = sQLiteData["CompanyType"].ToString();
            mCompany.RegistrationDate = sQLiteData["CreationDate"].ToString();

            sQLiteData = SelectCommand("Select * From Company_Location_Info;");
            mCompany.Country = sQLiteData["Country"].ToString();
            mCompany.Province = sQLiteData["Province"].ToString();
            mCompany.Town = sQLiteData["Town"].ToString();
            mCompany.Address = sQLiteData["Address"].ToString();



            return mCompany;
        }
        
    }
}
