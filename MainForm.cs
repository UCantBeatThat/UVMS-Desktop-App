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
    public partial class MainForm : Form
    {
        
        public static void initializeSchemas()
        {
            MySqlCommand comm;
            MySqlConnection conn;

            string sqldb = @"server=localhost;userid=root;password=sandy@root";  
            
            try
            {
                conn = new MySqlConnection(sqldb);
                conn.Open();
                string db_create = "create database if not exists UVDS_SCHEMAS";
                string db_use = "use UVDS_SCHEMAS";
                string uvds_schemas = "create table if not exists SCHEMATABLE(schemaname varchar(20) primary key)";
                try
                {
                    comm = new MySqlCommand();
                    comm.Connection = conn;
              
                    comm.CommandText = db_create;
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
              
                    comm.CommandText = db_use;
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();

                    comm.CommandText = uvds_schemas;
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                }
                catch (MySqlException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
            }catch (MySqlException ex)
            {
                MessageBox.Show("Error!\n\n" + ex.Message);
            }
        }
        
        public MainForm()
        {
            InitializeComponent();
            initializeSchemas();
            checkexist();
            display_Vehicles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm x = NewMethod();
            x.ShowDialog();
        }

        private static LoginForm NewMethod()
        {
            return new LoginForm();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //NewStore n = new NewStore();
            //n.ShowDialog();
        }

        private void checkexist()
        {
            MySqlCommand comm;
            MySqlConnection conn;

            int count = 0;

            string sqldb = @"server=localhost;userid='root';password='sandy@root'";

            conn = new MySqlConnection(sqldb);
            conn.Open();
            string db_use = "use UVDS_SCHEMAS";
            string query = "select count(schemaname) from schematable";
            try
            {
                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = query;
                comm.CommandType = CommandType.Text;
                count = int.Parse(comm.ExecuteScalar().ToString());
                //MessageBox.Show(""+count+"");
            }
            catch (MySqlException oe)
            {
                MessageBox.Show(oe.Message);
            }

            //if (count > 0)
            //    linkLabel1.Hide();
            //else
            //    linkLabel1.Show();
        }

        public void display_Vehicles()
        {
            MySqlCommand comm;
            MySqlConnection conn;

            string sqldb = @"server=localhost;userid='root';password='sandy@root'";

            conn = new MySqlConnection(sqldb);
            conn.Open();

            string db_use = "use uvds_schemas";
            try
            {
                conn = new MySqlConnection(sqldb);
                conn.Open();
                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                string selectvehicles = "Select model as Model,company as Company, year as Model_Year,cond as Vehicle_Condition,driven_km as Driven_KMs,cost as Price,type as Vehicle_Type from vehicle where reg_no not in(select reg_no from owns)";

                MySqlDataAdapter da = new MySqlDataAdapter(selectvehicles, conn);
                DataSet ds = new DataSet();

                da.Fill(ds, "Vehicle_table");
                conn.Close();

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Vehicle_table";
            }
            catch (MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);

            string sqldb = @"server=localhost;userid=root;password=sandy@root";           //database=used_vehicle_dealership_system";

            MySqlConnection conn;
            MySqlCommand comm;
            // MessageBox.Show(comboBox1.Text);
            string db_use = "use " + comboBox1.Text;
            try
            {
                conn = new MySqlConnection(sqldb);
                conn.Open();
                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = "use " + comboBox1.Text;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                string selectvehicles = "Select model as Model,company as Company, year as Model_Year,cond as Vehicle_Condition,driven_km as Driven_KMs,cost as Price,type as Vehicle_Type from vehicle where reg_no not in(select reg_no from owns)";

                MySqlDataAdapter da = new MySqlDataAdapter(selectvehicles, conn);
                DataSet ds = new DataSet();

                da.Fill(ds, "Vehicle_table");
                conn.Close();

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Vehicle_table";

            }
            catch (MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //button1_Click(sender, e);
            // TODO: This line of code loads data into the 'uvds_schemasDataSet1.schematable' table. You can move, or remove it, as needed.
            this.schematableTableAdapter1.Fill(this.uvds_schemasDataSet1.schematable);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
