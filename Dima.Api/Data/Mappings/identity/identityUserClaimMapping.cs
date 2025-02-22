using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings.identity;

public class identityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
    {
        builder.ToTable("IdentityUserClaim");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.ClaimType).HasMaxLength(256);
        builder.Property(u => u.ClaimValue).HasMaxLength(256);
    }
}