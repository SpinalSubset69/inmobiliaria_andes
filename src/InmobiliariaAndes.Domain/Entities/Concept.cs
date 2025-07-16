using System.Diagnostics.CodeAnalysis;

namespace InmobiliariaAndes.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Concept
{
    public short Concepto { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string DescAbrev { get; set; } = string.Empty;
    public byte Ptje_IVA { get; set; }
    public bool CveInt_Morat { get; set; }
    public byte TipoSaldo { get; set; }
    public byte TipoConcepto { get; set; }
    public bool Caseta { get; set; }
    public decimal Cuota_1 { get; set; }
    public decimal Cuota_2 { get; set; }
    public decimal Cuota_3 { get; set; }
    public decimal Cuota_4 { get; set; }
    public decimal Cuota_5 { get; set; }
    public decimal Cuota_6 { get; set; }
    public decimal Cuota_7 { get; set; }
    public short Cuenta_Cgo { get; set; }
    public short SubCuenta_Cgo { get; set; }
    public short SSubCuenta_Cgo { get; set; }
    public short SSSubCuenta_Cgo { get; set; }
    public short Cuenta_Cr { get; set; }
    public short SubCuenta_Cr { get; set; }
    public short SSubCuenta_Cr { get; set; }
    public short SSSubCuenta_Cr { get; set; }
    public bool GenPoliza { get; set; }
}
