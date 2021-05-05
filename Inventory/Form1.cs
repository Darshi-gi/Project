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

namespace User_Registation
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DARSHI;Initial Catalog=UserRegistationDB;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Please Fill sanatory field");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Pasword do not match");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlCon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@FirstName", txtFirst.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@LastName", txtLast.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Contact", txtContact.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Registation is Successful");
                    Clear();

                }
            }

        }
        void Clear()
        {
            txtFirst.Text = txtLast.Text = txtContact = txtAddress = txtUsername = txtPassword = txtConfirmPassword.Text ="" ;
        }
    }
}
