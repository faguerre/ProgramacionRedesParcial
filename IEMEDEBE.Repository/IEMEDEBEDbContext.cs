﻿using IEMEDEBE.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Repository
{
    public class IEMEDEBEDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
       
        public IEMEDEBEDbContext(DbContextOptions<IEMEDEBEDbContext> options) : base(options) { }

    }
}
