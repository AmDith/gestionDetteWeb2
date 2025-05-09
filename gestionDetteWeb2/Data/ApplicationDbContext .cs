﻿using Cours.Models;
using Microsoft.EntityFrameworkCore;

namespace Cours.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>()
            .HasMany(c => c.Dettes)
            .WithOne(d => d.Client)
            .HasForeignKey(d => d.ClientId);  // Associer la clé étrangère à la colonne ClientId dans la table Dettes

        modelBuilder.Entity<User>()
         .HasOne(user => user.Client)
         .WithOne(client => client.User)
         .HasForeignKey<Client>(c => c.UserId)  // Associer la clé étrangère à la colonne UserId dans la table Clients
         .OnDelete(DeleteBehavior.Cascade);  // Supprimer une entité Client implique la suppression de toutes les entités associées User
    }
    // Define your DbSet properties here.
    public DbSet<Client> Clients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Dette> Dettes { get; set; }

    /* 
        On ne peut pas augmenter la visibilité d'un attribut ou d'une méthode héritée

        * private (visible uniquement dans la classe elle même)

        * protected (visibile dans toutes les classes filles uniquement)

        * internal (visible dans le namespace)

        * public (visible partout)

        modelBuilder.Entity<Client>().ToTable("clients") => Changer le nom des tables
     */


}