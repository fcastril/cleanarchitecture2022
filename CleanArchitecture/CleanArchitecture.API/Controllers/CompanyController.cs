using CleanArchitecture.Application.DTO;
using CleanArchitecture.Application.Features.Companies.Queries.GetCompaniesList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{code}", Name = "GetCompanyByCode")]
        [Authorize]
        [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyDto>> GetCompanyByCode(string code)
        {
            GetCompanyByCodeQuery query = new GetCompanyByCodeQuery(code);
            CompanyDto companyDto = await _mediator.Send(query);

            return Ok(companyDto);
        }


    }
}
