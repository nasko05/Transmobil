﻿using System;
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
    public partial class EditCar : Form
    {
        int _id;
        public EditCar()
        {
            InitializeComponent();
        }
        public EditCar(int id) : this()
        {
            _id = id;
            using (TransmobilDBContext ctx = new())
            {
                Car car = ctx.Cars.Find(id);
                textBox1.Text = car.LicensePlate;
                textBox2.Text = car.Brand;
                textBox3.Text = car.Model;
                textBox4.Text = car.CostPerKm + "";
                comboBox1.DataSource = ctx.Categories.Select(x => x.Name).ToList();
                comboBox1.SelectedItem = ctx.Categories.Where(x => x.IdCategory == car.IdCategory).FirstOrDefault().Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (TransmobilDBContext ctx = new()) 
            {
                int CatID = ctx.Categories.Where(x => x.Name == comboBox1.SelectedItem.ToString()).FirstOrDefault().IdCategory;
                Car car = ctx.Cars.Find(_id);
                car.LicensePlate = textBox1.Text;
                car.Brand = textBox2.Text;
                car.Model = textBox3.Text;
                car.CostPerKm = decimal.Parse(textBox4.Text);
                car.IdCategory = CatID;
                ctx.SaveChanges();
            }
            MessageBox.Show($"Successfully edited the car with id:{_id}!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCar_Load(object sender, EventArgs e)
        {
        }
    }
}
