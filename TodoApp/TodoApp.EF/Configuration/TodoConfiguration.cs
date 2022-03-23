﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Model;

namespace TodoApp.EF.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");

            builder.HasKey(todo => todo.Id);
            builder.Property(todo => todo.Id).ValueGeneratedOnAdd();

            builder.Property(todo => todo.Title).HasMaxLength(100).IsRequired(true);

            builder.HasIndex(todo => todo.Finished).HasName("IX_My_Finished");

            builder.HasOne(todo => todo.Detail).WithOne(todoDetail => todoDetail.Todo).HasForeignKey<TodoDetail>(todoDetail => todoDetail.TodoId);
            builder.HasMany(todo => todo.Comments).WithOne(todoComment => todoComment.Todo).HasForeignKey(todoComment => todoComment.TodoId);
        }
    }
}
