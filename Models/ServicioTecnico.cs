using System.ComponentModel.DataAnnotations;

namespace StockCardiologia.Models;

public class ServicioTecnico
{
    public int Id { get; set; }
    
    public string Falla { get; set; }
    
    public string Observaciones { get; set; }

    public virtual List<Equipo> Equipos { get; set; }

}