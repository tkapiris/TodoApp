using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TodoApp.Model;

namespace TodoApp.EF.Configuration;

internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todo", "App");

        builder.HasKey(todo => todo.Id);
        builder.Property(todo => todo.Id).ValueGeneratedOnAdd();

        builder.Property(todo => todo.Title).HasMaxLength(maxLength: 200);

        builder.HasIndex(todo => todo.Finished);
    }
}