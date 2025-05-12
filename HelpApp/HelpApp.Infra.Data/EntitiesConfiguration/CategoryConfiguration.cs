using HelpApp.Domain;
using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(testc => testc.Id);
            builder.Property(prop => prop.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
               new Category(1, "Material Escolar"),
               new Category(2, "Eletronicos"),
               new Category(3, "Acessórios")
               );
        }
    }
}
