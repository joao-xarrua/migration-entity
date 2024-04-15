using Blog2.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog2.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
        {
            // indicate table
            builder.ToTable("Post");

            // Primary Key
            builder.HasKey(x => x.Id); // PRIMARY KEY 

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd() // AUTO INCREMENT
                .UseIdentityColumn(); // IDENTITY (1, 1)

            // Properties
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                // .HasDefaultValue("GETDATE()");
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            // Indices
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            // Relations
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Althor")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                                .WithMany()
                                .HasForeignKey("PostId")
                                .HasConstraintName("FK_PostTag_PostId")
                                .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                                .WithMany()
                                .HasForeignKey("TagId")
                                .HasConstraintName("FK_PostTag_TagId")
                                .OnDelete(DeleteBehavior.Cascade));
        }
    }
}