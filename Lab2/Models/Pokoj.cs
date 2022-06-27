using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Controllers;

namespace Lab2.Models
{
    public class Pokoj
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int HostelId { get; set; }
        [ForeignKey("HostelId")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public Hostel? Hostel { get; set; }

        public double CenaZaNocleg { get; set; }

        public int IloscLozek { get; set; }

        public RodzajPokoju RodzajPokoju { get; set; }
    }
}