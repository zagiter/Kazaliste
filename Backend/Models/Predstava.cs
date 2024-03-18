using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Predstava : Entitet
    {

        public string? Naziv { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Cijena { get; set; }
     


    }
}
