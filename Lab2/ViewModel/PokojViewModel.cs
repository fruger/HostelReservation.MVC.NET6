using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Controllers;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.ViewModel
{
    public class PokojViewModel
    {
        public int vmId { get; set; }

        public int? HostelId { get; set; }

        public string vmNazwa { get; set; }

        public string vmOpis { get; set; }

        public Hostel ? vmHostel { get; set; }

        public double vmCenaZaNocleg { get; set; }

        public int vmIloscLozek { get; set; }

        public RodzajPokoju vmRodzajPokoju { get; set; }

        public IEnumerable<SelectListItem>? ListaHosteli { get; set; }

    }
}