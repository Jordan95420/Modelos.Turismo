using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Turismo.Modelos;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<Turismo.Modelos.UserClient> UserClients { get; set; } = default!;

public DbSet<Turismo.Modelos.UserAdmin> UserAdmins { get; set; } = default!;

public DbSet<Turismo.Modelos.TouristTicket> TouristTickets { get; set; } = default!;

public DbSet<Turismo.Modelos.TouristRoute> TouristRoutes { get; set; } = default!;

public DbSet<Turismo.Modelos.SeatCategory> SeatCategories { get; set; } = default!;

public DbSet<Turismo.Modelos.PaymentTicket> PaymentTickets { get; set; } = default!;

public DbSet<Turismo.Modelos.Payment> Payments { get; set; } = default!;

public DbSet<Turismo.Modelos.CategoryTicket> CategoryTickets { get; set; } = default!;
    }
