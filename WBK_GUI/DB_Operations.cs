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

        public static SQLiteDataReader SelectItem(string item)
        {
            SQLite.Open();
            SQLiteCommand sqlc = new SQLiteCommand("Select * From Company;", SQLite);
            
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
        
    }
}
