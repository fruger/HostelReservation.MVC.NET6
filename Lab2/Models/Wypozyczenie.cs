using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }

        public DateTime DataUtworzenia { get; set; }

        public DateTime DataRozpoczecia { get; set; }

        public DateTime DataZakonczenia { get; set; }

        public string Status { get; set; }

        public User Klient { get; set; }

        public Pokoj Pokoj { get; set; }
    }
}
