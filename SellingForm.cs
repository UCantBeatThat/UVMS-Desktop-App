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
using System.Text.RegularExpressions;

namespace Used_Vehicle_Dealership_System
{
    public partial class SellingForm : Form
    {
        static MySqlConnection conn;
        MySqlCommand comm;

        public SellingForm()
        {
            InitializeComponent();
            textBox2.Text = Program.regno_global;
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox5.Text = Program.double_global.ToString();

            string sqldb = @"server=localhost;userid=root;password=sandy@root";

            MySqlConnection conn;
            MySqlCommand comm;
            try
            {
                conn = new MySqlConnection(sqldb);
                conn.Open();
                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = Program.db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                string selectcid = "Select c_id from customer";

                MySqlDataAdapter da = new MySqlDataAdapter(selectcid, conn);
                DataTable dt = new DataTable("customer");

                da.Fill(dt);
                conn.Close();

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "c_id";
            }
            catch (MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }

        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
             
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

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();

            string query = ";";
            string query_owns = ";";
            string upd_status = ";";
            string order_no,regno, odate, c_id, req_date, ship_date;
            double o_amt;

            bool insert = true;

            do
            {
                order_no = textBox1.Text;
                if(order_no=="")
                {
                    MessageBox.Show("Enter Order No.!");
                    continue;
                }

                regno = textBox2.Text;
                odate = textBox3.Text;

                c_id = comboBox2.Text;
                if(c_id=="")
                {
                    MessageBox.Show("Customer Does Not Exist!");
                    continue;
                }
               
                o_amt = Program.double_global;

                //status = comboBox1.Text;
                //if (status == "")
                //{
                //    MessageBox.Show("Select Paying Amount!");
                //    continue;
                //}

                req_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                ship_date = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                upd_status = "update vehicle set status = 'Sold' where reg_no = '" + regno + "';";
                query = "insert into order_out values('"+regno+"','"+order_no+"','"+odate+"','"+c_id+"',"+ o_amt + ",'" + req_date + "','" + ship_date + "','" + "Full Amount" + "')";
                query_owns = "insert into owns values('" + c_id + "','" + regno + "')";
                
            } while (insert == false);
                    
            int flag = 0;
            try
            {

                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = Program.db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = query;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = query_owns;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = upd_status;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                    
            }
            catch (MySqlException oe)
            {
                MessageBox.Show(oe.Message);
                flag = 1;
            }
            if (flag == 0)
            {
                MessageBox.Show("Successful!");
                conn.Close();
                this.Close();
            }
            conn.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
