using _04_caixa_eletronico_console_app_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_caixa_eletronico_console_app_mvc.Views;

public class AccountsView
{
    private static readonly List<string> _messages = new() {
        "Bem vindo ao MINI Caixa Eletrônico, usuário!",
        //$"Seu saldo inicial é de { accountService.GetAccountBalance().ToString("F2") }R$."
    };

    public static void EnqueueMessage(string message)
    {
        _messages.Add(message);
    }

    public void DisplayEnqueuedMessages() {
        foreach (string message in _messages)
        {
            Console.WriteLine($"\t- {message}");
        }

        _messages.Clear();
    }

    public string PromptUnauthenticatedMenu()
    {
        Console.WriteLine("\n1 - Acessar Conta");
        Console.WriteLine("2 - Criar Conta");
        Console.WriteLine("3 - Listar contas");
        Console.WriteLine("4 - Sair");

        return Console.ReadLine()!;
    }

    public string PromptAuthenticatedMenu(decimal balance)
    {
        Console.WriteLine("\n1 - Consultar Saldo");
        Console.WriteLine("2 - Realizar Depósito");
        Console.WriteLine("3 - Realizar Saque");
        Console.WriteLine("4 - Sair da Conta");
        Console.Write("\n> ");
        
        return Console.ReadLine()!;
    }

    public decimal PromptDecimal(string? message = null)
    {
        decimal parsedValue;

        while (true) {
            Console.Clear();
            if (message != null) Console.WriteLine($"\n{message}");
            
            DisplayEnqueuedMessages();
            Console.Write("\n> ");

            if (!decimal.TryParse(Console.ReadLine(), out parsedValue))
            {
                EnqueueMessage("Valor digitado é inválido. Por favor, tente novamente.");
                continue;
            }

            break;
        }

        return parsedValue;
    }

    public int PromptInt(string message)
    {
        int parsedValue;

        while (true)
        {
            Console.Clear();
            if (message != null) Console.WriteLine($"\n{message}");

            DisplayEnqueuedMessages();
            Console.Write("\n> ");

            if (!int.TryParse(Console.ReadLine(), out parsedValue))
            {
                EnqueueMessage("Valor digitado é inválido. Por favor, tente novamente.");
                continue;
            }

            break;
        }

        return parsedValue;
    }

    public string PromptString(string message)
    {
        Console.Clear();
        if (message != null) Console.WriteLine($"\n{message}");

        DisplayEnqueuedMessages();
        Console.Write("\n> ");
        return Console.ReadLine()!;
    }
}
