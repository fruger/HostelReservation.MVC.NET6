using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;

namespace Lab2.Models
{
    public class Hostel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public ICollection<Pokoj> Pokoje { get; set; }
    }
}