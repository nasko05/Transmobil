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

namespace Forms
{
    public partial class AddContract : Form
    {
        public AddContract()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using  (TransmobilDBContext ctx = new())
            {
                Contract contract = new();
                contract.IdRenter = int.Parse(comboBox1.SelectedItem.ToString());
                contract.IdCar = int.Parse(comboBox2.SelectedItem.ToString());
                contract.RentDate = dateTimePicker1.Value;
                contract.ReturnDate = dateTimePicker2.Value;
                contract.RentMileage = int.Parse(textBox5.Text);
                contract.ReturnMileage = int.Parse(textBox6.Text);
                contract.MoneyInAdvance = int.Parse(textBox7.Text);
                ctx.Add(contract);
                ctx.SaveChanges();
            }
            MessageBox.Show("Successfully added a contract!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddContract_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }
        void LoadOptions()
        {
            using (TransmobilDBContext ctx = new())
            {
                comboBox1.DataSource = ctx.Renters.Select(x => x.RenterName).ToList();
                comboBox2.DataSource = ctx.Cars.Select(x => x.Brand + " " + x.Model).ToList();
            }
        }
    }
}
