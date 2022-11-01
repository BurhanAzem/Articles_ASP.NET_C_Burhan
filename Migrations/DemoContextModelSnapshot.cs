﻿// <auto-generated />
using System;
using Backend_Controller_Burhan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    [DbContext(typeof(DemoContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Article", b =>
                {
                    b.Property<string>("slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("favoritesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("profileusername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("slug");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.ArticleProfile", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.Property<string>("slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Profileusername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("articleslug")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("username", "slug");

                    b.HasIndex("Profileusername");

                    b.HasIndex("articleslug");

                    b.ToTable("ArticleProfiles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Comment", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("articleslug")
                        .HasColumnType("TEXT");

                    b.Property<string>("authorusername")
                        .HasColumnType("TEXT");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("articleslug");

                    b.HasIndex("authorusername");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.Property<string>("articleslug")
                        .HasColumnType("TEXT");

                    b.Property<string>("bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("emailuser")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.HasKey("username");

                    b.HasIndex("articleslug")
                        .IsUnique();

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Tag", b =>
                {
                    b.Property<string>("tag")
                        .HasColumnType("TEXT");

                    b.Property<string>("articleslug")
                        .HasColumnType("TEXT");

                    b.HasKey("tag", "articleslug");

                    b.HasIndex("articleslug");

                    b.ToTable("Tages");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("profileusername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("email");

                    b.HasIndex("profileusername")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.Property<string>("ProfileFolloweresusername")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileFollowingusername")
                        .HasColumnType("TEXT");

                    b.HasKey("ProfileFolloweresusername", "ProfileFollowingusername");

                    b.HasIndex("ProfileFollowingusername");

                    b.ToTable("ProfileProfile");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.ArticleProfile", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "Profile")
                        .WithMany("FavoritArticle")
                        .HasForeignKey("Profileusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Controller_Burhan.Models.Article", "article")
                        .WithMany("FavoritArticle")
                        .HasForeignKey("articleslug")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("article");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Comment", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", "article")
                        .WithMany("comment")
                        .HasForeignKey("articleslug");

                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "author")
                        .WithMany()
                        .HasForeignKey("authorusername");

                    b.Navigation("article");

                    b.Navigation("author");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", "article")
                        .WithOne("author")
                        .HasForeignKey("Backend_Controller_Burhan.Models.Profile", "articleslug");

                    b.Navigation("article");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Tag", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", "article")
                        .WithMany("tagList")
                        .HasForeignKey("articleslug")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("article");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "profile")
                        .WithOne("User")
                        .HasForeignKey("Backend_Controller_Burhan.Models.User", "profileusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("profile");
                });

            modelBuilder.Entity("ProfileProfile", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfileFolloweresusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Controller_Burhan.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfileFollowingusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Article", b =>
                {
                    b.Navigation("FavoritArticle");

                    b.Navigation("author")
                        .IsRequired();

                    b.Navigation("comment");

                    b.Navigation("tagList");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Navigation("FavoritArticle");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
