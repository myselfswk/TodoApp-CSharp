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

namespace TodoApp_CSharp
{
    public partial class Dashboard : Form
    {
        SqlConnection conn;
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (gm1.Checked && gm2.Checked && gm3.Checked && gm4.Checked && gm5.Checked && gm6.Checked)
            {
                MessageBox.Show("Perfect, Done Your Whole Exercises...");
            }
            else
            {
                MessageBox.Show("Looks Like You Have Not Finished Your Exercise Yet...!");
            }

            if (st1.Checked && st2.Checked && st3.Checked && st4.Checked && st5.Checked && st6.Checked)
            {
                MessageBox.Show("Perfect, Done Your Whole Study Work...");
            }
            else
            {
                MessageBox.Show("Looks Like You Have Not Finished Your Study Work Yet...!");
            }

            if (ot1.Checked && ot2.Checked && ot3.Checked && ot4.Checked && ot5.Checked && ot6.Checked)
            {
                MessageBox.Show("Perfect, Done Your Whole Office Work...");
            }
            else
            {
                MessageBox.Show("Looks Like You Have Not Finished Your Office Work Yet...!");
            }

            string checkboxCon = ot1.Checked.ToString();

            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-QG8ONMB;Initial Catalog=RegisterUser;Integrated Security=True");
                SqlCommand command = new SqlCommand();

                command.CommandText = "Insert into [Tasks_Todo](task, dateAndTime) Values('"+ checkboxCon +"', '"+ dateTimePicker1.Text +"')";
                command.Connection = conn;

                conn.Open();

                MessageBox.Show("Date and Task Added..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        private void gbStudy_Enter(object sender, EventArgs e)
        {

        }
    }
}
