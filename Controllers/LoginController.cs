using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C_TEste.Data;
using C_TEste.Model;

namespace C_TEste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly C_TEsteContext _context;

        public LoginController(C_TEsteContext context)
        {
            _context = context;
        }


        // POST: Login/Create
        [HttpPost]
        public async Task<ActionResult> Create(Login login)
        {

            _context.Add(login);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }


        [HttpPost]
        public async Task<ActionResult> RealizarLogin(Login login)
        {
            var loginResult = await _context.Login.Where(z => z.email == login.email && z.senha == login.senha).FirstOrDefaultAsync();
            if (login == null)
            {
                return NotFound();
            }
            return StatusCode(200);
        }
    }
}
