using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace SchoolÖrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        SqlConnection connect = new SqlConnection("Data Source=halilfidan\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from StudentRegister", connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand addRegister = new SqlCommand("insert into StudentRegister(SudentID,StudentName,StudentLastName,Gender,StudentFaculty,StudentDepartment,StudentClass,StudentAge) values(@s1,@s2,@s3,@s4,@s5,@s6,@s7,@s8)",connect);

            addRegister.Parameters.AddWithValue("@s1", textBox1.Text);
            addRegister.Parameters.AddWithValue("@s2", textBox2.Text);
            addRegister.Parameters.AddWithValue("@s3", textBox3.Text);
            addRegister.Parameters.AddWithValue("@s4", textBox4.Text);
            addRegister.Parameters.AddWithValue("@s5", textBox5.Text);
            addRegister.Parameters.AddWithValue("@s6", textBox6.Text);
            addRegister.Parameters.AddWithValue("@s7", textBox7.Text);
            addRegister.Parameters.AddWithValue("@s8", textBox8.Text);

            addRegister.ExecuteNonQuery();
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand deleteRegister = new SqlCommand("Delete From StudentRegister where StudentName=@name",connect);

            deleteRegister.Parameters.AddWithValue("@name", textBox2.Text);
            deleteRegister.ExecuteNonQuery();
            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            string id = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            string lastname = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            string gender = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            string faculty = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            string department = dataGridView1.Rows[selected].Cells[6].Value.ToString();
            string classes = dataGridView1.Rows[selected].Cells[6].Value.ToString();
            string age = dataGridView1.Rows[selected].Cells[7].Value.ToString();

            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = lastname;
            textBox4.Text = gender;
            textBox5.Text = faculty;
            textBox6.Text = department;
            textBox7.Text = classes;
            textBox8.Text = age;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand updateRegister = new SqlCommand("update StudentRegister set SudentID=@s1, StudentName=@s2, StudentLastName=@s3, Gender=@s4,StudentFaculty=@s5,StudentDepartment=@s6,StudentClass=@s7,StudentAge=@s8 where SudentID=@s1" ,connect);

            updateRegister.Parameters.AddWithValue("@s1", textBox1.Text);
            updateRegister.Parameters.AddWithValue("@s2", textBox2.Text);
            updateRegister.Parameters.AddWithValue("@s3", textBox3.Text);
            updateRegister.Parameters.AddWithValue("@s4", textBox4.Text);
            updateRegister.Parameters.AddWithValue("@s5", textBox5.Text);
            updateRegister.Parameters.AddWithValue("@s6", textBox6.Text);
            updateRegister.Parameters.AddWithValue("@s7", textBox7.Text);
            updateRegister.Parameters.AddWithValue("@s8", textBox8.Text);
            
            updateRegister.ExecuteNonQuery();
            connect.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from StudentRegister where StudentName='" + textBox2.Text + "'", connect);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            connect.Close();
        }
    }
}
