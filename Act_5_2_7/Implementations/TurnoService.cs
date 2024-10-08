using Act_4_2_7.Contracts;
using Act_4_2_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository repository)
        {
            this._turnoRepository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _turnoRepository.Delete(id);
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _turnoRepository.GetAll();
        }

        public async Task<List<TTurno>> GetByClient(string client)
        {
            return await _turnoRepository.GetByClient(client);
        }

        public async Task<bool> Save(TTurno turno)
        {
            return await _turnoRepository.Save(turno);
        }

        public async Task<bool> Update(TTurno turno)
        {
            return await _turnoRepository.Update(turno);
        }
    }
}
