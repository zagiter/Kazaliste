using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Predstava : Entitet
    {

        public string? Naziv { get; set; }
        public string? Datum { get; set; }
        public string? Cijena { get; set; }
     


    }
}
