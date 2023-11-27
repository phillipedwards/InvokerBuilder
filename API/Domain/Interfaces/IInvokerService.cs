using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvokerService
    {
        Task<InvokerConfiguration> GetConfiguration( long id, Guid companyId );
        Task<IEnumerable<InvokerConfiguration>> GetConfigurations( Guid companyId );
        Task<InvokerConfiguration> CreateConfiguration( InvokerConfiguration configuration );
        Task<InvokerConfiguration?> UpdateConfiguration( long id, Guid companyId, InvokerConfiguration configuration );
        Task DeleteConfiguration( long id, Guid companyId );
    }
}
