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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(TransmobilDBContext ctx = new())
            { 
                Car car = new();
                car.LicensePlate = textBox1.Text;
                car.Brand = textBox2.Text;
                car.Model = textBox3.Text;
                car.CostPerKm = decimal.Parse(textBox4.Text);
                car.IdCategory = int.Parse(textBox5.Text);
                ctx.Add(car);
                ctx.SaveChanges();
            }
            MessageBox.Show("Successfully added a car!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
