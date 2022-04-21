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
    public partial class Renters : Form
    {
        public Renters()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData() 
        {
            using (TransmobilDBContext ctx = new())
            {
                dataGridView1.DataSource = ctx.Renters.Select(x => new {
                    IdRenter = x.IdRenter,
                    RenterName = x.RenterName,
                    RenterAddress = x.RenterAddress,
                    IsCompany = x.IsCompany,
                    Phone = x.Phone
                }).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRenter renter = new();
            this.Hide();
            renter.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EditRenter renter = new(id);
            this.Hide();
            renter.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RemoveRenter renter = new(id);
            this.Hide();
            renter.ShowDialog();
            this.Show();
            LoadData();
        }
    }
}
