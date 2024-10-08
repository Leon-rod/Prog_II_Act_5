using Act_4_2_7.Contracts;
using Act_4_2_7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DBTurnosContext _context;
        public ServiceRepository(DBTurnosContext context)
        {
            this._context = context;
        }
        public async Task<bool> Delete(int id)
        {
            TServicio oServicio = await _context.TServicios.FindAsync(id);
            if (oServicio == null) return false;
            _context.Remove(oServicio);
            return (await _context.SaveChangesAsync() > 0) ? true : false;
        }

        public async Task<List<TServicio>> GetByName(string name)
        {
            if (name.IsNullOrEmpty())
                return await _context.TServicios.ToListAsync();
            return await _context.TServicios.Where(s => s.Nombre.Contains(name)).ToListAsync();
        }

        public async Task<bool> Save(TServicio servicio)
        {
            await _context.AddAsync(servicio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(TServicio servicio, int id)
        {
            TServicio service = _context.TServicios.Find(id);
            if (service == null) return false;
            service.Nombre = servicio.Nombre;
            service.EnPromocion = servicio.EnPromocion;
            service.Costo = servicio.Costo;
            _context.TServicios.Update(service);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
