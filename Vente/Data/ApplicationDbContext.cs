using Microsoft.EntityFrameworkCore;
using Vente.Models;

namespace Vente.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Utilisateurs> Utilisateurs { get; set; }
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilisateurs>().HasKey(u => u.ID);

            modelBuilder.Entity<Proprietaire>()
                .HasKey(p => p.IDUtilisateur);

            modelBuilder.Entity<Proprietaire>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.IDUtilisateur)
                .IsRequired(false);

            modelBuilder.Entity<Admin>()
                .HasKey(a => a.ID);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Utilisateur)
                .WithMany()
                .HasForeignKey(a => a.ID)  // Utiliser la clé de la classe dérivée comme clé étrangère
                .IsRequired(false);
            modelBuilder.Entity<Produit>()
                .HasKey(pro => pro.IdPr);

            modelBuilder.Entity<Categorie>().HasKey(c => c.CategorieID);
            modelBuilder.Entity<Produit>()
                .HasOne(pr => pr.Categories)
                .WithMany()
                .HasForeignKey(pr => pr.IDC)  // Utiliser la clé de la classe dérivée comme clé étrangère
                .IsRequired(false);

            modelBuilder.Entity<Proprietaire>().HasKey(pro => pro.IDUtilisateur);
           
            modelBuilder.Entity<Produit>()
                .HasOne(pr => pr.proprietaires)
                .WithMany()
                .HasForeignKey(pr => pr.IDP)  // Utiliser la clé de la classe dérivée comme clé étrangère
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
       
    }
}
