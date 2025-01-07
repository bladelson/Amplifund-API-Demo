﻿// <auto-generated />
using System;
using APIDemo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIDemo.Database.Migrations
{
    [DbContext(typeof(APIDemoContext))]
    [Migration("20250107214437_TodoItemTable")]
    partial class TodoItemTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("APIDemo")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIDemo.Database.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(3)")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<DateTimeOffset>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(3)")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(512)")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.HasIndex("Created")
                        .HasDatabaseName("IX_TodoItem_Created")
                        .HasAnnotation("SqlServer:Online", true);

                    SqlServerIndexBuilderExtensions.HasFillFactor(b.HasIndex("Created"), 100);

                    b.ToTable("TodoItem", "APIDemo");
                });
#pragma warning restore 612, 618
        }
    }
}
