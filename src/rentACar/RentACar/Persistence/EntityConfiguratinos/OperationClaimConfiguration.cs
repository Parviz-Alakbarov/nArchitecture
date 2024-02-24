using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguratinos;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdateDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
        builder.HasMany(x => x.UserOperationClaims);
        //builder.HasData(_seed);
    }

    //private IEnumerable<OperationClaim> _seeds
    //{
    //    get
    //    {
    //        int id = 0;

    //        yield return new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin };

    //        #region Feature Operation Claims
    //        IEnumerable<Type> featureOperationClaimsTypes = Assembly
    //            .GetAssembly(typeof(ApplicationServiceRegistration))!
    //            .GetTypes()
    //            .Where(
    //                type =>
    //                    (type.Namespace?.Contains("Features") == true)
    //                    && (type.Namespace?.Contains("Constants") == true)
    //                    && type.IsClass
    //                    && type.Name.EndsWith("OperationClaims")
    //            );
    //        foreach (Type type in featureOperationClaimsTypes)
    //        {
    //            FieldInfo[] typeFields = type.GetFields(BindingFlags.Public | BindingFlags.Static);
    //            IEnumerable<string> typeFieldsValues = typeFields.Select(field => field.GetValue(null)!.ToString()!);

    //            IEnumerable<OperationClaim> featureOperationClaimsToAdd = typeFieldsValues.Select(
    //                value => new OperationClaim { Id = ++id, Name = value }
    //            );
    //            foreach (OperationClaim featureOperationClaim in featureOperationClaimsToAdd)
    //                yield return featureOperationClaim;
    //        }
    //        #endregion
    //    }
    //}
}
