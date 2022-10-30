using Final_Project_2._1.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Final_Project_2._1.Models
{
    public class Movimentos
    {
        public Movimentos()
        {
        }


        public async Task<List<Movimento>> GetMovimentos()
        {
            List<Movimento> movimentosLista = null;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    movimentosLista = await dbContext.Movimentos.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return movimentosLista;
        }

        public async Task<Movimento> GetMovimento(int iId)
        {
            Movimento movimento = null;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    movimento = await dbContext.Movimentos.Where(c => c.Id_mov == iId).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return movimento;
        }

        public async Task<bool> Adiciona_Mov(Movimento movimento)
        {
            if (movimento == null)
                return false;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.Movimentos.AddAsync(movimento);
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

        public async Task<bool> Elimina_Mov(int iId)
        {
            var movimento = await GetMovimento(iId);

            if (movimento == null)
                return false;

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Movimentos.Remove(movimento);
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

        public async Task<bool> Actualiza_Mov(int iId, Movimento movimentoActualizado)
        {
            var movimentoDB = await GetMovimento(iId);

            if (movimentoDB == null)
                return false;

            movimentoDB.Data_hora = movimentoActualizado.Data_hora;
            movimentoDB.Importancia = movimentoActualizado.Importancia;
            
        

            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Movimentos.Update(movimentoDB);
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
