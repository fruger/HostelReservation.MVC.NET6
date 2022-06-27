using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Repositories
{
    public class PokojRepository: Repository<Pokoj>, IPokojRepository
    {
        private readonly ApplicationDbContext _context;

        public PokojRepository (ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update (Pokoj obj)
        {
            _context.Pokoje.Update(obj);
        }
    }
}
