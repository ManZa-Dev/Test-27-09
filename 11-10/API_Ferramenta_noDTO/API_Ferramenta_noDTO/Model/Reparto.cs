using System.Text.Json.Serialization;

namespace API_Ferramenta_test.Models
{
    public class Reparto
    {
        [JsonIgnore]
        public int RepartoID { get; set; }
        public string RepartoCOD { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Fila { get; set; } = null!;
    }
}
