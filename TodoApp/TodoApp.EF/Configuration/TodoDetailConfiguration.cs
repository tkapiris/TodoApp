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
    public class TodoDetailConfiguration : IEntityTypeConfiguration<TodoDetail>
    {
        public void Configure(EntityTypeBuilder<TodoDetail> builder)
        {
            builder.ToTable("TodoDetail");

            builder.HasKey(todoDetail => todoDetail.Id);
            builder.Property(todoDetail => todoDetail.Id).ValueGeneratedOnAdd();

            builder.Property(todoDetail => todoDetail.CreateDate).IsRequired(true);
            builder.Property(todoDetail => todoDetail.FinishDate).IsRequired(false);

            builder.HasOne(todoDetail => todoDetail.Todo).WithOne(todo => todo.Detail).HasForeignKey<TodoDetail>(todoDetail => todoDetail.TodoId);
        }
    }
}
