
using AutoMapper;
using Backend.Controllers;
using Backend.Models;

namespace Backend.Mappers
{
    public class MappingKupovina : Mapping<Kupovina, KupovinaDTORead, KupovinaDTOInsertUpdate>
    {

        public MappingKupovina()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c =>
            {
                c.CreateMap<Kupovina, KupovinaDTORead>()
                .ConstructUsing(entitet =>
                 new KupovinaDTORead(
                     
                     entitet.Sifra,
                     entitet.predstava.Naziv,
                     entitet.predstava.Datum,
                     entitet.kupac.Ime + " " + entitet.kupac.Prezime,
                     entitet.Broj_sjedala));



            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<KupovinaDTOInsertUpdate, Kupovina>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Kupovina, KupovinaDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new KupovinaDTOInsertUpdate(
                     
                     entitet.predstava.Sifra,
                     entitet.kupac.Sifra,
                     entitet.Broj_sjedala));



            }));
        }



    }
}
