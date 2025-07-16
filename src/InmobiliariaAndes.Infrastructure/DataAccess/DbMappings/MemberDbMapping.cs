using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess.DbMappings;

[ExcludeFromCodeCoverage]
internal static class MemberDbMapping
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(e =>
        {
            e.HasNoKey();
            e.ToTable("socios");

            e.Property(m => m.Socio).HasColumnName("socio");
            e.Property(m => m.HomoClave).HasColumnName("homoclave");
            e.Property(m => m.Nombre).HasColumnName("nombre");
            e.Property(m => m.Paterno).HasColumnName("paterno");
            e.Property(m => m.Materno).HasColumnName("materno");
            e.Property(m => m.Sexo).HasColumnName("sexo");
            e.Property(m => m.TipoSocio).HasColumnName("tiposocio");
            e.Property(m => m.Accion).HasColumnName("accion");
            e.Property(m => m.Compania).HasColumnName("compañia");
            e.Property(m => m.RFC).HasColumnName("rfc");
            e.Property(m => m.Direccion).HasColumnName("direccion");
            e.Property(m => m.Colonia).HasColumnName("colonia");
            e.Property(m => m.Poblacion).HasColumnName("poblacion");
            e.Property(m => m.ZonaPostal).HasColumnName("zonapostal");
            e.Property(m => m.Direccion_Casa).HasColumnName("direccion_casa");
            e.Property(m => m.Colonia_Casa).HasColumnName("colonia_casa");
            e.Property(m => m.Poblacion_Casa).HasColumnName("poblacion_casa");
            e.Property(m => m.ZonaPostal_Casa).HasColumnName("zonapostal_casa");
            e.Property(m => m.ZonaCobranza).HasColumnName("zonacobranza");
            e.Property(m => m.Lada_Casa).HasColumnName("lada_casa");
            e.Property(m => m.Telefono_Casa).HasColumnName("telefono_casa");
            e.Property(m => m.Lada_Ofis).HasColumnName("lada_ofis");
            e.Property(m => m.Telefono_Ofis).HasColumnName("telefono_ofis");
            e.Property(m => m.FechaIngreso).HasColumnName("fechaingreso");
            e.Property(m => m.TipoCobranza).HasColumnName("tipocobranza");
            e.Property(m => m.Banco).HasColumnName("banco");
            e.Property(m => m.Sucursal_Banco).HasColumnName("sucursal_banco");
            e.Property(m => m.Cuenta_Banco).HasColumnName("cuenta_banco");
            e.Property(m => m.cveConsumo).HasColumnName("cveconsumo");
            e.Property(m => m.eMail).HasColumnName("email");
            e.Property(m => m.eMail_Alterno).HasColumnName("email_alterno");
            e.Property(m => m.FechaBaja).HasColumnName("fechabaja");
            e.Property(m => m.Telefono_Movil).HasColumnName("telefono_movil");
            e.Property(m => m.Lada_Movil).HasColumnName("lada_movil");
        });
    }
}
