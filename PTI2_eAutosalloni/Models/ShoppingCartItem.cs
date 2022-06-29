using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTI2_eAutosalloni.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Vehicle Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
    }
}
