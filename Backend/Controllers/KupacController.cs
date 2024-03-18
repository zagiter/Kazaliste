using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class KupacController 
    {

        private readonly EdunovaContext _context;
        


        public KupacController(EdunovaContext context)     
        { 
            _context = context;
        }
        
        
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Kupci.ToList());
        }

        [HttpPost]

        public IActionResult Post(Kupac kupac) 
        {
            _context.Kupci.Add(kupac);
            _context.SaveChanges();
            return new JsonResult(kupac);
        }

        [HttpPut]
        [Route("{sifra:int}")]

        public IActionResult Put(int sifra, Kupac kupac)
        {
            var kupacIzBaze = _context.Kupci.Find(sifra);
            
            kupacIzBaze.Ime = kupac.Ime;
            kupacIzBaze.Prezime = kupac.Prezime;
            kupacIzBaze.Email = kupac.Email;
            kupacIzBaze.Telefon = kupac.Telefon;
            
            _context.Kupci.Update(kupacIzBaze);
            _context.SaveChanges();

            return new JsonResult(kupacIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int sifra)
        {
            var kupacIzBaze = (_context.Kupci.Find(sifra));
            _context.Kupci.Remove(kupacIzBaze);
            _context.SaveChanges(); 

            return new JsonResult(new { poruka="Obrisano"});
        }
    }
    
    
}
