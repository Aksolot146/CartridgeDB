using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCartridges.Models;

namespace BackendCartridges.Services
{
    public class StatusService
    {
        private readonly ApplicationContext _context;

        public StatusService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.Id == id);
        }
    }
}
