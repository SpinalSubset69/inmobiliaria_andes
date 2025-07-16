using System.Diagnostics.CodeAnalysis;

namespace InmobiliariaAndes.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Member
{
    public int Socio { get; set; }
    public string HomoClave { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Paterno { get; set; }
    public string? Materno { get; set; }
    public string Sexo { get; set; } = string.Empty;
    public byte TipoSocio { get; set; }
    public string? Accion { get; set; }
    public string? Compania { get; set; }
    public string? RFC { get; set; }
    public string? Direccion { get; set; }
    public string? Colonia { get; set; }
    public string? Poblacion { get; set; }
    public int ZonaPostal { get; set; }
    public string? Direccion_Casa { get; set; }
    public string? Colonia_Casa { get; set; }
    public string? Poblacion_Casa { get; set; }
    public int ZonaPostal_Casa { get; set; }
    public short ZonaCobranza { get; set; }
    public short Lada_Casa { get; set; }
    public string? Telefono_Casa { get; set; }
    public short Lada_Ofis { get; set; }
    public string? Telefono_Ofis { get; set; }
    public DateTime FechaIngreso { get; set; }
    public byte TipoCobranza { get; set; }
    public byte? Banco { get; set; }
    public byte? Sucursal_Banco { get; set; }
    public string? Cuenta_Banco { get; set; }
    public byte cveConsumo { get; set; }
    public string? eMail { get; set; }
    public string? eMail_Alterno { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Telefono_Movil { get; set; }
    public short? Lada_Movil { get; set; }
}
