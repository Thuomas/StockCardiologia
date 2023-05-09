using System.ComponentModel.DataAnnotations;

namespace StockCardiologia.Models;

public class Deposito
{
    public int Id { get; set; }

    [Display(Name ="Deposito Cardiologia")]
    public string NombreDeposito { get; set; }

    public virtual List<Equipo> Equipos { get; set; }

}