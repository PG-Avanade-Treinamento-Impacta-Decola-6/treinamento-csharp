using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_caixa_eletronico_console_app.Data;

public class AccountRepository
{
    private readonly Account _account = new Account(0);
    private readonly List<Account> _accounts = new List<Account>();

    public Account GetAccount()
    {
        return _account;
    }
}
