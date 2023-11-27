using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InvokerConfigurationService : IInvokerService
    {
        private readonly ILogger<InvokerConfigurationService> log;
        private readonly IInvokerRepository repository;

        public InvokerConfigurationService( ILogger<InvokerConfigurationService> log, IInvokerRepository repository )
        {
            this.log = log;
            this.repository = repository;
        }

        public async Task<InvokerConfiguration> CreateConfiguration( InvokerConfiguration configuration )
        {
            log.LogInformation( "Creating new configuration for company {0}", configuration.CompanyId );

            if ( string.IsNullOrEmpty(configuration.ApiSchema ) )
            {
                throw new ArgumentException( "ApiSchema must be provided" );
            }

            return await repository.CreateConfiguration( configuration );
        }

        public async Task DeleteConfiguration( long id, Guid companyId )
        {
            log.LogInformation( "Deleting configuration {0} for company {1}", id, companyId );

            var existing = await repository.GetConfiguration( id, companyId );
            if ( existing == null )
            {
                log.LogInformation( "Configuration {0} for company {1} not found", id, companyId );
                throw new ArgumentException( "Configuration not found" );
            }

            await repository.DeleteConfiguration( id, companyId );
        }

        public async Task<InvokerConfiguration> GetConfiguration( long id, Guid companyId )
        {
            log.LogInformation( "Getting configuration {0} for company {1}", id, companyId );

            return await repository.GetConfiguration( id, companyId );
        }

        public async Task<IEnumerable<InvokerConfiguration>> GetConfigurations( Guid companyId )
        {
            log.LogInformation( "Getting configurations for company {0}", companyId );

            return await repository.GetConfigurations( companyId );
        }

        public async Task<InvokerConfiguration?> UpdateConfiguration( long id, Guid companyId, InvokerConfiguration configuration )
        {
            log.LogInformation( "Updating configuration {0} for company {1}", configuration.Id, configuration.CompanyId );

            if ( configuration.Id == 0 )
            {
                throw new ArgumentException( "Configuration Id must be greater than 0" );
            }

            if (string.IsNullOrEmpty(configuration.ApiSchema))
            {
                throw new ArgumentException( "ApiSchema must be provided" );
            }

            var existing = await repository.GetConfiguration( configuration.Id, configuration.CompanyId );
            if ( existing == null )
            {
                log.LogInformation( "Configuration {0} for company {1} not found", configuration.Id, configuration.CompanyId );
                return null;
            }

            if (existing.CompanyId != companyId || existing.Id != id)
            {
                log.LogInformation( "Configuration {0} for company {1} not found does not match existing configuration", configuration.Id, configuration.CompanyId );
                return null;
            }

            existing.Update( configuration );

            return await repository.UpdateConfiguration( existing );
        }
    }
}
