using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Model;

namespace TodoApp.EF.Configuration
{
    public class TodoCommentConfiguration : IEntityTypeConfiguration<TodoComment>
    {
        public void Configure(EntityTypeBuilder<TodoComment> builder)
        {
            builder.ToTable("TodoComment");

            builder.HasKey(todoComment => todoComment.Id);
            builder.Property(todoComment => todoComment.Id).ValueGeneratedOnAdd();

            builder.Property(todoComment => todoComment.Text).HasMaxLength(200).IsRequired(true);

            builder.HasOne(todoComment => todoComment.Todo).WithMany(todo => todo.Comments).HasForeignKey(todoComment => todoComment.TodoId);
        }
    }
}
