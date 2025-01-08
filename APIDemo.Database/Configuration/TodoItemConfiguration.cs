using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIDemo.Database.Configuration
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("int")
                .HasSentinel(-1)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasColumnType("nvarchar(512)")
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasSentinel(default(string));

            builder
                .Property(x => x.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasSentinel(default(string));

            builder
                .Property(x => x.Created)
                .HasColumnType("datetimeoffset(3)")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .HasSentinel(default(DateTimeOffset));

            builder
               .Property(x => x.Modified)
               .HasColumnType("datetimeoffset(3)")
               .IsRequired()
               .HasDefaultValueSql("GETUTCDATE()")
               .HasSentinel(default(DateTimeOffset));

            builder
                .Property(x => x.Deleted)
                .HasColumnType("bit")
                .IsRequired();

            builder
                .HasIndex(x => new { x.Deleted, x.Created })
                .HasDatabaseName("IX_TodoItem_Created")
                .IsCreatedOnline(true)
                .HasFillFactor(100);

            builder
                .ToTable("TodoItem");
        }
    }
}