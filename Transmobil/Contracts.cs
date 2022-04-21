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
    public partial class Contracts : Form
    {
        public Contracts()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddContract contract = new();
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EditContract contract = new(id);
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RemoveContract contract = new(id);
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }
        void LoadData()
        {
            using (TransmobilDBContext ctx = new())
            {
                dataGridView1.DataSource = ctx.Contracts.Select(x => new {
                    IdContract = x.IdContract,
                    IdRenter = x.IdRenter,
                    IdCar = x.IdCar,
                    RentDate = x.RentDate,
                    ReturnDate = x.ReturnDate,
                    RentMileage = x.RentMileage,
                    ReturnMileage = x.ReturnMileage,
                    MoneyInAdvance = x.MoneyInAdvance
                }).ToList();
            }
        }
    }
}
