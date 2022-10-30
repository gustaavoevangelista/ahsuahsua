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
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<Cliente> clientes = new();

            try
            {
                using (var dbContext = new MyDbContext())
                {

                    clientes = dbContext.Clientes.ToList();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            return View(clientes);
        }

        [HttpGet]
        // [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> ListaClientes()
        {
            // ViewBag.DTmsg = DateTime.Now.ToString();

            Clientes clientes = new Clientes();

            var colecao = await clientes.GetColecao();

            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Clientes clientes = new Clientes();

            var cliente = await clientes.GetCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // invocado quando chamamos a página com o form de criação

        [HttpGet, ActionName("Create")]
        public IActionResult Create()
        {
            Cliente cliente = new Cliente();

            return View(cliente);
        }

        // chamado de volta quando os dados são introduzidos no form, e é passado novamente ao controlador
        // o Url faz automaticamente o bind desses dados ao modelo Cliente

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            Clientes clientes = new Clientes();

            if (await clientes.Adiciona(cliente) == true)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clientes clientes = new Clientes();

            var cliente = await clientes.GetCliente((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            Clientes clientes = new Clientes();

            if (await clientes.Actualiza(id, cliente) == true)
            {
                return RedirectToAction(nameof(this.Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clientes clientes = new Clientes();

            var cliente = await clientes.GetCliente((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // permite fazer um POST com o método Delete, routeando depois para o método local DeleteConfirmed
        // alternativamente, poderíamos denominar este método Delete (que já existe acima)
        // ou invocar o método DeleteConfirmed externamente

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Clientes clientes = new Clientes();

            if (await clientes.Elimina(id) == false)
            {
                return Problem("Cliente não encontrado");
            }

            // redireciona a View devolvida pelo método acima
            return RedirectToAction(nameof(this.Index));
        }
    }
}
