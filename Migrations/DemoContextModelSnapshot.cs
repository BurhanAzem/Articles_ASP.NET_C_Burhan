﻿// <auto-generated />
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

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("profileUserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.HasIndex("profileUserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.User", b =>
                {
                    b.HasOne("Backend_Controller_Burhan.Models.Profile", "profile")
                        .WithMany("follow")
                        .HasForeignKey("profileUserName");

                    b.Navigation("profile");
                });

            modelBuilder.Entity("Backend_Controller_Burhan.Models.Profile", b =>
                {
                    b.Navigation("follow");
                });
#pragma warning restore 612, 618
        }
    }
}
