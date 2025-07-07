using _05_conta_bancaria_console_app.Models;

var _checkingAccount = new CheckingAccount("0201", "Checky");

List<Account> accounts = new() {
    new SavingsAccount("0101", "Sayvin", .5m),
    _checkingAccount
};

List<ITaxable> taxables = new() {
    new LifeInsurance(),
    _checkingAccount
};

Console.WriteLine("\nBem vindo ao banco MINI!");

foreach (ITaxable taxable in taxables)
{
    Console.WriteLine($"\n{taxable.GetType()}");
    Console.WriteLine($"Imposto a ser cobrado é {taxable.CalculateTax():F2} R$.");
}