using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models
{
    internal class Prestito
    {
        public int PrestitoId { get; set; }

        public string PrestitoCod { get; set; } = null!;

        public DateTime IniPrest { get; set; }

        public DateTime FinPrest { get; set; }
        public int UtenteRif { get; set; }

        public int LibroRif { get; set; }

        List<Libro> eleLib { get; set; } = null!;
        List<Libro> eleUte { get; set; } = null!;

        public override string ToString()
        {
            return $"[PRESTITO] {PrestitoCod} {IniPrest} {FinPrest}";
        }
    }
}
