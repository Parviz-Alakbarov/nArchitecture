using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> GetList([FromBody] PageRequest pageRequest)
        {
            GetListModelQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListModelDto> response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
