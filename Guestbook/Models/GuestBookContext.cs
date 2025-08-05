using Microsoft.EntityFrameworkCore;

namespace Guestbook.Models
{
    public class GuestBookContext: DbContext
    {

        //撰寫依賴注入用的建構子
        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
        {
        }


        //定義資料表
        public DbSet<Book> Book { get; set; }
        public DbSet<Rebook> Rebook { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            { 
                entity.HasKey(b => b.BookID).HasName("PK_Book");
                entity.Property(b => b.BookID)
                    .IsUnicode(false)
                    .HasMaxLength(36)
                    .HasDefaultValueSql("NEWID()");

                entity.Property(b => b.Title).HasMaxLength(30).IsRequired();
                entity.Property(b => b.Description).IsRequired();

                entity.Property(b => b.Author).HasMaxLength(10).IsRequired();
                entity.Property(b => b.Photo).HasMaxLength(40);
                entity.Property(b => b.PhotoType).HasMaxLength(20);

                entity.Property(b => b.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");
                 
            });

            modelBuilder.Entity<Rebook>(entity =>
            {
                entity.HasKey(r => r.RebookID);
                entity.Property(r => r.RebookID)
                    .IsUnicode(false)
                    .HasMaxLength(36);

                entity.Property(r => r.Description).IsRequired();
                entity.Property(r => r.Author).HasMaxLength(10).IsRequired();
                entity.Property(r => r.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETDATE()");
             
            });

        }

    }
}
