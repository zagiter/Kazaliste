
using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Backend.Mappers;
using System.Text.RegularExpressions;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KupovineController : EdunovaController<Kupovina, KupovinaDTORead, KupovinaDTOInsertUpdate>
    {
        public KupovineController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Kupovine;
            _mapper = new MappingKupovina();
        }

        protected override List<KupovinaDTORead> UcitajSve()
        {
            var lista = _context.Kupovine
                    .Include(g => g.predstava)
                    .Include(g => g.kupac)
                    .ToList();
            
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("Ne postoje podaci u bazi");
            }
            return _mapper.MapReadList(lista);
        }

        protected override Kupovina NadiEntitet(int Sifra)
        {
            return _context.Kupovine.Include(i => i.predstava).Include(i => i.kupac)
                    .FirstOrDefault(x => x.Sifra == Sifra) ?? throw new Exception("Ne postoji rez s Id-om " + Sifra + " u bazi");
        }

        protected override Kupovina KreirajEntitet(KupovinaDTOInsertUpdate dto)
        {
            var predstava = _context.Predstave.Find(dto.Predstava_sifra) ?? throw new Exception("Ne postoji " + dto.Predstava_sifra + " u bazi");
            var kupac = _context.Kupci.Find(dto.Kupac_sifra) ?? throw new Exception("Ne postoji kupac s šifrom " + dto.Kupac_sifra + " u bazi");
            var entitet = _mapper.MapInsertUpdatedFromDTO(dto);
            entitet.predstava = predstava;
            entitet.kupac = kupac;
            return entitet;
        }

        protected override Kupovina PromjeniEntitet(KupovinaDTOInsertUpdate dto, Kupovina entitet)
        {
            var predstava = _context.Predstave.Find(dto.Predstava_sifra) ?? throw new Exception("Ne postoji film " + dto.Predstava_sifra + " u bazi");
            var kupac = _context.Kupci.Find(dto.Kupac_sifra) ?? throw new Exception("Ne postoji kupac " + dto.Kupac_sifra + " u bazi");


            entitet.kupac = kupac;
            entitet.predstava = predstava;
            entitet.Broj_sjedala = (int)dto.Broj_sjedala;
            

            
            

            return entitet;
        }

        protected override void KontrolaBrisanje(Kupovina entitet)
        {
            // Implementirati logiku za brisanje
        }
    }
}
// overide include kupac , include film
