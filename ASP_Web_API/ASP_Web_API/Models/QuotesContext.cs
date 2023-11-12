using Microsoft.EntityFrameworkCore;

namespace ASP_Web_API.Models
{
    public class QuotesContext : DbContext
    {
        public QuotesContext(DbContextOptions<QuotesContext> options)
            : base(options) { }


        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationships
            modelBuilder.Entity<QuoteTag>()
                .HasKey(qt => new { qt.QuoteId, qt.TagId });

            modelBuilder.Entity<QuoteTag>()
                .HasOne(qt => qt.Quote)
                .WithMany(q => q.QuoteTags)
                .HasForeignKey(qt => qt.QuoteId);

            modelBuilder.Entity<QuoteTag>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.QuoteTags)
                .HasForeignKey(qt => qt.TagId);


            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, Text = "The only limit to our realization of tomorrow will be our doubts of today.", Author = "Franklin D. Roosevelt" },
                new Quote { Id = 2, Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill" },
                new Quote { Id = 3, Text = "Life is what happens when you're busy making other plans.", Author = "John Lennon" },
                new Quote { Id = 4, Text = "In three words I can sum up everything I've learned about life: it goes on.", Author = "Robert Frost" },
                new Quote { Id = 5, Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs" }
            );

            modelBuilder.Entity<Like>().HasData(
                new Like { Id = 1, QuoteId = 1 },
                new Like { Id = 2, QuoteId = 2 },
                new Like { Id = 3, QuoteId = 3 }
            );

            modelBuilder.Entity<QuoteTag>().HasData(
               new QuoteTag { QuoteId = 1, TagId = 1 },
               new QuoteTag { QuoteId = 2, TagId = 2 },
               new QuoteTag { QuoteId = 3, TagId = 1 },
               new QuoteTag { QuoteId = 4, TagId = 3 }
           );

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Funny" },
                new Tag { Id = 2, Name = "Philosophical" },
                new Tag { Id = 3, Name = "Motivational" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
