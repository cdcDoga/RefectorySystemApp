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

namespace Refectory_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=IDE;Initial Catalog=Refectory;User ID=sa;Password=msSQLroot");

        private void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users WHERE email='" + txtEmail.Text.Trim() + "' AND uPassword='" + txtPassword.Text.Trim() + "'", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    SqlDataAdapter nameAtapter = new SqlDataAdapter("SELECT firstName, lastName FROM Users WHERE email='" + txtEmail.Text.Trim() + "'", conn);
                    DataTable nameDt = new DataTable();
                    nameAtapter.Fill(nameDt);

                    Name = nameDt.Rows[0][0].ToString() + " " + nameDt.Rows[0][1].ToString();

                    this.Hide();
                    UserForm userFrm = new UserForm();
                    userFrm.Show();
                }
                else
                {
                    MessageBox.Show("Please check the password.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is a problem about the connection!\n" + ex);
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "password")
            {
                this.Hide();
                AdminForm adminFrm = new AdminForm();
                adminFrm.Show();
            }
            else
            {
                MessageBox.Show("Please check the password.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
