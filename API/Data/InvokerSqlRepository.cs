using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class InvokerSqlRepository : DbContext, IInvokerRepository
    {
        private readonly ILogger<InvokerSqlRepository> log;

        public DbSet<InvokerConfiguration> InvokerItems { get; set; }

        public InvokerSqlRepository(DbContextOptions<InvokerSqlRepository> options, ILogger<InvokerSqlRepository> log)
            : base(options)
        {
            this.log = log;
        }

        public async Task<InvokerConfiguration> CreateConfiguration( InvokerConfiguration configuration )
        {
            throw new NotImplementedException();
        }

        public async Task DeleteConfiguration( long id, Guid companyId )
        {
            throw new NotImplementedException();
        }

        public async Task<InvokerConfiguration> GetConfiguration( long id, Guid companyId )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvokerConfiguration>> GetConfigurations( Guid companyId )   
        {
            throw new NotImplementedException();
        }

        public async Task<InvokerConfiguration> UpdateConfiguration( InvokerConfiguration configuration )
        {
            throw new NotImplementedException();
        }
    }
}