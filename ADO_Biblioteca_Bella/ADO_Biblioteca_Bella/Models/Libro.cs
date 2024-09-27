using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models
{
    internal class Libro
    {
        public int LibroId { get; set; }

        public string LibroCod { get; set; } = null!;

        public string Titolo { get; set; } = null!;

        public string AnnoPub { get; set; } = null!;

        public bool IsDisp { get; set; } = true;


        public override string ToString()
        {
            return $"[LIBRO] {LibroCod} {Titolo} {AnnoPub} {IsDisp}";
        }

        public string StampDettaglioL()
        {
            return $"[LIBRO] {LibroCod} {Titolo} {AnnoPub} {IsDisp}";
        }
    }
}
