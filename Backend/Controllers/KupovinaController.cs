using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class KupovinaController:ControllerBase
    {

        private readonly EdunovaContext _context;
        


        public KupovinaController(EdunovaContext context)     
        { 
            _context = context;
        }
        
        
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Kupovine.ToList());
        }

        [HttpPost]

        public IActionResult Post(Kupovina kupovina) 
        {
            _context.Kupovine.Add(kupovina);
            _context.SaveChanges();
            return new JsonResult(kupovina);
        }

        [HttpPut]
        [Route("{sifra:int}")]

        public IActionResult Put(int sifra, Kupovina kupovina)
        {
            var kupovinaIzBaze = _context.Kupovine.Find(sifra);
            
            kupovinaIzBaze.Kupac_sifra = kupovina.Kupac_sifra;
            kupovinaIzBaze.Predstava_sifra = kupovina.Predstava_sifra;
            kupovinaIzBaze.Broj_sjedala = kupovina.Broj_sjedala;
          
            
            _context.Kupovine.Update(kupovinaIzBaze);
            _context.SaveChanges();

            return new JsonResult(kupovinaIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int sifra)
        {
            var kupovinaIzBaze = (_context.Kupovine.Find(sifra));
            _context.Kupovine.Remove(kupovinaIzBaze);
            _context.SaveChanges(); 

            return new JsonResult(new { poruka="Obrisano"});
        }
    }
    
    
}
