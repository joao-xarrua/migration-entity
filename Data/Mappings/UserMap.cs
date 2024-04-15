using Blog2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog2.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // indicate table
            builder.ToTable("User");

            // Primary Key
            builder.HasKey(x => x.Id); // PRIMARY KEY 

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd() // AUTO INCREMENT
                .UseIdentityColumn(); // IDENTITY (1, 1)

            // Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email);
            builder.Property(x => x.PasswordHash);
            builder.Property(x => x.Image);
            builder.Property(x => x.Bio);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80); ;

            // Indices
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
        }
    }
}