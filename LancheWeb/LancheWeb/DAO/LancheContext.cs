﻿using LancheWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Estoque.DAO
{
    public class LancheContext : DbContext
    {

        public DbSet<Ingrediente> Ingredientes { get; set; }

        public DbSet<Lanche> Lanches { get; set; }

        public DbSet<IngredienteLanche> IngredienteLanche { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredienteLanche>()
                .HasKey(il => new {il.IdLanche, il.IdIngrediente });

            modelBuilder.Entity<IngredienteLanche>()
                .HasOne(il => il.Lanche)
                .WithMany(il => il.IngredienteLanches)
                .HasForeignKey(il => il.IdLanche);

            modelBuilder.Entity<IngredienteLanche>()
                .HasOne(il => il.Ingrediente)
                .WithMany(il => il.IngredienteLanches)
                .HasForeignKey(il => il.IdIngrediente);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettingsManager.LancheWebConnection);
        }



    }
}