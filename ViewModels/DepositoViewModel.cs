using System.ComponentModel.DataAnnotations;
using StockCardiologia.Models;

namespace StockCardiologia.ViewModels;

public class DepositoViewModel
{
    public int Id { get; set; }
    public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }

    public string NombreDeposito { get; set; }

    public List<Deposito> Depositos { get; set; } = new List<Deposito>();
}