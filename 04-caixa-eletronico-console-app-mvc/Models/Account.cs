namespace _04_caixa_eletronico_console_app_mvc.Models;

using _04_caixa_eletronico_console_app_mvc.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    public decimal Balance { get; private set; }

    public Account(decimal startingBalance = 1500m)
    {
        Balance = startingBalance;
    }

    public void MakeDeposit(decimal value)
    {
        if (value <= 0)
        {
            AccountsView.EnqueueMessage("Valor inválido para depósito.");
            return;
        }

        Balance += value;
        AccountsView.EnqueueMessage("Depósito realizado com sucesso.");
    }

    public void MakeWithdrawal(decimal value)
    {
        if (Balance < value)
        {
            AccountsView.EnqueueMessage("Saldo insuficiente.");
            return;
        }

        if (value <= 0)
        {
            AccountsView.EnqueueMessage("Valor inválido para saque.");
            return;
        }

        Balance -= value;
        AccountsView.EnqueueMessage("Saque realizado com sucesso.");
    }
}
