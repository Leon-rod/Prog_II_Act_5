using Act_4_2_7.Contracts;
using Act_4_2_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_4_2_7.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Task<bool> Delete(int id)
        {
            return _serviceRepository.Delete(id);
        }

        public async Task<List<TServicio>> GetByName(string name)
        {
            return await _serviceRepository.GetByName(name);
        }

        public async Task<bool> Save(TServicio servicio)
        {
            return await _serviceRepository.Save(servicio);
        }

        public async Task<bool> Update(TServicio servicio,int id)
        {
            return await _serviceRepository.Update(servicio,id);
        }
    }
}
