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
    public partial class KilometersDate : Form
    {
        public KilometersDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            using (TransmobilDBContext ctx = new())
            {
               var JoinedTable =      (from car in ctx.Cars
                                        join contract in (from contract1 in ctx.Contracts where contract1.ReturnDate <= date select contract1)
                                        on car.IdCar equals contract.IdCar
                                        into Joined
                                        from entry in Joined.DefaultIfEmpty()
                                        select new { car, entry}
                                      );
                dataGridView1.DataSource = (from entry in JoinedTable
                                           group entry by entry.car.Brand + " " + entry.car.Model into newGroup1
                                           select new {
                                               Name = newGroup1.Key,
                                               Kilometers = newGroup1.Sum(x => x.entry.ReturnMileage - x.entry.RentMileage)
                                           }).ToList();
            }
        }
    }
}
