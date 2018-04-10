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
    public partial class ManagerRegistrationForm : Form
    {

        static MySqlConnection conn;
        static MySqlCommand comm;

        public ManagerRegistrationForm()
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
            string fname, lname, dob, address, man_id, pwd1, pwd2, phno;
            string insert_manager = ";";
            double sal;
            char gender;
            bool insert = true;
            do{
                    fname = textBox3.Text;
                    if(fname=="")
                    {
                        MessageBox.Show("Enter First Name!");
                        continue;
                    }
                    /*
                    else if(!Regex.Match(fname,"^[a-zA-Z]*$" ).Success )
                    {
                        MessageBox.Show("Invalid First Name!");
                        continue;
                    }
                    */
                    lname = textBox4.Text;
                    if (lname == "")
                    {
                        MessageBox.Show("Enter Last Name!");
                        continue;
                    }

                    DateTime result = dateTimePicker1.Value;
                    dob = result.ToString("yyyy-MM-dd");
                    
                    phno = textBox7.Text;

                    address = textBox8.Text;

                    man_id = textBox2.Text;
                    if (man_id == "")
                    {
                        MessageBox.Show("Enter ID!");
                        continue;
                    }

                    pwd1 = textBox5.Text;
                    pwd2 = textBox6.Text;
                    if(pwd1!=pwd2)
                    { 
                        MessageBox.Show("Passwords do not match!");
                        continue;
                    }
                    else if(pwd1=="")
                    {
                        MessageBox.Show("Enter Password!");
                        continue;
                    }
                    else if (pwd2 == "")
                    {
                        MessageBox.Show("Please Confirm Password!");
                        continue;
                    }

                    sal = 0;

                    if (radioButton1.Checked)
                        gender = 'M';
                    else if (radioButton2.Checked)
                        gender = 'F';
                    else
                    {
                        MessageBox.Show("Select Gender!");
                        continue;
                    }

                    insert_manager = "insert into manager values('" + man_id + "','" + fname + "','" + lname + "','" + phno + "','" + address + "'," + sal + ",'" + dob + "','" + gender + "','" + pwd1 + "')";
                    //MessageBox.Show(insert_manager);
            } while (insert == false);


            int flag = 0;
            try
            {

                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = Program.db_use;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

                comm.CommandText = insert_manager;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException oe)
            {
                MessageBox.Show(oe.GetBaseException().ToString());
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
