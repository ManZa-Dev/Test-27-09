using System;
using System.Collections.Generic;

namespace EF_Biblioteca_Bella.Models;

public partial class Prestito
{
    public int PrestitoId { get; set; }

    public string PrestitoCod { get; set; } = null!;

    public DateTime IniPrest { get; set; }

    public DateTime FinPrest { get; set; }

    public int UtenteRif { get; set; }

    public int LibroRif { get; set; }

    public virtual Libro LibroRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;
}
