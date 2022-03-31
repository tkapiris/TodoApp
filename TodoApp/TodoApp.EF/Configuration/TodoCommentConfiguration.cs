using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TodoApp.Model;

namespace TodoApp.EF.Configuration;

public class TodoCommentConfiguration : IEntityTypeConfiguration<TodoComment>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<TodoComment> builder)
    {
        builder.ToTable("TodoComment", "App");

        builder.HasKey(todoComment => todoComment.Id);
        builder.Property(todoComment => todoComment.Id).ValueGeneratedOnAdd();

        builder.Property(todoComment => todoComment.Text).HasMaxLength(maxLength: 1000);

        builder.HasOne(todoComment => todoComment.Todo).WithMany(todo => todo.Comments)
            .HasForeignKey(todoComment => todoComment.TodoId).IsRequired();
    }
}