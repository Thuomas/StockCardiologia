using System.ComponentModel.DataAnnotations;
using StockCardiologia.Models;

namespace StockCardiologia.ViewModels;

public class DepositoViewModel
{

    public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }

   [Display(Name ="Deposito Cardiologia")]
    public string NombreDeposito { get; set; }

    public List<Deposito> Depositos { get; set; } = new List<Deposito>();
}