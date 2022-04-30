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
                try
                {
                    car.IdCategory = ctx.Categories.Where(x => x.Name == comboBox1.SelectedItem.ToString()).FirstOrDefault().IdCategory;
                }
                catch (Exception)
                {
                    MessageBox.Show("Невалидна категория");
                }
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

        private void AddCar_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }
        void LoadOptions()
        {
            using (TransmobilDBContext ctx = new())
            {
                comboBox1.DataSource = ctx.Categories.Select(x => x.Name).ToList();
            }
        }
    }
}
