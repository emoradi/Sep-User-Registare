using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SEP.User.Registare.Domain.Models.Users.ValueObjects;

namespace SEP.User.Registare.Persistance.Configurations
{
    public class SeedConfigure : IEntityTypeConfiguration<Domain.Models.Users.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Users.User> builder)
        {



            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.FirstName).IsRequired(true).HasMaxLength(maxLength: FirstName.MaxLength).HasConversion(p => p.value,p => new FirstName(p));
            builder.Property(e => e.LastName).IsRequired(true).HasMaxLength(maxLength: LastName.MaxLength).HasConversion(p => p.value,p => new LastName(p));
            builder.Property(e => e.EmailAddress).IsRequired(true).HasColumnType("char").HasMaxLength(maxLength: EmailAddress.MaxLength).HasConversion(p => p.value,p => new EmailAddress(p));
            builder.Property(e => e.PhoneNumber).IsRequired(true).HasColumnType("char").HasMaxLength(maxLength: PhoneNumber.MaxLength).HasConversion(p => p.value,p => new PhoneNumber(p));
            builder.Property(e => e.DateOfBirth).HasColumnType("Datetime2").IsRequired(true);
            
          
            builder
                    .HasIndex
                        (m => new { m.EmailAddress })
                    .IsUnique(unique: true);
        }
    }
}
