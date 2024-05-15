using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class FormWorkers : Form
    {
        static Database database = new Database();
        Collection<Post> posts = database.getAllPost();
        Collection<ProductivitiAssessment> productivitiAssessments = database.getAllProductivityAssesment();
        Collection<Worker> workers = database.getAllWorker();
        Collection<Order> orders = database.getAllOrdes();
        Collection<InfrigementType> infrigementsTypes = database.getAllInfrigementType();
        Collection<EncouragementType> encouragementsTypes = database.getAllEncouragementType();
        Collection<ProductivitiReport> productivitiReports = database.getProductivitiReport();
        Collection<Encourgament> encourgaments = database.getEncourgament();
        Collection<Infrigement> infrigements = database.getInfrigement();
        Collection<PaySheet> paySheets = database.getPaySheet();
        string PostUser;
        public FormWorkers(DataTable loginUser)
        {
            InitializeComponent();
            fillComboBoxWorkers();
            fillComboBoxInfrigementType();
            ViewAssessment();
            fillComboBoxPost();
            ViewWorker();

            fillComboBoxWorkersEncouragement();
            fillComboBoxEncouragementType();

            ViewOrders();
            ViewEncourgamentInfringament();

            fillComboBoxidEncouragement();
            fillComboBoxIdinfrigement();

            ViewEncouragement();
            ViewInfrigements();
            
            ViewPaySheet();
            ViewReport();

            PostUser = loginUser.Rows[0][8].ToString();

            switch (PostUser)
            {
                case "1":
                    tabControl.TabPages.Remove(tabPageCreateRaport);
                    tabControl.TabPages.Remove(tabPagePutAssessment);
                    tabControl.TabPages.Remove(tabPageEncourgament);
                    tabControl.TabPages.Remove(tabPageCreateWorker);
                    tabControl.TabPages.Remove(tabPageInfringament);
                    break;
                case "4":
                    tabControl.TabPages.Remove(tabPageCreatePaySheet);
                    tabControl.TabPages.Remove(tabPageCreateOrder);
                    tabControl.TabPages.Remove(tabPagePutAssessment);
                    tabControl.TabPages.Remove(tabPageEncourgament);
                    tabControl.TabPages.Remove(tabPageInfringament);
                    break;
                case "6":
                    tabControl.TabPages.Remove(tabPageCreatePaySheet);
                    tabControl.TabPages.Remove(tabPageCreateRaport);
                    tabControl.TabPages.Remove(tabPageCreateWorker);
                    tabControl.TabPages.Remove(tabPageCreateOrder);
                    break;
                default: 
                    
                    tabControl.TabPages.Remove(tabPageCreatePaySheet);
                    tabControl.TabPages.Remove(tabPageCreateRaport);
                    tabControl.TabPages.Remove(tabPageCreateWorker);
                    tabControl.TabPages.Remove(tabPageCreateOrder);
                    tabControl.TabPages.Remove(tabPagePutAssessment);
                    tabControl.TabPages.Remove(tabPageEncourgament);
                    tabControl.TabPages.Remove(tabPageInfringament);
                    break;
            }
        }

        private void fillComboBoxEncouragementType()
        {
            Collection<string> strings = new Collection<string>();
            foreach (EncouragementType type in encouragementsTypes)
            {
                strings.Add(type.title);
            }
            fillComboBox(comboBoxEncouragementsTypes, strings);
            comboBoxEncouragementsTypes.SelectedIndex = 0;
        }
        private void fillComboBoxidEncouragement()
        {
            Collection<string> strings = new Collection<string>();
            foreach (Encourgament encourgament in encourgaments)
            {
                strings.Add(encourgament.id.ToString());
            }
            fillComboBox(comboBox_id_encouragement, strings);
            comboBox_id_encouragement.SelectedIndex = 0;
        }
        private void fillComboBoxIdinfrigement()
        {
            Collection<string> strings = new Collection<string>();
            foreach (Infrigement encourgament in infrigements)
            {
                strings.Add(encourgament.id.ToString());
            }
            fillComboBox(comboBox_id_infrigement, strings);
            comboBox_id_infrigement.SelectedIndex = 0;
        }
        private void fillComboBoxWorkersEncouragement()
        {
            Collection<string> strings = new Collection<string>();
            foreach (Worker worker in workers)
            {
                strings.Add(worker.ToString());
            }
            
            fillComboBox(comboBox_setProductAssesment, strings);
            fillComboBox(comboBoxWorkerEncouragement, strings);
            fillComboBox(comboBoxid_worker, strings);
            comboBoxWorkerEncouragement.SelectedIndex = 0;
            comboBox_setProductAssesment.SelectedIndex = 0;
            comboBoxid_worker.SelectedIndex = 0;
        }

        private void buttonEncouragement_Click(object sender, EventArgs e)
        {
            database.openConnection(); MySqlCommand commandEncouragemen = new MySqlCommand($"INSERT INTO encouragement (`id`, id_worker, id_encouragement_type, `date`) VALUES ('0', '{workers[comboBoxWorkerEncouragement.SelectedIndex].id_worker}', '{encouragementsTypes[comboBoxEncouragementsTypes.SelectedIndex].id_encouragement_type}', '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}');");
            commandEncouragemen.Connection = database.getConnection(); commandEncouragemen.ExecuteNonQuery();
            database.closeConnection();
            encourgaments = database.getEncourgament();
            ViewEncouragement();
        }

        private void ViewAssessment()
        {
            dataGridViewAssessment2.Rows.Clear();
            productivitiAssessments = database.getAllProductivityAssesment();
            dataGridViewAssessment.Rows.Clear();
            foreach (ProductivitiAssessment productiviti in productivitiAssessments)
            {
                Worker workerProduct = null;
                foreach (Worker tempWorker in workers)
                {
                    if (tempWorker.id_worker == productiviti.id_worker)
                    {
                        workerProduct = tempWorker;
                    }
                }
                dataGridViewAssessment.Rows.Add(productiviti.id, workerProduct.ToString(), productiviti.value);
                dataGridViewAssessment2.Rows.Add(productiviti.id, workerProduct.ToString(), productiviti.value);
                
            }
        }
        private void ViewEncouragement()
        {
            encourgaments = database.getEncourgament();
            dataGridView_encouragement.Rows.Clear();
            foreach(Encourgament encourgament in encourgaments)
            {
                Worker workerProduct = null;
                foreach (Worker tempWorker in workers)
                {
                    if (tempWorker.id_worker == encourgament.id_worker)
                    {
                        workerProduct = tempWorker;
                    }
                }
                EncouragementType encouragementType = null;
                foreach (EncouragementType encouragementTypeTemp in encouragementsTypes)
                {
                    if(encouragementTypeTemp.id_encouragement_type == encourgament.id_encourgament_type)
                    {
                        encouragementType = encouragementTypeTemp;
                    }
                }
                dataGridView_encouragement.Rows.Add(workerProduct.ToString(),encouragementType.title, encourgament.date);
            }
        }
        private void ViewInfrigements()
        {
            infrigements = database.getInfrigement();
            dataGridViewinfrigements.Rows.Clear();
            foreach (Infrigement infrigement in infrigements)
            {
                Worker workerProduct = null;
                foreach (Worker tempWorker in workers)
                {
                    if (tempWorker.id_worker == infrigement.id_worker)
                    {
                        workerProduct = tempWorker;
                    }
                }
                InfrigementType infrigementType = null;
                foreach (InfrigementType infrigementTypeTemp in infrigementsTypes)
                {
                    if (infrigementTypeTemp.id_infrigement_type == infrigement.id_infrigement_type)
                    {
                        infrigementType = infrigementTypeTemp;
                    }
                }
                dataGridViewinfrigements.Rows.Add(workerProduct.ToString(), infrigementType.title, infrigement.date);
            }
        }
        private void ViewWorker()
        {
            workers = database.getAllWorker();
            dataGridViewWorkers.Rows.Clear();
            foreach (Worker worker in workers)
            {
                Post post = null;
                foreach (Post tempPost in posts)
                {
                    if (tempPost.id_post == worker.id_post)
                    {
                        post = tempPost;
                    }
                }
                dataGridViewWorkers.Rows.Add(worker.id_worker,worker.last_name,worker.first_name, worker.surname, worker.birthday, worker.phone_number, post.title_post );
            }
        }
        private void ViewEncourgamentInfringament()
        {
            encourgaments = database.getEncourgament();
            infrigements = database.getInfrigement();
            dataGridViewEncourgamentInfringament.Rows.Clear();
            foreach (Encourgament encourgament in encourgaments)
            {
                string encouragement_type = "";
                foreach (EncouragementType encouragementType in encouragementsTypes)
                {
                    if(encourgament.id_encourgament_type == encouragementType.id_encouragement_type)
                    {
                        encouragement_type = encouragementType.title;
                    }
                }
                Worker worker = null;
                foreach (Worker workerTemp in workers)
                {
                    if (encourgament.id_worker == workerTemp.id_worker)
                    {
                        worker = workerTemp; break;
                    }
                }
                dataGridViewEncourgamentInfringament.Rows.Add(encourgament.id,worker.ToString(),encouragement_type, encourgament.date);
            }
            foreach (Infrigement infrigement in infrigements)
            {
                string infrigement_type = "";
                foreach (InfrigementType infrigementType in infrigementsTypes)
                {
                    if (infrigement.id_infrigement_type == infrigementType.id_infrigement_type)
                    {
                        infrigement_type = infrigementType.title;
                    }
                }
                Worker worker = null;
                foreach(Worker workerTemp in workers)
                {
                    if(infrigement.id_worker == workerTemp.id_worker)
                    {
                        worker = workerTemp; break;
                    }
                }
                dataGridViewEncourgamentInfringament.Rows.Add(infrigement.id, worker.ToString(), infrigement_type, infrigement.date);
            }
        }
        private void ViewOrders()
        {
            orders = database.getAllOrdes();
            dataGridViewSeeOrder.Rows.Clear();

            foreach (Order order in orders)
            {
                Worker worker = null;
                Encourgament encourgament = new Encourgament(0, 0, 0, new DateTime(0));
                EncouragementType encouragementType = new EncouragementType(0, "None", 0);
                foreach (Encourgament encourgamentTemp in encourgaments)
                {
                    if(encourgamentTemp.id == order.id_encouragement)
                    {
                        encourgament = encourgamentTemp;
                        foreach (Worker workerTemp in workers)
                        {
                            if (encourgament.id_worker == workerTemp.id_worker)
                            {
                                worker = workerTemp; break;
                            }
                        }
                    }
                }
                foreach(EncouragementType encouragementTypeTemp in encouragementsTypes)
                {
                    if(encourgament.id_encourgament_type == encouragementTypeTemp.id_encouragement_type)
                    {
                        encouragementType = encouragementTypeTemp;
                    }
                }
                Infrigement infrigement = new Infrigement(0,0,0,new DateTime(0));
                InfrigementType infrigementType = new InfrigementType(0,"None",0);
                foreach (Infrigement infrigementTemp in infrigements)
                {
                    if (infrigementTemp.id == order.id_infrigement)
                    {
                        infrigement = infrigementTemp;

                        foreach (Worker workerTemp in workers)
                        {
                            if (infrigement.id_worker == workerTemp.id_worker)
                            {
                                worker = workerTemp; break;
                            }
                        }
                    }
                }
                foreach (InfrigementType infrigementTypeTemp in infrigementsTypes)
                {
                    if (infrigementType != null)
                    {
                        if (infrigement.id_infrigement_type == infrigementTypeTemp.id_infrigement_type)
                        {
                            infrigementType = infrigementTypeTemp;
                        }
                    }
                }



                dataGridViewSeeOrder.Rows.Add(order.id, worker.ToString(),encouragementType.title, infrigementType.title, order.type, order.date);
            }
        }//

        private void ViewReport()
        {
            productivitiReports = database.getProductivitiReport();
            dataGridView_ViewReport.Rows.Clear();
            ProductivitiReport productivitiReport = null;
            foreach(ProductivitiReport product in productivitiReports)
            {
                dataGridView_ViewReport.Rows.Add(product.id,product.date,product.report_indicator);
            }
        }
        private void ViewPaySheet()
        {
            paySheets = database.getPaySheet();
            dataGridViewPaySheet.Rows.Clear();
            Worker worker = null;
            foreach(PaySheet paySheet in paySheets)
            {
                foreach (Worker workerTemp in workers)
                {
                    if (paySheet.id_worker == workerTemp.id_worker)
                    {
                        worker = workerTemp; break;
                    }
                }
                dataGridViewPaySheet.Rows.Add(paySheet.id, worker.ToString(),paySheet.date,paySheet.number_of_hourse,paySheet.price_of_an_hour);
            }
            //dataGridViewPaySheet
        }
        private void fillComboBoxPost()
        {
            Collection<string> strings = new Collection<string>();
            foreach (Post post in posts)
            {
                strings.Add(post.title_post);
            }
            fillComboBox(comboBox_setWorker_postSelector, strings);
            comboBox_setWorker_postSelector.SelectedIndex = 0;
        }
        private void fillComboBoxInfrigementType()
        {
            Collection<string> strings = new Collection<string>();
            foreach (InfrigementType type in infrigementsTypes)
            {
                strings.Add(type.title) ;
            }
            fillComboBox(comboBoxinfrigementsTypes, strings);
            comboBoxinfrigementsTypes.SelectedIndex = 0;
        }
        private void fillComboBoxWorkers()
        {
            Collection<string> strings = new Collection<string>();
            foreach(Worker worker in workers)
            {
                strings.Add(worker.ToString());
            }
            fillComboBox(comboBoxWorkerInfrigement, strings);
            comboBoxWorkerInfrigement.SelectedIndex = 0;
        }
        private void fillComboBox(ComboBox comboBox,Collection<string> strings)
        {
            foreach(string str in strings)
            {
                comboBox.Items.Add(str);
            }
        }
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonInfrigement_Click(object sender, EventArgs e)
        {
            database.openConnection();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `infrigement` (`id_infrigement`, `id_worker`, `id_infrigement_type`, `date`) VALUES ('0', '{workers[comboBoxWorkerInfrigement.SelectedIndex].id_worker}', '{infrigementsTypes[comboBoxinfrigementsTypes.SelectedIndex].id_infrigement_type}', '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}');");

            command.Connection = database.getConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
            infrigements = database.getInfrigement();
            ViewInfrigements();
        }
        private void button_setWorker_Click(object sender, EventArgs e)
        {
            database.openConnection();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `workers` (`id_worker`, `last_name`, `first_name`, `surname`, `birthday`, `phone_number`, `login`, `password`, `id_post`) VALUES ('0', '{textBox_setWorker_Lastname.Text}', '{textBox_setWorker_Firstname.Text}', '{textBox_setWorker_surname.Text}', '{setWorker_birthday.Value.ToString("yyyy-MM-dd")}', '{textBox_setWorker_phonenumber.Text}', '{textBox_setWorker_login.Text}', '{textBox_setWorker_password.Text}', '{posts[comboBox_setWorker_postSelector.SelectedIndex].id_post}');");

            command.Connection = database.getConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
            ViewWorker();
        }
        private void button_setOrder_Click(object sender, EventArgs e)
        {
            database.openConnection();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `orders` (`id_order`, `id_encouragement`, `id_infrigement`, `type_order`, `date`) VALUES ('0', '{encourgaments[comboBox_id_encouragement.SelectedIndex].id}', '{infrigements[comboBox_id_infrigement.SelectedIndex].id}', '{textBox_type_order.Text}', '{dateTimePicker_dateSetOrder.Value.ToString("yyyy-MM-dd")}');");

            command.Connection = database.getConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
            ViewOrders();
        }
        private void button_setProductAssesment_Click(object sender, EventArgs e)
        {
            database.openConnection();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `productiviti_assessment` (`id_productiviti_assesment`, `id_worker`, `value`) VALUES ('0', '{infrigements[comboBoxWorkerInfrigement.SelectedIndex].id}', '{textBox_setProductAssesment.Text}');");

            command.Connection = database.getConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
            ViewAssessment();
        }
        private void button_paySheet_Click(object sender, EventArgs e)
        {
            database.openConnection();
            MySqlCommand command = new MySqlCommand($"INSERT INTO `pay_sheet` (`id_pay_sheet`, `id_worker`, `date`, `number_of_hourse`, `price_of_an_hour`) VALUES ('0', '{workers[comboBoxid_worker.SelectedIndex].id_worker}', '{dateTimePicker_PaySheet_date.Value.ToString("yyyy-MM-dd")}', '{textBox_paySheet_number_of_hourse.Text}', '{textBox_paySheet_price_of_an_hour.Text}');");

            command.Connection = database.getConnection();
            command.ExecuteNonQuery();
            database.closeConnection();
            paySheets = database.getPaySheet();
            ViewPaySheet();
        }


        private void buttonProductivitiReport_Click(object sender, EventArgs e)
        {

        }
    }
}
