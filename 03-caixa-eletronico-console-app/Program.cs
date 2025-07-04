
using System.Threading.Tasks.Dataflow;

decimal accountBalance = 1500.0m;

bool menuCtFlagExit = false;
List<string> messages = new List<string>() {
    "Bem vindo ao MINI Caixa Eletrônico, usuário!",
    $"Saldo inicial: { accountBalance.ToString("C") }R$"
}; 

while (!menuCtFlagExit) {
    Console.Clear();
    Console.WriteLine("MINI Caixa - Console");

    foreach (string message in messages) {
        Console.WriteLine($"\t- {message}");
    }
    messages.Clear();

    Console.WriteLine("\n1 - Consultar Saldo");
    Console.WriteLine("2 - Realizar Depósito");
    Console.WriteLine("3 - Realizar Saque");
    Console.WriteLine("4 - Sair");

    Console.Write("\n> ");

    string userOptionInput = Console.ReadLine();

    switch (userOptionInput) {
        case "1": break;
        case "2": break;
        case "3": break;
        case "4":
            menuCtFlagExit = true;
            break;
        default:
            messages.Add("Opção inválida.");
            break;
    }
}
