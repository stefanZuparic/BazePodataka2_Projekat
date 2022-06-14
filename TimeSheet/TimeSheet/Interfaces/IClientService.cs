using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.DTOs;

namespace TimeSheet.Interfaces
{
    public interface IClientService
    {
        ClientDTO GetById(int id);

        void Create(ClientDTO clientDTO);

        void DeleteById(int id);

        void UpdateActivity(bool state, int id);

        List<ClientDTO> GetAll();
    }
}
