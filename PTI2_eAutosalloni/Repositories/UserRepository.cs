using PTI2_eAutosalloni.Data;
using PTI2_eAutosalloni.Interfaces.Repositories;
using PTI2_eAutosalloni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Customer Create(Customer customer)
        {
            if (customer != null)
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                return customer;
            }
            else
            {
                throw new ArgumentNullException("Customer cannot be null");
            }
        }

        public Customer Get(int Id)
        {
            Customer customer = context.Customers.Find(Id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}
