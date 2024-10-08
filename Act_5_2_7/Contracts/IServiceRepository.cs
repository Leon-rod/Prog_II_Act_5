using Act_4_2_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Contracts
{
    public interface IServiceRepository
    {
        Task<bool> Save(TServicio servicio);
        Task<List<TServicio>> GetByName(String name);
        Task<bool> Update(TServicio servicio,int id);
        Task<bool> Delete(int id);
    }
}
