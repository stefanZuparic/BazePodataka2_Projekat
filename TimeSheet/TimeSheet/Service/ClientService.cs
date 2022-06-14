using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Interfaces;
using TimeSheet.Repository;
using TimeSheet.Repository.DTOs;
using TimeSheet.Repository.Models;

namespace TimeSheet.Service
{
    public class ClientService : IClientService
    {
        private IMapper _mapper;
        private TimeSheetEntryDbContext _context;

        public ClientService(IMapper mapper, TimeSheetEntryDbContext context) {
            _mapper = mapper;
            _context = context;
        }

        public void Create(ClientDTO clientDTO)
        {
            Client client = _mapper.Map<Client>(clientDTO);

            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Client client = _context.Client.Find(id);

            if (client != null) 
            {
                _context.Client.Remove(client);
                _context.SaveChanges();
            }
        }

        public List<ClientDTO> GetAll()
        {
            List<Client> clients = _context.Client.Include("Project").AsNoTracking().ToList();

            return _mapper.Map<List<ClientDTO>>(clients);
        }

        public ClientDTO GetById(int id)
        {
            Client client = _context.Client.Find(id);

            return _mapper.Map<ClientDTO>(client);
        }

        public Client GetByIdClient(int id)
        {
            Client client = _context.Client.Find(id);

            return client;
        }

        public void UpdateActivity(bool state, int id)
        {
            Client client = _context.Client.Find(id);

            client.IsActive = state == true ? "YES" : "NO";
        }
    }
}
