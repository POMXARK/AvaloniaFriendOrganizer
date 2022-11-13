﻿// <auto-generated />
using FriendOrganizer.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221113093805_InitialDatabase")]
    partial class InitialDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("FriendOrganizer.Model.Friend", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            FirstName = "Thomas",
                            LastName = "Huber"
                        },
                        new
                        {
                            Id = 2u,
                            FirstName = "Urs",
                            LastName = "Meier"
                        },
                        new
                        {
                            Id = 3u,
                            FirstName = "Erkan",
                            LastName = "Egin"
                        },
                        new
                        {
                            Id = 4u,
                            FirstName = "Sara",
                            LastName = "Huber"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
