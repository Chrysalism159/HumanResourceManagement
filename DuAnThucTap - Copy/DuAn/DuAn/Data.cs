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

namespace DuAn
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DuAnThucTap\Database\EmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            //add btn
            if (id.Text == "" || name.Text == "" || add.Text == "" || phone.Text =="")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    con.Open();
                    string querry = "insert into EmployeeTbl values ('"+id.Text+"', '"+name.Text+"', '" +add.Text +"', '" +gender.SelectedItem.ToString()+"', '" +EducaCb.SelectedItem.ToString() +"', '" +phone.Text +"', '" +position.SelectedItem.ToString() +"', '" +DoB.Value.ToShortDateString()+"')";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data add successfuly!");
                    con.Close();
                    populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void populate()
        {
            con.Open();
            string querry = " select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DataTable.DataSource = ds.Tables[0];
            
            con.Close();
        }
        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Data_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(id.Text =="")
            {
                MessageBox.Show("Enter the employ id");

            }
            else
            {
                try
                {
                    con.Open();
                    string querry = "delete from EmployeeTbl where EmId = '"+id.Text+"';";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data delete successfully");
                    con.Close();
                    populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DataTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = DataTable.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = DataTable.SelectedRows[0].Cells[1].Value.ToString();
            add.Text = DataTable.SelectedRows[0].Cells[2].Value.ToString();
            gender.Text = DataTable.SelectedRows[0].Cells[3].Value.ToString();
            EducaCb.Text = DataTable.SelectedRows[0].Cells[4].Value.ToString();
            phone.Text = DataTable.SelectedRows[0].Cells[5].Value.ToString();
            position.Text = DataTable.SelectedRows[0].Cells[6].Value.ToString();
            DoB.Text = DataTable.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || name.Text == "" || add.Text == "" || phone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string querry = "update EmployeeTbl set EmID ='" + id.Text + "', EmName = '" + name.Text + "',EmAdd = '" + add.Text + "',EmGender= '" + gender.SelectedItem.ToString() + "',EmCollage = '" + EducaCb.SelectedItem.ToString() + "',  EmPhone='" + phone.Text + "',EmPosition = '" + position.SelectedItem.ToString() + "',EmDoB = '" + DoB.Value.ToShortDateString() + "' where EmID = '"+id.Text+"'";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee update success");
                    con.Close();
                    populate();

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DoB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
