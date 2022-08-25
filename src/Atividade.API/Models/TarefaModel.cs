namespace Atividade.API.Models
{
    public class TarefaModel : BaseModel
    {
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        public bool Excluido { get; set; }
    }
}