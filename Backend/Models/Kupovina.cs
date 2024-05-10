using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Kupovina : Entitet
    {
        
        [ForeignKey("predstava_sifra")]
        public required Predstava predstava { get; set; }

        [ForeignKey("kupac_sifra")]
        public required Kupac kupac { get; set; }
        public int Broj_sjedala { get; set; }
        
    }
}