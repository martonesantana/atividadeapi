namespace Atividade.API.Models
{
    public class AtividadeModel : BaseModel
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Concluida { get; set; }
    }

}