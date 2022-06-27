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
    public class EditViewModel
    {
        public int vmeId { get; set; }
        public int? HostelId { get; set; }
        public string vmeNazwa { get; set; }

        public string vmeOpis { get; set; }

        public Hostel? vmeHostel { get; set; }

        public double vmeCenaZaNocleg { get; set; }

        public int vmeIloscLozek { get; set; }

        public RodzajPokoju vmeRodzajPokoju { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? ListaHosteli { get; set; }
    }
}