using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBK_GUI
{
    class Company
    {
        private string _id;
        private string _province;
        private string _town;
        private string _address;
        private int _net_value;
        private string _employees_hired;
        private string _name;
        private string _company_type;
        private string _registration_date;
        private string _twitter_id;
        private int _partners_count;
        private string _country;

        public string Id
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
        public string EmployeesHired
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
    }
}
