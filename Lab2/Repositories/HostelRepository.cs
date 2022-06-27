using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Repositories
{
    public class HostelRepository : Repository<Hostel>, IHostelRepository
    {
        private readonly ApplicationDbContext _context;
        
        public HostelRepository(ApplicationDbContext context): base (context)
        {
            _context = context;
        }

        public void Update(Hostel obj)
        {
            _context.Hostele.Update(obj);
        }
    }
}
