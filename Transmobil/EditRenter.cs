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
    public partial class EditRenter : Form
    {
        int _id;
        public EditRenter()
        {
            InitializeComponent();
        }
        public EditRenter(int id) : this()
        {
            _id = id;
            using (TransmobilDBContext ctx = new())
            {
                Renter renter = ctx.Renters.Find(_id);
                textBox1.Text = renter.RenterName;
                textBox2.Text = renter.RenterAddress;
                textBox3.Text = renter.IsCompany + "";
                textBox4.Text = renter.Phone;
            }
        }

        private void EditRenter_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (TransmobilDBContext ctx = new())
            {
                Renter renter = ctx.Renters.Find(_id);
                renter.RenterName = textBox1.Text;
                renter.RenterAddress = textBox2.Text;
                renter.IsCompany = bool.Parse(textBox3.Text);
                renter.Phone = textBox4.Text;
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully edited the renter with id:{_id}!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
