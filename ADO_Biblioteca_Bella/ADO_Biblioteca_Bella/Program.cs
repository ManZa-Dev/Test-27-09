using ADO_Biblioteca_Bella.Models;
using ADO_Biblioteca_Bella.Models.DAL;

namespace ADO_Biblioteca_Bella
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UtenteDAO.GetInstance().GetAll();
            //LibroDAO.GetInstance().GetAll();
            //PrestitoDAO.GetInstance().GetAll();

            //Console.WriteLine("Inserisci Nome");
            //string insNome = Console.ReadLine();
            //Console.WriteLine("Inserisci Cognome");
            //string insCognome = Console.ReadLine();
            //Console.WriteLine("Inserisci Email");
            //string insEmail = Console.ReadLine();

            //Utente ut1 = new Utente()
            //{
            //    Nome = insNome
            //    Cognome
            //};

            //Console.WriteLine("Inserisci il codice libro da eliminare");
            //string insCodiL = Console.ReadLine();

            //Libro lib = new Libro()
            //{
            //    LibroCod = insCodiL
            //};

            //LibroDAO.GetInstance().delete(lib);


            //Console.WriteLine("Inserisci il codice Utente da eliminare");
            //string insCodiU = Console.ReadLine();

            //Utente ute = new Utente()
            //{
            //    UtenteCod = insCodiU
            //};

            //UtenteDAO.GetInstance().delete(ute);

            Console.WriteLine("Inserisci il codice Utente da eliminare");
            string insCodiP = Console.ReadLine();

            Prestito pre = new Prestito()
            {
                PrestitoCod = insCodiP
            };

            PrestitoDAO.GetInstance().delete(pre);

        }
    }
}
