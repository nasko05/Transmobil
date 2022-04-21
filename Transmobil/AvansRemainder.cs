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
    public partial class AvansRemainder : Form
    {
        public AvansRemainder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                using (TransmobilDBContext ctx = new())
                {
                    Func<DataModel, double> sum = delegate (DataModel x) {
                        double result;
                        if ((bool)x._renter.IsCompany)
                        {
                            result = ((x._contract.ReturnDate - x._contract.RentDate).TotalDays + 1) * x._result.RentPerDay + (x._contract.ReturnMileage - x._contract.RentMileage) * decimal.ToDouble(x._car.CostPerKm) + x._contract.MoneyInAdvance;
                        }
                        else
                        {
                            result = ((x._contract.ReturnDate - x._contract.RentDate).TotalDays + 1) * x._result.RentPerDay + (x._contract.ReturnMileage - x._contract.RentMileage) * decimal.ToDouble(x._car.CostPerKm) * 0.9 + x._contract.MoneyInAdvance;
                        }
                        return result;
                    };
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
                    dataGridView1.DataSource = (from s in JoinedTable.ToList()
                                                select new
                                                {
                                                    ContractID = s._contract.IdContract,
                                                    Avans = s._contract.MoneyInAdvance,
                                                    Remainder = sum(s) - s._contract.MoneyInAdvance
                                                }).ToList();
                }
        }
    }
}
