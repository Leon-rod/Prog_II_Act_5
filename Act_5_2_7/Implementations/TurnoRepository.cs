using Act_4_2_7.Contracts;
using Act_4_2_7.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly DBTurnosContext _context;
        public TurnoRepository(DBTurnosContext context)
        {
            this._context = context;
        }

        public async Task<bool> Delete(int id)
        {
            TTurno turno =await  _context.TTurnos.FindAsync(id);
            turno.detallesTurno = _context.TDetallesTurnos.Where(d => d.IdTurno == id).ToList()[0];
            _context.TDetallesTurnos.Remove(turno.detallesTurno);
            _context.TTurnos.Remove(turno);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TTurno>> GetAll()
        {
            List<TTurno> turnos = await _context.TTurnos
                .ToListAsync();
            return turnos;
        }

        public async Task<List<TTurno>> GetByClient(string client)
        {
            List<TTurno> result =await  _context.TTurnos
                .Where(t => t.Cliente.Contains(client))
                .ToListAsync();
            return result;
        }

        public async Task<bool> Save(TTurno turno)
        {
            await _context.TDetallesTurnos.AddAsync(turno.detallesTurno);
            await _context.TTurnos.AddAsync(turno);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(TTurno turno)
        {
            TTurno t = _context.TTurnos.Find(turno.Id);
            t = turno;
            _context.TTurnos.Update(t);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
