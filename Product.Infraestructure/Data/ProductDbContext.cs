﻿using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Product.Infraestructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        
        public DbSet<ProductEntity> Products { get; set; }
    }
}
