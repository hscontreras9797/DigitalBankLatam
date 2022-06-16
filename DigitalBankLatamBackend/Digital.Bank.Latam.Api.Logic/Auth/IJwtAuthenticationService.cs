using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.Logic.Auth
{
    public interface  IJwtAuthenticationService
    {
        string Authenticate(string username, string password);
    }
}
