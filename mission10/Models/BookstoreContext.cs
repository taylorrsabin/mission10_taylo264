using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mission10.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source = Bookstore.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.HasIndex(e => e.BookId)
                    .IsUnique();

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author).IsRequired();

                entity.Property(e => e.Category).IsRequired();

                entity.Property(e => e.Classification).IsRequired();

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN");

                entity.Property(e => e.Publisher).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
