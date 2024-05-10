using AutoMapper;
using Backend.Models;

namespace Backend.Mappers
{
    public class MappingPredstava : Mapping<Predstava, PredstavaDTORead, PredstavaDTOInsertUpdate>
    {

        public MappingPredstava()
        {
            MapperMapReadToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Predstava, PredstavaDTORead>()
                .ConstructUsing(entitet =>
                 new PredstavaDTORead(
                    entitet.Sifra,
                    entitet.Naziv,
                    entitet.Datum,
                    entitet.Cijena));
            }));

            MapperMapInsertUpdatedFromDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<PredstavaDTOInsertUpdate, Predstava>();
            }));

            MapperMapInsertUpdateToDTO = new Mapper(new MapperConfiguration(c => {
                c.CreateMap<Predstava, PredstavaDTOInsertUpdate>()
                .ConstructUsing(entitet =>
                 new PredstavaDTOInsertUpdate(
                    entitet.Naziv,
                    entitet.Datum,
                    entitet.Cijena));
            }));
        }



    }
}