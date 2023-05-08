using System.ComponentModel.DataAnnotations;

namespace StockCardiologia.Models;

public class Equipo
{
    public int Id { get; set; }

    [Display(Name = "N° de Serie")]
    public string NSerie { get; set; }

    [Display(Name = "Remito")]
    public string Remito { get; set; }

    [Display(Name = "Planilla")]
    public string Planilla { get; set; }

    [Display(Name = "Fecha Produccion")]
    public DateOnly FechaProd { get; set; }

    [Display(Name = "Condicion")]
    public string Condicion { get; set; } 

    public int DepositoId { get; set; }

    public virtual Deposito Deposito { get; set; }

}
