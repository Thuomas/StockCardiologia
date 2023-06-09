using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockCardiologia.Models;

namespace StockCardiologia.Data
{
    public class DepositoContext : DbContext
    {
        public DepositoContext (DbContextOptions<DepositoContext> options)
            : base(options)
        {
        }

        public DbSet<StockCardiologia.Models.Deposito> Deposito { get; set; } = default!;

        public DbSet<StockCardiologia.Models.Equipo> Equipo { get; set; } = default!;

        public DbSet<StockCardiologia.Models.ServicioTecnico> ServicioTecnico { get; set; } = default!;
    }
}
