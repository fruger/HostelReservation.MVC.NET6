using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Repositories
{
    public interface IUnitOfWork
    {
        IHostelRepository? Hostel { get; set; }

        IPokojRepository? Pokoj { get; set; }

        Task Save();
    }
}
