using StockCardiologia.Models;
using System.ComponentModel.DataAnnotations;

namespace StockCardiologia.ViewModels;

public class EquipoViewModel
{
     public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }

   [Display(Name ="Deposito Cardiologia")]
    public string NombreDeposito { get; set; }
}