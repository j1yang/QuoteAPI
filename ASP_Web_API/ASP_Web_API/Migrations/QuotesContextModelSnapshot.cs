﻿// <auto-generated />
using ASP_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP_Web_API.Migrations
{
    [DbContext(typeof(QuotesContext))]
    partial class QuotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP_Web_API.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuoteId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuoteId = 1
                        },
                        new
                        {
                            Id = 2,
                            QuoteId = 2
                        },
                        new
                        {
                            Id = 3,
                            QuoteId = 3
                        });
                });

            modelBuilder.Entity("ASP_Web_API.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quotes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Franklin D. Roosevelt",
                            Text = "The only limit to our realization of tomorrow will be our doubts of today."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Winston Churchill",
                            Text = "Success is not final, failure is not fatal: It is the courage to continue that counts."
                        },
                        new
                        {
                            Id = 3,
                            Author = "John Lennon",
                            Text = "Life is what happens when you're busy making other plans."
                        },
                        new
                        {
                            Id = 4,
                            Author = "Robert Frost",
                            Text = "In three words I can sum up everything I've learned about life: it goes on."
                        },
                        new
                        {
                            Id = 5,
                            Author = "Steve Jobs",
                            Text = "The only way to do great work is to love what you do."
                        });
                });

            modelBuilder.Entity("ASP_Web_API.Models.QuoteTag", b =>
                {
                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuoteTag");

                    b.HasData(
                        new
                        {
                            QuoteId = 1,
                            TagId = 1
                        },
                        new
                        {
                            QuoteId = 2,
                            TagId = 2
                        },
                        new
                        {
                            QuoteId = 3,
                            TagId = 1
                        },
                        new
                        {
                            QuoteId = 4,
                            TagId = 3
                        });
                });

            modelBuilder.Entity("ASP_Web_API.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Funny"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Philosophical"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Motivational"
                        });
                });

            modelBuilder.Entity("ASP_Web_API.Models.Like", b =>
                {
                    b.HasOne("ASP_Web_API.Models.Quote", "Quote")
                        .WithMany("Likes")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("ASP_Web_API.Models.QuoteTag", b =>
                {
                    b.HasOne("ASP_Web_API.Models.Quote", "Quote")
                        .WithMany("QuoteTags")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP_Web_API.Models.Tag", "Tag")
                        .WithMany("QuoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ASP_Web_API.Models.Quote", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("QuoteTags");
                });

            modelBuilder.Entity("ASP_Web_API.Models.Tag", b =>
                {
                    b.Navigation("QuoteTags");
                });
#pragma warning restore 612, 618
        }
    }
}
