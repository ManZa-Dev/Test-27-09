using System;
using System.Collections.Generic;

namespace EF_Biblioteca_Bella.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string LibroCod { get; set; } = null!;

    public string Titolo { get; set; } = null!;

    public DateOnly AnnoPub { get; set; }

    public bool IsDisp { get; set; }

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();
}
