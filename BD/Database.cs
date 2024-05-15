using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Forms;

namespace BD
{
    internal class Database
    {
        
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=human_resources_management");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

        public string getTable(string tableName, DataGridView dataGridView)
        {
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand($"SELECT * FROM `{tableName}` WHERE 1", connection);
            adapter.Fill(data);

            dataGridView.Rows.Clear(); 

            foreach (DataRow row in data.Rows)
            {
                dataGridView.Rows.Add(row.ItemArray);
            }
            return "Успешно!";
        }

        public DataTable getAllInfo(string tableName)
        {
            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand($"SELECT * FROM `{tableName}` WHERE 1", connection);
            adapter.Fill(data);
            return data;
        }

        public Collection<Post> getAllPost()
        {
            Collection<Post> posts = new Collection<Post>();
            DataTable data = getAllInfo("posts");
            foreach (DataRow row in data.Rows)
            {
                posts.Add(new Post(int.Parse(row[0].ToString()), row[1].ToString()));
            }
            return posts;
        }

        public Collection<Worker> getAllWorker()
        {
            Collection<Worker> workers = new Collection<Worker>();
            DataTable data = getAllInfo("workers");
            foreach (DataRow row in data.Rows)
            {
                workers.Add(new Worker(int.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), DateTime.Parse(row[4].ToString()), Int64.Parse(row[5].ToString()), row[6].ToString(), row[7].ToString(), Int32.Parse(row[8].ToString())));
            }
            return workers;
        }

        public Collection<EncouragementType> getAllEncouragementType()
        {
            Collection<EncouragementType> EncouragementTypes = new Collection<EncouragementType>();
            DataTable data = getAllInfo("encouragement_type");
            foreach (DataRow row in data.Rows)
            {
                EncouragementTypes.Add(new EncouragementType(int.Parse(row[0].ToString()), row[1].ToString(), int.Parse(row[2].ToString())));
            }
            return EncouragementTypes;
        }

        public Collection<InfrigementType> getAllInfrigementType()
        {
            Collection<InfrigementType> InfrigementTypes = new Collection<InfrigementType>();
            DataTable data = getAllInfo("infrigement_type");
            foreach (DataRow row in data.Rows)
            {
                InfrigementTypes.Add(new InfrigementType(int.Parse(row[0].ToString()), row[1].ToString(), int.Parse(row[2].ToString())));
            }
            return InfrigementTypes;
        }

        public Collection<ProductivitiAssessment> getAllProductivityAssesment()
        {
            Collection<ProductivitiAssessment> ProductivitiAssessments = new Collection<ProductivitiAssessment>();
            DataTable data = getAllInfo("productiviti_assessment");
            foreach (DataRow row in data.Rows)
            {
                ProductivitiAssessments.Add(new ProductivitiAssessment(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), int.Parse(row[2].ToString())));
            }
            return ProductivitiAssessments;
        }

        public Collection<Order> getAllOrdes()
        {
            Collection<Order> Orders = new Collection<Order>();
            DataTable data = getAllInfo("orders");
            foreach (DataRow row in data.Rows)
            {
                int str0 = 0;
                if (row[0].ToString() != null) str0 = int.Parse(row[0].ToString());
                int str1 = 0;
                int.TryParse(row[1].ToString(), out str1);
                int str2 = 0;
                int.TryParse(row[2].ToString(), out str2);
                string str3 = "0";
                if (row[0].ToString() != null) str0 = int.Parse(row[0].ToString());
                Orders.Add(new Order(str0,str1,str2, row[3].ToString(), DateTime.Parse(row[4].ToString())));
            }
            return Orders;
        }

        public Collection<ProductivitiReport> getProductivitiReport()
        {
            Collection<ProductivitiReport> ProductivitiReports = new Collection<ProductivitiReport>();
            DataTable data = getAllInfo("productiviti_report");
            foreach (DataRow row in data.Rows)
            {
                ProductivitiReports.Add(new ProductivitiReport(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), int.Parse(row[2].ToString()), DateTime.Parse(row[3].ToString()), double.Parse(row[4].ToString())));
            }
            return ProductivitiReports;
        }

        public Collection<Encourgament> getEncourgament()
        {
            Collection<Encourgament> Encourgaments = new Collection<Encourgament>();
            DataTable data = getAllInfo("encouragement");
            foreach (DataRow row in data.Rows)
            {
                Encourgaments.Add(new Encourgament(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), int.Parse(row[2].ToString()), DateTime.Parse(row[3].ToString())));
            }
            return Encourgaments;
        }

        public Collection<Infrigement> getInfrigement()
        {
            Collection<Infrigement> Infrigement = new Collection<Infrigement>();
            DataTable data = getAllInfo("infrigement");
            foreach (DataRow row in data.Rows)
            {
                Infrigement.Add(new Infrigement(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), int.Parse(row[2].ToString()), DateTime.Parse(row[3].ToString())));
            }
            return Infrigement;
        }

        public Collection<PaySheet> getPaySheet()
        {
            Collection<PaySheet> PaySheet = new Collection<PaySheet>();
            DataTable data = getAllInfo("pay_sheet");
            foreach (DataRow row in data.Rows)
            {
                PaySheet.Add(new PaySheet(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), DateTime.Parse(row[2].ToString()), int.Parse(row[3].ToString()), int.Parse(row[4].ToString())));
            }
            return PaySheet;
        }



    }
    /// <summary>
    /// Должность 
    /// </summary>
    class Post
    {
        
        public int id_post { private set; get; }
        public string title_post { private set; get; }

        public Post(int id_post, string title_post)
        {
            this.id_post = id_post;
            this.title_post = title_post;
        }


    }
    /// <summary>
    /// Работник
    /// </summary>
    class Worker
    {
        public int id_worker { private set; get; }
        public string last_name { private set; get; }
        public string first_name { private set; get; }
        public string surname { private set; get; }
        public DateTime birthday { private set; get; }
        public decimal phone_number { private set; get; }
        public string login { private set; get; }
        public string password { private set; get; }
        public int id_post { private set; get; }

        public Worker(int id_worker, string last_name, string first_name, string surname, DateTime birthday, decimal phone_number, string login, string password, int id_post)
        {
            this.id_worker = id_worker;
            this.last_name = last_name;
            this.first_name = first_name;
            this.surname = surname;
            this.birthday = birthday;
            this.phone_number = phone_number;
            this.login = login;
            this.password = password;
            this.id_post = id_post;
        }

        public override string ToString()
        {
            return ($"{last_name} {first_name} {surname}");
        }
    }
    /// <summary>
    /// Тип поощрения
    /// </summary>
    class EncouragementType
    {
        public int id_encouragement_type { private set; get; }
        public string title { private set; get; }
        public int value { private set; get; }
        public EncouragementType(int id_encouragement_type, string title, int value)

        {
            this.id_encouragement_type = id_encouragement_type;
            this.title = title;
            this.value = value;
        }
    }
    /// <summary>
    /// Поощрение
    /// </summary>
    class Encourgament
    {
        public int id { private set; get; }
        public int id_worker { private set; get; }
        public int id_encourgament_type { private set; get; }
        public DateTime date { private set; get; }

        public Encourgament(int id, int id_worker, int id_encourgament_type, DateTime date)
        {
            this.id = id;
            this.id_worker = id_worker;
            this.id_encourgament_type = id_encourgament_type;
            this.date = date;
        }
    }
    /// <summary>
    /// Тип нарушения
    /// </summary>
    class InfrigementType
    {
        public int id_infrigement_type { private set; get; }
        public string title { private set; get; }
        public int value { private set; get; }
        public InfrigementType(int id_infrigement_type, string title, int value)
        {
            this.id_infrigement_type = id_infrigement_type;
            this.title = title;
            this.value = value;
        }
    }
    /// <summary>
    /// Нарушение
    /// </summary>
    class Infrigement
    {

        public int id { private set; get; }
        public int id_worker { private set; get; }
        public int id_infrigement_type { private set; get; }
        public DateTime date { private set; get; }

        public Infrigement(int id, int id_worker, int id_infrigement_type, DateTime date)
        {
            this.id = id;
            this.id_worker = id_worker;
            this.id_infrigement_type = id_infrigement_type;
            this.date = date;
        }
    }
    /// <summary>
    /// Приказ 
    /// </summary>
    class Order
    {
        public int id { private set; get; }
        public int id_encouragement { private set; get; }
        public int id_infrigement { private set; get; }
        public string type { private set; get; }
        public DateTime date { private set; get; }
        public Order(int id, int id_encouragement, int id_infrigement, string type, DateTime date)
        {
            this.id = id;
            this.id_encouragement = id_encouragement;
            this.id_infrigement = id_infrigement;
            this.date = date;
            this.type = type;
        }
    }
    /// <summary>
    /// Расчетный лист
    /// </summary>
    class PaySheet
    {
        public int id { private set; get; }
        public int id_worker { private set; get; }
        public DateTime date { private set; get; }
        public int number_of_hourse { private set; get; }
        public int price_of_an_hour { private set; get; }
        public PaySheet(int id, int id_worker, DateTime date, int number_of_hourse, int price_of_an_hour)
        {
            this.id = id;
            this.id_worker = id_worker;
            this.date = date;
            this.number_of_hourse = number_of_hourse;
            this.price_of_an_hour = price_of_an_hour;
        }
    }
    /// <summary>
    /// Оценка продуктивности
    /// </summary>
    class ProductivitiAssessment
    {
        Collection<string> strings = new Collection<string>();
        public int id { private set; get;}
        public int id_worker { private set; get;}
        public int value { private set; get; }
        public ProductivitiAssessment(int id, int id_worker, int value)
        {
            this.id = id;
            this.id_worker= id_worker;
            this.value = value;
        }
        public Collection<string> getInfo(Collection<Worker> workers)
        {
            Worker tempWorker = null;
            foreach(Worker worker in workers)
            {
                if(worker.id_worker == id_worker)
                {
                    tempWorker = worker;
                }
            }
            strings.Add(id.ToString());
            strings.Add(tempWorker.last_name + " " + tempWorker.surname);
            return strings;
        }
        

    }
    /// <summary>
    /// Отчет
    /// </summary>
    class ProductivitiReport
    {
        public int id { private set; get;}
        public int id_order { private set; get; }
        public int id_productiviti_assesment { private set; get; }
        public DateTime date { private set; get; }
        public double report_indicator { private set; get; }
        public ProductivitiReport(int id, int id_order, int id_productiviti_assesment, DateTime date, double report_indicator)
        {
            this.id = id;
            this.id_order = id_order;
            this.id_productiviti_assesment = id_productiviti_assesment;
            this.date = date;
            this.report_indicator = report_indicator;
        }
    }
}
