using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace SEP.User.Registare.Persistance.Configurations
{
    public class UserConfigure : IEntityTypeConfiguration<Domain.Models.Users.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Users.User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.FirstName).HasColumnName("FirstName");
            builder.Property(e => e.LastName).HasColumnName("LastName");
            builder.Property(e => e.Email).HasColumnName("Email");
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
            
        }
    }
}
