using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Interfaces.Services
{
    public interface IUserService
    {
        Customer Get(int Id);
        Customer Create(Customer customer);
    }
}
