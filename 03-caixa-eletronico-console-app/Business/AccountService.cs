using _03_caixa_eletronico_console_app.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_caixa_eletronico_console_app.Business;

public class AccountService
{
    private readonly AccountRepository AccountRepository;

    public AccountService()
    {
        AccountRepository = new AccountRepository();
    }

    public decimal GetAccountBalance()
    {
        Account account = AccountRepository.GetAccount();
        return account.Balance;
    }
}