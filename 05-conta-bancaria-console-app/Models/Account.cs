using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

public abstract class Account
{
    protected decimal _balance { get; set; }
    public string IdNumber { get; protected set; }
    public string OwnerName { get; protected set; }

    public Account(string idNumber, string ownerName, decimal startingBalance = 1500)
    {
        IdNumber = idNumber;
        OwnerName = ownerName;
        _balance = startingBalance;
    }

    public void MakeDeposit(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException($"Valor inválido para depósito.");
        }

        _balance += value;
        Console.WriteLine("Depósito realizado com sucesso.");
    }

    public void MakeWithdrawal(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException($"Valor inválido para depósito.");
        }

        if (value > _balance)
        {
            throw new ArgumentException($"Saldo insuficiente.");
        }

        _balance -= value;
        Console.WriteLine("Saque realizado com sucesso.");
    }

    public void DisplayBalance() => Console.WriteLine($"O saldo da conta é de {_balance:F2} R$.");
}
