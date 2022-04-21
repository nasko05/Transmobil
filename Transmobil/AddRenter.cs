using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transmobil.Models;

namespace Transmobil
{
    public partial class AddRenter : Form
    {
        public AddRenter()
        {
            InitializeComponent();
        }

        private void AddRenter_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TransmobilDBContext ctx = new())
            {
                Renter renter = new();
                renter.RenterName = textBox1.Text;
                renter.RenterAddress = textBox2.Text;
                renter.IsCompany = bool.Parse(textBox3.Text);
                renter.Phone = textBox4.Text;
                ctx.Add(renter);
                ctx.SaveChanges();
            }
            MessageBox.Show("Successfully added a renter!");
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
