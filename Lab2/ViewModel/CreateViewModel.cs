using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Controllers;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.ViewModel
{
    public class CreateViewModel
    {
        public int vmcId { get; set; }
        public int HostelId { get; set; }

        public string vmcNazwa { get; set; }

        public string vmcOpis { get; set; }

        public Hostel? vmcHostel { get; set; }

        public double vmcCenaZaNocleg { get; set; }

        public int vmcIloscLozek { get; set; }
        public RodzajPokoju vmcRodzajPokoju { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? ListaHosteli { get; set; }
    }
}