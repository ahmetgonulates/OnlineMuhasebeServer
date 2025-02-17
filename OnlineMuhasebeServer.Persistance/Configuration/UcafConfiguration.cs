using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Constants;

namespace OnlineMuhasebeServer.Persistance.Configuration;

public sealed class UcafConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
{
    public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
    {
        builder.ToTable(TableNames.UniformChartOfAccounts);
        builder.HasKey(p => p.Id);
    }
}