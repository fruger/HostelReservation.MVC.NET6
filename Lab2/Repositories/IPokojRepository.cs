using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Repositories
{
    public interface IPokojRepository : IRepository<Pokoj>
    {
        void Update(Pokoj obj);
    }
}
