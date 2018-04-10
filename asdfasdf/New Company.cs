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
    public partial class New_Company : Form
    {
        static MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

        public New_Company()
        {
            InitializeComponent();
        }

        public static void connect1()
        {
            string sqldb = @"server=localhost;userid=root;password=vicfirth";           //database=used_vehicle_dealership_system";
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

            string db_create = "create database "+textBox1.Text;

            string db_use = "use "+textBox1.Text;

            string manager_create = "create table MANAGER(man_id varchar(10) primary key, fname varchar(30) not null, lname varchar(30) not null, phone varchar(10), address varchar(50), salary numeric(6,2), dob date, gender char, password varchar(15) not null)";
            string worker_create = "create table WORKER(work_id varchar(10) primary key, fname varchar(30) not null, lname varchar(30) not null, phone varchar(10), address varchar(50), salary numeric(6,2), dob date, password varchar(15) not null)";
            string customer_create = "create table CUSTOMER(c_id varchar(10) primary key, fname varchar(30) not null, lname varchar(30) not null, phone varchar(10) not null, address varchar(50) not null, password varchar(15) not null, city varchar(20), state varchar(20), dob date, pin varchar(10), country varchar(20))";
            string vehicle_create = "create table VEHICLE(reg_no varchar(10) primary key, cost numeric(6,2), cond varchar(20), model varchar(20), company varchar(20), driven_km int, year int, type varchar(20))";
            string accident_create = "create table ACCIDENT(report_no varchar(10) primary key, location varchar(20), accident_date date, reg_no varchar(10), damage_amt numeric(6,2))";
            string order_in_create = "create table ORDER_IN(order_no varchar(10) primary key, o_date date, o_amt numeric(6,2), reg_no varchar(10))";
            string order_out_create = "create table ORDER_OUT(order_no varchar(10) primary key, reg_no varchar(10), o_date date, c_id varchar(10), o_amt numeric(6,2), req_date date, ship_date date, status varchar(20))";
            string owns_create = "create table OWNS(c_id varchar(10), reg_no varchar(10))";
            
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

                    if (radioButton1.Enabled)
                        gender = 'M';
                    else if (radioButton2.Enabled)
                        gender = 'F';
                    else
                    {
                        MessageBox.Show("Select Gender!");
                        continue;
                    }

                    insert_manager = "insert into manager values('" + man_id + "','" + fname + "','" + lname + "','" + phno + "','" + address + "'," + sal + ",'" + dob + "','" + gender + "','" + pwd1 + "')";
                    
                    //MessageBox.Show(insert_manager);
            }while(insert==false);
           
            int flag = 0;
            try
            {
                comm = new MySqlCommand();
                comm.Connection = conn;

                comm.CommandText = db_create;
                comm.ExecuteNonQuery();

                comm.CommandText = db_use;
                comm.ExecuteNonQuery();

                comm.CommandText = manager_create;
                comm.ExecuteNonQuery();

                comm.CommandText = worker_create;
                comm.ExecuteNonQuery();

                comm.CommandText = customer_create;
                comm.ExecuteNonQuery();

                comm.CommandText = vehicle_create;
                comm.ExecuteNonQuery();

                comm.CommandText = owns_create;
                comm.ExecuteNonQuery();

                comm.CommandText = order_in_create;
                comm.ExecuteNonQuery();

                comm.CommandText = order_out_create;
                comm.ExecuteNonQuery();

                comm.CommandText = accident_create;
                comm.ExecuteNonQuery();

                comm.CommandText = insert_manager;
                comm.ExecuteNonQuery();
            }
            catch (MySqlException oe)
            {
               // MessageBox.Show(insert_manager);
                MessageBox.Show(oe.Message);
                flag = 1;
            }
            if (flag == 0)
                MessageBox.Show("Successful!");
            conn.Close();
            this.Close();
        }
    }
}
