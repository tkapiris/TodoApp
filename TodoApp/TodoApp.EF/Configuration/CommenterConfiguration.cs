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
    internal class CommenterConfiguration : IEntityTypeConfiguration<Commenter>
    {
        public void Configure(EntityTypeBuilder<Commenter> builder)
        {
            builder.ToTable("Commenter", "App");

            builder.HasKey(todo => todo.Id);
            builder.Property(todo => todo.Id).ValueGeneratedOnAdd();

            builder.Property(todo => todo.Name).HasMaxLength(maxLength: 200);

            builder.HasMany(commenter => commenter.TodoComments).WithOne(comment => comment.Commenter)
                   .HasForeignKey(x => x.CommenterId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
