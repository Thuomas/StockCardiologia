using StockCardiologia.Models;

namespace StockCardiologia.Services;
public interface IEquipoService
{
    void Create(Equipo obj);
    List<Equipo> GetAll();
    void Update(Equipo obj);
    void Delete(int id);
    Equipo? GetById(int id);


}