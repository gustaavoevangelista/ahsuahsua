using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project_2._1.DatabaseContext;
using Final_Project_2._1.Models;

namespace Final_Project_2._1.Controllers
{
    public class MovimentoController : Controller
    {


        /*// GET: Movimento
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Movimentos.Include(m => m.Clientes);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Movimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movimentos == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos
                .Include(m => m.Clientes)
                .FirstOrDefaultAsync(m => m.Id_mov == id);
            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }

        // GET: Movimento/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "id", "id");
            return View();
        }

        // POST: Movimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_mov,Data_hora,Importancia,ClienteId")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "id", "id", movimento.ClienteId);
            return View(movimento);
        }

        // GET: Movimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movimentos == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "id", "id", movimento.ClienteId);
            return View(movimento);
        }

        // POST: Movimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_mov,Data_hora,Importancia,ClienteId")] Movimento movimento)
        {
            if (id != movimento.Id_mov)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentoExists(movimento.Id_mov))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "id", "id", movimento.ClienteId);
            return View(movimento);
        }

        // GET: Movimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movimentos == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos
                .Include(m => m.Clientes)
                .FirstOrDefaultAsync(m => m.Id_mov == id);
            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }

        // POST: Movimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movimentos == null)
            {
                return Problem("Entity set 'MyDbContext.Movimentos'  is null.");
            }
            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento != null)
            {
                _context.Movimentos.Remove(movimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentoExists(int id)
        {
          return _context.Movimentos.Any(e => e.Id_mov == id);
        }*/

        [HttpGet]
        public IActionResult Index()
        {
            List<Movimento> movimentos = new();

            try
            {
                using (var dbContext = new MyDbContext())
                {

                    movimentos = dbContext.Movimentos.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            return View(movimentos);
        }

        //[HttpGet]
        //// [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        //public async Task<IActionResult> ListaMovimentos()
        //{
        //    // ViewBag.DTmsg = DateTime.Now.ToString();

        //    Movimentos movimentos= new Movimentos();

        //    var colecao = await movimentos.GetMovimentos();

        //    if (colecao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(colecao);
        //}



        //[HttpGet]
        //public async Task<IActionResult> Details(int id)
        //{
        //    Movimentos movimentos = new Movimentos();

        //    var movimento = await movimentos.GetMovimento(id);

        //    if (movimento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movimento);
        //}

        // invocado quando chamamos a página com o form de criação

        [HttpGet, ActionName("AddSaldo")]
        public IActionResult AddSaldo()
        {
            Movimento movimento = new Movimento();

            return View(movimento);
        }

        // chamado de volta quando os dados são introduzidos no form, e é passado novamente ao controlador
        // o Url faz automaticamente o bind desses dados ao modelo Cliente

        [HttpPost, ActionName("AddSaldo")]
        public async Task<IActionResult> AddSaldo(Movimento movimento)
        {
            Movimentos movimentos = new Movimentos();

            if (await movimentos.Adiciona_Saldo(movimento) == true)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Movimentos movimentos = new Movimentos();

        //    var movimento = await movimentos.GetMovimento((int)id);

        //    if (movimento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movimento);
        //}

        //[HttpPost, ActionName("Edit")]
        //public async Task<IActionResult> Edit(int id, Movimento movimento)
        //{
        //    Movimentos movimentos = new Movimentos();

        //    if (await movimentos.Actualiza_Mov(id, movimento) == true)
        //    {
        //        return RedirectToAction(nameof(this.Index));
        //    }

        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AddConsumo()
        {

            Movimento movimento = new Movimento();


            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }


        [HttpPost, ActionName("AddConsumo")]
        public async Task<IActionResult> AddConsumo(Movimento movimento)
        {
            Movimentos movimentos = new Movimentos();

            if (await movimentos.Adiciona_Consumo(movimento) == true)
            {
                return RedirectToAction("Index");
            }

            return View();

            // redireciona a View devolvida pelo método acima
            //return RedirectToAction(nameof(this.Index));
        }
    }
}
