using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumos.Data;
using Sumos.Data.Models;

namespace Sumos.AdminApi.Controllers;

[ApiController]
[Route("admin/api/[controller]")]
public class OrganizationsController(SumosDbContext context) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Organization>>> ListOrganizations()
    {
        return await context.Organizations.ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Organization>> GetOrganization(long id)
    {
        var organization = await context.Organizations.FindAsync(id);
        if (organization == null)
        {
            return NotFound();
        }

        return organization;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Organization>> CreateOrganization([FromBody] Organization organization)
    {
        context.Organizations.Add(organization);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetOrganization), new { id = organization.Id }, organization);
    }
}