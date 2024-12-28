using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HizmetController : ControllerBase
    {
        private readonly BarberContext _context;

        public HizmetController(BarberContext context)
        {
            _context = context;
        }

        // GET: api/Hizmet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hizmet>>> GetHizmetler()
        {
            var hizmetler = await _context.Hizmetler.ToListAsync();
            return Ok(hizmetler);
        }
        
    }
}
    