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
    public partial class RemoveCategory : Form
    {
        int _id;
        public RemoveCategory()
        {
            InitializeComponent();
        }
        public RemoveCategory(int id) : this()
        {
            _id = id;
            using (TransmobilDBContext ctx = new())
            {
                Category category = ctx.Categories.Find(_id);
                textBox1.Text = category.Name;
                textBox2.Text = category.RentPerDay + "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TransmobilDBContext ctx = new())
            {
                Category category = ctx.Categories.Find(_id);
                ctx.Remove(category);
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully removed the category with id:{_id}!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
