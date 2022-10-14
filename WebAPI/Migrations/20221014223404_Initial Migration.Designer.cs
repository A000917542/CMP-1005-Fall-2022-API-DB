﻿// <auto-generated />
using DatabaseAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20221014223404_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DatabaseAccess.Models.Blog", b =>
                {
                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Url");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("DatabaseAccess.Models.BlogPost", b =>
                {
                    b.Property<string>("PostUrl")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostUrl");

                    b.HasIndex("BlogUrl");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("DatabaseAccess.Models.BlogPost", b =>
                {
                    b.HasOne("DatabaseAccess.Models.Blog", "Blog")
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogUrl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("DatabaseAccess.Models.Blog", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}