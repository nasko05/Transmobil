using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transmobil
{
    public partial class Queries : Form
    {
        public Queries()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCat cat = new SearchCat();
            this.Hide();
            cat.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchNaem naem = new SearchNaem();
            this.Hide();
            naem.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KilometersDate date = new KilometersDate();
            this.Hide();
            date.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KilometersPeriod period = new KilometersPeriod();
            this.Hide();
            period.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IncomeFromLicensePlate income = new IncomeFromLicensePlate();
            this.Hide();
            income.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IncomeFromCategory category = new IncomeFromCategory();
            this.Hide();
            category.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IncomeFromClient client = new IncomeFromClient();
            this.Hide();
            client.ShowDialog();
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AvansRemainder avans = new AvansRemainder();
            this.Hide();
            avans.ShowDialog();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CountRent naemane = new CountRent();
            this.Hide();
            naemane.ShowDialog();
            this.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Top10 top10 = new Top10();
            this.Hide();
            top10.ShowDialog();
            this.Show();
        }
    }
}
