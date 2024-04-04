using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class PredstavaController:ControllerBase
    {

        private readonly EdunovaContext _context;
        


        public PredstavaController(EdunovaContext context)     
        { 
            _context = context;
        }
        
        
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Predstave.ToList());
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            return new JsonResult(_context.Predstave.Find(sifra));
        }

        [HttpPost]

        public IActionResult Post(Predstava predstava) 
        {
            _context.Predstave.Add(predstava);
            _context.SaveChanges();
            return new JsonResult(predstava);
        }

        [HttpPut]
        [Route("{sifra:int}")]

        public IActionResult Put(int sifra, Predstava predstava)
        {
            var predstavaIzBaze = _context.Predstave.Find(sifra);
            
            predstavaIzBaze.Naziv = predstava.Naziv;
            predstavaIzBaze.Datum = predstava.Datum;
            predstavaIzBaze.Cijena = predstava.Cijena;
          
            
            _context.Predstave.Update(predstavaIzBaze);
            _context.SaveChanges();

            return new JsonResult(predstavaIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int sifra)
        {
            var predstavaIzBaze = (_context.Predstave.Find(sifra));
            _context.Predstave.Remove(predstavaIzBaze);
            _context.SaveChanges(); 

            return new JsonResult(new { poruka="Obrisano"});
        }
    }
    
    
}
