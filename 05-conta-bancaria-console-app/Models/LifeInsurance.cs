using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

internal class LifeInsurance : ITaxable
{
    public decimal CalculateTax() => 50;
}
