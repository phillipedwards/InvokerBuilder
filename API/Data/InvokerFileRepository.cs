using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InvokerFileRepository : IInvokerRepository
    {
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
