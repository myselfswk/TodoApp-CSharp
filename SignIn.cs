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
    public partial class SignIn : Form
    {
        SqlConnection conn;
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-QG8ONMB;Initial Catalog=RegisterUser;Integrated Security=True");

                string credentials = "select * from [Users_Todo].[dbo].[User] where [username] = '" + txtUsername.Text + "' and [password] = '" + txtPassword.Text + "'";

                conn.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(credentials, conn);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 1)
                {
                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Check Your Username and password");
                }
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
    }
}
