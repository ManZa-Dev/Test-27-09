using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models
{
    internal class Utente
    {
        public int UtenteId { get; set; }

        public string UtenteCod { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Cognome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public override string ToString()
        {
            return $"[Utente] {UtenteCod} {Nome} {Cognome} {Email}";
        }

        public string StampDettaglioU()
        {
            return $"[Utente] {UtenteCod} {Nome} {Cognome} {Email}";
        }

    }
}
