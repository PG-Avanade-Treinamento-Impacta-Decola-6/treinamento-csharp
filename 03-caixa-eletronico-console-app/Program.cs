using _03_caixa_eletronico_console_app;
using _03_caixa_eletronico_console_app.Business;

AccountService accountService = new AccountService();

ProgramData.messages.AddRange([
    "Bem vindo ao MINI Caixa Eletrônico, usuário!",
    $"Seu saldo inicial é de { accountService.GetAccountBalance().ToString("F2") }R$."
]);

while (!ProgramData.menuCtFlagExit) {
    Console.Clear();
    Console.WriteLine("MINI Caixa - Console");

    foreach (string message in ProgramData.messages) {
        Console.WriteLine($"\t- {message}");
    }
    ProgramData.messages.Clear();

    Console.WriteLine("\n1 - Consultar Saldo");
    Console.WriteLine("2 - Realizar Depósito");
    Console.WriteLine("3 - Realizar Saque");
    Console.WriteLine("4 - Sair");
    Console.Write("\n> ");

    string userOptionInput = Console.ReadLine()!;

    switch (userOptionInput) {
        case "1":
            ProgramData.messages.Add($"Seu saldo é de {accountService.GetAccountBalance().ToString("F2")}R$.");
            break;
        case "2": break;
        case "3": break;
        case "4":
            ProgramData.menuCtFlagExit = true;
            break;
        default:
            ProgramData.messages.Add("Opção inválida.");
            break;
    }
}