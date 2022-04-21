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
    public partial class SearchNaem : Form
    {
        public SearchNaem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int naem = int.Parse(textBox1.Text);
            using (TransmobilDBContext ctx = new())
            {
                dataGridView1.DataSource = (from car in ctx.Cars
                                            join cat in ctx.Categories
                                            on car.IdCategory equals cat.IdCategory
                                            where cat.RentPerDay == naem
                                            select new
                                            {
                                                Car = car.Brand + " " + car.Model,
                                                car.LicensePlate,
                                                car.CostPerKm,
                                                cat.Name,
                                                cat.RentPerDay
                                            }).ToList();
            }
        }
    }
}
