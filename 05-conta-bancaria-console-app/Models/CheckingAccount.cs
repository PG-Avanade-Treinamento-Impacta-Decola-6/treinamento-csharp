using _05_conta_bancaria_console_app.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

public class CheckingAccount : Account, ITaxable
{
    private decimal _limit;

    public CheckingAccount(string idNumber, string ownerName, decimal startingBalance = 1500, decimal startingLimit = 500)
        : base(idNumber, ownerName, startingBalance)
    {
        _limit = startingLimit;
    }

    public decimal CalculateTax() => _balance * .02m;

    public override void MakeWithdrawal(decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Valor inválido para depósito. Deve ser maior que 0.");
        }

        if (value > _balance + _limit)
        {
            throw new InsufficientBalanceException();
        }

        _balance -= value;
        Console.WriteLine("Saque realizado com sucesso.");

        if (_balance < 0)
        {
            _limit += _balance;
            _balance = 0;
        }
    }
}