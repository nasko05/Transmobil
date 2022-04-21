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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCar cars = new();
            this.Hide();
            cars.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EditCar cars = new(id);
            this.Hide();
            cars.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RemoveCar cars = new(id);
            this.Hide();
            cars.ShowDialog();
            this.Show();
            LoadData();
        }
        void LoadData()
        {
            using(TransmobilDBContext ctx = new TransmobilDBContext())
            {
                dataGridView1.DataSource = ctx.Cars.Select(x => new {
                    IdCar = x.IdCar,
                    LicensePlate = x.LicensePlate,
                    Brand = x.Brand,
                    Model = x.Model,
                    CostPerKm = x.CostPerKm,
                    IdCategory = x.IdCategory
                }).ToList();
            }
        }
        private void Cars_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
