using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;


namespace SignUpAndSignIn
{
    public partial class frmLogin : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public static string loginuser = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\NH-EXT\\Desktop\\SignUpAndSignIn\\SignUpAndSignIn\\SignUpAndSignIn.mdb");
            con.Open();
        }
        private void btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {

                cmd = new OleDbCommand("select * from users where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    loginuser = txtusername.Text;   
                    dr.Close();
                    this.Hide();
                    Menu home = new Menu();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string HashPassword(string password)
        {
            // Convert the password to a byte array
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Create a SHA-256 hash object
            SHA256 sha256 = SHA256.Create();

            // Compute the hash value for the password
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Convert the hash bytes to a hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            // Return the hashed password
            return sb.ToString();
        }

    }
}
