using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


[Route( "api/[controller]" )]
[ApiController]
public class InvokerConfigurationController : ControllerBase
{
    private readonly ILogger<InvokerConfigurationController> log;
    private readonly IInvokerService service;

    public InvokerConfigurationController( IInvokerService service, ILogger<InvokerConfigurationController> log )
    {
        this.service = service;
        this.log = log;
    }

    [HttpGet( "companyId/{companyId}")]
    public async Task<ActionResult<IEnumerable<InvokerConfiguration>>> GetConfigurations(Guid companyId)
    {
        try
        {
            var configurations = await service.GetConfigurations( companyId );
            return Ok( configurations );
        }
        catch ( Exception ex )
        {
            log.LogError( ex, "Error getting all configurations for company {0}", companyId );
            throw;
        }
    }

    [HttpGet( "companyId/{companyId}/{id}" )]
    public async Task<ActionResult<InvokerConfiguration>> GetConfiguration( Guid companyId, long id )
    {
        try
        {
            var configuration = await service.GetConfiguration( id, companyId );

            if ( configuration == null )
                return NotFound();

            return Ok( configuration );
        }
        catch ( Exception ex)
        {
            log.LogError( ex, "Error getting configuration {0} for company {1}", id, companyId );
            throw;
        }
    }

    [HttpPost]
    public ActionResult<InvokerConfiguration> Create( [FromBody] InvokerConfiguration configuration )
    {
        try
        {
            service.CreateConfiguration( configuration );
            return CreatedAtAction( nameof( GetConfiguration ), new { id = configuration.Id }, configuration );
        }
        catch (ArgumentException aex)
        {
            log.LogError( aex, "Error creating configuration for company {0}", configuration.CompanyId );
            return BadRequest( aex.Message );
        }
        catch (Exception ex)
        {
            log.LogError( ex, "Error creating configuration for company {0}", configuration.CompanyId );
            throw;
        }
    }

    [HttpPut( "companyId/{companyId}/{id}" )]
    public async Task<IActionResult> Update( Guid companyId, long id, [FromBody] InvokerConfiguration configuration )
    {
        try
        {
            var updatedConfiguration = await service.UpdateConfiguration( id, companyId, configuration );
            if ( updatedConfiguration == null )
                return NotFound();

            return NoContent();
        }
        catch ( ArgumentException aex )
        {
            log.LogError( aex, "Error update configuration {0} for company {1}", configuration.Id, configuration.CompanyId );
            return BadRequest( aex.Message );
        }
        catch ( Exception ex )
        {
            log.LogError( ex, "Error updateing configuration {0} for company {1}", configuration.Id, configuration.CompanyId );
            throw;
        }
    }

    [HttpDelete( "companyId/{companyId}/{id}" )]
    public async Task<IActionResult> DeleteConfiguration( Guid companyId, long id )
    {
        try
        {
            await service.DeleteConfiguration( id, companyId );
            return NoContent();
        }
        catch ( ArgumentException aex )
        {
            log.LogError( aex, "Error deleting configuration {0} for company {1}", id, companyId );
            return BadRequest( aex.Message );
        }
        catch ( Exception ex )
        {
            log.LogError( ex, "Error deleting configuration {0} for company {1}", id, companyId );
            throw;
        }
    }
}