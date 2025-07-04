using _04_caixa_eletronico_console_app_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_caixa_eletronico_console_app_mvc.Data;

public class AccountsRepository
{
    private readonly List<Account> _accounts = new();

    public Account CreateAccount(string ownerName)
    {
        Account newAccount = new(_accounts.Count, ownerName);
        _accounts.Add(newAccount);
        return newAccount;
    }

    public IEnumerable<Account> FindAll() => _accounts;

    public Account? FindByAccountNumber(int accountNumber) => _accounts.Find(x => x.IdNumber == accountNumber);

    public Account? FindByOwnerName(string ownerName) => _accounts.Find(x => x.OwnerName == ownerName);

    public void DeleteByAccountNumber(int accountNumber) => _accounts.Remove(_accounts.Find(x => x.IdNumber == accountNumber)!);
}
