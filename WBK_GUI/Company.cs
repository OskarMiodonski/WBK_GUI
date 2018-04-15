using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Threading;

namespace WBK_GUI
{
    public class Company
    {
        private string _id;
        private string _province;
        private string _town;
        private string _address;
        private long _net_value;
        private int _employees_hired;
        private string _name;
        private string _company_type;
        private string _registration_date;
        private string _twitter_id;
        private string _country;
        private int _connection_count;
        private int _partners_count;
        private int _branch_count;
        private int _points;

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }
        public int ConnectionCount
        {
            get { return _connection_count; }
            set { _connection_count = value; }
        }
        public int BranchCount
        {
            get { return _branch_count; }
            set { _branch_count = value; }
        }
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
        public long NetValue
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
        public string Twitter_id
        {
            get { return _twitter_id; }
            set { _twitter_id = value; }
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

        //just to safely go through data colisions :v 
        private static void LoadBestCompanies(int imp, ref Company[,] CompanySet, int amount_of_items, ref bool finished, int ThreadCount)
        {
            int i = imp;
            Company[] tmp_array = new Company[amount_of_items];
            JToken tmp_krs_json;
            string tmp_krs_string;
            WebClient tmp_client = new WebClient();
            Company tmp_company = new Company();
            int last_place_on_list = 0;
            tmp_krs_string = tmp_client.DownloadString(new Uri("https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json?limit=500&page=" + i));//!^
                                                                                                                                            //while (!downloaded) { }
            tmp_krs_json = (JToken)JsonConvert.DeserializeObject(tmp_krs_string);
            for (int j = 0; j < 500; j++)
            {
                tmp_company = new Company();
                tmp_company.Points = 0;
                tmp_company.Id = (string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.id"];
                //check if the company has enough points
                string connection_string = tmp_client.DownloadString("https://api-v3.mojepanstwo.pl/dane/krs_podmioty/" + tmp_company.Id + ".json?layers[]=graph&layers[]=oddzialy&layers[]=wspolnicy");
                JToken connection_json = (JToken)JsonConvert.DeserializeObject(connection_string);
                JToken TmpConnectionTokens = connection_json["layers"]["graph"]["nodes"];
                foreach (var connection in TmpConnectionTokens)
                {
                    tmp_company.Points++;
                }
                TmpConnectionTokens = connection_json["layers"]["wspolnicy"];
                foreach (var connection in TmpConnectionTokens)
                {
                    tmp_company.Points++;
                }
                TmpConnectionTokens = connection_json["layers"]["oddzialy"];
                foreach (var connection in TmpConnectionTokens)
                {
                    tmp_company.Points++;
                }

                if (tmp_company.Points > CompanySet[i, last_place_on_list].Points)
                {
                    if (last_place_on_list >= 0)
                    {
                        Console.WriteLine(last_place_on_list);
                        int iter = last_place_on_list;
                        while ((tmp_company.Points > CompanySet[i, iter].Points) && iter > 0)
                        {
                            iter--;
                        }
                        if ((tmp_company.Points <= CompanySet[i, iter].Points))
                        {
                            iter += 1;
                        }
                        CompanySet[i, iter] = tmp_company;
                        CompanySet[i, iter].NetValue = int.Parse((string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.wartosc_kapital_zakladowy"]);
                        CompanySet[i, iter].Address = (string)(tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.adres"]);
                        CompanySet[i, iter].CompanyType = (string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.forma_prawna_str"];
                        CompanySet[i, iter].Id = (string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.id"];
                        CompanySet[i, iter].RegistrationDate = (string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.data_dokonania_wpisu"];
                        CompanySet[i, iter].Province = ((string)(tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.siedziba"])).Split(',')[1].Remove(0, 6);
                        CompanySet[i, iter].Twitter_id = (string)(tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.twitter_account_id"]);
                        CompanySet[i, iter].Country = ((string)(tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.siedziba"])).Split(',')[0].Remove(0, 5);
                        CompanySet[i, iter].Town = ((string)(tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.adres"])).Split(',')[3].Remove(0, 8);
                        CompanySet[i, iter].Name = (string)tmp_krs_json["Dataobject"][j]["data"]["krs_podmioty.nazwa"];
                        if ((last_place_on_list + 1) < amount_of_items)
                        {
                            last_place_on_list += 1;
                        }
                    }
                }
            }

            if (i >= ThreadCount - 2)
                finished = true;
        }
        //Loads KRS companies and sort them in term of branches, partners and from other connected firms
        //select top "amount" of them by calculating how they are spread across the country in terms of dinstances
        public static Company[] GenerateListOfCompanies(int amount_of_items)
        {
            //load 
            bool finished = false;
            WebClient client = new WebClient();
            JsonSerializer serializer = new JsonSerializer();
            int PagesCount = 0;
            string krs_string = client.DownloadString("https://api-v3.mojepanstwo.pl/dane/krs_podmioty.json");
            JToken krs_json = (JToken)JsonConvert.DeserializeObject(krs_string);
            PagesCount = int.Parse(((string)(krs_json["Links"]["last"])).Split('&')[1].Remove(0, 5));
            int ThreadCount = PagesCount / 500;
            Company[,] CompanySet = new Company[ThreadCount, amount_of_items];
            Task[] TaskList = new Task[ThreadCount - 1];
            for (int j = 0; j < ThreadCount; j++)
            {
                for (int i = 0; i < amount_of_items; i++)
                {
                    CompanySet[j, i] = new Company();
                }
            }
            for (int it = 0; it < ThreadCount - 1; it++)
            {
                TaskList[it] = Task.Factory.StartNew(() => {
                    LoadBestCompanies(it, ref CompanySet, amount_of_items, ref finished, ThreadCount);
                });
                Thread.Sleep(200);
            }
            while (!finished) { }

            Company[] BestCompanyList = new Company[amount_of_items];
            for (int i = 0; i < amount_of_items; i++)
            {
                BestCompanyList[i] = CompanySet[0, i];
                int jj = i, kk = 0;
                for (int j = 0; j < ThreadCount - 1; j++)
                {
                    for (int k = 0; k <= i; k++)
                    {
                        if (CompanySet[j, k].Points > BestCompanyList[i].Points)
                        {
                            BestCompanyList[i] = CompanySet[j, k];
                            jj = j;
                            kk = k;
                        }
                    }
                }
                CompanySet[jj, kk].Points = 0;
            }

            //add points in terms of dinstance 
            foreach (Company company in BestCompanyList)
            {
                string connection_string = client.DownloadString("https://api-v3.mojepanstwo.pl/dane/krs_podmioty/" + company.Id + ".json?layers[]=graph&layers[]=oddzialy&layers[]=wspolnicy");
                JToken connection_json = (JToken)JsonConvert.DeserializeObject(connection_string);
                JToken TmpConnectionTokens = connection_json["layers"]["graph"]["nodes"];
                foreach (var town in TmpConnectionTokens)
                {
                    string graph_string = client.DownloadString("https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + company.Town + "&destinations=" + town["data"]["miejscowosc"] + "&key=AIzaSyBZOVCuqgWlEgYFjObVh1zcAYOE-LN4aEU");
                    JToken graph_json = (JToken)JsonConvert.DeserializeObject(graph_string);
                    try
                    {
                        int distance = int.Parse(graph_json["rows"][0]["elements"]["distance"]["value"].ToString());
                        company.Points += (distance / 100000);
                        if (distance == 0)
                            company.Points += 3;
                    }
                    catch (Exception e)
                    {
                        company.Points += 1;
                    }
                }
            }
            int lowest = 0;
            Company tmp = new Company();
            for(int i = 0; i < BestCompanyList.Count(); i++)
            {
                for(int j = i; j < BestCompanyList.Count(); j++)
                {
                    if (BestCompanyList[i].Points < BestCompanyList[j].Points)
                        lowest = j;
                }
                tmp = BestCompanyList[i];
                BestCompanyList[i] = BestCompanyList[lowest];
                BestCompanyList[lowest] = tmp;
            }
            return BestCompanyList;
        }
    }
}
