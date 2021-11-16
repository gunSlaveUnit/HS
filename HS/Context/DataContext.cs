﻿using Hotel.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HS.Context
{
    public class DataContext : DbContext
    {
        private DbSet<Client> Clients { get; set; }
        private DbSet<Reservation> Reservations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}