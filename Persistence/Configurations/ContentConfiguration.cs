using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCMS.Domain.Entities;

namespace SimpleCMS.Persistence.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(128);
        }
    }
}
