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
    public partial class SearchCat : Form
    {
        public SearchCat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TransmobilDBContext ctx = new())
            {
                dataGridView1.DataSource = (from car in ctx.Cars
                                           join cat in ctx.Categories
                                           on car.IdCategory equals cat.IdCategory
                                           where cat.Name == comboBox1.SelectedItem.ToString()
                                           select new {
                                               Car = car.Brand + " " + car.Model,
                                               car.LicensePlate,
                                               car.CostPerKm,
                                               cat.Name,
                                               cat.RentPerDay
                                           }).ToList();
            }
        }

        private void SearchCat_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }
        void LoadOptions()
        {
            using (TransmobilDBContext ctx = new())
            {
                comboBox1.DataSource = ctx.Categories.Select(c => c.Name).ToList();
            }
        }
    }
}
