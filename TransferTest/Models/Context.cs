using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TransferTest.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            
        }

        public System.Data.Entity.DbSet<TransferTest.Models.Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<TransferTest.Models.Conta> Contas { get; set; }
    }
}