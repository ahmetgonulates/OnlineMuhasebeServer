using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using OnlineMuhasebeServer.Presentation.Abstractions;

namespace OnlineMuhasebeServer.Presentation.Controllers;

public class CompaniesController : ApiController
{
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases([FromQuery] MigrateCompanyDatabaseRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}