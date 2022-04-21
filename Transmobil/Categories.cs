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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCategory contract = new();
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            EditCategory contract = new(id);
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RemoveCategory contract = new(id);
            this.Hide();
            contract.ShowDialog();
            this.Show();
            LoadData();
        }
        void LoadData()
        {
            using  (TransmobilDBContext ctx = new())
            {
                dataGridView1.DataSource = ctx.Categories.Select(x => new {
                    IdCategory = x.IdCategory,
                    Name = x.Name,
                    RentPerDay = x.RentPerDay
                }).ToList();
            }
        }
    }
}
