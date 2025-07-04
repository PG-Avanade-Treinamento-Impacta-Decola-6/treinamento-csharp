using _04_caixa_eletronico_console_app_mvc.Models;
using _04_caixa_eletronico_console_app_mvc.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_caixa_eletronico_console_app_mvc.Controllers;

public class AccountsController
{
    private readonly Account _model;
    private readonly AccountsView _view;

    public AccountsController()
    {
        _model = new (3000m);
        _view = new AccountsView();
    }

    public void Start()
    {
        bool menuCtFlagExit = false;

        while (!menuCtFlagExit)
        {
            Console.Clear();
            Console.WriteLine("\nMINI Caixa - Console");

            _view.DisplayEnqueuedMessages();

            string userOptionInput = _view.PromptAccountMenu(_model.Balance);

            switch (userOptionInput)
            {
                case "1":
                    AccountsView.EnqueueMessage($"Seu saldo é de {_model.Balance:F2}R$.");
                    break;
                case "2":
                    decimal depositValue = _view.PromptDecimal("Que valor deseja depositar?");
                    _model.MakeDeposit(depositValue);
                    break;
                case "3":
                    decimal withdrawalValue = _view.PromptDecimal("Que valor deseja sacar?");
                    _model.MakeWithdrawal(withdrawalValue);
                    break;
                case "4":
                    menuCtFlagExit = true;
                    break;
                default:
                    AccountsView.EnqueueMessage("Opção inválida.");
                    break;
            }
        }
    }
}
