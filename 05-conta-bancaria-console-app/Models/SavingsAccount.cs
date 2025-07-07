using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

public class SavingsAccount : Account
{
    public decimal InterestRate { get; set; }

    public SavingsAccount(string idNumber, string ownerName, decimal interestRate, decimal startingBalance = 1500)
        : base(idNumber, ownerName, startingBalance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = _balance * InterestRate / 100;
        _balance += interest;
        Console.WriteLine($"Taxa de juros aplicada. Novo saldo: {_balance:F2} R$.");
    }
}
