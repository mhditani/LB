using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface ITokenRepo
    {
       string CreateJwToken(IdentityUser user, List<string> roles);
    }
}
