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
    public partial class Menu : Form
    {
        OleDbConnection con;
        public Menu()
        {
            InitializeComponent();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (frmLogin.loginuser != null) {

                label1.Text = frmLogin.loginuser;
            }
        }

        private void BorrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Borrow br1 = new Borrow();
            br1.ShowDialog();
        }

        private void BorrowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Borrower br = new Borrower();
            br.ShowDialog();

        }

        private void BooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books book = new Books();
            book.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReturn re = new frmReturn();
            re.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

    }
}
