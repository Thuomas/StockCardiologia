using StockCardiologia.Data;
using StockCardiologia.Models;
using Microsoft.EntityFrameworkCore;

namespace StockCardiologia.Services;

public class EquipoService : IEquipoService
{
    private readonly DepositoContext _context;

    public EquipoService(DepositoContext context)
    {
        _context = context;
    }

    public void Create(Equipo obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var borrar = GetById(id);
        if(borrar !=null)
        {
            _context.Remove(borrar);
            _context.SaveChanges();
        }
    }

    public List<Equipo> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public Equipo? GetById(int id)
    {
         var equipo = GetQuery()
			.Include(x=>x.Deposito)
			.FirstOrDefault(m=>m.Id == id);

        return equipo;  
    }

    public void Update(Equipo obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Equipo> GetQuery()
    {
        return from equipo in _context.Equipo select equipo;
    }
}