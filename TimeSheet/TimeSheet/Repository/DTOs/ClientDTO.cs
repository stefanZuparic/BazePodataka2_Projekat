using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Repository.Models;

namespace TimeSheet.Repository.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
        public virtual ICollection<Project> Project { get; set; }

    }
}
