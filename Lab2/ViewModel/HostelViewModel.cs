using Lab2.Models;
using System.Collections.Generic;

namespace Lab2.ViewModel
{
    public class HostelViewModel
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public ICollection<Pokoj> Pokoje { get; set; }
    }
}
