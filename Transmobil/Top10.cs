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
    public partial class Top10 : Form
    {
        public Top10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(TransmobilDBContext ctx = new()) {
                var JoinedTable = from contract in ctx.Contracts
                                  join car in ctx.Cars on contract.IdCar equals car.IdCar
                                  join renter in ctx.Renters on contract.IdRenter equals renter.IdRenter
                                  join category in ctx.Categories on car.IdCategory equals category.IdCategory
                                  into results
                                  from result in results
                                  select new DataModel
                                  {
                                      _contract = contract,
                                      _car = car,
                                      _renter = renter,
                                      _result = result
                                  };
                dataGridView1.DataSource = (from entry in JoinedTable
                                            orderby entry._contract.RentDate descending, entry._contract.ReturnDate descending, entry._contract.IdContract descending
                                            select new {
                                                entry._contract.IdContract,
                                                entry._renter.RenterName,
                                                Car = entry._car.Brand + entry._car.Model,
                                                entry._car.LicensePlate,
                                                entry._contract.RentDate,
                                                entry._contract.ReturnDate
                                            }).Take(10).ToList();
            }
        }
    }
}
