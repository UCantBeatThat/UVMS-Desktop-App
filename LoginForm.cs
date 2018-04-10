using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Used_Vehicle_Dealership_System
{
    public partial class LoginForm : Form
    {
        static MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int flag = 0;

        public LoginForm()
        {
            InitializeComponent();
            
        }

        public static void connect1()
        {
            string sqldb = @"server=localhost;userid=root;password=sandy@root";           //database=used_vehicle_dealership_system";
            try
            {
                conn = new MySqlConnection(sqldb);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!\n\n" + ex.Message);
            }
        }

        private void Open_Company_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uvds_schemasDataSet2.schematable' table. You can move, or remove it, as needed.
            this.schematableTableAdapter.Fill(this.uvds_schemasDataSet2.schematable);
            // TODO: This line of code loads data into the 'performance_schemaDataSet.accounts' table. You can move, or remove it, as needed.
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            string companyname = comboBox1.Text;
            string id = textBox2.Text;
            string pwd = textBox3.Text;
            string query = "";
            Program.db_use = "use " + comboBox1.Text;         //Use what is in store name
            
            try
            {
                comm = new MySqlCommand();
                comm.Connection = conn;

               
                try
                {
                    comm.CommandText = Program.db_use;                  //select the database
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    MessageBox.Show("Store Does Not Exist!");
                    goto JUMP;
                }

                int table=0;

                if (radioButton1.Checked)
                {
                    
                    try
                    {
                        query = "Select password from MANAGER where man_id = '" + id + "'";

                        comm.CommandText = query;                           //
                        comm.CommandType = CommandType.Text;                //Sending query to select password
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("ID does not exist!");
                    }
                    table=1;
                }
                else if (radioButton2.Checked)
                {                   
                    try
                    {
                        query = "Select password from WORKER where work_id = '" + id + "'";

                        comm.CommandText = query;                           //
                        comm.CommandType = CommandType.Text;                //Sending query to select password
                    }
                    catch (MySqlException)
                    {
                        MessageBox.Show("ID does not exist!");
                    }
                    table = 2;
                }
                else if (radioButton3.Checked)
                {
                    try
                    {
                        query = "Select password from CUSTOMER where c_id = '" + id + "'";

                        comm.CommandText = query;                           //
                        comm.CommandType = CommandType.Text;                //Sending query to select password
                    }
                    catch(MySqlException)
                    {
                        MessageBox.Show("ID does not exist!");
                    }
                    table = 3;
                    Program.c_id_global = id;
                }

                else
                    throw new Exception("Select User Role!");



                String pwd_check="";


                try
                {
                    pwd_check= comm.ExecuteScalar().ToString();     //returns first object from data selected and converts to string
                                                                    //          MessageBox.Show(pwd_check);
                }
                catch(Exception)
                {
                }

                if (pwd.Equals(pwd_check))
                {
                    if(table==1)
                    {
                        new ManagerPortal().ShowDialog();
                    }

                    else if (table==2)
                    {
                        new WorkerPortal().ShowDialog();
                    }
                    else if (table==3)
                    {
                        new CustomerPortal().ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Credentials Entered!");
                }



            }catch(Exception exc){
                MessageBox.Show(exc.ToString());
            };

            JUMP:
            conn.Close();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
