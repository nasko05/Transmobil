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
    public partial class EditCategory : Form
    {
        int _id;
        public EditCategory()
        {
            InitializeComponent();
        }
        public EditCategory(int id) : this()
        {
            _id = id;
            using (TransmobilDBContext ctx = new())
            {
                Category category = ctx.Categories.Find(_id);
                textBox1.Text = category.Name;
                textBox2.Text = category.RentPerDay + "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TransmobilDBContext ctx = new())
            {
                Category category = ctx.Categories.Find(_id);
                category.Name = textBox1.Text;
                category.RentPerDay = int.Parse(textBox2.Text);
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully edited the category with id:{_id}!");
            this.Close();
        }
    }
}
