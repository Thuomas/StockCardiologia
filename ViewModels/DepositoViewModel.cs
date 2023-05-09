using StockCardiologia.Models;

namespace StockCardiologia.ViewModels;

public class DepositoViewModel
{

    public List<Equipo> Equipos { get; set; } = new List<Equipo>();

    public string? NameFilter { get; set; }
}