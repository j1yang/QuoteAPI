using ASP_Web_API.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_Web_API.Models
{
    public class QuotesContext : IdentityDbContext<User>
    {
        public QuotesContext(DbContextOptions<QuotesContext> options)
            : base(options) { }


        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<TagAssignment> QuoteTags { get; set; }

        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // call base class version to init Identity entities:
            base.OnModelCreating(modelBuilder);

            // apply our role config'n
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Configure many-to-many relationships
            modelBuilder.Entity<TagAssignment>()
                .HasKey(qt => new { qt.QuoteId, qt.TagId });

            modelBuilder.Entity<TagAssignment>()
                .HasOne(qt => qt.Quote)
                .WithMany(q => q.TagAssignments)
                .HasForeignKey(qt => qt.QuoteId);

            modelBuilder.Entity<TagAssignment>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.TagAssignments)
                .HasForeignKey(qt => qt.TagId);


            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, Text = "You must be the change you wish to see in the world.", Author = "Mahatma Gandhi" },
                new Quote { Id = 2, Text = "Spread love everywhere you go. Let no one ever come to you without leaving happier.", Author = "Mother Teresa" },
                new Quote { Id = 3, Text = "The only thing we have to fear is fear itself.", Author = "Franklin D. Roosevelt" },
                new Quote { Id = 4, Text = "Darkness cannot drive out darkness: only light can do that. Hate cannot drive out hate: only love can do that.", Author = "Martin Luther King Jr." },
                new Quote { Id = 5, Text = "Do one thing every day that scares you.", Author = "Eleanor Roosevelt" },
                new Quote { Id = 6, Text = "Well done is better than well said.", Author = "Benjamin Franklin" },
                new Quote { Id = 7, Text = "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart.", Author = "Helen Keller" },
                new Quote { Id = 8, Text = "It is during our darkest moments that we must focus to see the light.", Author = "Aristotle" },
                new Quote { Id = 9, Text = "Do not go where the path may lead, go instead where there is no path and leave a trail.", Author = "Ralph Waldo Emerson" },
                new Quote { Id = 10, Text = "Be yourself; everyone else is already taken.", Author = "Oscar Wilde" },
                new Quote { Id = 11, Text = "If life were predictable it would cease to be life and be without flavor.", Author = "Eleanor Roosevelt" },
                new Quote { Id = 12, Text = "In the end, it's not the years in your life that count. It's the life in your years.", Author = "Abraham Lincoln" },
                new Quote { Id = 13, Text = "Life is a succession of lessons which must be lived to be understood.", Author = "Ralph Waldo Emerson" },
                new Quote { Id = 14, Text = "You will face many defeats in life, but never let yourself be defeated.", Author = "Maya Angelou" },
                new Quote { Id = 15, Text = "Never let the fear of striking out keep you from playing the game.", Author = "Babe Ruth" },
                new Quote { Id = 16, Text = "Life is never fair, and perhaps it is a good thing for most of us that it is not.", Author = "Oscar Wilde" },
                new Quote { Id = 17, Text = "The only impossible journey is the one you never begin.", Author = "Tony Robbins" },
                new Quote { Id = 18, Text = "In this life we cannot do great things. We can only do small things with great love.", Author = "Mother Teresa" },
                new Quote { Id = 19, Text = "Only a life lived for others is a life worthwhile.", Author = "Albert Einstein" },
                new Quote { Id = 20, Text = "The purpose of our lives is to be happy.", Author = "Dalai Lama" },
                new Quote { Id = 21, Text = "You may say I'm a dreamer, but I'm not the only one. I hope someday you'll join us. And the world will live as one.", Author = "John Lennon" },
                new Quote { Id = 22, Text = "You only live once, but if you do it right, once is enough.", Author = "Mae West" },
                new Quote { Id = 23, Text = "To be yourself in a world that is constantly trying to make you something else is the greatest accomplishment.", Author = "Ralph Waldo Emerson" },
                new Quote { Id = 24, Text = "Don't worry when you are not recognized, but strive to be worthy of recognition.", Author = "Abraham Lincoln" },
                new Quote { Id = 25, Text = "The greatest glory in living lies not in never falling, but in rising every time we fall.", Author = "Nelson Mandela" }
            );


            modelBuilder.Entity<Like>().HasData(
                new Like { Id = 1, QuoteId = 1 },
                new Like { Id = 2, QuoteId = 2 },
                new Like { Id = 3, QuoteId = 3 },
                new Like { Id = 4, QuoteId = 4 },
                new Like { Id = 5, QuoteId = 5 },
                new Like { Id = 6, QuoteId = 6 },
                new Like { Id = 7, QuoteId = 7 },
                new Like { Id = 8, QuoteId = 8 },
                new Like { Id = 9, QuoteId = 9 },
                new Like { Id = 10, QuoteId = 10 },
                new Like { Id = 11, QuoteId = 11 },
                new Like { Id = 12, QuoteId = 12 },
                new Like { Id = 13, QuoteId = 13 },
                new Like { Id = 14, QuoteId = 14 },
                new Like { Id = 15, QuoteId = 15 },
                new Like { Id = 16, QuoteId = 16 },
                new Like { Id = 17, QuoteId = 17 },
                new Like { Id = 18, QuoteId = 18 },
                new Like { Id = 19, QuoteId = 19 },
                new Like { Id = 20, QuoteId = 20 },
                new Like { Id = 21, QuoteId = 21 },
                new Like { Id = 22, QuoteId = 22 },
                new Like { Id = 23, QuoteId = 23 },
                new Like { Id = 24, QuoteId = 24 },
                new Like { Id = 25, QuoteId = 25 }
            );

            var random = new Random();

            for (int i = 26; i <= 175; i++)
            {
                modelBuilder.Entity<Like>().HasData(
                    new Like { Id = i, QuoteId = random.Next(1, 26) }
                );
            }

            modelBuilder.Entity<TagAssignment>().HasData(
                new TagAssignment { QuoteId = 1, TagId = 1 },
                new TagAssignment { QuoteId = 1, TagId = 2 },
                new TagAssignment { QuoteId = 1, TagId = 3 },
                new TagAssignment { QuoteId = 1, TagId = 4 },
                new TagAssignment { QuoteId = 1, TagId = 5 },
                new TagAssignment { QuoteId = 2, TagId = 2 },  
                new TagAssignment { QuoteId = 3, TagId = 3 },  
                new TagAssignment { QuoteId = 4, TagId = 4 },  
                new TagAssignment { QuoteId = 5, TagId = 5 },  
                new TagAssignment { QuoteId = 6, TagId = 3 }, 
                new TagAssignment { QuoteId = 7, TagId = 3 }, 
                new TagAssignment { QuoteId = 8, TagId = 3 }, 
                new TagAssignment { QuoteId = 9, TagId = 5 }, 
                new TagAssignment { QuoteId = 10, TagId = 5 }, 
                new TagAssignment { QuoteId = 11, TagId = 5 }, 
                new TagAssignment { QuoteId = 12, TagId = 6 }, 
                new TagAssignment { QuoteId = 13, TagId = 6 }, 
                new TagAssignment { QuoteId = 14, TagId = 6 },
                new TagAssignment { QuoteId = 15, TagId = 7 },
                new TagAssignment { QuoteId = 16, TagId = 7 }, 
                new TagAssignment { QuoteId = 17, TagId = 7 }, 
                new TagAssignment { QuoteId = 18, TagId = 7 },
                new TagAssignment { QuoteId = 19, TagId = 1 },
                new TagAssignment { QuoteId = 20, TagId = 1 },
                new TagAssignment { QuoteId = 21, TagId = 1 },
                new TagAssignment { QuoteId = 22, TagId = 1 },
                new TagAssignment { QuoteId = 23, TagId = 1 },
                new TagAssignment { QuoteId = 24, TagId = 2 },
                new TagAssignment { QuoteId = 25, TagId = 3 }
                );


            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Leadership" },
                new Tag { Id = 2, Name = "Motivational" },
                new Tag { Id = 3, Name = "Life" },
                new Tag { Id = 4, Name = "Attitude" },
                new Tag { Id = 5, Name = "Wisdom" },
                new Tag { Id = 6, Name = "Love" },
                new Tag { Id = 7, Name = "Happiness" }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
