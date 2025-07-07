using _05_conta_bancaria_console_app.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_conta_bancaria_console_app.Models;

public class SavingsAccount : Account
{
    private const decimal WITHDRAWAL_TAX = 2.5m;
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

    public override void MakeWithdrawal(decimal value)
    {
        decimal valueAfterTax = value + (_balance * (WITHDRAWAL_TAX / 100));

        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Valor inválido para depósito. Deve ser maior que 0.");
        }

        if (valueAfterTax > _balance)
        {
            throw new InsufficientBalanceException();
        }

        _balance -= valueAfterTax;
        Console.WriteLine("Saque realizado com sucesso.");
    }
}
