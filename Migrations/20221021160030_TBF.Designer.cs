﻿// <auto-generated />
using System;
using Backend_Controller_Burhan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Controller_Burhan.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20221021160030_TBF")]
    partial class TBF
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Article", b =>
                {
                    b.Property<string>("slug")
                        .HasColumnType("TEXT");

                    b.Property<string>("authorusername")
                        .IsRequired()
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

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("slug");

                    b.HasIndex("authorusername");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Comment", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Articleslug")
                        .HasColumnType("TEXT");

                    b.Property<string>("authorusername")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Articleslug");

                    b.HasIndex("authorusername");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Articleslug")
                        .HasColumnType("TEXT");

                    b.Property<string>("Profileusername")
                        .HasColumnType("TEXT");

                    b.Property<string>("bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .HasColumnType("TEXT");

                    b.HasKey("username");

                    b.HasIndex("Articleslug");

                    b.HasIndex("Profileusername");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Tag", b =>
                {
                    b.Property<string>("tag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Articleslug")
                        .HasColumnType("TEXT");

                    b.HasKey("tag");

                    b.HasIndex("Articleslug");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("profileusername")
                        .HasColumnType("TEXT");

                    b.HasKey("email");

                    b.HasIndex("profileusername");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Article", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "author")
                        .WithMany()
                        .HasForeignKey("authorusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Comment", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", null)
                        .WithMany("comment")
                        .HasForeignKey("Articleslug");

                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "author")
                        .WithMany()
                        .HasForeignKey("authorusername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", null)
                        .WithMany("favorite")
                        .HasForeignKey("Articleslug");

                    b.HasOne("Backend_Controller_Burhan.Models.Profile", null)
                        .WithMany("follow")
                        .HasForeignKey("Profileusername");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Tag", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Article", null)
                        .WithMany("tagList")
                        .HasForeignKey("Articleslug");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "profile")
                        .WithMany()
                        .HasForeignKey("profileusername");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Article", b =>
                {
                    b.Navigation("comment");

                    b.Navigation("favorite");

                    b.Navigation("tagList");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Navigation("follow");
                });
#pragma warning restore 612, 618
        }
    }
}
