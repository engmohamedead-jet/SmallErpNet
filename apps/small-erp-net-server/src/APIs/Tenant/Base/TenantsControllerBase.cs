using Microsoft.AspNetCore.Mvc;
using SmallErpNet_1.APIs;
using SmallErpNet_1.APIs.Common;
using SmallErpNet_1.APIs.Dtos;
using SmallErpNet_1.APIs.Errors;

namespace SmallErpNet_1.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TenantsControllerBase : ControllerBase
{
    protected readonly ITenantsService _service;

    public TenantsControllerBase(ITenantsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Tenant
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Tenant>> CreateTenant(TenantCreateInput input)
    {
        var tenant = await _service.CreateTenant(input);

        return CreatedAtAction(nameof(Tenant), new { id = tenant.Id }, tenant);
    }

    /// <summary>
    /// Delete one Tenant
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTenant([FromRoute()] TenantWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTenant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Tenants
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Tenant>>> Tenants([FromQuery()] TenantFindManyArgs filter)
    {
        return Ok(await _service.Tenants(filter));
    }

    /// <summary>
    /// Meta data about Tenant records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TenantsMeta(
        [FromQuery()] TenantFindManyArgs filter
    )
    {
        return Ok(await _service.TenantsMeta(filter));
    }

    /// <summary>
    /// Get one Tenant
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Tenant>> Tenant([FromRoute()] TenantWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Tenant(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Tenant
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTenant(
        [FromRoute()] TenantWhereUniqueInput uniqueId,
        [FromQuery()] TenantUpdateInput tenantUpdateDto
    )
    {
        try
        {
            await _service.UpdateTenant(uniqueId, tenantUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Users records to Tenant
    /// </summary>
    [HttpPost("{Id}/users")]
    public async Task<ActionResult> ConnectUsers(
        [FromRoute()] TenantWhereUniqueInput uniqueId,
        [FromQuery()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.ConnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Users records from Tenant
    /// </summary>
    [HttpDelete("{Id}/users")]
    public async Task<ActionResult> DisconnectUsers(
        [FromRoute()] TenantWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.DisconnectUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Users records for Tenant
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> FindUsers(
        [FromRoute()] TenantWhereUniqueInput uniqueId,
        [FromQuery()] UserFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindUsers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Users records for Tenant
    /// </summary>
    [HttpPatch("{Id}/users")]
    public async Task<ActionResult> UpdateUsers(
        [FromRoute()] TenantWhereUniqueInput uniqueId,
        [FromBody()] UserWhereUniqueInput[] usersId
    )
    {
        try
        {
            await _service.UpdateUsers(uniqueId, usersId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
