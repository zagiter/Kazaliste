using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }   
    
    }
}
