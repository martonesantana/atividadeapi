using Atividade.API.Data;
using Atividade.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade.API.Controllers
{
    [ApiController]
    [Route("api/atividade")]
    public class AtividadeAPIController : BaseApiController<AtividadeModel>
    {
        public AtividadeAPIController(DataContext context) : base(context)
        {
        }
    }
}