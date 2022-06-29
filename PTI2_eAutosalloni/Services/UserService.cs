using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Interfaces.Services;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Customer Create(Customer customer)
        {
            return userRepository.Create(customer);
        }
        public Customer Get(int Id)
        {
            return userRepository.Get(Id);
        }
    }
}
