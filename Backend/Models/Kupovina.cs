using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Kupovina : Entitet
    {

        public int? Kupac_sifra { get; set; }
        public int? Predstava_sifra { get; set; }
        public int? Broj_sjedala { get; set; }
     


    }
}
