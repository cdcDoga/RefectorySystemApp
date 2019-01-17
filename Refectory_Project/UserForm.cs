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
    public partial class UserForm : Form
    {
        ArrayList dateArr = new ArrayList();

        public UserForm()
        {
            InitializeComponent();
            lblUserScroll.Width = btnBreakfast.Width;
            lblUserScroll.Left = btnBreakfast.Left;
            pnlLunch.Visible = false;
            pnlDinner.Visible = false;
            pnlCheckOut.Visible = false;

            cbLocationD.Enabled = true;

            btnPay.Enabled = false;
        }
        
        SqlConnection conn = new SqlConnection("Data Source=IDE;Initial Catalog=Refectory;User ID=sa;Password=msSQLroot");

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm log = new LoginForm();
            log.Show();
        }

        private void btnBreakfast_Click(object sender, EventArgs e)
        {
            lblUserScroll.Width = btnBreakfast.Width;
            lblUserScroll.Left = btnBreakfast.Left;
            pnlLunch.Visible = false;
            pnlDinner.Visible = false;
            pnlCheckOut.Visible = false;

            cbLocationD.Enabled = true;

        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            lblUserScroll.Width = btnLunch.Width;
            lblUserScroll.Left = btnLunch.Left;
            pnlLunch.Visible = true;
            pnlDinner.Visible = false;
            pnlCheckOut.Visible = false;

            cbLocationD.Enabled = true;
        }

        private void btnDinner_Click(object sender, EventArgs e)
        {
            lblUserScroll.Width = btnDinner.Width;
            lblUserScroll.Left = btnDinner.Left;
            pnlLunch.Visible = true;
            pnlDinner.Visible = true;
            pnlCheckOut.Visible = false;

            cbLocationD.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblUserScroll.Width = btnSave.Width;
            lblUserScroll.Left = btnSave.Left;
            cbLocationD.Enabled = false;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            lblUserScroll.Width = btnCheckOut.Width;
            lblUserScroll.Left = btnCheckOut.Left;
            pnlLunch.Visible = true;
            pnlDinner.Visible = true;
            pnlCheckOut.Visible = true;

            cbLocationD.Enabled = false;

        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            fillTheField();

            groupBox6.Enabled = false;
            groupBox7.Enabled = false;

            groupBox13.Enabled = false;
            groupBox14.Enabled = false;

            groupBox20.Enabled = false;
            groupBox21.Enabled = false;

            groupBox22.Enabled = false;
            groupBox37.Enabled = false;

            groupBox23.Enabled = false;
            groupBox31.Enabled = false;

            groupBox24.Enabled = false;
            groupBox25.Enabled = false;

            groupBox43.Enabled = false;
            groupBox46.Enabled = false;

            groupBox44.Enabled = false;
            groupBox52.Enabled = false;

            groupBox45.Enabled = false;
            groupBox58.Enabled = false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment is successfully recieved !", "Congrats !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void btnSelect1stWeek_Click(object sender, EventArgs e)
        {
            checkBox1.CheckState = CheckState.Checked;
            checkBox2.CheckState = CheckState.Checked;
            checkBox3.CheckState = CheckState.Checked;
            checkBox4.CheckState = CheckState.Checked;
            checkBox5.CheckState = CheckState.Checked;
        }

        private void btnDeselect1stWeek_Click(object sender, EventArgs e)
        {
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
            checkBox4.CheckState = CheckState.Unchecked;
            checkBox5.CheckState = CheckState.Unchecked;
        }

        private void btnSelect2ndWeek_Click(object sender, EventArgs e)
        {
            checkBox8.CheckState = CheckState.Checked;
            checkBox9.CheckState = CheckState.Checked;
            checkBox10.CheckState = CheckState.Checked;
            checkBox11.CheckState = CheckState.Checked;
            checkBox12.CheckState = CheckState.Checked;
        }

        private void btnDeselect2ndWeek_Click(object sender, EventArgs e)
        {
            checkBox8.CheckState = CheckState.Unchecked;
            checkBox9.CheckState = CheckState.Unchecked;
            checkBox10.CheckState = CheckState.Unchecked;
            checkBox11.CheckState = CheckState.Unchecked;
            checkBox12.CheckState = CheckState.Unchecked;
        }

        private void btnSelect3rdWeek_Click(object sender, EventArgs e)
        {
            checkBox15.CheckState = CheckState.Checked;
            checkBox16.CheckState = CheckState.Checked;
            checkBox17.CheckState = CheckState.Checked;
            checkBox18.CheckState = CheckState.Checked;
            checkBox19.CheckState = CheckState.Checked;
        }

        private void btnDeselect3rdWeek_Click(object sender, EventArgs e)
        {
            checkBox15.CheckState = CheckState.Unchecked;
            checkBox16.CheckState = CheckState.Unchecked;
            checkBox17.CheckState = CheckState.Unchecked;
            checkBox18.CheckState = CheckState.Unchecked;
            checkBox19.CheckState = CheckState.Unchecked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBox42.CheckState = CheckState.Checked;
            checkBox41.CheckState = CheckState.Checked;
            checkBox40.CheckState = CheckState.Checked;
            checkBox39.CheckState = CheckState.Checked;
            checkBox38.CheckState = CheckState.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox42.CheckState = CheckState.Unchecked;
            checkBox41.CheckState = CheckState.Unchecked;
            checkBox40.CheckState = CheckState.Unchecked;
            checkBox39.CheckState = CheckState.Unchecked;
            checkBox38.CheckState = CheckState.Unchecked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox36.CheckState = CheckState.Checked;
            checkBox35.CheckState = CheckState.Checked;
            checkBox34.CheckState = CheckState.Checked;
            checkBox33.CheckState = CheckState.Checked;
            checkBox32.CheckState = CheckState.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox36.CheckState = CheckState.Unchecked;
            checkBox35.CheckState = CheckState.Unchecked;
            checkBox34.CheckState = CheckState.Unchecked;
            checkBox33.CheckState = CheckState.Unchecked;
            checkBox32.CheckState = CheckState.Unchecked;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBox30.CheckState = CheckState.Checked;
            checkBox29.CheckState = CheckState.Checked;
            checkBox28.CheckState = CheckState.Checked;
            checkBox27.CheckState = CheckState.Checked;
            checkBox26.CheckState = CheckState.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox30.CheckState = CheckState.Unchecked;
            checkBox29.CheckState = CheckState.Unchecked;
            checkBox28.CheckState = CheckState.Unchecked;
            checkBox27.CheckState = CheckState.Unchecked;
            checkBox26.CheckState = CheckState.Unchecked;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            checkBox63.CheckState = CheckState.Checked;
            checkBox62.CheckState = CheckState.Checked;
            checkBox61.CheckState = CheckState.Checked;
            checkBox60.CheckState = CheckState.Checked;
            checkBox59.CheckState = CheckState.Checked;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkBox63.CheckState = CheckState.Unchecked;
            checkBox62.CheckState = CheckState.Unchecked;
            checkBox61.CheckState = CheckState.Unchecked;
            checkBox60.CheckState = CheckState.Unchecked;
            checkBox59.CheckState = CheckState.Unchecked;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkBox57.CheckState = CheckState.Checked;
            checkBox56.CheckState = CheckState.Checked;
            checkBox55.CheckState = CheckState.Checked;
            checkBox54.CheckState = CheckState.Checked;
            checkBox53.CheckState = CheckState.Checked;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkBox57.CheckState = CheckState.Unchecked;
            checkBox56.CheckState = CheckState.Unchecked;
            checkBox55.CheckState = CheckState.Unchecked;
            checkBox54.CheckState = CheckState.Unchecked;
            checkBox53.CheckState = CheckState.Unchecked;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkBox51.CheckState = CheckState.Checked;
            checkBox50.CheckState = CheckState.Checked;
            checkBox49.CheckState = CheckState.Checked;
            checkBox48.CheckState = CheckState.Checked;
            checkBox47.CheckState = CheckState.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkBox51.CheckState = CheckState.Unchecked;
            checkBox50.CheckState = CheckState.Unchecked;
            checkBox49.CheckState = CheckState.Unchecked;
            checkBox48.CheckState = CheckState.Unchecked;
            checkBox47.CheckState = CheckState.Unchecked;
        }

        private void btnTotalAmount_Click(object sender, EventArgs e)
        {
            int price = 0;
            CheckBox[] checkBoxes = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4,
                checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11,
                checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18,
                checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24, checkBox25,
                checkBox26, checkBox27, checkBox28, checkBox29, checkBox30, checkBox31, checkBox32,
                checkBox33, checkBox34, checkBox35, checkBox36, checkBox37, checkBox38, checkBox39,
                checkBox40, checkBox41, checkBox42, checkBox43, checkBox44, checkBox45, checkBox46,
                checkBox47, checkBox48, checkBox49, checkBox50, checkBox51, checkBox52, checkBox53,
                checkBox54, checkBox55, checkBox56, checkBox57, checkBox58, checkBox59, checkBox60,
                checkBox61, checkBox62, checkBox63 };

            for(int i = 0; i < checkBoxes.Length; i++)
            {
                if(checkBoxes[i].CheckState == CheckState.Checked)
                {
                    price++;
                }
            }

            lblTotalAmount.Text = price + " TL";
        }

        private void chbConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if(chbConfirm.CheckState == CheckState.Checked)
            {
                btnPay.Enabled = true;
            }
            else
            {
                btnPay.Enabled = false;
            }
        }

         
        private void fillTheField()
        {
            Label[] datesB = new Label[]{ label1, label2, label3, label4, label5, label6, label7, label8,
                label9, label10, label11, label12, label13, label14, label15, label16, label17, label18,
                label19, label20, label21 };
            Label[] datesL = new Label[]{ label43, label42, label41, label40, label39, label38, label25,
                label37, label36, label35, label34, label33, label32, label24, label31, label30, label29,
                label28, label27, label26, label23 };
            Label[] datesD = new Label[]{ label65, label64, label63, label62, label61, label60, label47,
                label59, label58, label57, label56, label55, label54, label46, label53, label52, label51,
                label50, label49, label48, label45 };

            DateTime pzts = DateTime.Now;
            string varDate = DateTime.Now.ToString("dddd");
            switch (varDate)
            {
                case "Monday":
                case "Pazartesi":
                    pzts = DateTime.Now.AddDays(0);
                    break;
                case "Tuesday":
                case "Salı":
                    pzts = DateTime.Now.AddDays(-1);
                    break;
                case "Wednesday":
                case "Çarşamba":
                    pzts = DateTime.Now.AddDays(-2);
                    break;
                case "Thursday":
                case "Perşembe":
                    pzts = DateTime.Now.AddDays(-3);
                    break;
                case "Friday":
                case "Cuma":
                    pzts = DateTime.Now.AddDays(-4);
                    break;
                case "Saturday":
                case "Cumartesi":
                    pzts = DateTime.Now.AddDays(-5);
                    break;
                case "Sunday":
                case "Pazar":
                    pzts = DateTime.Now.AddDays(-6);
                    break;
                default:
                    MessageBox.Show("Unexpected error!");
                    break;
            }

            for (int i = 0; i < 21; i++)
            {
                datesB[i].Text = pzts.AddDays(i).ToString("dd-MM-yyyy dddd");
            }

            for (int i = 0; i < 21; i++)
            {
                datesL[i].Text = pzts.AddDays(i).ToString("dd-MM-yyyy dddd");
            }

            for (int i = 0; i < 21; i++)
            {
                datesD[i].Text = pzts.AddDays(i).ToString("dd-MM-yyyy dddd");
            }
            /*
            SqlDataAdapter countAdapter = new SqlDataAdapter("SELECT COUNT(DISTINCT dmDate) FROM Assign", conn);
            DataTable countDT = new DataTable();
            countAdapter.Fill(countDT);
            string c = countDT.Rows[0][0].ToString();
            int count = Convert.ToInt32(c);

            SqlDataAdapter mealAdapter = new SqlDataAdapter("SELECT dmDate, dmType, mCode FROM Assign WHERE dmDate > GETDATE()-1 ORDER BY dmDate, dmType;", conn);
            DataTable dtMeal = new DataTable();
            mealAdapter.Fill(dtMeal);
            
            for (int i = 0; i <= 14 * (count - 1); i += 14)
            {
                DateTime dm_Date = DateTime.Parse(dtMeal.Rows[i][0].ToString());


                for (int k = 0; k < 6; k++)
                {
                    dtMeal.Rows[i + k][2].ToString();
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


                for (int k = 6; k < 10; k++)
                {
                    dtMeal.Rows[i + k][2].ToString();
                }
                
                SqlDataAdapter reservedAdapterL = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='lunch' AND paid=0", conn);
                DataTable dtReservedL = new DataTable();
                reservedAdapterL.Fill(dtReservedL);

                liv.SubItems.Add(dtReservedL.Rows[0][0].ToString());

                SqlDataAdapter paidAdapterL = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='lunch' AND paid=1", conn);
                DataTable dtPaidL = new DataTable();
                paidAdapterL.Fill(dtPaidL);

                liv.SubItems.Add(dtPaidL.Rows[0][0].ToString());


                for (int k = 10; k < 14; k++)
                {
                    dtMeal.Rows[i + k][2].ToString();
                }
                
                SqlDataAdapter reservedAdapterD = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='dinner' AND paid=0", conn);
                DataTable dtReservedD = new DataTable();
                reservedAdapterD.Fill(dtReservedD);

                liv.SubItems.Add(dtReservedD.Rows[0][0].ToString());

                SqlDataAdapter paidAdapterD = new SqlDataAdapter("SELECT COUNT(paid) FROM Selection WHERE dmDate='" + modifiedDate + "' AND dmType='dinner' AND paid=1", conn);
                DataTable dtPaidD = new DataTable();
                paidAdapterD.Fill(dtPaidD);
            
                liv.SubItems.Add(dtPaidD.Rows[0][0].ToString());

            }*/
        }

        private void cbLocationB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox[] locationsD = new ComboBox[] { comboBox43, comboBox44, comboBox45, comboBox46,
                comboBox47, comboBox48, comboBox49, comboBox50, comboBox51, comboBox52, comboBox53,
                comboBox54, comboBox55, comboBox56, comboBox57, comboBox58, comboBox59, comboBox60,
                comboBox61, comboBox62, comboBox63 };

            ComboBox[] locationsL = new ComboBox[] { comboBox22, comboBox23, comboBox24, comboBox25,
                comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32,
                comboBox33, comboBox34, comboBox35, comboBox36, comboBox37, comboBox38, comboBox39,
                comboBox40, comboBox41, comboBox42 };

            ComboBox[] locationsB = new ComboBox[] { comboBox1, comboBox2, comboBox3, comboBox4,
                comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11,
                comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18,
                comboBox19, comboBox20, comboBox21 };
            for (int i = 0; i < locationsB.Length; i++)
            {
                locationsB[i].SelectedIndex = cbLocationB.SelectedIndex;
                locationsL[i].SelectedIndex = cbLocationB.SelectedIndex;
                locationsD[i].SelectedIndex = cbLocationB.SelectedIndex;
            }
        }

        private void cbLocationL_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox[] locationsL = new ComboBox[] { comboBox22, comboBox23, comboBox24, comboBox25,
                comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32,
                comboBox33, comboBox34, comboBox35, comboBox36, comboBox37, comboBox38, comboBox39,
                comboBox40, comboBox41, comboBox42 };
            for (int i = 0; i < locationsL.Length; i++)
            {
                locationsL[i].SelectedIndex = cbLocationL.SelectedIndex;
            }
        }

        private void cbLocationD_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox[] locationsD = new ComboBox[] { comboBox43, comboBox44, comboBox45, comboBox46,
                comboBox47, comboBox48, comboBox49, comboBox50, comboBox51, comboBox52, comboBox53,
                comboBox54, comboBox55, comboBox56, comboBox57, comboBox58, comboBox59, comboBox60,
                comboBox61, comboBox62, comboBox63 };
            for (int i = 0; i < locationsD.Length; i++)
            {
                locationsD[i].SelectedIndex = cbLocationD.SelectedIndex;
            }
        }
    }
}
