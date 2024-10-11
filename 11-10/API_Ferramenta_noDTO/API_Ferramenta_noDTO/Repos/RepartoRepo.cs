using API_Ferramenta_test.Models;

namespace API_Ferramenta_test.Repos
{
    public class RepartoRepo : IRepo<Reparto>
    {
        private readonly FerramentaContext _context;

        public RepartoRepo(FerramentaContext context)
        {
            _context = context;
        }

        public bool Create(Reparto t)
        {
            bool ris = false;
            try
            {
                Reparto oRep = new Reparto()
                {
                    RepartoCOD = t.RepartoCOD,
                    Nome = t.Nome,
                    Fila = t.Fila,
                };

                _context.Reparto.Add(oRep);
                _context.SaveChanges();
                ris = true;
            }catch (Exception ex)
            {
                Console.WriteLine($"Beccati sto errore -> {ex.Message}");
            }
            return ris;
        }

        // Questo sotto no
        //public bool Delete(Reparto cod)
        //{
        //    bool risultato = false;
            
            

        //    _context.Reparto.Remove(cod);
        //    _context.SaveChanges();

        //    return risultato;
        //}

        public bool Delete(string cod)
        {
            bool risultato = false;
            try
            {
                Reparto? rep = _context.Reparto.Single(r => r.RepartoCOD == cod);

                if(rep is not null)
                _context.Reparto.Remove(rep);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        // Check Ienumerable!!! 
        public IEnumerable<Reparto> GetAll()
        {
            return _context.Reparto.ToList();
        }

        public Reparto? GetByCodice(string cod)
        {
            // return _context.Reparti.FirstOrDefault(c => c.RepartoCOD == cod); // Plurale errore controllare
            return _context.Reparto.FirstOrDefault(r => r.RepartoCOD == cod);
        }

        public Reparto? GetById(int id)
        {
            return _context.Reparto.FirstOrDefault(r => r.RepartoID == id);
        }

        public bool Update(Reparto t)
        {
            bool risultato = false;
            try
            {
                Reparto? rep = _context.Reparto.SingleOrDefault(r => r.RepartoCOD == t.RepartoCOD);

                if (rep is not null)
                {
                    rep.Nome = t.Nome;
                    rep.Fila = t.Fila;
                    
                    _context.SaveChanges();
                    risultato = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Non leggere");
            }

            return risultato;
        }
    }
}
