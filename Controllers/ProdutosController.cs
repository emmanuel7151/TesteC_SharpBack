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
    public class ProdutosController : ControllerBase
    {
        private readonly C_TEsteContext _context;

        public ProdutosController(C_TEsteContext context)
        {
            _context = context;
        }

        // GET: Produtos
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

       // GET: Produtos/Details/5
        [HttpGet]
        public async Task<ActionResult<Produto>> Details(int id)
        {
            if (id == null)
            {
                return StatusCode(404);
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return StatusCode(404);
            }

            return produto;
        }


        // POST: Produtos/Create
        [HttpPut]
        public async Task<ActionResult<Produto>> Create(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


        // POST: Produtos/Edit/5
        [HttpPut]
        public async Task<ActionResult<Produto>> Edit(Produto produto)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return produto;
        }

        // POST: Produtos/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpGet]
        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
