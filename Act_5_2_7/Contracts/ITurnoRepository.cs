using Act_4_2_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Contracts
{
    public interface ITurnoRepository
    {
        Task<bool> Save(TTurno turno);
        Task<List<TTurno>> GetAll();
        Task<List<TTurno>> GetByClient(String client);
        Task<bool> Update(TTurno turno);
        Task<bool> Delete(int id);


    }
}
