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
    public partial class WorkerPortal : Form
    {
        public WorkerPortal()
        {
            InitializeComponent();
        }

        private void WorkerPortal_Load(object sender, EventArgs e)
        {
            button9_Click(sender, e);
            button10_Click(sender, e);
            button6_Click(sender, e);
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomerRegistrationForm().ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.regno_global = dataGridView1.Rows[e.RowIndex].Cells["Reg_Number"].Value.ToString();
            //try
            //{
            //    Program.double_global = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());
            //}catch(Exception)
            //{ }
            Program.double_global = double.Parse(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
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

                string selectvehicles = "Select reg_no as Reg_Number, model as Model,company as Company, year as Model_Year,cond as Vehicle_Condition,driven_km as Driven_KMs,cost as Price,type as Vehicle_Type from vehicle where reg_no not in(select reg_no from owns);";

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

        private void button2_Click(object sender, EventArgs e)
        {
            //    if (textBox4.Text == "")
            //    {
            //        MessageBox.Show("Select Row!");
            //        return;
            //    }
            if (Program.regno_global == "")
            {
                MessageBox.Show("Select Row");
                return;
            }
            //    Program.regno_global = textBox4.Text;

               new SellingForm().ShowDialog();
               WorkerPortal_Load(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
        //    string sqldb = @"server=localhost;userid=root;password=sandy@root";

        //    MySqlConnection conn;
        //    MySqlCommand comm;
        //    try
        //    {
        //        conn = new MySqlConnection(sqldb);
        //        conn.Open();
        //        comm = new MySqlCommand();
        //        comm.Connection = conn;

        //        comm.CommandText = Program.db_use;
        //        comm.CommandType = CommandType.Text;
        //        comm.ExecuteNonQuery();

        //        string selectorders = "Select order_no as Order_Number, reg_no as Reg_Number, o_date as Order_Date, c_id as Customer_ID, req_date as Reqirement_Date, ship_date as Shipment_Date, status as Status from order_out where status = 'Half Amount'";

        //        MySqlDataAdapter da = new MySqlDataAdapter(selectorders, conn);
        //        DataSet ds = new DataSet();

        //        da.Fill(ds, "order_out_table");
        //        conn.Close();

        //        dataGridView3.DataSource = ds;
        //        dataGridView3.DataMember = "order_out_table";
        //    }
        //    catch (MySqlException ex1)
        //    {
        //        MessageBox.Show(ex1.Message);
        //    }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox5.Text = dataGridView3.Rows[e.RowIndex].Cells["Reg_Number"].Value.ToString();
            //Program.regno_global = textBox5.Text;        
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            //string query = "Update order_out set status = 'Full Amount' where reg_no = '" + textBox5.Text + "'";

            //if (textBox5.Text == "")
            //{
            //    MessageBox.Show("Select A Vehicle First!");
            //    return;
            //}
            //else
            //{
            //    var confirmResult = MessageBox.Show("Make Changes?", "Warning", MessageBoxButtons.YesNo);
            //    if (confirmResult == DialogResult.Yes)
            //    {
            //        string sqldb = @"server=localhost;userid=root;password=sandy@root";

            //        MySqlConnection conn;
            //        MySqlCommand comm;
            //        try
            //        {
            //            conn = new MySqlConnection(sqldb);
            //            conn.Open();
            //            comm = new MySqlCommand();
            //            comm.Connection = conn;

            //            comm.CommandText = query;
            //            comm.CommandType = CommandType.Text;
            //            comm.ExecuteNonQuery();
            //        }
            //        catch (Exception)
            //        {
            //            MessageBox.Show("Error!");
            //            return;
            //        }
            //        WorkerPortal_Load(sender, e);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
        }

        private void button10_Click(object sender, EventArgs e)
        {
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

                string selectorders = "Select order_no as Order_Number, reg_no as Reg_Number, o_date as Order_Date, c_id as Customer_ID, req_date as Reqirement_Date, ship_date as Shipment_Date, status as Status from order_out";

                MySqlDataAdapter da = new MySqlDataAdapter(selectorders, conn);
                DataSet ds = new DataSet();

                da.Fill(ds, "order_out_table");
                conn.Close();

                dataGridView4.DataSource = ds;
                dataGridView4.DataMember = "order_out_table";
            }
            catch (MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CustomerRegistrationForm().ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
