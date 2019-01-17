using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace Refectory_Project
{
    public partial class AdminForm : Form
    {
        ArrayList dateArr = new ArrayList();

        public AdminForm()
        {
            InitializeComponent();
            lblAdminScroll.Width = btnDailyMenu.Width;
            lblAdminScroll.Left = btnDailyMenu.Left;
            pnlStats.Visible = false;
        }

        SqlConnection conn = new SqlConnection("Data Source=IDE;Initial Catalog=Refectory;User ID=sa;Password=msSQLroot");

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm log = new LoginForm();
            log.Show();
        }

        private void btnDailyMenu_Click(object sender, EventArgs e)
        {
            lblAdminScroll.Width = btnDailyMenu.Width;
            lblAdminScroll.Left = btnDailyMenu.Left;
            pnlStats.Visible = false;
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            lblAdminScroll.Width = btnStats.Width;
            lblAdminScroll.Left = btnStats.Left;
            pnlStats.Visible = true;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            fillLisView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*
            if (lvDailyMenu.SelectedItems.Count == 1 && MessageBox.Show("Data will be deleted permenantly. Are you sure ?", "Warning !", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string command = @"DELETE * FROM Daily_Menu INNER JOIN  Assign WHERE Daily_Menu.dmDate=Assign.dmDate INNER JOIN Selection WHERE Daily_Menu.dmDate=Selection.dmDate AND (((Daily_Menu.dmDate)=[?]));";
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.Add("date", SqlDbType.Date).Value = DateTime.Parse(dateArr[lvDailyMenu.SelectedIndices[0]].ToString());
                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {

                        MessageBox.Show("Movie Deleted Successfuly !");

                    }
                    conn.Close();
                    fillLisView();
                }
                catch (Exception)
                {

                    MessageBox.Show("Error at Delete !");
                }
            }*/
        }



        private void fillLisView()
        {
            lvDailyMenu.Items.Clear();
            dateArr.Clear();

            /*
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT dmDate, dmType, mCode FROM Assign ORDER BY dmDate, dmType";
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime dmDate = DateTime.Parse(reader["dmDate"].ToString());  // for better visualize in listView. 

                ListViewItem items = new ListViewItem(dmDate.ToString("dd/MM/yyyy"));
                items.SubItems.Add(reader["dmType"].ToString());
                items.SubItems.Add(reader["mCode"].ToString());
                lvDailyMenu.Items.Add(items);
                
            }
            reader.Close();
            conn.Close();*/

            SqlDataAdapter countAdapter = new SqlDataAdapter("SELECT COUNT(DISTINCT dmDate) FROM Assign", conn);
            DataTable countDT = new DataTable();
            countAdapter.Fill(countDT);
            string c = countDT.Rows[0][0].ToString();
            int count = Convert.ToInt32(c);

            SqlDataAdapter mealAdapter = new SqlDataAdapter("SELECT dmDate, dmType, mCode FROM Assign ORDER BY dmDate, dmType", conn);
            DataTable dtMeal = new DataTable();
            mealAdapter.Fill(dtMeal);
            

            for (int i = 0; i <= 14*(count-1); i+=14)
            {
                DateTime dm_Date = DateTime.Parse(dtMeal.Rows[i][0].ToString());

                ListViewItem liv = new ListViewItem(dm_Date.ToString("dd-MM-yyyy"));
                dateArr.Add(dm_Date.ToString("dd-MM-yyyy"));

                for (int k = 0; k < 6; k++)
                {
                    liv.SubItems.Add(dtMeal.Rows[i+k][2].ToString());
                }

                string modifiedDate = dm_Date.ToString("yyyy-MM-dd");
                SqlDataAdapter reservedAdapterB = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='breakfast' AND paid=0", conn);
                DataTable dtReservedB = new DataTable();
                reservedAdapterB.Fill(dtReservedB);

                liv.SubItems.Add(dtReservedB.Rows[0][0].ToString());

                SqlDataAdapter paidAdapterB = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='breakfast' AND paid=1", conn);
                DataTable dtPaidB = new DataTable();
                paidAdapterB.Fill(dtPaidB);

                liv.SubItems.Add(dtPaidB.Rows[0][0].ToString());


                for (int k = 10; k < 14; k++)
                {
                    liv.SubItems.Add(dtMeal.Rows[i+k][2].ToString());
                }

                SqlDataAdapter reservedAdapterL = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='lunch' AND paid=0", conn);
                DataTable dtReservedL = new DataTable();
                reservedAdapterL.Fill(dtReservedL);

                liv.SubItems.Add(dtReservedL.Rows[0][0].ToString());

                SqlDataAdapter paidAdapterL = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='lunch' AND paid=1", conn);
                DataTable dtPaidL = new DataTable();
                paidAdapterL.Fill(dtPaidL);

                liv.SubItems.Add(dtPaidL.Rows[0][0].ToString());


                for (int k = 6; k < 10; k++)
                {
                    liv.SubItems.Add(dtMeal.Rows[i+k][2].ToString());
                }

                SqlDataAdapter reservedAdapterD = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='dinner' AND paid=0", conn);
                DataTable dtReservedD = new DataTable();
                reservedAdapterD.Fill(dtReservedD);

                liv.SubItems.Add(dtReservedD.Rows[0][0].ToString());

                SqlDataAdapter paidAdapterD = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='dinner' AND paid=1", conn);
                DataTable dtPaidD = new DataTable();
                paidAdapterD.Fill(dtPaidD);

                liv.SubItems.Add(dtPaidD.Rows[0][0].ToString());


                lvDailyMenu.Items.Add(liv);
            }
        }
    }
}
