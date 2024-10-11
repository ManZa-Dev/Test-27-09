using API_Ferramenta_test.Models;

namespace API_Ferramenta_test.Repos
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private readonly FerramentaContext _context;

        public ProdottoRepo(FerramentaContext context)
        {
            _context = context;
        }

        public bool Create(Prodotto t)
        {
            bool ris = false;
            try
            {
                Prodotto oRep = new Prodotto()
                {
                   ProdottoCOD = t.ProdottoCOD,
                   Nome = t.Nome,
                   Descrizione = t.Descrizione,
                   Prezzo = t.Prezzo,
                   Quantita = t.Quantita,
                   RepartoRIF = t.RepartoRIF,
                };

                _context.Prodotto.Add(oRep);
                _context.SaveChanges();
                ris = true;
            }
            catch (Exception ex)
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
                Prodotto? pro = _context.Prodotto.Single(r => r.ProdottoCOD == cod);

                if (pro is not null)
                    _context.Prodotto.Remove(pro);
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
        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodotto.ToList();
        }

        public Prodotto? GetByCodice(string cod)
        {
            return _context.Prodotto.FirstOrDefault(r => r.ProdottoCOD == cod);
        }

        public Prodotto? GetById(int id)
        {
            return _context.Prodotto.FirstOrDefault(p => p.ProdottoID == id);
        }

        public bool Update(Prodotto t)
        {
            throw new NotImplementedException();
        }

    }
}
