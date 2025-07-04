namespace _03_caixa_eletronico_console_app.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    public int IdNumber { get; private set; }
    public decimal Balance { get; private set; }

    public Account(int idNumber, decimal startingBalance = 1500m)
    {
        IdNumber = idNumber;
        Balance = startingBalance;
    }

    public void MakeDeposit(decimal value) {
        if (value <= 0)
        {
            ProgramData.messages.Add("Valor inválido para depósito.");
            return;
        }

        Balance += value;
    }

    public void MakeWithdrawal(decimal value) {
        if (Balance < value)
        {
            ProgramData.messages.Add("Saldo insuficiente.");
            return;
        }
        
        if (value <= 0)
        {
            ProgramData.messages.Add("Valor inválido para saque.");
            return;
        }

        Balance -= value;
    }
}
