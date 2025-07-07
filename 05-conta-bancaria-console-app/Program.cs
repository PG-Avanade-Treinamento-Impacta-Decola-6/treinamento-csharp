using _05_conta_bancaria_console_app.Models;

SavingsAccount savings = new ("0101", "Sayvin", .5m);
CheckingAccount checking = new ("0201", "Checky");

Console.WriteLine("\nBem vindo ao banco MINI!");

Console.WriteLine("\nMovimentações com conta conta corrente (CheckingAccount):");
checking.DisplayBalance();
checking.MakeDeposit(500);
checking.DisplayBalance();

Console.WriteLine("\nMovimentações com conta poupança (SavingsAccount):");
savings.DisplayBalance();
savings.MakeDeposit(500);
savings.DisplayBalance();
savings.ApplyInterest();