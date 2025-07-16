using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess.DbMappings;

[ExcludeFromCodeCoverage]
internal static class ConceptDbMapping
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concept>(e =>
        {
            e.HasNoKey();
            e.ToTable("conceptos");

            e.Property(c => c.Concepto).HasColumnName("concepto");
            e.Property(c => c.Descripcion).HasColumnName("descripcion");
            e.Property(c => c.DescAbrev).HasColumnName("descabrev");
            e.Property(c => c.Ptje_IVA).HasColumnName("ptje_iva");
            e.Property(c => c.CveInt_Morat).HasColumnName("cveint_morat");
            e.Property(c => c.TipoSaldo).HasColumnName("tiposaldo");
            e.Property(c => c.TipoConcepto).HasColumnName("tipoconcepto");
            e.Property(c => c.Caseta).HasColumnName("caseta");
            e.Property(c => c.Cuota_1).HasColumnName("cuota_1");
            e.Property(c => c.Cuota_2).HasColumnName("cuota_2");
            e.Property(c => c.Cuota_3).HasColumnName("cuota_3");
            e.Property(c => c.Cuota_4).HasColumnName("cuota_4");
            e.Property(c => c.Cuota_5).HasColumnName("cuota_5");
            e.Property(c => c.Cuota_6).HasColumnName("cuota_6");
            e.Property(c => c.Cuota_7).HasColumnName("cuota_7");
            e.Property(c => c.Cuenta_Cgo).HasColumnName("cuenta_cgo");
            e.Property(c => c.SubCuenta_Cgo).HasColumnName("subcuenta_cgo");
            e.Property(c => c.SSubCuenta_Cgo).HasColumnName("ssubcuenta_cgo");
            e.Property(c => c.SSSubCuenta_Cgo).HasColumnName("sssubcuenta_cgo");
            e.Property(c => c.Cuenta_Cr).HasColumnName("cuenta_cr");
            e.Property(c => c.SubCuenta_Cr).HasColumnName("subcuenta_cr");
            e.Property(c => c.SSubCuenta_Cr).HasColumnName("ssubcuenta_cr");
            e.Property(c => c.SSSubCuenta_Cr).HasColumnName("sssubcuenta_cr");
            e.Property(c => c.GenPoliza).HasColumnName("genpoliza");
        });
    }
}
