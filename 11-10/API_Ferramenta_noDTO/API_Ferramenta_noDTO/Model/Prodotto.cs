using System.Text.Json.Serialization;

namespace API_Ferramenta_test.Models
{
    public class Prodotto
    {
        [JsonIgnore]
        public int ProdottoID { get; set; }
        public string ProdottoCOD { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int Quantita { get; set; }
        public int RepartoRIF{ get; set; }
    }
}
