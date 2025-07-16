using System.Diagnostics.CodeAnalysis;
using InmobiliariaAndes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAndes.Infrastructure.DataAccess.DbMappings;

[ExcludeFromCodeCoverage]
internal static class BalanceMovementDbMapping
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BalanceMovement>(e =>
        {
            e.HasNoKey();
            e.ToTable("movtos_saldos");

            e.Property(b => b.Socio).HasColumnName("socio");
            e.Property(b => b.Homoclave).HasColumnName("homoclave");
            e.Property(b => b.Fecha).HasColumnName("fecha");
            e.Property(b => b.Referencia).HasColumnName("referencia");
            e.Property(b => b.Concepto).HasColumnName("concepto");
            e.Property(b => b.Consec).HasColumnName("consec");
            e.Property(b => b.FechaVenc).HasColumnName("fechavenc");
            e.Property(b => b.Valor).HasColumnName("valor");
            e.Property(b => b.Propina).HasColumnName("propina");
            e.Property(b => b.Mesero).HasColumnName("mesero");
            e.Property(b => b.TipoOperacion).HasColumnName("tipooperacion");
            e.Property(b => b.Serie).HasColumnName("serie");
            e.Property(b => b.Total).HasColumnName("total");
        });
    }
}
