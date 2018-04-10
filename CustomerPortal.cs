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
    public partial class CustomerPortal : Form
    {
        public CustomerPortal()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
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

                string selectorders = "Select * from owns where c_id = '" + Program.c_id_global + "'";

                MySqlDataAdapter da = new MySqlDataAdapter(selectorders, conn);
                DataSet ds = new DataSet();

                da.Fill(ds,"Owns_table");
                conn.Close();

                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Owns_table";
            }
            catch (MySqlException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void CustomerPortal_Load(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["reg_no"].Value.ToString();
            //Program.regno_global = textBox4.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (textBox4.Text == "")
        //    {
        //        MessageBox.Show("Select Row!");
        //        return;
        //    }

        //    Program.regno_global = textBox4.Text;

        //    new InsuranceForm().ShowDialog();
        //    CustomerPortal_Load(sender, e);
        //}
    }
}
