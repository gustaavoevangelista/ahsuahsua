using Final_Project_2._1.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Final_Project_2._1.Models
{
    public class Clientes
    {
        public Clientes()
        {

        }

        public async Task<List<Cliente>> GetColecao()
        {
            List<Cliente> clientesLista = null;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    clientesLista = await dbContext.Clientes.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return clientesLista;
        }

        public async Task<Cliente> GetCliente(int iId)
        {
            Cliente cliente = null;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    cliente = await dbContext.Clientes.Where(c => c.id == iId).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return cliente;
        }

        public async Task<bool> Adiciona(Cliente cliente)
        {
            if (cliente == null)
                return false;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.Clientes.AddAsync(cliente);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public async Task<bool> Elimina(int iId)
        {
            var cliente = await GetCliente(iId);

            if (cliente == null)
                return false;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Clientes.Remove(cliente);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }

        public async Task<bool> Actualiza(int iId, Cliente clienteActualizado)
        {
            var clienteDB = await GetCliente(iId);

            if (clienteDB == null)
                return false;

            clienteDB.nome = clienteActualizado.nome;
            clienteDB.morada = clienteActualizado.morada;
            clienteDB.codPostal = clienteActualizado.codPostal;
            clienteDB.localidade = clienteActualizado.localidade;
            clienteDB.telefone = clienteActualizado.telefone;
            clienteDB.email = clienteActualizado.email;
            clienteDB.nif = clienteActualizado.nif;
            clienteDB.saldoDisp = clienteActualizado.saldoDisp;
            clienteDB.validade = clienteActualizado.validade;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Clientes.Update(clienteDB);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    


    }
}

    
