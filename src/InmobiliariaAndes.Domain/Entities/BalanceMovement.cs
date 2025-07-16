using System.Diagnostics.CodeAnalysis;

namespace InmobiliariaAndes.Domain.Entities;

[ExcludeFromCodeCoverage]
public class BalanceMovement
{
    public int Socio { get; set; }
    public string Homoclave { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public int Referencia { get; set; }
    public short Concepto { get; set; }
    public int Consec { get; set; }
    public DateTime? FechaVenc { get; set; }
    public decimal Valor { get; set; }
    public decimal? Propina { get; set; }
    public byte? Mesero { get; set; }
    public byte? TipoOperacion { get; set; }
    public short? Serie { get; set; }
    public short? Total { get; set; }
}
