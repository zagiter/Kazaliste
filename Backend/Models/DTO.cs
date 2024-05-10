using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public record KupacDTORead(int Sifra, string? Ime, string? Prezime, string? Email, string? Telefon);
    public record KupacDTOInsertUpdate([Required(ErrorMessage = "Ime obavezno")] string? Ime, string? Prezime, string? Email, string? Telefon);
    public record PredstavaDTORead(int Sifra, string? Naziv, string? Datum, string? Cijena);
    public record PredstavaDTOInsertUpdate([Required(ErrorMessage = "Naziv obavezan")] string? Naziv, string? Datum, string? Cijena);
    public record KupovinaDTORead(int Sifra, string PredstavaNaziv, string Datum, string KupacImePrezime, int Broj_sjedala)
    {

    }

    public record KupovinaDTOInsertUpdate(
        [Required(ErrorMessage = "Predstava obavezno")]
        int? Kupac_sifra,
        [Required(ErrorMessage = "Kupac obavezno")]
        int? Predstava_sifra,
        int? Broj_sjedala);

}