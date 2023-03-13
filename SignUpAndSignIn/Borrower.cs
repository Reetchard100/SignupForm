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

namespace SignUpAndSignIn
{
    public partial class Borrower : Form

    {
        OleDbConnection con;
        public Borrower()
        {
            InitializeComponent();
            loadDatagrid();

        }

        private void loadDatagrid()
        {
            con.Open();
            OleDbCommand com = new OleDbCommand("Select * from book order by accession_number asc", con);
            com.ExecuteNonQuery();

            OleDbDataAdapter adap = new OleDbDataAdapter(com);
            DataTable tab = new DataTable();

            adap.Fill(tab);
            grid1.DataSource = tab;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void Borrower_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'signUpAndSignInDataSet2.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.signUpAndSignInDataSet2.users);
            // TODO: This line of code loads data into the 'signUpAndSignInDataSet1.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.signUpAndSignInDataSet1.users);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
                con.Open();
                OleDbCommand com = new OleDbCommand("Insert into book values ('" + txtno.Text + "', '" + txttitle.Text + "', '"
                                                    + txtauthor.Text + "')", con);
                com.ExecuteNonQuery();
                MessageBox.Show("Succesfully SAVED!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                loadDatagrid();


        }
    }
}
