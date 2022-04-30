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
    public partial class EditContract : Form
    {
        int _id;
        public EditContract()
        {
            InitializeComponent();
        }
        public EditContract(int id) : this()
        {
            _id = id;
            using (TransmobilDBContext ctx = new())
            {
                Contract contract = ctx.Contracts.Find(_id);
                comboBox1.DataSource = ctx.Renters.Select(x => x.RenterName).ToList();
                comboBox2.DataSource = ctx.Cars.Select(x => x.Brand + " " + x.Model).ToList();
                comboBox1.SelectedItem = ctx.Renters.Where(x => x.IdRenter == contract.IdRenter).Select(x => x.RenterName).FirstOrDefault();
                comboBox2.SelectedItem = ctx.Cars.Select(x => x.Brand + " " + x.Model).FirstOrDefault();
                dateTimePicker1.Value = contract.RentDate;
                dateTimePicker2.Value = contract.ReturnDate;
                textBox5.Text = contract.RentMileage + "";
                textBox6.Text = contract.ReturnMileage + "";
                textBox7.Text = contract.MoneyInAdvance + "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (TransmobilDBContext ctx = new())
            {
                Contract contract = ctx.Contracts.Find(_id);
                contract.IdRenter = int.Parse(comboBox1.SelectedItem.ToString());
                contract.IdCar = int.Parse(comboBox2.SelectedItem.ToString());
                contract.RentDate = dateTimePicker1.Value;
                contract.ReturnDate = dateTimePicker2.Value;
                contract.RentMileage = int.Parse(textBox5.Text);
                contract.ReturnMileage = int.Parse(textBox6.Text);
                contract.MoneyInAdvance = int.Parse(textBox7.Text);
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully edited the contract with id:{_id}!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
