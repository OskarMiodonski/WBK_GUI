using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBK_GUI
{
    public class Company
    {



        private int _id;
        private string _province;
        private string _town;
        private string _address;
        private int _net_value;
        private int _employees_hired;
        private string _name;
        private string _company_type;
        private string _registration_date;
        private string _twitter_id;
        private int _partners_count;
        private string _country;
        private string _clients_count;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public int NetValue
        {
            get { return _net_value; }
            set { _net_value = value; }
        }
        public int EmployeesHired
        {
            get { return _employees_hired; }
            set { _employees_hired = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string CompanyType
        {
            get { return _company_type; }
            set { _company_type = value; }
        }
        public string RegistrationDate
        {
            get { return _registration_date; }
            set { _registration_date = value; }
        }
        public int PartnersCount
        {
            get { return _partners_count; }
            set { _partners_count = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string ClientsCount
        {
            get { return _clients_count; }
            set { _clients_count = value; }
        }

        public List<List<string>> PropertiesList(Company cpn)
        {
            List<string> list = new List<string>();
            List<string> list1 = new List<string>();
            List<List<string>> dblist = new List<List<string>>();


            list.Add(cpn.Name.ToString()); list1.Add("Name");
            list.Add(cpn.Id.ToString()); list1.Add("ID");
            //list.Add(cpn.ClientsCount.ToString()); list1.Add("Clients Count");
            list.Add(cpn.PartnersCount.ToString()); list1.Add("Partners Count");
            list.Add(cpn.EmployeesHired.ToString()); list1.Add("Employees Hired");
            list.Add(cpn.NetValue.ToString()); list1.Add("Net Value");
            list.Add(cpn.CompanyType.ToString()); list1.Add("Company Type");
            list.Add(cpn.RegistrationDate.ToString()); list1.Add("Registration Date");
            list.Add(cpn.Country.ToString()); list1.Add("Country");
            list.Add(cpn.Province.ToString()); list1.Add("Province");
            list.Add(cpn.Town.ToString()); list1.Add("Town");
            list.Add(cpn.Address.ToString()); list1.Add("Address");

            dblist.Add(list1);
            dblist.Add(list);

            return dblist;
        }



    }
}
