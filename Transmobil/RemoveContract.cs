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
    public partial class RemoveContract : Form
    {
        int _id;
        public RemoveContract()
        {
            InitializeComponent();
        }
        public RemoveContract(int id) : this()
        {
            _id = id;
            using  (TransmobilDBContext ctx = new())
            {
                Contract contract = ctx.Contracts.Find(_id);
                textBox1.Text = contract.IdRenter + "";
                textBox2.Text = contract.IdCar + "";
                textBox3.Text = contract.RentDate + "";
                textBox4.Text = contract.ReturnDate + "";
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
                ctx.Remove(contract);
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully removed the contract with id:{_id}!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
