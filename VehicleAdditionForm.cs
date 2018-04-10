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
    public partial class VehicleAdditionForm : Form
    {
        static MySqlConnection conn;
        MySqlCommand comm;

        public VehicleAdditionForm()
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

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            string regno, model, company, type, condition, orderno, odate;
            double bprice, sprice;
            int year, dkms;

            bool insert = true;

            string insert_vehicle=";";
            string insert_order_in=";";
            string status = "Unsold";

            do{
                regno = textBox1.Text;
                if(regno=="")
                {
                    MessageBox.Show("Enter Reg. No.!");
                    continue;
                }
                
                model = textBox2.Text;
                if (model == "")
                {
                    MessageBox.Show("Enter Model!");
                    continue;
                }
                
                company = textBox3.Text;
                if (company == "")
                {
                    MessageBox.Show("Enter Company!");
                    continue;
                }
                
                type = comboBox2.Text;
                if (type == "")
                {
                    MessageBox.Show("Select Type!");
                    continue;
                }
                
                condition = comboBox1.Text;
                if (condition == "")
                {
                    MessageBox.Show("Select Condition!");
                    continue;
                }

                try
                {
                    dkms = int.Parse(textBox4.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid Driven KMs!");
                    continue;
                }

                try
                {
                    sprice = double.Parse(textBox5.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Invalid Selling Price!");
                    continue;
                }

                try
                {
                    year = int.Parse(textBox8.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Enter Valid Model Year!");
                    continue;
                }
                if(year>2018||year<1880)
                {
                    MessageBox.Show("Enter Valid Model Year!");
                    continue;
                }
                
                DateTime result = dateTimePicker1.Value;
                odate = result.ToString("yyyy-MM-dd");
                
                orderno = textBox6.Text;
                if (orderno == "")
                {
                    MessageBox.Show("Enter Order Number!");
                    continue;
                }

                try
                {
                    bprice = double.Parse(textBox7.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Buying Price!");
                    continue;
                }

                insert_vehicle = "insert into vehicle values('" + regno + "'," + sprice + ",'" + condition + "','" + model + "','" + company + "'," + dkms + "," + year + ",'" + type + "','" + status +"')";
                insert_order_in = "insert into order_in values('" + orderno + "','" + odate + "'," + bprice + ",'" + regno + "')";
            } while (insert == false);

            int flag = 0;

            try
            {

                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = Program.db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = insert_vehicle;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = insert_order_in;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException oe)
            {
                flag = 1;
                MessageBox.Show(oe.Message);
            }
            if (flag == 0)
            {
                MessageBox.Show("Successful!");
                conn.Close();
                this.Close();
            }
            conn.Close();
        }
    }
}
