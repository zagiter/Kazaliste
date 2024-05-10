using System.Text;
using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PredstaveController : EdunovaController<Predstava, PredstavaDTORead, PredstavaDTOInsertUpdate>
    {
        public PredstaveController(EdunovaContext context) : base(context)
        {
            DbSet = _context.Predstave;
        }
        protected override void KontrolaBrisanje(Predstava entitet)
        {

        }
    }
}