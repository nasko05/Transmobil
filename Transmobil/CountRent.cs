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
    public partial class CountRent : Form
    {
        public CountRent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            using (TransmobilDBContext ctx = new())
            {
                var JoinedTable = (from car in ctx.Cars
                                   join contract in (from contract1 in ctx.Contracts where contract1.ReturnDate <= date2 && contract1.RentDate >= date1 select contract1) on car.IdCar equals contract.IdCar
                                   into Joined
                                   from entry in Joined
                                   orderby entry.IdCar ascending
                                   select new { car, entry }
                                       );
                dataGridView1.DataSource = (from entry in JoinedTable.ToList()
                                            group entry by entry.car.Model into newGroup1
                                            select new
                                            {
                                                Name = newGroup1.Key,
                                                Times = newGroup1.Count()
                                            }).ToList();
            }
        }
    }
}
