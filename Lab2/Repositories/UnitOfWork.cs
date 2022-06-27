using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Hostel = new HostelRepository(_context);
            Pokoj = new PokojRepository(_context);

        }
        public IHostelRepository Hostel { get; set; }
        public IPokojRepository Pokoj { get; set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
