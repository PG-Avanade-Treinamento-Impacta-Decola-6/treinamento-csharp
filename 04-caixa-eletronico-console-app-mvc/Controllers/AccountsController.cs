using _04_caixa_eletronico_console_app_mvc.Data;
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
    private readonly AccountsRepository _repository = new ();
    private readonly AccountsView _view = new ();

    public void Start()
    {
        bool menuCtFlagExit = false;
        Account? activeAccount = null;
        string? userOptionInput = null;

        while (!menuCtFlagExit)
        {
            Console.Clear();
            Console.WriteLine("\nMINI Caixa - Console");

            _view.DisplayEnqueuedMessages();

            if (activeAccount == null)
            {
                userOptionInput = _view.PromptUnauthenticatedMenu();
                switch (userOptionInput)
                {
                    case "1":
                        int accountNumber = _view.PromptInt("Digite o número da conta que deseja acessar.");
                        activeAccount = _repository.FindByAccountNumber(accountNumber);
                        if (activeAccount == null) AccountsView.EnqueueMessage("Conta não foi encontrada.");
                        else AccountsView.EnqueueMessage($"Acesso realizado com sucesso. Bem vindo, {activeAccount.OwnerName}!");
                            continue;
                    case "2":
                        string ownerName = _view.PromptString("Digite seu nome.");
                        Account newAccount = _repository.CreateAccount(ownerName);
                        AccountsView.EnqueueMessage($"Conta criada! O número da sua conta é {newAccount.IdNumber}.");
                        continue;
                    case "3":
                        string message = "As seguintes contas existem no sistema:";
                        foreach (string contaString in _repository.FindAll().Select(x => $"\n\t\t{x.IdNumber} - {x.OwnerName}"))
                        {
                            message += contaString;
                        }

                        AccountsView.EnqueueMessage(message);
                        continue;
                    case "4":
                        menuCtFlagExit = true;
                        continue;
                    default:
                        AccountsView.EnqueueMessage("Opção inválida.");
                        continue;
                }
            }

            userOptionInput = _view.PromptAuthenticatedMenu(activeAccount.Balance);
            switch (userOptionInput)
            {
                case "1":
                    AccountsView.EnqueueMessage($"Seu saldo é de {activeAccount.Balance:F2}R$.");
                    break;
                case "2":
                    decimal depositValue = _view.PromptDecimal("Que valor deseja depositar?");
                    activeAccount.MakeDeposit(depositValue);
                    break;
                case "3":
                    decimal withdrawalValue = _view.PromptDecimal("Que valor deseja sacar?");
                    activeAccount.MakeWithdrawal(withdrawalValue);
                    break;
                case "4":
                    activeAccount = null;
                    break;
                default:
                    AccountsView.EnqueueMessage("Opção inválida.");
                    break;
            }
        }
    }
}
