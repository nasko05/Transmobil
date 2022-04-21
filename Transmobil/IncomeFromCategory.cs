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
    public partial class IncomeFromCategory : Form
    {
        public IncomeFromCategory()
        {
            InitializeComponent();
        }
        void LoadOptions()
        {
            using(TransmobilDBContext ctx = new())
            {
                comboBox1.DataSource = ctx.Categories.Select(x => x.Name).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String categoryName = comboBox1.SelectedItem.ToString();
            using (TransmobilDBContext ctx = new())
            {
                Func<DataModel, double> sum = delegate (DataModel x) {
                    double result;
                    if ((bool)x._renter.IsCompany)
                    {
                        result = (x._contract.ReturnDate - x._contract.RentDate).TotalDays * x._result.RentPerDay + (x._contract.ReturnMileage - x._contract.RentMileage) * decimal.ToDouble(x._car.CostPerKm) + x._contract.MoneyInAdvance;
                    }
                    else
                    {
                        result = (x._contract.ReturnDate - x._contract.RentDate).TotalDays * x._result.RentPerDay + (x._contract.ReturnMileage - x._contract.RentMileage) * decimal.ToDouble(x._car.CostPerKm) * 0.9 + x._contract.MoneyInAdvance;
                    }
                    return result;
                };
                var JoinedTable = from contract in ctx.Contracts
                                  join car in ctx.Cars on contract.IdCar equals car.IdCar
                                  join renter in ctx.Renters on contract.IdRenter equals renter.IdRenter
                                  join category in (from cat in ctx.Categories where cat.Name == categoryName select cat) on car.IdCategory equals category.IdCategory
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
                                            group s by s._result.Name into Group1
                                            select new
                                            {
                                                Car = Group1.Key,
                                                Income = Group1.Sum(x => sum(x))
                                            }).ToList();
            }
        }

        private void IncomeFromCategory_Load(object sender, EventArgs e)
        {
            LoadOptions();
        }
    }
}
