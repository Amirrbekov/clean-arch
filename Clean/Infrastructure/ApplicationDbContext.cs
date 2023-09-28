using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}
