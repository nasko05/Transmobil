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
    public partial class RemoveCar : Form
    {
        int _id;
        public RemoveCar()
        {
            InitializeComponent();
        }
        public RemoveCar(int id) : this()
        {
            _id = id;
            using(TransmobilDBContext ctx = new())
            {
                Car car = ctx.Cars.Find(id);
                textBox1.Text = car.LicensePlate;
                textBox2.Text = car.Brand;
                textBox3.Text = car.Model;
                textBox4.Text = car.CostPerKm + "";
               textBox5.Text = car.IdCategory + "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(TransmobilDBContext ctx = new())
            {
                Car car = ctx.Cars.Find(_id);
                ctx.Remove(car);
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully removed the car with id:{_id}!");
            this.Close();

        }
    }
}
