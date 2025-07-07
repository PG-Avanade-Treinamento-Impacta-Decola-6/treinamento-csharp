using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

public class CheckingAccount : Account
{
    public CheckingAccount(string idNumber, string ownerName, decimal startingBalance = 1500)
        : base(idNumber, ownerName, startingBalance)
    {
    }


}